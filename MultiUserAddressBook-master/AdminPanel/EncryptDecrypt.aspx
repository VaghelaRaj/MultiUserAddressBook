<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncryptDecrypt.aspx.cs" Inherits="AdminPanel_Encrypt_Decrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href  ="~/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Content/JS/bootstrap.bundle.min.js"></script>
</head><br />
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtencrypt" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnencrypt" runat="server" Text="Encrypt" OnClick="btnencrypt_Click" CssClass="btn btn btn-primary btn-sm" /><br />
        <asp:Label ID="lblencrypt" runat="server" ForeColor="#003399"></asp:Label>

        <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />

         <asp:TextBox ID="txtdecrypt" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btndecrypt" runat="server" Text="Decrypt" OnClick="btndecrypt_Click" CssClass="btn btn btn-success btn-sm" /><br />
        <asp:Label ID="lbldecrypt" runat="server" ForeColor="#003399"></asp:Label><br /><br />
        <asp:Label ID="lblmessage" runat="server"></asp:Label>
    </form>
</body>
</html>
