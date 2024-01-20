using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
namespace RADSampleASP
{
    public class Users
    {
        //Properties
        public int UserID { get; set; }
        public string UserName { get; set; }
        //Constructors
        public Users() { }
        public Users(int id, string name)
        {
            UserID = id;
            UserName = name;
        }
        //Methods
        //Connection initializer method
        public SqlConnection ConnectDB()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=HAILE-VEN;Initial Catalog=UsersDB_ASP;Integrated Security=True");
                con.Open();
            }
            catch (Exception dbE)
            { return null; }
            return con;
        }
        //DB Insertion method
        public int AddUser(int id, string name)
        {
            int rowsAffected = 0;
            try
            {
                string sqlCmd = string.Format("INSERT INTO Users (UserID,UserName) " +
                    "VALUES ({0},'{1}')", id, name);
                SqlCommand Insertcmd = new SqlCommand(sqlCmd, ConnectDB());
                rowsAffected = Insertcmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException dbE)
            { if (dbE.Number == 2627 || dbE.Number == 2602) return -1; else return -2; }

            return rowsAffected;
        }
        //DB Update method
        public int UpdateUser(int id, string name)
        {
            int rowsAffected = 0;
            try
            {
                string sqlCmd = string.Format("UPDATE Users SET UserName = '{1}' " +
                    "WHERE UserID = {0}", id, name);
                SqlCommand Insertcmd = new SqlCommand(sqlCmd, ConnectDB());
                rowsAffected = Insertcmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException dbE)
            { if (dbE.Number == 2627 || dbE.Number == 2602) return -1; else return -2; }

            return rowsAffected;
        }
        //DB Delete method
        public int DeleteUser(int id)
        {
            int rowsAffected = 0;
            try
            {
                string sqlCmd = string.Format("DELETE FROM Users WHERE UserID = {0}", id);
                SqlCommand Insertcmd = new SqlCommand(sqlCmd, ConnectDB());
                rowsAffected = Insertcmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException dbE)
            { if (dbE.Number == 2627 || dbE.Number == 2602) return -1; else return -2; }

            return rowsAffected;
        }
        //DB Select all method
        public DataTable ViewAllUser()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter usrLst = null;
            try
            {
                
                usrLst = new SqlDataAdapter("SELECT * FROM Users", ConnectDB());
                usrLst.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException dbE)
            { if (dbE.Number == 2627 || dbE.Number == 2602) return null; else return dt; }
            return dt;
        }
    }
}