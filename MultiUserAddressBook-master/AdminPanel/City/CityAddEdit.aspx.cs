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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownForStateList();
            if (Page.RouteData.Values["CityID"] != null)
            {
                lblMessage.Text = "Edit Mode | CityID = " + EncodeDecode.Base64Decode(Page.RouteData.Values["CityID"].ToString());
                FillControls(Convert.ToInt32(EncodeDecode.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim())), (Convert.ToInt32(Request.QueryString["UserID"])));
                   
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

            //if (Page.RouteData.Values["operationname"] != null)
            //{
            //    lblMessage.Text += Page.RouteData.Values["operationname"].ToString().Trim();
            //}
            //if (Page.RouteData.Values["cityid"] != null)
            //{
            //    lblMessage.Text += "<br />cityid = " + Page.RouteData.Values["cityid"].ToString().Trim();
            //}
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;

        #endregion Local Variables


        try
        {
            #region Server Side Validation

            String strErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += "- Select State <br />";

            if (txtCityName.Text.Trim() == "")
                strErrorMessage += "- Enter City Name <br />";

            if (txtSTDCode.Text.Trim() == "")
                strErrorMessage += "- Enter STD Code <br />";

            if (txtPinCode.Text.Trim() == "")
                strErrorMessage += "- Enter Pin Code <br />";

            // if (txtCreationDate.Text.Trim() == "")
            //     strErrorMessage += "- Enter Creation Date <br />";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();

            if (txtSTDCode.Text.Trim() != "")
                strSTDCode = txtSTDCode.Text.Trim();

            if (txtPinCode.Text.Trim() != "")
                strPinCode = txtPinCode.Text.Trim();

            // if (txtCreationDate.Text.Trim() != "")
            //  strCreationDate = txtCreationDate.Text.Trim();
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.Parameters.AddWithValue("@StateID", strStateID);
            objcmd.Parameters.AddWithValue("@CityName", strCityName);
            objcmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objcmd.Parameters.AddWithValue("@PinCode", strPinCode);

            #endregion Set Connection & Command Object
            if (Page.RouteData.Values["CityID"] != null)
            {
                #region Update Record
                objcmd.Parameters.AddWithValue("@CityID", EncodeDecode.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim()));
                objcmd.CommandText = "[dbo].[PR_City_updateByPK]";

                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objcmd.CommandText = "[dbo].[PR_City_Insert]";
                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objcmd.ExecuteNonQuery();
                txtCityName.Text = "";
                txtPinCode.Text = "";
                txtSTDCode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Items.Clear();
                ddlStateID.Focus();
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
        Response.Redirect("~/AdminPanel/City/List", true);
    }

    #endregion Button : Cancel

    #region Fill DropDownForStateList
    private void FillDropDownForStateList()

    {


        CommonFillDropDownMethods.FillDropDownForStateList(ddlStateID);
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    #region Set Connection and Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
        //    objCmd.CommandText = "PR_State_SelectForDropDownList";
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #endregion Set Connection and Command Object

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlStateID.DataSource = objSDR;
        //        ddlStateID.DataValueField = "StateID";
        //        ddlStateID.DataTextField = "StateName";
        //        ddlStateID.DataBind();

        //    }

        //    ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

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

    #endregion Fill DropDownForStateList

    #region Fill Controls

    private void FillControls(SqlInt32 CityID, SqlInt32 UserID)
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
            objCmd.CommandText = "[dbo].[PR_City_SelectByPK]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the values and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CityName"].Equals(DBNull.Value) != true)
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (objSDR["PinCode"].Equals(DBNull.Value) != true)
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CityID = " + CityID.ToString();
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
