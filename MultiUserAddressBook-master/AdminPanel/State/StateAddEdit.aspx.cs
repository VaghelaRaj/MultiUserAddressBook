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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownForCountryList();

            if (Page.RouteData.Values["StateID"] != null)
            {
                lblMessage.Text = "Edit Mode | StateID = " +  EncodeDecode.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncodeDecode.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim())), (Convert.ToInt32(Request.QueryString["UserID"])));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

            //if (Page.RouteData.Values["OperationName"] != null)
            //{
            //    lblMessage.Text += Page.RouteData.Values["OperationName"].ToString().Trim();
            //}
            //if (Page.RouteData.Values["StateID"] != null)
            //{
            //    lblMessage.Text += "<br />StateID = " + Page.RouteData.Values["StateID"].ToString().Trim();
            //}
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlDateTime strCreationDate = SqlDateTime.Null;


        #endregion Local Variables

        try
        {
            #region Server Side Validation
            String strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "- Select Country <br />";

            if (txtStateName.Text.Trim() == "")
                strErrorMessage += "- Enter State Name <br />";

            if (txtStateCode.Text.Trim() == "")
                strErrorMessage += "- Enter State Code <br />";

            // if (txtCreationDate.Text.Trim() == "")
            //   strErrorMessage += "- Enter Creation Date <br />";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (txtStateName.Text.Trim() != "")
                strStateName = txtStateName.Text.Trim();


            strStateCode = txtStateCode.Text.Trim();

            // if (txtCreationDate.Text.Trim() != "")
            //   strCreationDate = txtCreationDate.Text.Trim();

            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;

            objcmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objcmd.Parameters.AddWithValue("@StateName", strStateName);
            objcmd.Parameters.AddWithValue("@StateCode", strStateCode);
            objcmd.Parameters.AddWithValue("@CreationDate", strCreationDate);

            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["StateID"] != null)
            {
                #region Update Record
                objcmd.Parameters.AddWithValue("@StateID", EncodeDecode.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim()));
                objcmd.CommandText = "[dbo].[PR_State_updateByPK]"; 
                
                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objcmd.CommandText = "[dbo].[PR_State_Insert]";

                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.ExecuteNonQuery();
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Items.Clear();
                ddlCountryID.Focus();
                lblMessage.Text = "Data Inserted Successfully";
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/List", true);
    }

    #endregion Button : Cancel

    #region Fill DropDownForCountryList
    private void FillDropDownForCountryList()
    {

        CommonFillDropDownMethods.FillDropDownForCountryList(ddlCountryID);
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    #region Set Connection and Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_Country_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #endregion Set Connection and Command Object

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountryID.DataSource = objSDR;
        //        ddlCountryID.DataValueField = "CountryID";
        //        ddlCountryID.DataTextField = "CountryName";
        //        ddlCountryID.DataBind();

        //    }

        //    ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
    }

    #endregion Fill DropDownForCountryList

    #region Fill Controls

    private void FillControls(SqlInt32 StateID, SqlInt32 UserID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variables

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();



            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectByPK]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            #endregion Set Connection & Command Object

            #region Read the values and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateName"].Equals(DBNull.Value) != true)
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["StateCode"].Equals(DBNull.Value) != true)
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the StateID = " + StateID.ToString();
            }
            #endregion Read the values and set the controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill Controls
}


