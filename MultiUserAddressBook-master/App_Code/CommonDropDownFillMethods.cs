using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public static class CommonFillDropDownMethods
{
    #region Fill DropDownForCountryList
    public static void FillDropDownForCountryList(DropDownList ddlCountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";

            if (HttpContext.Current.Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();

            }

            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));


            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill DropDownForCountryList

    #region Fill DropDownForStateList
    public static void FillDropDownForStateList(DropDownList ddlStateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            if (HttpContext.Current.Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();

            }

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill DropDownForStateList

    #region Fill DropDownForCityList
    public static void FillDropDownForCityList(DropDownList ddlCityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownList";

            if (HttpContext.Current.Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

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

        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill DropDownForCityList
    
}

    //#region Fill DropDownForContactCategoryList

    //public static void FillDropDownForContactCategoryList()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

    //    try
    //    {
    //        #region Set Connection and Command Object
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
    //        if (Session["UserID"] != null)
    //        {
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
    //        }
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        #endregion Set Connection and Command Object

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlContactCategoryID.DataSource = objSDR;
    //            ddlContactCategoryID.DataValueField = "ContactCategoryID";
    //            ddlContactCategoryID.DataTextField = "ContactCategoryName";
    //            ddlContactCategoryID.DataBind();

    //        }

    //        ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

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

    //#endregion Fill DropDownForContactCategoryList

    //#region Fill DropDownForStateByCountryID
    // public static void FillDropDownForStateByCountryID(DropDownList ddlStateID, SqlInt32 CountryID, DropDownList ddlCityID)
    // {
    //     SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //     SqlInt32 StrCountryID = SqlInt32.Null;

    //     try
    //     {
    //         #region Server Side Validation
    //         String StrErrorMessge = "";

    //         if (ddlCountryID.SelectedIndex == 0)
    //         {
    //             StrErrorMessge += "- Select Country  <br />";
    //             ddlStateID.Items.Clear();
    //             ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
    //             ddlCityID.Items.Clear();
    //             ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    //         }
    //         if (StrErrorMessge != "")
    //         {
    //             lblMessage.Text = StrErrorMessge;
    //             return;
    //         }
    //         #endregion Server Side Validation

    //         #region Gather Information

    //         if (ddlCountryID.SelectedIndex > 0)
    //         {
    //             StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
    //         }
    //         #endregion Gather Information

    //         #region Set Connection & Command Object
    //         if (objConn.State != ConnectionState.Open)
    //             objConn.Open();

    //         SqlCommand objCmd = objConn.CreateCommand();
    //         objCmd.CommandType = CommandType.StoredProcedure;
    //         objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
    //         if (Session["UserID"] != null)
    //         {
    //             objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
    //         }
    //         objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByCountryID]";
    //         SqlDataReader objSDR = objCmd.ExecuteReader();

    //         #endregion Set Connection & Command Object

    //         if (objSDR.HasRows == true)
    //         {
    //             ddlStateID.DataSource = objSDR;
    //             ddlStateID.DataValueField = "StateID";
    //             ddlStateID.DataTextField = "StateName";
    //             ddlStateID.DataBind();
    //         }
    //         ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));


    //         if (objConn.State == ConnectionState.Open)
    //             objConn.Close();
    //     }
    //     catch (Exception ex)
    //     {

    //     }
    //     finally
    //     {
    //         if (objConn.State == ConnectionState.Open)
    //             objConn.Close();
    //     }
    // }
    // #endregion  Fill DropDownForStateByCountryID 

    // #region Fill DropDownForCityByStateID
    // public static void FillDropDownForCityByStateID(object sender, EventArgs e)
    // {

    //     SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //     SqlInt32 StrCountryID = SqlInt32.Null;
    //     SqlInt32 StrStateID = SqlInt32.Null;

    //     try
    //     {
    //         #region Server Side Validation
    //         String StrErrorMessge = "";

    //         if (ddlStateID.SelectedIndex == 0)
    //         {
    //             StrErrorMessge += "- Select State  <br />";
    //             ddlCityID.Items.Clear();
    //             ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    //         }

    //         if (ddlStateID.SelectedIndex == 0)
    //         {
    //             StrErrorMessge += "- Select State  <br />";
    //         }
    //         if (StrErrorMessge != "")
    //         {
    //             lblMessage.Text = StrErrorMessge;
    //             return;
    //         }
    //         #endregion Server Side Validation

    //         #region Gather Information

    //         if (ddlCountryID.SelectedIndex > 0)
    //         {
    //             StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
    //         }

    //         if (ddlStateID.SelectedIndex > 0)
    //         {
    //             StrStateID = Convert.ToInt32(ddlStateID.SelectedValue);
    //         }
    //         #endregion Gather Information

    //         #region Set Connection & Command Object
    //         if (objConn.State != ConnectionState.Open)
    //             objConn.Open();

    //         SqlCommand objCmd = objConn.CreateCommand();
    //         objCmd.CommandType = CommandType.StoredProcedure;

    //         //objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
    //         objCmd.Parameters.AddWithValue("@StateID", StrStateID);

    //         if (Session["UserID"] != null)
    //         {
    //             objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
    //         }

    //         objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownListByStateID]";
    //         SqlDataReader objSDR = objCmd.ExecuteReader();

    //         #endregion Set Connection & Command Object

    //         if (objSDR.HasRows == true)
    //         {
    //             ddlCityID.DataSource = objSDR;
    //             ddlCityID.DataValueField = "CityID";
    //             ddlCityID.DataTextField = "CityName";
    //             ddlCityID.DataBind();
    //         }

    //         ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    //         if (objConn.State == ConnectionState.Open)
    //             objConn.Close();
    //     }
    //     catch (Exception ex)
    //     {
    //         lblMessage.Text = ex.Message;
    //     }
    //     finally
    //     {
    //         if (objConn.State == ConnectionState.Open)
    //             objConn.Close();
    //     }
    // }
    // #endregion Fill DropDownForCityByStateID



//#region DropDowns
///// <summary>
///// Summary description for CommonDropDownFillMethods
///// </summary>
////public  static class CommonDropDownFillMethods
////{
////    public static void FillDropDownForCountryList(DropDownList ddlCountryID, String UserID)
////    {
////        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

////        try
////        {
////            #region Set Connection and Command Object
////            if (objConn.State != ConnectionState.Open)
////                objConn.Open();

////            SqlCommand objCmd = objConn.CreateCommand();
////            objCmd.CommandType = CommandType.StoredProcedure;
////            objCmd.CommandText = "PR_Country_SelectForDropDownList";

////            if (UserID.ToString().Trim() != "")
////           {
////                objCmd.Parameters.AddWithValue("@UserID", UserID);
////           }

////            SqlDataReader objSDR = objCmd.ExecuteReader();
////            #endregion Set Connection and Command Object

////            if (objSDR.HasRows == true)
////            {
////                ddlCountryID.DataSource = objSDR;
////                ddlCountryID.DataValueField = "CountryID";
////                ddlCountryID.DataTextField = "CountryName";
////                ddlCountryID.DataBind();

////            }

////            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        catch (Exception ex)
////        {

////        }
////        finally
////        {
////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////    }

////    public static void FillDropDownForStateList(DropDownList ddlStateID, String UserID)
////    {
////        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

////        try
////        {
////            #region Set Connection and Command Object
////            if (objConn.State != ConnectionState.Open)
////                objConn.Open();

////            SqlCommand objCmd = objConn.CreateCommand();
////            objCmd.CommandType = CommandType.StoredProcedure;
////            objCmd.CommandText = "PR_State_SelectForDropDownList";

////            if (UserID.ToString().Trim() != "")
////            {
////                objCmd.Parameters.AddWithValue("@UserID", UserID);
////            }

////            SqlDataReader objSDR = objCmd.ExecuteReader();
////            #endregion Set Connection and Command Object

////            if (objSDR.HasRows == true)
////            {
////                ddlStateID.DataSource = objSDR;
////                ddlStateID.DataValueField = "StateID";
////                ddlStateID.DataTextField = "StateName";
////                ddlStateID.DataBind();

////            }

////            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        catch (Exception ex)
////        {

////        }
////        finally
////        {
////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////    }

////    public static void FillDropDownListForCity(DropDownList ddlCityID, String UserID)
////       {
////           SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
////           try
////           {
////               #region Set Connection & Command Object
////               if (objConn.State != ConnectionState.Open)
////                   objConn.Open();

////               SqlCommand objcmd = objConn.CreateCommand();
////               objcmd.CommandType = CommandType.StoredProcedure;
////               objcmd.CommandText = "PR_City_SelectForDropDownList";

////               if (UserID.ToString().Trim() != "")
////               {
////                   objcmd.Parameters.AddWithValue("@UserID", UserID);
////               }
////               SqlDataReader objSDR = objcmd.ExecuteReader();
////               #endregion Set Connection & Command Object
////               if (objSDR.HasRows == true)
////               {
////                   ddlCityID.DataSource = objSDR;
////                   ddlCityID.DataValueField = "CityID";
////                   ddlCityID.DataTextField = "CityName";
////                   ddlCityID.DataBind();
////               }
////               ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));



////               if (objConn.State == ConnectionState.Open)
////                   objConn.Close();
////           }
////           catch (Exception ex)
////           {

////           }
////           finally
////           {
////               if (objConn.State == ConnectionState.Open)
////                   objConn.Close();
////           }
////       }

////    public static void FillDropDownListForContactCategory(DropDownList ddlContactCategoryID, String UserID)
////    {
////        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
////        try
////        {
////            #region Set Connection & Command Object
////            if (objConn.State != ConnectionState.Open)
////                objConn.Open();

////            SqlCommand objcmd = objConn.CreateCommand();
////            objcmd.CommandType = CommandType.StoredProcedure;
////            objcmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

////            if (UserID.ToString().Trim() != "")
////            {
////                objcmd.Parameters.AddWithValue("@UserID", UserID);
////            }
////            SqlDataReader objSDR = objcmd.ExecuteReader();
////            #endregion Set Connection & Command Object
////            if (objSDR.HasRows == true)
////            {
////                ddlContactCategoryID.DataSource = objSDR;
////                ddlContactCategoryID.DataValueField = "ContactCategoryID";
////                ddlContactCategoryID.DataTextField = "ContactCategoryName";
////                ddlContactCategoryID.DataBind();
////            }
////            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));


////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        catch (Exception ex)
////        {

////        }
////        finally
////        {
////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////    }

////    public static void FillDropDownListForStateByCountryID(DropDownList ddlStateID,string UserID, SqlInt32 CountryID, DropDownList ddlCityID)
////    {
////        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

////        try
////        {
////            if (objConn.State != ConnectionState.Open)
////                objConn.Open();

////            SqlCommand objcmd = objConn.CreateCommand();
////            objcmd.CommandType = CommandType.StoredProcedure;
////            objcmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByCountryID]";
////            objcmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = CountryID;

////            if (UserID.ToString().Trim() != "")
////            {
////                objcmd.Parameters.AddWithValue("@UserID", UserID);
////            }


////            SqlDataReader objSDR = objcmd.ExecuteReader();
////            if (objSDR.HasRows == true)
////            {
////                ddlStateID.DataSource = objSDR;
////                ddlStateID.DataValueField = "StateID";
////                ddlStateID.DataTextField = "StateName";
////                ddlStateID.DataBind();
////            }

////            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
////            ddlCityID.Items.Clear();
////            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

////         if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        catch (Exception ex)
////        {

////        }
////        finally
////        {
////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////    }

////    public static void FillDropDownListForCityByStateID(DropDownList ddlCityID, String UserID, SqlInt32 StateID, DropDownList ddlStateID )
////    {
////        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

////        try
////        {
////            if (objConn.State != ConnectionState.Open)
////                objConn.Open();

////            SqlCommand objCmd = objConn.CreateCommand();
////            objCmd.CommandType = CommandType.StoredProcedure;
////            objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = StateID;
////            objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownListByStateID]";

////            if (UserID.ToString().Trim() != "")
////            {
////                objCmd.Parameters.AddWithValue("@UserID", UserID);
////            }

////            SqlDataReader objSDR = objCmd.ExecuteReader();
////            if (objSDR.HasRows == true)
////            {
////                ddlCityID.DataValueField = "CityID";
////                ddlCityID.DataTextField = "CityName";
////                ddlCityID.DataBind();
////                ddlCityID.DataSource = objSDR;
////            }

////            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
////            ddlCityID.Items.Clear();
////            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

////         if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        catch (Exception ex)
////        {

////        }
////        finally
////        {
////            if (objConn.State == ConnectionState.Open)
////                objConn.Close();
////        }
////        }

////}
//#endregion DropDowns