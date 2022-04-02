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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactCategoryID = " + EncodeDecode.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncodeDecode.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim())), (Convert.ToInt32(Request.QueryString["UserID"])));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

            //if (Page.RouteData.Values["OperationName"] != null)
            //{
            //    lblMessage.Text += Page.RouteData.Values["OperationName"].ToString().Trim();
            //}
            //if (Page.RouteData.Values["ContactCategoryID"] != null)
            //{
            //    lblMessage.Text += "<br />ContactCategoryID = " + Page.RouteData.Values["ContactCategoryID"].ToString().Trim();
            //}
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        SqlString strContactCategoryID = SqlString.Null;
        SqlString strContactCategoryName = SqlString.Null;
       
        #endregion Local Variables

        try
        {
            #region Server Side Validation 

        String strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage += "- Enter ContactCategory Name <br />";
        //if (txtCreationDate.Text.Trim() == "")
          //  strErrorMessage += "- Enetr Creation Date <br />";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
            #endregion Server Side Validation

            #region Gather Information 

        //if (ddlContactCategoryID.SelectedIndex > 0)
          //  strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

        if (txtContactCategoryName.Text.Trim() != "")
            strContactCategoryName = txtContactCategoryName.Text.Trim();

        // if (txtCreationDate.Text.Trim() != "")
        //   strCreationDate = txtCreationDate.Text.Trim();

            #endregion Gather Information

        #region Set Connection & Command Object
        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objcmd = objConn.CreateCommand();
        objcmd.CommandType = CommandType.StoredProcedure;

        //objcmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
        objcmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
       

        #endregion Set Connection & Command Object

        if (Page.RouteData.Values["ContactCategoryID"] != null)
        {
            #region Update Record
            objcmd.Parameters.AddWithValue("@ContactCategoryID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
            objcmd.CommandText = "[dbo].[PR_ContactCategory_updateByPK]";

            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objcmd.ExecuteNonQuery();
            Response.Redirect("~/AdminPanel/ContactCategory/List", true);
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            objcmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objcmd.ExecuteNonQuery();
            txtContactCategoryName.Text = "";
            //ddlContactCategoryID.SelectedIndex = 0;
            //ddlContactCategoryID.Focus();
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
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
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

            //if (Session["UserID"] != null)
            //{
            //    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            //}

            objcmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
            SqlDataReader objSDR = objcmd.ExecuteReader();
            #endregion Set Connection & Command Object
            if (objSDR.HasRows == true)
            {
                //ddlContactCategoryID.DataSource = objSDR;
                //ddlContactCategoryID.DataValueField = "ContactCategoryID";
                //ddlContactCategoryID.DataTextField = "ContactCategoryName";
                //ddlContactCategoryID.DataBind();
            }
            //ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));


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

    private void FillControls(SqlInt32 ContactCategoryID, SqlInt32 UserID)
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
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectByPK]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());

            #endregion Set Connection & Command Object

            #region Read the values and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactCategoryName"].Equals(DBNull.Value) != true)
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {
                        //ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactCategoryID = " + ContactCategoryID.ToString();
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

       
