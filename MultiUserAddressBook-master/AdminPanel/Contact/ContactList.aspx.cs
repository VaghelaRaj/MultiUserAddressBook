using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region FillGridView

    private void FillGridView()
    {


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserID]";
            if (Session["UserID"] != null)

                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            //if (objSDR.HasRows)
            //{
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            //}

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

    #endregion FillGridView

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record

    }

    #endregion gvContact : RowCommand

    #region Delete Contact Record

    private void DeleteContact(SqlInt32 ContactID)
    {
        DeleteImg(Convert.ToInt32(ContactID.ToString().Trim()));

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_DeleteByPK]";

            if (Session["UserID"] != null)

                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);


            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.ExecuteNonQuery();
            objConn.Close();

            FillGridView();
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

    #endregion Delete Contact Record
    
    #region DeleteImage
    private void DeleteImg(Int32 ContactID)
    {
        #region Connection Establish
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #region Try Block
        try
        {
            #region Connection
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            #region Command Object
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByPK]";
            #region Parameters
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Parameters
            #region Read the Values and set the Controls
            #region Rows
            if (objSDR.HasRows)
            {
                #region Read
                while (objSDR.Read())
                {

                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        String ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();

                        FileInfo file = new FileInfo(Server.MapPath(ContactPhotoPath));

                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    break;
                }
                #endregion Read
            }
            #endregion Rows
            #endregion Read the Values and set the Controls
            else
            {
                lblMessage.Text = "No Data available for the ContactID = " + ContactID.ToString();
            }
            #endregion Command Object
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }


            #endregion Connection
        }
        #endregion Try Block

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }


        finally
        {

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

        #endregion Connection Establish
    }
    #endregion DeleteImage
}
