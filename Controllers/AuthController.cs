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
        public int questionId {get; set;}
        public int answerId {get; set;}
        public int userId {get; set;}
        public string question {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public int role {get; set;}
        public string question_priority {get; set;}

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
            ViewBag.Answer= this.getAnswerInfo().Rows[0]["answer"].ToString();
            ViewBag.AnswerDescription= this.getAnswerInfo().Rows[0]["text"].ToString();
            return View();
        }

        public DataTable oneQuestionList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM questions Limit 1");
            return result;
        } 
        public DataTable oneUserList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM users Where username='"+this.username+"' AND password ='"+this.password+"' ");
            return result;
        }        
        public DataTable answersList(int questionId)
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM answers WHERE question_id ='"+questionId+"' ORDER BY answer_priority ASC");
            return result;
        }

        private void getQuestion()
        {
            this.questionId= Convert.ToInt32(oneQuestionList().Rows[0]["id"]);
            this.question= oneQuestionList().Rows[0]["question"].ToString();
            this.question_priority= oneQuestionList().Rows[0]["question_priority"].ToString();
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
        private DataTable getAnswerInfo()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM	answers AS a LEFT JOIN answer_description as ad ON a.id=ad.answer_id Where a.id='"+this.answerId+"'");
            return result;
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
        public void accesPagesAdmin()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM page_access");
            for(int i=0 ; i < result.Rows.Count; i++)
            {
            }
            //string json = JsonConvert.SerializeObject(HttpContext.Current.Request.Url.AbsoluteUri, Formatting.Indented);
            Console.WriteLine(ControllerContext.ActionDescriptor.ActionName);
        }
    }
}