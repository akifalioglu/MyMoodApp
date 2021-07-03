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



namespace MoodApp.Controllers
{
    public class AuthController : Controller
    {
        ConnectionMysqlModel db= new ConnectionMysqlModel();
        public int questionId {get; set;}
        public int answerId {get; set;}
        public string question {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public string question_priority {get; set;}
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
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
                ViewBag.Message = "Başarıyla giriş yapıldı..";
                ViewBag.Status= true;
                //Session için bytes formatına dönüştürmek
            
                var usernameToByte = Encoding.UTF8.GetBytes(this.username);
                HttpContext.Session.Set("ses_username",usernameToByte);

                var passwordToByte = Encoding.UTF8.GetBytes(this.password);
                HttpContext.Session.Set("ses_password",passwordToByte);
                return ViewBag.Status;
            }
            else
            {
                ViewBag.Message="Hatalı kimlik bilgileri !";
                ViewBag.Status= false;
                return ViewBag.Status;
            }
        }
    }
}