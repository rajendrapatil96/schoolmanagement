<%@ Page Title="" Language="C#" MasterPageFile="~/AccountHome.master" AutoEventWireup="true" CodeFile="Account_group_Master.aspx.cs" Inherits="Account_group_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style>

        .Common-Buttons 
        {        
           margin-left: 20px;
           width: 90px;  
           /*color:#333;background-color:#fff;border-color:#ccc*/      
        }

        .Common-Buttons:hover,.Common-Buttons:focus,.Common-Buttons:active,.Common-Buttons.active,.open .dropdown-toggle.Common-Buttons
        {color:#333;background-color:#ebebeb;border-color:#adadad}
        .Common-Buttons:active,.Common-Buttons.active,.open .dropdown-toggle.Common-Buttons
        {background-image:none}

            .Common-Buttons:disabled {
                margin-left: 20px;
                width: 90px;
            }
    </style>
<link href="css/ButtonCSS.css" rel="stylesheet" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
   

    <panel class="container">
    <div class="row">
        <div><span><h1 style="margin-top: 10px;text-align: center;background-color: #CBFCFE;" class="auto-style1">मुख्य  खात्यांची यादी</h1></span></div>
    </div><br />
  <form class="form-horizontal">
    <div class="form-group">
      <label class="control-label col-sm-2" style="text-align:right;" for="email">अनुक्रमांक :</label>
      <div class="col-sm-2">
         <input name="txtgroupno" style="border-radius:0px;" type="text" height="30" width="130"  value="<%= this.group_id %>"  />
      </div>
       <label class="control-label col-sm-2" style="text-align:right;" for="pwd">छपाई क्रम :</label>
      <div class="col-sm-4">          
        <input id="txtprno" name="txtprno"  style="border-radius:0px;" type="text" height="30" width="130" required  value="<%= this.prno %>"/>&nbsp;</div>   
          
    </div>
      <br/>


    <div class="form-group">
          <div class="col-sm-2">
      <label  style="text-align:right;" for="email">ग्रुपचे नाव :</label>
              </div>
      <div class="col-sm-4">
         <input id="txtgroupname"  name ="txtgroupname"   style="border-radius:0px; width: 170px;" type="text" height="30"  required  value="<%= this.group_name %>" />
      </div>
          <div class="col-sm-1">  
            </div>   
        
     
    </div>
      <br />
    <div class="form-group">
      <label class="control-label col-sm-2" style="text-align:right;" for="email">मुख्य ग्रुप निवडा :</label>
      <div class="col-sm-2">
         <asp:DropDownList ID="DropDownList1" style="border-radius:0px;" runat="server" Height="25px" Width="196px">
        </asp:DropDownList>

      </div>
        <div class="col-sm-6">
         <asp:CheckBox ID="chbPotKhate"  style="margin-left: 165px;"  runat="server" Text="जमा/खर्च पत्रकात पोटखाती दाखवायची का?" />
            </div>
    </div>
      <br />
      <br />
     
            <div class="form-group" style="margin-left:70px;">
          
&nbsp;<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Width="788px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" CellPadding="1" OnPageIndexChanging="GridView1_PageIndexChanging">
     <rowstyle Height="30px" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#BFE4FF" />
                    <Columns>
                        <asp:CommandField SelectText="&gt;" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="अनुक्रमांक" ItemStyle-Width="60"  DataField="account_group_id" >
<ItemStyle Width="60px"></ItemStyle>
                         </asp:BoundField>
                        <asp:BoundField HeaderText="ग्रुप" ItemStyle-Width="230"  DataField="group_name" >
<ItemStyle Width="230px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="छपाई क्रम" ItemStyle-Width="130"  DataField="print_no" >
<ItemStyle Width="130px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="मुख्य ग्रुप" ItemStyle-Width="230"  DataField="main_group_name" >
<ItemStyle Width="230px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="पोटखाती दाखवणे" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkid" runat="server"  Checked='<%#Convert.ToBoolean( Eval("RP_disp")) %>' Enabled="false"  />
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView> 
      </div>

      <br />

    <div class="form-group" style="margin-left: 50px; height: 33px;">  
              <asp:Button ID="btnnew" class="myButton" runat="server" Text="ADD" OnClick="btnnew_Click" Height="35px" />
              <asp:Button ID="btnsave" class="myButton" runat="server" Text="SAVE" OnClick="btnsave_Click" Height="37px" />
              <asp:Button ID="btnupdate" class="myButton" runat="server" Text="MODIFY" OnClick="btnupdate_Click" Height="38px" />
              
              <asp:Button ID="btndelete" class="myButton" runat="server" Text="DELETE" OnClick="btndelete_Click" Height="37px" />
              <asp:Button ID="btnexit" class="myButton" runat="server" Text="EXIT" OnClick="btnexit_Click" Height="37px" formnovalidate />

       <br />
              
    </div>
  </form>
</panel>   

<br />
        



</asp:Content>

