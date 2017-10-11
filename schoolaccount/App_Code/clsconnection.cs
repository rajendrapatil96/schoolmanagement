using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for clsconnection
/// </summary>
public class clsconnection
{     
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataSet ds;
        int cnt;
      
        public static string fontid, schoolid,schdeptid,mainaccgrid,acc_head_id;
        public static string crloginid, mdloginid, database_name;
        public static int pageno;

        public static string database
        {
            get { return database_name; }
            set { database_name = value; }
        }
     
        public clsconnection()
        {

            string server = "192.168.1.222";
            if (database_name == null)
            {
                database_name = "studentmanagement";
            }
            string uid = "root";
            string Passward = "motiv@ted";

            string connstr = "SERVER =" + server + "; DATABASE =" + database_name + "; UID =" + uid + "; PASSWORD = " + Passward + ";charset=utf8";
            con = new MySqlConnection(connstr);

        }
      

        public static string font_id
        {
            get { return fontid; }
            set { fontid = value; }
        }
        public static string school_id
        {
            get { return schoolid; }
            set { schoolid = value; }
        }
        public static string main_account_groupid
        {
            get { return mainaccgrid; }
            set { mainaccgrid = value; }
        }
        public static string account_head_id
        {
            get { return acc_head_id; }
            set { acc_head_id = value; }
        }
        public static string school_dept_id
        {
            get { return schdeptid; }
            set { schdeptid = value; }
        }
        public static string create_login_id
        {
            get { return crloginid; }
            set { crloginid = value; }
        }
        public static string modify_login_id
        {
            get { return mdloginid; }
            set { mdloginid = value; }
        }
        public static int page_no
        {
            get { return pageno; }
            set { pageno = value; }
        }
        public void open()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void close()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public DataSet Getresult(string qry, string tblnm)
        {
            try
            {
                da = new MySqlDataAdapter(qry, con);
                ds = new DataSet();
                da.Fill(ds, tblnm);
                //dt = ds.Tables(tblnm);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }
      
            public void  GetDDLValue(DropDownList ddl, string qry, string tablenm)
        {
            try
            {

              ds =  Getresult(qry, tablenm);
               ddl.AutoPostBack = true;
              ddl.DataSource = ds;
              DataTable dt = ds.Tables[tablenm];
          
              ddl.DataTextField = dt.Columns[1].ColumnName;
              ddl.DataValueField = dt.Columns[0].ColumnName;
              ddl.DataBind();
              ddl.Items.Insert(0, "Select a value");
             
               } 
            catch (Exception ex)
            {
                
            }
                   
            }
        public void updaterecord(string qry)
        {
            try
            {
                open();
                cmd = new MySqlCommand(qry, this.con);
                int cnt = cmd.ExecuteNonQuery();

                close();
            }
             catch (Exception ex)
            {
                close();
                
            }
        }
        public int readrecord(string qry)
        {
           
            try
            {
                
                cmd = new MySqlCommand(qry,con);
                open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   cnt = 1;
                }
                 close();
            }
            catch (Exception ex)
            {
                cnt= 0;
                close();
            }
            return cnt;

        }
        public string GetNextId(string tblnm, string column)
        {
            
            try
            {
                int []maxno;
                string sql;
                if (acc_head_id == null)
                {
                      sql = "Select max(" + column + ") from " + tblnm;
                }
                else
                {
                     sql = "Select  max(" + column + ") from " + tblnm + " where account_head_id = '" + acc_head_id + "'";
                }
                da = new MySqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, tblnm);
                DataTable dt = ds.Tables[tblnm];
                if (dt.Rows.Count == 0)
                {
                    string marno = 1.ToString();
                    var marathi = numberreplace.ReplaceNumbers(marno);
                    return marathi;
                }
                else
                {
               DataRow drow =dt.Rows[0];
                 int count = dt.Rows.Count;
                 
                maxno = new int[count];
                 
                for (int i = 0; i < count; i++)
                {
                   string input = ds.Tables[tblnm].Rows[i].ToString();
                
                      input =dt.Rows[0][0].ToString();
                    int value = 0;
                    if (Int32.TryParse(String.Join(String.Empty, input.Select(Char.GetNumericValue)), out value))
                    {
                         maxno[i] = value;
                        //....
                    }
               }
                   
                  int maxIndex = -1;
                  int maxInt = Int32.MinValue;
                  
    // Modern C# compilers optimize the case where we put array.Length in the condition
                   for (int i = 0; i < maxno.Length; i++)
                 {
                   int   value = maxno[i];
                    if (value > maxInt)
                    {
                      maxInt = value;
                        maxIndex = i;
                     }
                   }
                   string marno = (maxInt+1).ToString();
                   var marathi = numberreplace.ReplaceNumbers(marno);
                return marathi;
            }
            }
            catch (Exception ex)
            {
                return " ";
            }
            
        }

        public int GetNextIdint(string tblnm, string column)
        {
            try
            {
                string sql;
                if (acc_head_id == null)
                {
                     sql = "Select max(" + column + ") from " + tblnm ;
                }
                else
                {
                    sql = "Select max(" + column + ") from " + tblnm + " where account_head_id = '" + acc_head_id + "'";
                }
              
                da = new MySqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, tblnm);
                if (ds.Tables[tblnm].Rows[0][0].ToString() == "")
                    return 1;
                else
                {
                    int maxno = Convert.ToInt32(ds.Tables[tblnm].Rows[0][0].ToString());
                    int id = maxno + 1;
                    return id;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        public static double ParseValue(string value)
        {
            return double.Parse(string.Join("",
                value.Select(c => "+-.".Contains(c)
                   ? "" + c : "" + char.GetNumericValue(c)).ToArray()),
                NumberFormatInfo.InvariantInfo);
        }
        }
    
	 
