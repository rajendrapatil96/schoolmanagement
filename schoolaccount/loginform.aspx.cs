using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginform : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            fillschool();
            if (Session["accounthead_id"] != null)
            {

                logyear();

                //ddlAccountHead.SelectedValue = Session["accounthead_id"].ToString();
                // ddlAccountHead.SelectedItem.Value = account_head;
            }
            else
            {
                logyear();
            }
        }
       
    }

    private void fillschool()
    {
         string accyear = "SELECT  school_id,school_name FROM school_mst";
        ds = con.Getresult(accyear, "school_mst");
        ddlschoolid.DataSource = ds;
        ddlschoolid.DataTextField = "school_name";
        ddlschoolid.DataValueField = "school_id";
        ddlschoolid.DataBind();
        ddlschoolid.Items.Insert(0, new ListItem("-- Select School --", "0")); 
       
    }
     
    clsconnection con = new clsconnection();
    DataSet ds = new DataSet();
    public static string account_head;
   // this function fill the records into accountHead grid
    public void logyear()
    {
       /* string accyear = "SELECT  id,academic_year FROM academic_year";
        ds = con.Getresult(accyear, "academic_year");
        ddllogyear.DataSource = ds;
        ddllogyear.DataTextField = "academic_year";
        ddllogyear.DataValueField = "id";
        ddllogyear.DataBind();
        ddllogyear.Items.Insert(0, new ListItem("-- Select Log Year --", "0"));*/
        int year = DateTime.Now.Year, count = 1;
        ddllogyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year; i > year - 3; i--)
        {
            ddllogyear.Items.Insert(count, new ListItem(i.ToString() + "_" + (i+ 1).ToString()));
            count++;
        }
                
        
     
    }
  public void fillschoolsection()
{

    string  schoolsection = "SELECT school_dept_id,school_dept_name FROM school_dept_mst where school_id =" + ddlschoolid.SelectedItem.Value;
    ds = con.Getresult(schoolsection, "school_dept_master");
            ddlsclsections.DataSource = ds;
            ddlsclsections.DataTextField = "school_dept_name";
            ddlsclsections.DataValueField = "school_dept_id";
            ddlsclsections.DataBind();
            // ddlAccountHead.Items.Insert(0, new ListItem("-- प्रमुख खाते निवडा --", "0"));
         
}
  protected void ddlsclsections_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["schooldeptname"] = ddlsclsections.SelectedItem.Text;
        Session["schholdeptid"] = ddlsclsections.SelectedValue;
    }

    protected void btnexit_Click(object sender, EventArgs e)
    {
        clsconnection con = new clsconnection();
        clsconnection.create_login_id = Request.Form["txtuid"];
        string sql = "Select user_pwd,user_name from user_master where login_id ='" + Request.Form["txtuid"] +"'" ;
        ds = con.Getresult(sql, "user_master");
        DataTable dt = ds.Tables["user_master"];
        double dPrice = 0;
        if (ds.Tables.Count > 0)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == Request.Form["txtpwd"])
                {
                    string login_id = Request.Form["txtuid"].ToString();
                    Session["login_name"] = dt.Rows[0][1].ToString();
                      Session["login_id"] = Request.Form["txtuid"];
                      Session["schoolname"] =ddlschoolid.SelectedItem.Text;
                      Session["schoolid"] = ddlschoolid.SelectedItem.Value;
                      Session["schooldeptname"] = ddlsclsections.SelectedItem.Text;
                      Session["schholdeptid"] = ddlsclsections.SelectedItem.Value;
                      Session["accounthead_id"] = "५";
                      Response.Redirect("GRModulepage.aspx?login_id=" + login_id);
                     
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Password is Incorrrect')</script>");
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('User not found')</script>");
            }
        }

    }
    protected void ddllogyear_SelectedIndexChanged(object sender, EventArgs e)
    {

    //   Session["LogYear"] = "studentmanagement" + ddllogyear.SelectedItem.Text + ddlschoolid.SelectedItem.Value;
        Session["LogYear"] = "studentmanagement";
      //  clsconnection.database = "studentmanagement" + ddllogyear.SelectedItem.Text + ddlschoolid.SelectedItem.Value;
        clsconnection.database = "studentmanagement";
        fillschoolsection();
    }
}