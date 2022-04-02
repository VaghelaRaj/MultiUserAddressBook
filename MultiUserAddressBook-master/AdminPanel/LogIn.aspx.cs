using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        #region Local Variables

        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation
        String strErrorMessege = "";

        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessege += " Enter User Name <br/>";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessege += " Enter Password <br/>";
        }

        if (strErrorMessege != "")
        {
            lblmessage.Text = "Kindly solve followimg Error(s) <br />" + strErrorMessege;
            return;
        }
        #endregion Server Side Validation

        #region Assign Value

        if (txtUserName.Text.Trim() != "")
            strUserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        #endregion Assign Value

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressbookConnectionString"].ConnectionString.Trim());
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_User_SelectByUserNamePassword]";

            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                lblmessage.Text = "Valid User";

                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx", true);
            }
            else
            {
                lblmessage.Text = "Either Username or Password is not Valid, Try Again....";
            }
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {

        }
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/NewRegisterPage.aspx");
    }
}