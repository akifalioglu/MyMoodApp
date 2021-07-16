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

    public class General : Controller
    {
        ConnectionMysqlModel db= new ConnectionMysqlModel();

        public bool status { get; set; }
        public dynamic accesPagesAdmin(HttpContext context)
        {
            DataTable result;
            DataTable accesList = new DataTable();
            accesList.Columns.Add("role_id");
            result = db.listForDatatable("SELECT * FROM page_access");
            string pageName = context.Request.Path;
            for(int i=0 ; i < result.Rows.Count; i++)
            {
                if(pageName.Contains(result.Rows[i]["page_name"].ToString()))
                {
                    accesList.Rows.Add(result.Rows[i]["role_id"]);
                }
            }
            bool exists = accesList.AsEnumerable().Where(c => c.Field<string>("role_id").Equals(context.Session.GetString("ses_role"))).Count() > 0;
            if(exists==false)
            {
                this.status=false;
                this.setSessions(context,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return Redirect("../Auth/Login");
            }
            else
            {
                this.status=true;
                return View();
            }        
        }
        public bool accesPagesStatus(HttpContext context)
        {
            DataTable result;
            DataTable accesList = new DataTable();
            accesList.Columns.Add("role_id");
            result = db.listForDatatable("SELECT * FROM page_access");
            string pageName = context.Request.Path;
            Console.WriteLine(pageName);
            for(int i=0 ; i < result.Rows.Count; i++)
            {

                if(pageName.Contains(result.Rows[i]["page_name"].ToString()))
                {
                    accesList.Rows.Add(result.Rows[i]["role_id"]);       
                }
            }
            bool exists = accesList.AsEnumerable().Where(c => c.Field<string>("role_id").Equals(context.Session.GetString("ses_role"))).Count() > 0;
            if(exists==false)
            {
                this.status=false;
                this.setSessions(context,("errorMessage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                return this.status;
            }
            else
            {
                this.status=true;
                return this.status;
            }   
        }
        public void setSessions( HttpContext context, params (string name, object content)[] sessionName)
        {
            string key;
            string value;

            foreach (var setSession in sessionName)
            {
                value= setSession.content.ToString();
                key = "ses_"+ setSession.name;
                context.Session.SetString(key,value);
            }                
        }
    }
}