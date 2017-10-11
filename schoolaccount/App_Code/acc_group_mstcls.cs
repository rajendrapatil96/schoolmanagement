using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for acc_group_mstcls
/// </summary>
public class acc_group_mstcls :clsconnection
{
    string accgroup_id, prt_no;
    string accgroup_name;
    int id;
    Boolean rpdisp;
    clsconnection con = new clsconnection();

    public string Acc_group_id
    {
        get { return accgroup_id; }
        set { accgroup_id = value; }
    }
    public string Acc_group_name
    {
        get { return accgroup_name; }
        set { accgroup_name = value; }
    }
    public string print_no
    {
        get { return prt_no; }
        set { prt_no = value; }
    }
    
    
    public Boolean rp_disp
    {
        get { return rpdisp; }
        set { rpdisp = value; }
    }
    public int id_eng
    {
        get { return id ; }
        set { id  = value; }
    }
    
    DateTime dt = DateTime.Now; // Gives the date for today
    //string sdate = DateTime.Now.ToShortDateString();
    string sdate = DateTime.Now.ToString("yyyy-MM-dd");
    public int saverecord()
    {
        string query = "Insert into account_group_mst values('" + accgroup_id + "','" + accgroup_name + "','" + prt_no + "','" + mainaccgrid + "'," + rpdisp + ",'" + create_login_id + "','" + sdate + "','" + modify_login_id + "','" + sdate + "','" + font_id + "','" + school_id + "','" + school_dept_id + "','" + account_head_id + "'," + id + ")";
        con.updaterecord(query);
        return 1;
    }
    public int updaterecord()
    {
        string query = "update account_group_mst set group_name= '" + accgroup_name + "',print_no ='" + prt_no + "',main_group_id='" + mainaccgrid + "',RP_disp=" + rpdisp + ",created_by ='" + create_login_id + "',created_on ='" + sdate + "',modified_by='" + modify_login_id + "',modified_on ='" + sdate + "',account_head_id='" + account_head_id + "'where  Account_group_id  ='" + accgroup_id + "'";
         con.updaterecord(query);
        return 1;
    }
    public int deleterecord()
    {
        string query = "delete  from account_group_mst  where  Account_group_id  ='" + accgroup_id + "'";
        con.updaterecord(query);
        return 1;
    }
    public string AutoIncr()
    {
        return con.GetNextId("account_group_mst", "Account_group_id");
    }
}