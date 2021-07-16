using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoodApp.Controllers
{
    public class QuestionController: Controller
    {
        General general = new General();
        ConnectionMysqlModel db= new ConnectionMysqlModel();
        private int questionId {get; set;}
        private int answerId {get; set;}
        private string question {get; set;}
        private int questionPriority {get; set;}
        public bool functionStatus { get; set; }

        public QuestionController()
        {
            this.functionStatus=false;
        }
        public IActionResult Index()
        {
            this.controlAndGiveMessage();
            this.getQuestion();
            this.getAnswers();
            return View();
        }
        public IActionResult Add()
        {
            return general.accesPagesAdmin(HttpContext);
        }
        public IActionResult Answer()
        {
            return View();
        }
        [HttpGet("Answer")] 
        public IActionResult Answer(int number)
        {
            this.answerId=number;
            if(this.getAnswerInfo().Rows.Count>0)
            {
                ViewBag.Answer= this.getAnswerInfo().Rows[0]["answer"].ToString();
                ViewBag.AnswerDescription= this.getAnswerInfo().Rows[0]["text"].ToString();
            }
                return View();
        }
        
        [HttpGet("{controller=Question}/{action=Update}/{delete}/{id?}")] 
        public IActionResult Update(int id)
        {
            this.questionsList();
            this.questionId=id;
            string getAction = HttpContext.Request.Path.ToUriComponent().Split('/')[3];
            if(getAction=="delete")
            {
                if(this.deleteQuestionsAndOptions()>0)
                {
                    general.setSessions(HttpContext,("succesMessage","Başarıyla silindi "));
                    Response.Redirect("/Question/Update");
                }
                else
                {
                    general.setSessions(HttpContext,("errorMessage","Böyle bir kayıt yok ! "));
                    Response.Redirect("/Question/Update");
                }
            }
            else if (getAction=="update")
            {
                Response.Redirect("/Question/UpdateQuestion/update/"+id);
            }
            return View();
        }

        public IActionResult Update()
        {
            if (general.accesPagesStatus(HttpContext)==true)
            {
                this.questionsList();
                return View();
            }
            else
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("Login");
        }
        [HttpPost]
        public IActionResult Add(IFormCollection formCollection)
        {
            insertAnswerAndQuestion(formCollection);
            return View();
        }
        public IActionResult UpdateQuestion()
        {
            return general.accesPagesAdmin(HttpContext);
        }
        [HttpGet] 
        public IActionResult UpdateQuestion(int id)
        {
            if (general.accesPagesStatus(HttpContext)==true)
            {
                this.questionId=id;
                ViewBag.QuestionList = this.listQuestionsAndOptions();
                return View();
            }
            else
            {
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Login");
            }

        }

        [HttpPost]
        public IActionResult UpdateQuestion(IFormCollection formCollection,int id)
        {
            Console.WriteLine("form");
            this.questionId=id;
            insertAnswerAndQuestion(formCollection);            
            if(this.functionStatus==true)
            {
                Console.WriteLine(this.questionId+" ... id");
                deleteQuestionsAndOptions();
            }

            return View();
        }

       private DataTable getAnswerInfo()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM	answers AS a LEFT JOIN answer_description as ad ON a.id=ad.answer_id Where a.id='"+this.answerId+"'");
            return result;
        }
        private DataTable answersList(int questionId)
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM answers WHERE question_id ='"+questionId+"' ORDER BY answer_priority ASC");
            return result;
        }        
        private DataTable questionsList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM questions ORDER BY question_priority ASC");
            ///List<string> test = new List<string>();
            //IEnumerable<DataRow> dtToList= result.AsEnumerable();
            ViewBag.Questions= result;
            return result;
        }
                private int deleteQuestionsAndOptions()
        {
            return db.insertUpdateDelete("DELETE questions,answers,answer_description  FROM questions LEFT JOIN answers ON questions.id=answers.question_id LEFT JOIN answer_description ON answer_description.answer_id= answers.id Where questions.id="+this.questionId+"");
        }
        private DataTable listQuestionsAndOptions()
        {
            return db.listForDatatable("SELECT * FROM questions LEFT JOIN answers ON questions.id=answers.question_id LEFT JOIN answer_description ON answer_description.answer_id= answers.id Where questions.id="+this.questionId+"");
        }

        private void insertAnswerAndQuestion(IFormCollection formCollection)
        {
            List<string> txtOption = new List<string>();
            List<string> txtDescription = new List<string>();
            int counter=0;
            int emptyValue=0;
            foreach(var form in formCollection)
            {
                Console.WriteLine(form.Key);
                if(form.Key.Contains("txtOption")==true)
                {
                    counter++;
                    txtOption.Add(form.Value);
                }
                                
                if(form.Key.Contains("txtDescription")==true)
                {
                    counter++;
                    txtDescription.Add(form.Value);
                }

                if(form.Value==string.Empty)
                {
                    emptyValue++;
                }
            }
                            
            if(emptyValue>0)
            {
                ViewBag.Message ="Tüm alanları doldurunuz";
            }
            else if(counter < 4 )
            {
                ViewBag.Message="En az iki seçenek seçilmelidir.";
            }
            else
            {
                this.question=formCollection["txtQuestion"];
                this.addQuestionAndOptions(txtOption,txtDescription);
            }
        }

        private void addQuestionAndOptions(List<string> txtOption, List<string> txtDescription)
        {
            db.startTransaction();
            try
            {

                db.insertUpdateDelete("INSERT INTO questions (question, question_priority) VALUES ('"+this.question+"', "+this.questionPriority+")");
                long id = db.lastInsertedId;
                Console.WriteLine(id);
                int answer_priority= 1;
                for (var i=0; i<txtOption.Count;i++)
                {
                    db.insertUpdateDelete("INSERT INTO answers (question_id, answer, answer_priority) VALUES ("+id+", '"+txtOption[i]+"', "+answer_priority+")");
                    db.insertUpdateDelete("INSERT INTO answer_description (text, answer_id) VALUES ('"+txtDescription[i]+"', "+db.lastInsertedId+")");
                    answer_priority++;
                }

                //İşlem başarılı
                db.mySqlTransaction.Commit();
                ViewBag.Message = "Başarıyla eklendi...";
                this.functionStatus=true;
            }
            catch(Exception err)
            {
                db.stopTransaction(err);
                ViewBag.Message = "Eklenirken hata oluştu.. Hata mesajı : "+err.Message;
            }
        }
                private void getQuestion()
        {
            if(this.oneQuestionList().Rows.Count>0)
            {
                this.questionId= Convert.ToInt32(oneQuestionList().Rows[0]["id"]);
                this.question= oneQuestionList().Rows[0]["question"].ToString();
                this.questionPriority=  Convert.ToInt32(oneQuestionList().Rows[0]["question_priority"]);
                ViewBag.Question= this.question;
            }
            else
            {
                ViewBag.Message="Henüz kayıt yok";
            }
        }
        private void getAnswers()
        {
            List<string> Answers = new List<string>();
            List<string> AnswersID = new List<string>();
            DataTable answers= answersList(this.questionId);
            for(int i=0; i < answers.Rows.Count; i++)
            {
                Answers.Add(answers.Rows[i]["answer"].ToString());
                AnswersID.Add(answers.Rows[i]["id"].ToString());
            }
            ViewBag.AnswersList= Answers;
            ViewBag.AnswersListID= AnswersID;
        }
        private DataTable oneQuestionList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM questions Limit 1");
            return result;
        }
        private void controlAndGiveMessage()
        {
            if(oneQuestionList().Rows.Count > 0)
            {
                ViewBag.Message = "Başarılı..";
                ViewBag.Status= true;
            }
            else
            {
                ViewBag.Message="Veritabanında henüz kayıt yok !";
                ViewBag.Status= false;
            }
        }   
        ////////////////////////777
        public IActionResult Test()
        {
            ViewBag.Message ="deneme";
            return testElemani(23);
        }
        public dynamic testElemani(int a)
        {
            if(a==2)
            {
                return Redirect("Index");
            }
            else
            {
                return View();
            }
        }

        ///////////////////////////

    }
}