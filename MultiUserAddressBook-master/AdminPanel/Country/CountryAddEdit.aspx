<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2 style="color:darkred">Country Add Edit Page</h2>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="#009933" />
        </div>
    </div>
    <br/> 
    <div class="row">
        <div class="col-md-4">
            Country Name
        </div>
         <div class="col-md-8">
             <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control" placeholder="Enter Country Name" />
        </div>
    </div>
     <br/> 
    <div class="row">
        <div class="col-md-4">
            Country Code
        </div>
         <div class="col-md-8">
             <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control" placeholder="Enter Country Code" /><br />
        </div>
    </div>
     <div class="row">
         <div class="col-md-4"></div>
         <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
        </div>
    </div>


</asp:Content>

