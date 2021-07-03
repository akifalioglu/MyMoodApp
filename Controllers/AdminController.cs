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
    public class AdminController : Controller
    {
        public DataTable accesPagesAdmin()
        {
            DataTable dtb = new DataTable();
            dtb.Rows.Add("Dashboard","1");

            return dtb;

        }
    }
}