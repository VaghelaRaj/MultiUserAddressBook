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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Page.RouteData.Values["OperationName"] != null)
            //{
            //    lblMessage.Text += Page.RouteData.Values["OperationName"].ToString().Trim();
            //}
            //if (Page.RouteData.Values["CountryID"] != null)
            //{
            //    lblMessage.Text += "<br />CountryID = " + Page.RouteData.Values["CountryID"].ToString().Trim();
            //}

            FillDropDownList();
            if (Page.RouteData.Values["CountryID"] != null)
            {
                lblMessage.Text = "Edit Mode | CountryID = " + EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim())) , (Convert.ToInt32(Session["UserID"])));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        SqlString strCountryID = SqlString.Null;
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlDateTime strCreationDate = SqlDateTime.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation

            String strErrorMessage = "";

            if (txtCountryName.Text.Trim() == "")
                strErrorMessage += "- Enter Country Name <br />";
            if (txtCountryCode.Text.Trim() == "")
                strErrorMessage += "- Enter Country Code <br />";
            //if (txtCreationDate.Text.Trim() == "")
            // strErrorMessage += "- Enetr Creation Date <br />";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            // if (ddlCountryID.SelectedIndex > 0)
            //   strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (txtCountryName.Text.Trim() != "")
                strCountryName = txtCountryName.Text.Trim();

            if (txtCountryCode.Text.Trim() != "")
                strCountryCode = txtCountryCode.Text.Trim();

            // if (txtCreationDate.Text.Trim() != "")
            // strCreationDate = txtCreationDate.Text.Trim();

            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;

            //objcmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objcmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objcmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            objcmd.Parameters.AddWithValue("@CreationDate", strCreationDate);

            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["CountryID"] != null)
            {
                #region Update Record
                objcmd.Parameters.AddWithValue("@CountryID", EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));
                objcmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";

                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objcmd.CommandText = "[dbo].[PR_Country_Insert]";

                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.ExecuteNonQuery();
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                //ddlCountryID.SelectedIndex = 0;
                //ddlCountryID.Focus();
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
        Response.Redirect("~/AdminPanel/Country/List", true);
    }

    #endregion Button : Cancel

    #region Fill DropDownList

    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_Country_SelectForDropDownList";


            SqlDataReader objSDR = objcmd.ExecuteReader();
            #endregion Set Connection & Command Object
            if (objSDR.HasRows == true)
            {
                //ddlCountryID.DataSource = objSDR;
                //ddlCountryID.DataValueField = "CountryID";
                //ddlCountryID.DataTextField = "CountryName";
                //ddlCountryID.DataBind();
            }
            //ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

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

    #endregion Fill DropDownList

    #region Fill Controls

    private void FillControls(SqlInt32 CountryID, SqlInt32 UserID)
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
            objCmd.CommandText = "[dbo].[PR_Country_SelectByPK]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            //objCmd.Parameters.AddWithValue("@CountryCode", CountryCode.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the values and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryName"].Equals(DBNull.Value) != true)
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        //ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["CountryCode"].Equals(DBNull.Value) != true)
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    //if (objSDR["CreationDate"].Equals(DBNull.Value) != true)
                    //{
                    //    txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    //}
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
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
