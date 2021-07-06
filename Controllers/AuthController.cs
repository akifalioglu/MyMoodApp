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

namespace MoodApp.Controllers
{
    public class AuthController : Controller
    {
        ConnectionMysqlModel db= new ConnectionMysqlModel();
        private readonly ILogger<HomeController> _logger;
        private int questionId {get; set;}
        private int answerId {get; set;}
        private int userId {get; set;}
        private string question {get; set;}
        private string username {get; set;}
        private string password {get; set;}
        private int role {get; set;}
        private int questionPriority {get; set;}

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            this.controlAndGiveMessage();
            this.getQuestion();
            this.getAnswers();
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }        
        public IActionResult Dashboard()
        {
            if (this.accesPagesAdmin()==true)
                return View();
            else
                this.setSessions(("errorMesssage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("Login");
        }

        [HttpPost]

        public IActionResult Dashboard(IFormCollection formCollection)
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
            return View();
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

        private DataTable oneQuestionList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM questions Limit 1");
            return result;
        } 
        private DataTable oneUserList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM users Where username='"+this.username+"' AND password ='"+this.password+"' ");
            return result;
        }        
        private DataTable answersList(int questionId)
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM answers WHERE question_id ='"+questionId+"' ORDER BY answer_priority ASC");
            return result;
        }
        private DataTable getAnswerInfo()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM	answers AS a LEFT JOIN answer_description as ad ON a.id=ad.answer_id Where a.id='"+this.answerId+"'");
            return result;
        }
        private void getQuestion()
        {
            this.questionId= Convert.ToInt32(oneQuestionList().Rows[0]["id"]);
            this.question= oneQuestionList().Rows[0]["question"].ToString();
            this.questionPriority=  Convert.ToInt32(oneQuestionList().Rows[0]["question_priority"]);
            ViewBag.Question= this.question;
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

        
        [HttpPost]
        public IActionResult Login(string txtUsername, string txtPassword)
        {
            this.username = txtUsername; 
            this.password = txtPassword;


            if(this.userControl()==true)
            {
                DataRow user=this.oneUserList().Rows[0];
                this.role= Convert.ToInt32( user["role"] );
                this.userId=Convert.ToInt32( user["id"] );
                this.setSessions(("id",this.userId),("role",this.role),("username",this.username));
                return Redirect("Dashboard");
            }
            else
            {
                return View();
            }
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
        
        private bool userControl()
        {
            if(this.oneUserList().Rows.Count > 0)
            {
                ViewBag.Status= true;
                return ViewBag.Status;
            }
            else
            {
                ViewBag.Message="Hatalı kimlik bilgileri !";
                ViewBag.Status= false;
                return ViewBag.Status;
            }
        }
        private void setSessions(params (string name, object content)[] sessionName)
            {
                string key;
                string value;

                foreach (var setSession in sessionName)
                {
                    value= setSession.content.ToString();
                    key = "ses_"+ setSession.name;
                    HttpContext.Session.SetString(key,value);
                }                


            }
        private bool accesPagesAdmin()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM page_access");
            string pageName = HttpContext.Request.Path;
            Console.WriteLine(pageName);
            for(int i=0 ; i < result.Rows.Count; i++)
            {

                if(pageName==result.Rows[i]["page_name"].ToString())
                {
                    if(Convert.ToInt32( HttpContext.Session.GetString("ses_role") ) != Convert.ToInt32( result.Rows[i]["role_id"]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void addQuestionAndOptions(List<string> txtOption, List<string> txtDescription)
        {
            db.startTransaction();
            try
            {

                db.insertUpdateDelete("INSERT INTO questions (question, question_priority) VALUES ('"+this.question+"', "+this.questionPriority+")");
                long id = db.lastInsertedId;
                Console.WriteLine(id);
                //Dictionary<string, string> openWith = new Dictionary<string, string>();
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

            }
            catch(Exception err)
            {
                db.stopTransaction(err);
                ViewBag.Message = "Eklenirken hata oluştu.. Hata mesajı : "+err.Message;
            }
        }


    }
}