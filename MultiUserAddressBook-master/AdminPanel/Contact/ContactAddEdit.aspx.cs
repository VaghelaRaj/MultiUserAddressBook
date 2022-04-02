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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            FillDropDownListForCountry();
            FillCBLContactCategoryID();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            //FillDropDownListForContactCategory();
            if (Page.RouteData.Values["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID = " + EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim())));
                FillDropDownListForState();
                FillDropDownListForCity();
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
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        //SqlInt32 strUserID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime dtBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedINID = SqlString.Null;
        SqlString strContactPhtotoPath = SqlString.Null;

        #endregion Local Variables

        try


        {
            #region Server Side Validation


            String strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "- Select Country <br />";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += "- Select State <br />";

            if (ddlCityID.SelectedIndex == 0)
                strErrorMessage += "- Select City <br />";

            //if (ddlUserID.SelectedIndex == 0)
            //    strErrorMessage += "- Select User <br />";

            //if (cblContactCategoryID.SelectedIndex == 0)
            //    strErrorMessage += "- Select ContactCategory <br />";

            if (txtContactName.Text.Trim() == "")
                strErrorMessage += "- Enter Contact Name <br />";

            if (txtContactNo.Text.Trim() == "")
                strErrorMessage += "- Enter Contact No <br />";

            if (txtWhatsAppNo.Text.Trim() == "")
                strErrorMessage += "- Enter WhatsApp No <br />";

            if (txtBirthDate.Text.Trim() == "")
                strErrorMessage += "- Enter Birth Date <br />";

            if (txtEmail.Text.Trim() == "")
                strErrorMessage += "- Enter Email <br />";

            if (txtAge.Text.Trim() == "")
                strErrorMessage += "- enter age <br />";

            if (txtAddress.Text.Trim() == "")
                strErrorMessage += "- Enter Address <br />";

            if (txtBloodGroup.Text.Trim() == "")
                strErrorMessage += "- Enter Blood Group <br />";

            if (txtFacebookID.Text.Trim() == "")
                strErrorMessage += "- Enter Facebook <br />";

            if (txtLinkedINID.Text.Trim() == "")
                strErrorMessage += "- Enter LinkedIN <br />";

            if (!fuContactPhotopath.HasFile)
                strErrorMessage += "Upload Photo <br />";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region ContactPhotoPath
            String ContactPhotoPath = "";
            if (fuContactPhotopath.HasFile)
            {
                ContactPhotoPath = "~/UserContent/" + fuContactPhotopath.FileName.ToString().Trim();
                //ContactPhotoPath = "~/UserContent/" + DateTime.Now.ToString("ddMMyyyyhhmmssffftt") + ".";
                fuContactPhotopath.SaveAs(Server.MapPath(ContactPhotoPath));
            }
            #endregion ContactPhotoPath

            #region Gather Information
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (ddlCityID.SelectedIndex > 0)
                strCityID = Convert.ToInt32(ddlCityID.SelectedValue);

            //if (cblContactCategoryID.SelectedIndex > 0)
            //    strContactCategoryID = Convert.ToInt32(cblContactCategoryID.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();

            if (txtContactNo.Text.Trim() != "")
                strContactNo = txtContactNo.Text.Trim();

            if (txtWhatsAppNo.Text.Trim() != "")
                strWhatsAppNo = txtWhatsAppNo.Text.Trim();

            if (txtBirthDate.Text.Trim() != "")
                dtBirthDate = DateTime.Parse(txtBirthDate.Text);

            if (txtEmail.Text.Trim() != "")
                strEmail = txtEmail.Text.Trim();

            if (txtAge.Text.Trim() != "")
                strAge = txtAge.Text.Trim();

            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();

            if (txtBloodGroup.Text.Trim() != "")
                strBloodGroup = txtBloodGroup.Text.Trim();

            if (txtFacebookID.Text.Trim() != "")
                strFacebookID = txtFacebookID.Text.Trim();

            if (txtLinkedINID.Text.Trim() != "")
                strLinkedINID = txtLinkedINID.Text.Trim();

            if (ContactPhotoPath != "")
                strContactPhtotoPath = ContactPhotoPath;

            #endregion Gather Information

            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            //objcmd.CommandText = "[dbo].[PR_Contact_Insert]";

            //objcmd.Parameters.AddWithValue("@ContactName", txtContactName.Text.Trim());
            //objcmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);

            //objcmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;



           
            //objcmd.Parameters["@ContactID"].Direction = ParameterDirection.Output;
            objcmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objcmd.Parameters.AddWithValue("@StateID", strStateID);
            objcmd.Parameters.AddWithValue("@CityID", strCityID);
            //objcmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objcmd.Parameters.AddWithValue("@ContactName", strContactName);
            objcmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objcmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objcmd.Parameters.AddWithValue("@BirthDate", dtBirthDate);
            objcmd.Parameters.AddWithValue("@Email", strEmail);
            objcmd.Parameters.AddWithValue("@Age", strAge);
            objcmd.Parameters.AddWithValue("@Address", strAddress);
            objcmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objcmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objcmd.Parameters.AddWithValue("@LinkedINID", strLinkedINID);
            objcmd.Parameters.AddWithValue("@ContactPhotoPath", strContactPhtotoPath);

            #endregion Set Connection & Command Object

                if (Page.RouteData.Values["ContactID"] != null)
            {
                SqlCommand objcmdContactCategory = objConn.CreateCommand();
                objcmdContactCategory.CommandType = CommandType.StoredProcedure;
                objcmdContactCategory.CommandText = "[dbo].[PR_ContactWiseContactCategory_DeletByUserID]";
                objcmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objcmdContactCategory.Parameters.AddWithValue("@ContactID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objcmdContactCategory.ExecuteNonQuery();

                #region Update Record
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objcmd.Parameters.AddWithValue("@ContactID",  EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objcmd.CommandText = "[dbo].[PR_Contact_updateByPK]";

                objcmd.ExecuteNonQuery();

                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objcmd.Parameters["@ContactID"].Value);

                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objcmdContactCategoryDelete = objConn.CreateCommand();
                        objcmdContactCategoryDelete.CommandType = CommandType.StoredProcedure;
                        objcmdContactCategoryDelete.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";

                        if (Session["UserID"] != null)
                            objcmdContactCategoryDelete.Parameters.AddWithValue("@UserID", Session["UserID"]);

                        objcmdContactCategoryDelete.Parameters.AddWithValue("@ContactID", ContactID);
                        objcmdContactCategoryDelete.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objcmdContactCategoryDelete.ExecuteNonQuery();
                    }
                }
                Response.Redirect("~/AdminPanel/Contact/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objcmd.CommandText = "[dbo].[PR_Contact_Insert]";
                 //objcmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());

                if (Session["UserID"] != null)
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                objcmd.Parameters.Add("ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                objcmd.ExecuteNonQuery();

                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objcmd.Parameters["ContactID"].Value);



                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objcmdContactCategory = objConn.CreateCommand();
                        objcmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objcmdContactCategory.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";

                        if (Session["UserID"] != null)
                            objcmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);

                        objcmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                        objcmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());

                        objcmdContactCategory.ExecuteNonQuery();
                    }
                }


                //objcmd.ExecuteNonQuery();
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsAppNo.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFacebookID.Text = "";
                txtLinkedINID.Text = "";
                cblContactCategoryID.SelectedIndex = 0;
                cblContactCategoryID.Items.Clear();
                ddlStateID.SelectedIndex = 0;
                //ddlStateID.Focus();
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                ddlCityID.SelectedIndex = 0;
                //ddlCityID.Focus();
                ////cblContactCategoryID.Focus();
                lblMessage.Text = "Data Inserted Successfully with ContactID = " + ContactID.ToString();
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

    #region FillCBLContactCategoryID
    private void FillCBLContactCategoryID()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownList]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                cblContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactCategoryID.DataSource = objSDR;
                cblContactCategoryID.DataBind();
            }

            objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();

        }
    }
    #endregion FillCBLContactCategoryID()

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }

    #endregion Button : Cancel

    #region Fill DropDownListForState

    private void FillDropDownListForState()
    {
        
        CommonFillDropDownMethods.FillDropDownForStateList(ddlStateID);
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MutliUserAddressBookConnectionString"].ConnectionString.Trim());
        //try
        //{
        //    #region Set Connection & Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objcmd = objConn.CreateCommand();
        //    objcmd.CommandType = CommandType.StoredProcedure;
        //    objcmd.CommandText = "PR_State_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objcmd.ExecuteReader();
        //    #endregion Set Connection & Command Object
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
    #endregion Fill DropDownListForState

    #region Fill DropDownListForCity
    private void FillDropDownListForCity()
    {
        CommonFillDropDownMethods.FillDropDownForCityList(ddlCityID);

        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MutliUserAddressBookConnectionString"].ConnectionString.Trim());
        //try
        //{
        //    #region Set Connection & Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objcmd = objConn.CreateCommand();
        //    objcmd.CommandType = CommandType.StoredProcedure;
        //    objcmd.CommandText = "PR_City_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objcmd.ExecuteReader();
        //    #endregion Set Connection & Command Object
        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCityID.DataSource = objSDR;
        //        ddlCityID.DataValueField = "CityID";
        //        ddlCityID.DataTextField = "CityName";
        //        ddlCityID.DataBind();
        //    }
        //    ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));


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
    #endregion Fill DropDownListForCity

    #region Fill DropDownListForCountry
    private void FillDropDownListForCountry()
    {
        CommonFillDropDownMethods.FillDropDownForCountryList(ddlCountryID);

        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MutliUserAddressBookConnectionString"].ConnectionString.Trim());
        //try
        //{
        //    #region Set Connection & Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objcmd = objConn.CreateCommand();
        //    objcmd.CommandType = CommandType.StoredProcedure;
        //    objcmd.CommandText = "PR_Country_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objcmd.ExecuteReader();
        //    #endregion Set Connection & Command Object
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
    #endregion Fill DropDownListForCountry

    #region Fill DropDownListForContactCategory
    //private void FillDropDownListForContactCategory()
    //{

    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MutliUserAddressBookConnectionString"].ConnectionString.Trim());
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objcmd = objConn.CreateCommand();
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objcmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
    //        if (Session["UserID"] != null)
    //            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //        SqlDataReader objSDR = objcmd.ExecuteReader();
    //        #endregion Set Connection & Command Object
    //        if (objSDR.HasRows == true)
    //        {
    //            cblContactCategoryID.DataSource = objSDR;
    //            cblContactCategoryID.DataValueField = "ContactCategoryID";
    //            cblContactCategoryID.DataTextField = "ContactCategoryName";
    //            cblContactCategoryID.DataBind();
    //        }
    //        cblContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));


    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
    #endregion Fill DropDownListForContactCategory

    #region Fill DropDownForStateByCountryID
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 StrCountryID = SqlInt32.Null;

        try
        {
            #region Server Side Validation
            String StrErrorMessge = "";

            if (ddlCountryID.SelectedIndex == 0)
            {
                StrErrorMessge += "- Select Country  <br />";
                ddlStateID.Items.Clear();
                ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            }
            if (StrErrorMessge != "")
            {
                lblMessage.Text = StrErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByCountryID]";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));


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
    #endregion  Fill DropDownForStateByCountryID

    #region Fill DropDownForCityByStateID
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 StrCountryID = SqlInt32.Null;
        SqlInt32 StrStateID = SqlInt32.Null;

        try
        {
            #region Server Side Validation
            String StrErrorMessge = "";

            if (ddlStateID.SelectedIndex == 0)
            {
                StrErrorMessge += "- Select State  <br />";
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            }

            if (ddlStateID.SelectedIndex == 0)
            {
                StrErrorMessge += "- Select State  <br />";
            }
            if (StrErrorMessge != "")
            {
                lblMessage.Text = StrErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }

            if (ddlStateID.SelectedIndex > 0)
            {
                StrStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            //objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            objCmd.Parameters.AddWithValue("@StateID", StrStateID);

            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }

            objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownListByStateID]";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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
    #endregion Fill DropDownForCityByStateID

   
    #region Fill Controls

    private void FillControls(SqlInt32 ContactID)
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
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByPK]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            #endregion Set Connection & Command Object

             #region Read the values and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            SqlCommand objCmdContactCategory = objConn.CreateCommand();
            objCmdContactCategory.CommandType = CommandType.StoredProcedure;
            objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_SelectByPKUserID";
            if (Session["UserID"] != null)
            {
                objCmdContactCategory.Parameters.AddWithValue("UserId", Session["UserId"].ToString().Trim());
            }
            objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDRContactCategory = objCmdContactCategory.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    //if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    //{
                    //    cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    //}
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (objSDR["ContactNo"].Equals(DBNull.Value) != true)
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }

                    if (objSDR["WhatsAppNo"].Equals(DBNull.Value) != true)
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (objSDR["BirthDate"].Equals(DBNull.Value) != true)
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"]).ToString("yyyy-MM-dd");
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (objSDR["Age"].Equals(DBNull.Value) != true)
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (objSDR["BloodGroup"].Equals(DBNull.Value) != true)
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (objSDR["FacebookID"].Equals(DBNull.Value) != true)
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (objSDR["LinkedINID"].Equals(DBNull.Value) != true)
                    {
                        txtLinkedINID.Text = objSDR["LinkedINID"].ToString().Trim();
                    }
                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        Image1.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactID = " + ContactID.ToString();
            }

            if (objSDRContactCategory.HasRows)
            {
                while (objSDRContactCategory.Read())
                {
                    if (!objSDRContactCategory["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        foreach (ListItem liContactCategory in cblContactCategoryID.Items)
                        {
                            if (liContactCategory.Value == objSDRContactCategory["ContactCategoryID"].ToString())
                            {
                                liContactCategory.Selected = true;
                            }
                        }
                    }
                }
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

    public string UserID { get; set; }
}