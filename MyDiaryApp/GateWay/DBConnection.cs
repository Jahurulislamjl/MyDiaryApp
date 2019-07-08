using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace MyDiaryApp.GateWay
{
    public class DBConnection
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["MyDiaryAppConnectionString"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public string Query { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public int Count { get; set; }

        public DBConnection()
        {
            Connection = new SqlConnection(ConnectionString);
        }

    }
}