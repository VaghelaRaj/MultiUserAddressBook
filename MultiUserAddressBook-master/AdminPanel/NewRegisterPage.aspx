<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewRegisterPage.aspx.cs" Inherits="AdminPanel_NewRegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Registration Page</title>

    <link href="~/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Content/JS/bootstrap.bundle.min.js"></script>

</head>
    <br />
<body>
   <form id="form" runat="server" >
        <div class="container">
            <div class="row text-center" style="background-color:lightblue;">
                <div class="col-md-12 text-center">
                    <h1>New User Register</h1>
                </div>
            </div>
            <br />
            <div class="row">
                    <div class="col-md-3">
                        User Name :&nbsp;
                       
                    </div>
                    <div class="col-md-6">
                         <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Username" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            <br />
            
            <div class="row">
                    <div class="col-md-3">
                        Display Name :&nbsp;
                        
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtDisplayName" runat="server" placeholder="Enter Display Name" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            <br />
            
            <div class="row">
                    <div class="col-md-3">
                        Password :&nbsp;
                        
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password" CssClass="form-control" Type="password"></asp:TextBox>
                    </div>
                </div>
            <br />

            <div class="row">
                    <div class="col-md-3">
                        Confirm Password :&nbsp;
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Enter Password" CssClass="form-control" Type="password" ></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                               ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                               ErrorMessage="Password does not match" ForeColor="#CC0000"></asp:CompareValidator>
                    </div>
                </div>
            <br />

            
            <div class="row">
                    <div class="col-md-3">
                        Mobile No :&nbsp;
                       
                    </div>
                    <div class="col-md-6">
                         <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Enter Mobile No" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please Enter 10 Digit Mobile No"
                            ValidationExpression="[0-9]{10}" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>
            <br />
            
            <div class="row">
                    <div class="col-md-3">
                        Email :&nbsp;
                        
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email Address" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revemailValid" runat="server" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" BackColor="White" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>
            <br />
            <div class="row text-left">
                    <div class="col-md-6">
            
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click"/>
                &nbsp;
            <asp:Button runat="server" ID="btnCancle" Text="Cancle" OnClick="btnCancle_Click" CssClass="btn btn-danger btn-sm"/>
                </div><br />
                <asp:Label runat="server" ID="lblMessaage" class="red" ForeColor="Red"></asp:Label><br />
        </div>
    </form>
</body>
</html>
