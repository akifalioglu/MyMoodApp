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



namespace MoodApp.Controllers
{
    public class AuthController : Controller
    {
        ConnectionMysqlModel db= new ConnectionMysqlModel();
        public int questionId {get; set;}
        public string question {get; set;}
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

        public DataTable oneQuestionList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM questions Limit 1");
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
            DataTable answers= answersList(this.questionId);
            for(int i=0; i < answers.Rows.Count; i++)
            {
                Answers.Add(answers.Rows[i]["answer"].ToString());
            }
            ViewBag.AnswersList= Answers;
        }
        
        //[HttpPost]
        /*public IActionResult Index(string username, string password)
        {
            //ViewBag.Name = string.Format("Name: {0} {1} {2}", firstName, lastName,number);
            //this.username=username;
            //this.password=password;
            //this.request=Request.HttpContext.ToString();
            //this.controlAndGiveMessage();
            return View();
        }
        */  

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
    }
}