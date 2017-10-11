using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_group_Master : System.Web.UI.Page
{
    DataSet ds;
    MySqlDataAdapter da;
    clsconnection cn = new clsconnection();
    acc_group_mstcls accgrpobj = new acc_group_mstcls();
   // string acc_headid = HttpContext.Current.Session["accounthead_id"].ToString();
     protected string group_id { get; set; }
    protected string group_name { get; set; }
    protected string prno { get; set; }
    protected string branch { get; set; }
    protected string address { get; set; }
    string acc_headid;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(Session["accounthead_id"] as string))
 
        {
             acc_headid = Session["accounthead_id"].ToString();

            if (!IsPostBack)
            {
                acc_headid = Session["accounthead_id"].ToString();
                group_id = accgrpobj.AutoIncr().ToString();
                LoadGrid();
                load_dropdown();
            }

        }
        else
      {
         Response.Redirect("loginform.aspx");
        }
        
        
    }
    private void load_dropdown()
    {
        string sql = "Select * from main_group_mst ";

        ds = cn.Getresult(sql, "main_group_mst");

        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "main_group_name";
        DropDownList1.DataValueField = "main_group_id";
        DropDownList1.DataBind();

    }

    private void LoadGrid()
    {
       // acc_headid = Session["accounthead_id"].ToString();
        string sql = "Select   g.account_group_id,g.group_name, g.print_no, m.main_group_name, g.RP_disp from account_group_mst g inner join main_group_mst m on g.main_group_id = m.main_group_id  where account_head_id ='" + acc_headid +"' order by id";
        ds = cn.Getresult(sql, "account_group_mst");
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }

    private void ClearTextBoxes(ControlCollection controlCollection) //To clear the values of TextBoxes
    {
        foreach (Control ctrl in controlCollection)
        {
            TextBox tb = ctrl as TextBox;
            if (tb != null)
                tb.Text = "";
            else
                ClearTextBoxes(ctrl.Controls);
        }
        group_id  = accgrpobj.AutoIncr().ToString();
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        ClearTextBoxes(this.Controls);
        btnsave.Visible = true ;

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        load_data();

        accgrpobj.saverecord();
        LoadGrid();
        ClearTextBoxes(this.Controls);

    }

    private void load_data()
    {
       
        Label str = Master.FindControl("lblAccountHead") as Label;
        accgrpobj.Acc_group_id =  Request.Form["txtgroupno"];
        accgrpobj.Acc_group_name = Request.Form["txtGroupname"];  
        accgrpobj.print_no =  Request.Form["txtprno"];
          string input = Request.Form["txtgroupno"];
            accgrpobj.id_eng  = Convert.ToInt32(clsconnection.ParseValue(input));
       
        if (chbPotKhate.Checked)
        {

            accgrpobj.rp_disp = true;
        }
        else
        {
            accgrpobj.rp_disp = false;
        }
        clsconnection.main_account_groupid = DropDownList1.SelectedItem.Value;
       /* clsconnection.acc_head_id = acc_headid;
       clsconnection.school_id = "1";
        clsconnection.school_dept_id = "1";
        clsconnection.font_id = "1";
        clsconnection.modify_login_id = "";
        clsconnection.create_login_id = "";*/
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        load_data();
        accgrpobj.updaterecord();
        LoadGrid();
        ClearTextBoxes(this.Controls);
        btnsave.Visible = true ;
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        accgrpobj.Acc_group_id = Request.Form["txtgroupno"];
        accgrpobj.deleterecord();
        LoadGrid();
        ClearTextBoxes(this.Controls);
        btnsave.Visible = true;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnsave.Visible = false;
        group_id = GridView1.SelectedRow.Cells[1].Text;
        group_name = GridView1.SelectedRow.Cells[2].Text;
         prno  = GridView1.SelectedRow.Cells[3].Text;
        DropDownList1.SelectedItem.Text  = GridView1.SelectedRow.Cells[4].Text;
        bool isSelected = (GridView1.SelectedRow.FindControl("chkid") as CheckBox).Checked;

        if (isSelected == true)
        {
            chbPotKhate.Checked = true;
        }
        else
        {
            chbPotKhate.Checked = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void btnexit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}