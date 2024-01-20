using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
namespace RADSampleASP
{
    public partial class UserFrom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) LoadTable();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if (usrIDTxtBx.Text != string.Empty && usrNmTxtBx.Text != string.Empty)
            {
                if (saveBtn.Text == "Save")
                {
                    try
                    {
                        int res = new Users().AddUser(Convert.ToInt32(usrIDTxtBx.Text), usrNmTxtBx.Text);
                        if (res>0)
                        {
                           Response.Write("<div class=\"response-message\">User Saved Successfully.</div>");
                            LoadTable();
                            usrIDTxtBx.Text = string.Empty;
                            usrNmTxtBx.Text = string.Empty;
                        }
                        else if(res==-1)
                        { Response.Write("<div class=\"response-message lightcoral\">Save Was Not Successful ID Is Already Used. Please Use A Different ID.</div>"); }
                    }
                    catch { Response.Write("<div class=\"response-message lightcoral\">Possible Wrong Input For ID.</div>"); }
                    //else ShowAlert("Something Went Wrong. Try Again");
                }
                else if (saveBtn.Text == "Update")
                {
                    int res = new Users().UpdateUser(Convert.ToInt32(usrIDTxtBx.Text), usrNmTxtBx.Text);
                    if (res > 0)
                    {
                        usrIDTxtBx.Text = string.Empty;
                        usrNmTxtBx.Text = string.Empty;
                        LoadTable();
                        Response.Write("<div class=\"response-message\">User Updated Successfully.</div>");
                        saveBtn.Text = "Save";
                    }
                    else if (res == -1)
                    { Response.Write("<div class=\"response-message lightcoral\">Update Was Not Successful because of Issues with database.</div>"); }
                }
                usrIDTxtBx.Enabled = true;
            }
            else Response.Write("<div class=\"response-message lightcoral\">Both User ID and User Name have to be provided.</div>");
            //else ShowAlert("Both User ID and User Name have to be provided.");
        }

        protected void userGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            WebControl wc = e.CommandSource as WebControl;
            GridViewRow row = wc.NamingContainer as GridViewRow;
            if (e.CommandName == "updateCmd")
            {
                usrIDTxtBx.Text = row.Cells[0].Text;
                usrIDTxtBx.Enabled = false;
                usrNmTxtBx.Text = row.Cells[1].Text;
                saveBtn.Text = "Update";
            }
            else if (e.CommandName == "deleteCmd")
            {
                if (delCon.Value == "Ok")
                {
                    if (new Users().DeleteUser(Convert.ToInt32(row.Cells[0].Text)) > 0)
                    {
                        Response.Write("<div class=\"response-message\">User Deleted Successfully.</div>");
                        usrIDTxtBx.Text = string.Empty;
                        usrNmTxtBx.Text = string.Empty;
                        usrIDTxtBx.Enabled = true;
                        saveBtn.Text = "Save";
                        LoadTable();
                    }
                }
            }
        }

        //Methods
        private void LoadTable()
        {
            userGridView.DataSource = new Users().ViewAllUser();
            userGridView.DataBind();
        }
        private void ShowAlert(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", $"alert('{message}');", true);
        }
    }
}