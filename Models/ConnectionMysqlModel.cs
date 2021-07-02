using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;

namespace MoodApp.Models
{
    class ConnectionMysqlModel
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySqlConnection connectionGenerator ()
        {
            server = "127.0.0.1";
            database = "mood";
            uid = "root";
            password = "akif";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            return connection;
        }
        public DataTable listForDatatable(string sorgu)
        {
            this.connectionGenerator().Open();
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, this.connectionGenerator());
            DataTable dtb = new DataTable();
            adap.Fill(dtb);
            this.connectionGenerator().Close();
            return dtb;
        }
    } 
}