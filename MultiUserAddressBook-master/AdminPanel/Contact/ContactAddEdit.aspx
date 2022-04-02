<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
   <div class="row">
        <div class="col-md-12">
            <h2 style="color:darkred;">Contact Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="#009933"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
             <div class="row">
                <div class="col-md-4">
                    Country
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select"  AutoPostBack="true" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList><br />
                    <div class="Col-md-4">
                       <h5>ContactCategory</h5>
                        <asp:CheckBoxList ID="cblContactCategoryID" runat="server"></asp:CheckBoxList>

                    </div><br />
                </div>
            </div>
           
            <div class="row">
                <div class="col-md-4">
                    State
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-select"  AutoPostBack="true" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <br />
             <div class="row">
                <div class="col-md-4">
                    City
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <br />
           <%--  <div class="row">
                <div class="col-md-4">
                    ContactCategory
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-select"></asp:DropDownList>
                </div>
            </div><br />--%>
            <div class="row">
                <div class="col-md-4">
                    Contact Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter Contact Name" ID="txtContactName" CssClass="form-control"/>
                </div>
            </div>
             <br/>
            
            <div class="row">
                <div class="col-md-4">
                    Contact No
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter Contact No" ID="txtContactNo" CssClass="form-control" />
                    <asp:RegularExpressionValidator ID="REVMobileNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please Enter 10 Digit Mobile No"
                            ValidationExpression="[0-9]{10}" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    WhatsAppNo
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter WhatsAppNo" ID="txtWhatsAppNo" CssClass="form-control"/>
                     <asp:RegularExpressionValidator ID="REVWhatsappNo" runat="server" ControlToValidate="txtWhatsAppNo" ErrorMessage="Please Enter 10 Digit Mobile No"
                            ValidationExpression="[0-9]{10}" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    BirthDate
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date" CssClass="form-control" />
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    Email
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter Email" ID="txtEmail" CssClass="form-control"/>
                    <asp:RegularExpressionValidator ID="revemailValid" runat="server" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" BackColor="White" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>
             <br />
            <div class="row">
                <div class="col-md-4">
                    Age
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter Age" ID="txtAge" CssClass="form-control"/>
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    Address
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter Address" ID="txtAddress" CssClass="form-control"  />
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    BloodGroup
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter BloodGroup" ID="txtBloodGroup" CssClass="form-control"/>
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    FacebookID
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter FacebookID" ID="txtFacebookID" CssClass="form-control"  />
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    LinkedINID
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" placeholder="Enter LinkedINID" ID="txtLinkedINID" CssClass="form-control" />
                </div>
            </div>
            <br/> 
              <div class="row">
                <div class="col-md-4">
                    Upload Photo
                </div>
                <div class="col-md-8">
                    <asp:FileUpload ID="fuContactPhotopath" runat="server" /><br />
                    <asp:Image ID="Image1" runat="server"  Height="50"/>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>

