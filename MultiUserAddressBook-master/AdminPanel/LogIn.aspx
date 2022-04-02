<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href  ="~/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Content/JS/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class ="row">
             <div class="col-md-12 "> 
                        <p style="text-align:left">             
                        <asp:Image ID="imglogo" runat ="server" ImageUrl="https://www.darshan.ac.in/Content/media/DU-logo.svg" />
                        </p>
                     </div>
            <hr style="border-top:1px solid black"/>
            <div class =" col-md-12">
                <h1 style="color:darkblue ; text-align:center">Existing User Login to AddressBook</h1>
                <hr style="border-top:1px solid black"/>
            </div>
        </div> <br /><br />
         <div class ="row">
            <div class =" col-md-12">
                <asp:Label ID="lblmessage" runat="server" EnableViewState="False" ForeColor="#CC0000"></asp:Label>
            </div>
        </div> <br /><br />
        <div class="row">
            <div class="col-md-2">
                User Name
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter User Name">
                </asp:TextBox>
            </div>
        </div><br />
         <div class="row">
            <div class="col-md-2">
                Password
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtPassword" runat="server" Type="password" placeholder="Enter Password">
                </asp:TextBox>
            </div>
        </div><br />
        <div class="col-md-2">
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="btn btn btn-success btn-sm" />
            </div><br />
         <div class="col-md-2">
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnNewUser" runat="server" Text="Sign Up"  CssClass="btn btn btn-primary btn-sm" OnClick="btnNewUser_Click" />
            </div>
        </div>
    </form>
</body>
</html>
