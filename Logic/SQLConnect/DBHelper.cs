using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace VideoLibrary.Logic.SQLConnect
{
    public class DBHelper
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ATSYSTEMS"].ConnectionString);
    }
}   //ATSYSTEMS\SQLEXPRESS