using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["DisplayName"] != null)
                lblUserName.Text = "<h1 style=text-align:center; color:red;> WelCome to MultiuserAddressBook " + Session["DisplayName"] + "</h1>";
        }
    }
 }