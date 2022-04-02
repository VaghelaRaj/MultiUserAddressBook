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

public partial class AdminPanel_NewRegisterPage : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        insertData();
    }

    private void insertData()
    {
        #region Varible | Conn string
        SqlString strUserName = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string


        #region Assigne Value 
        if (txtUsername.Text.Trim() != "")
            strUserName = txtUsername.Text.Trim();
        if (txtDisplayName.Text.Trim() != "")
            strDisplayName = txtDisplayName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        if (txtMobileNo.Text.Trim() != "")
            strMobileNo = txtMobileNo.Text.Trim();
        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";
            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            #endregion SQL Command

            #region Execute | Close
            objCmd.ExecuteNonQuery();

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            lblMessaage.Text = "User Registered";
            Response.Redirect("~/AdminPanel/Login.aspx");
            #endregion Execute | Close
        }

        catch (Exception ex)
        {
            lblMessaage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }

        #endregion Try | Catch | Finally


    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
}