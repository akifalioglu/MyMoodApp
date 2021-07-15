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
            result = db.listForDatatable("SELECT * FROM page_access");
            string pageName = context.Request.Path;
            for(int i=0 ; i < result.Rows.Count; i++)
            {
                if(pageName.Contains(result.Rows[i]["page_name"].ToString()))
                {
                    try
                    {
                        if(Convert.ToInt32( context.Session.GetString("ses_role") ) != Convert.ToInt32( result.Rows[i]["role_id"]))
                        {
                            this.status=false;
                            this.setSessions(context,("errorMesssage","Yetkisiz Erişim Engellendi. Lütfen yetkiniz olan sayfalara erişiniz.!"));
                            return Redirect("../Auth/Login");
                        }
                    }
                    catch(Exception err)
                    {
                        Console.WriteLine(err);
                        this.status=false;
                    }
                }
            }
        this.status=true;
        return View();
        
        }
        public bool accesPagesStatus(HttpContext context)
        {
            DataTable result;
            result = db.listForDatatable("SELECT * FROM page_access");
            string pageName = context.Request.Path;
            Console.WriteLine(pageName);
            for(int i=0 ; i < result.Rows.Count; i++)
            {

                if(pageName==result.Rows[i]["page_name"].ToString())
                {
                    if(Convert.ToInt32( context.Session.GetString("ses_role") ) != Convert.ToInt32( result.Rows[i]["role_id"]))
                    {
                        return false;
                    }
                }
            }
            return true;
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