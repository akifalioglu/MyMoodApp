using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace MoodApp.Models
{
    class ConnectionMysqlModel
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public long lastInsertedId { get; set; }
        public MySqlTransaction mySqlTransaction {get; set;}
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

        public DataTable listForDatatable(string query)
        {
            this.connectionGenerator().Open();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, this.connectionGenerator());
            DataTable dtb = new DataTable();
            adap.Fill(dtb);
            this.connectionGenerator().Close();
            return dtb;
        }
        public int insertUpdateDelete(string query)
        {
            MySqlConnection connection = this.connectionGenerator();
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            int mod;
            mod= mySqlCommand.ExecuteNonQuery();
            this.lastInsertedId = mySqlCommand.LastInsertedId;
            connection.Close();
            return mod;
        }
        public void startTransaction()
        {
            MySqlConnection connection = this.connectionGenerator();
            connection.Open();
            MySqlTransaction mySqlTransaction;
            mySqlTransaction= connection.BeginTransaction();
            MySqlCommand mySqlCommand=connection.CreateCommand();
            mySqlCommand.Transaction=mySqlTransaction;
            this.mySqlTransaction=mySqlTransaction;
        }
        public void stopTransaction(Exception error)
        {
           MySqlConnection connection = this.connectionGenerator();
           if(error.Message is string)
            {
                Console.WriteLine("hata bulundu");
                //İşlemler geri alındı
                this.mySqlTransaction.Rollback();
                connection.Close();
            }
        }
    } 
}