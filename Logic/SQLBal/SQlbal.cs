using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using VideoLibrary.Logic.SQLConnect;
using System.Configuration;
namespace VideoLibrary.Logic.SQLBal
{
    public class SQlbal
    {
        DBHelper dbhelp = new DBHelper();
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public string StreamID { get; set; }
        public string StreamName { get; set; }
        public string StreamURL { get; set; }
        public string PosterPath { get; set; }
        
        SqlCommand cmd;
        SqlDataAdapter DA;
        int i;
      //  string a;
        public int Save_Video()
        {
            dbhelp.conn.Open();
            cmd = new SqlCommand("sp_VideoSave", dbhelp.conn);
            cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.Parameters.AddWithValue("@ID", ID);
            if(Name!=null)
            {
                cmd.Parameters.AddWithValue("@Name", Name);
            }
            if(Path != null)
            {
                cmd.Parameters.AddWithValue("@Path", Path);
            }
           if(PosterPath!=null)
           {
               cmd.Parameters.AddWithValue("@PosterPath", PosterPath);
           }
           if(StreamName !=null)
            {
                cmd.Parameters.AddWithValue("@HallName", StreamName);
            }
            i = cmd.ExecuteNonQuery();
            dbhelp.conn.Close();
            return i;
        }
        public int Del()
        {
            dbhelp.conn.Open();
            cmd = new SqlCommand("usp_delstream", dbhelp.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ID != 0)
            {
                cmd.Parameters.AddWithValue("@ID", ID);
            }
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public DataSet GetAllCameraVideo()
        {
            DataSet ds = new DataSet();
            cmd = new SqlCommand("usp_GetAllCameraVideos", dbhelp.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DA = new SqlDataAdapter(cmd);

            DA.Fill(ds);
            return ds;
        }
        //public static DataTable GetDayByConfer_ID(string Confer_ID)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[1];
        //    sqlparam[0] = new SqlParameter("@Name", Confer_ID);

        //    return SQlbal.GetDataTable("SearchSalt", sqlparam);
        //}
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DEVELOPERTEST"].ToString();
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());

        }
        private static SqlCommand GetCommand(string cmdTxt, SqlConnection connection, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand(cmdTxt, connection);
            if (cmdTxt.ToLower().StartsWith("usp_") || cmdTxt.ToLower().StartsWith("pr"))
                command.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
                AttachParameters(command, commandParameters);
            return command;
        }
        public static DataTable GetDataTable(string cmdTxt, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(cmdTxt, connection, commandParameters);
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
        public static DataSet GetDataSet(string cmdTxt, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = GetCommand(cmdTxt, connection, commandParameters);
            command.CommandTimeout = 180;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet(command.CommandText);
            da.Fill(ds);
            return ds;
        }
        public static int ExecuteNonQuery(string cmdTxt, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = GetCommand(cmdTxt, connection, commandParameters);
            int rVal = command.ExecuteNonQuery();
            connection.Close();
            return rVal;
        }
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
    }
}