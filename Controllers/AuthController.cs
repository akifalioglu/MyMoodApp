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
    public class AuthController : Controller
    {
        ConnectionMysqlModel db= new ConnectionMysqlModel();
        General general= new General();
        private readonly ILogger<HomeController> _logger;

        private int userId {get; set;}

        private string username {get; set;}
        private string password {get; set;}
        private int role {get; set;}

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }        
        public IActionResult Dashboard()
        {
            if (general.accesPagesStatus(HttpContext)==true)
            {
                ViewBag.UserCount= this.userCount();
                ViewBag.QuestionCount = this.questionCount();
                return View();
            }
            else
            {
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
        }

        public IActionResult AssignRole()
        {
            if (general.accesPagesStatus(HttpContext)==true)
            {
                var vm = new UsersModel();
                vm.roles = new List<SelectListItem>();
                for (int i = 0; i < this.getRole().Rows.Count; i++)
                {
                    vm.roles.Add(new SelectListItem() { Text = this.getRole().Rows[i]["name"].ToString(), Value =  this.getRole().Rows[i]["id"].ToString() });
                }
                return View(vm);
            }
            else
            {
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
        }
        [HttpPost]
        public IActionResult AssignRole(string txtUsername,int roleId)
        {
            if (general.accesPagesStatus(HttpContext)==true)
            {
                this.username=txtUsername;
                try{
                    this.userId=Convert.ToInt32( this.oneUserList().Rows[0]["id"] );
                    if(this.updateRole(roleId)==1)
                        ViewBag.SuccesMessage="Yetki başarıyla atandı !";
                }
                catch(IndexOutOfRangeException)
                {
                    ViewBag.ErrorMessage = "Olmayan bir kullanıcıya yetki atanamaz !";
                }
                ViewBag.RoleList=this.getRole();
                                var vm = new Models.UsersModel();
                vm.roles = new List<SelectListItem>();
                for (int i = 0; i < this.getRole().Rows.Count; i++)
                {
                    vm.roles.Add(new SelectListItem() { Text = this.getRole().Rows[i]["name"].ToString(), Value =  this.getRole().Rows[i]["id"].ToString() });
                }

                return View(vm);
            }
            else
            {
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
        }
       [HttpPost]
        public IActionResult Login(string txtUsername, string txtPassword)
        {
            this.username = txtUsername; 
            this.password = txtPassword;


            if(this.userControl()==true)
            {
                DataRow user=this.oneUserPasswordList().Rows[0];
                this.role= Convert.ToInt32( user["role"] );
                this.userId=Convert.ToInt32( user["id"] );
                Console.WriteLine("id = ",this.userId + "-- role = ",this.role+"--username =",this.username);
                general.setSessions(HttpContext,("id",this.userId),("role",this.role),("username",this.username));
                return Redirect("Dashboard");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            general.setSessions(HttpContext,("succesMessage","Başarıyla çıkış yaptınız.."));
            return Redirect("../Auth/Login");

        }

        public IActionResult AddUser()
        {
            if(general.accesPagesStatus(HttpContext)==false)
            {                                
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
            else
            {
                var vm = new UsersModel();
                vm.roles = new List<SelectListItem>();
                for (int i = 0; i < this.getRole().Rows.Count; i++)
                {
                    vm.roles.Add(new SelectListItem() { Text = this.getRole().Rows[i]["name"].ToString(), Value =  this.getRole().Rows[i]["id"].ToString() });
                }
                return View(vm);
            }
        }
        [HttpPost]
        public IActionResult AddUser(string txtUsername,string txtPassword,int roleId)
        {
            if(general.accesPagesStatus(HttpContext)==false)
            {                                
                general.setSessions(HttpContext,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
            else
            {
                var vm = new UsersModel();
                vm.roles = new List<SelectListItem>();
                for (int i = 0; i < this.getRole().Rows.Count; i++)
                {
                    vm.roles.Add(new SelectListItem() { Text = this.getRole().Rows[i]["name"].ToString(), Value =  this.getRole().Rows[i]["id"].ToString() });
                }

                this.username=txtUsername;
                this.password=txtPassword;

                if(this.addUser(roleId)>0)
                {
                    Console.WriteLine("eklendi");
                    string deger =txtUsername +" adlı kullanıcı eklendi.";
                    ViewBag.SuccesMessage=deger;
                }
                else
                {
                    ViewBag.ErrorMessage ="Bir hata oluştu !";
                }
                
                return View(vm);
            }

        }

        private DataTable oneUserPasswordList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM users Where username='"+this.username+"' AND password ='"+this.password+"' ");
            return result;
        }
        private DataTable oneUserList()
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM users Where username='"+this.username+"'");
            return result;
        }       
        private bool userControl()
        {
            if(this.oneUserPasswordList().Rows.Count > 0)
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
        private DataTable getRole()
        {
            return db.listForDatatable("SELECT * FROM roles");
        }
        public UsersModel GetRole(string result)
        {
            UsersModel roles = new UsersModel();

            roles.Result = result;
            this.username=result;
            if(this.oneUserList().Rows.Count>0)
            {
                if(this.oneUserList().Rows[0]["username"].ToString()==result)
                {
                    roles.resultCode=true;
                    roles.roleValue=Convert.ToInt32(this.oneUserList().Rows[0]["role"]);
                }
                else
                {
                    roles.resultCode=false;
                }
            }
            
            return roles;
        }
        private int updateRole(int roleId)
        {
            return db.insertUpdateDelete("UPDATE users SET role = "+roleId+" WHERE id = "+this.userId+"");
        }
        private int addUser(int roleId)
        {
            return db.insertUpdateDelete(" INSERT INTO users (username, password, role) VALUES ('"+this.username+"', '"+this.password+"', "+roleId+")");
        }
        public dynamic userCount()
        {
            return db.listForDatatable("SELECT count(*) FROM users").Rows[0][0];
        }
        private dynamic questionCount()
        {
            return db.listForDatatable("SELECT count(*) FROM questions").Rows[0][0];
        }

    }
}