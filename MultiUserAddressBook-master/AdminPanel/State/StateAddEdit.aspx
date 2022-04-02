<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 style="color:darkred">State Add Edit Page</h2>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" ForeColor="#009933" />
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    Country Name
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-md-4">
                    State Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"  placeholder="Enter State Name"/>
                </div>
            </div><br />
            <div class="row">
                <div class="col-md-4">
                    State Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control" placeholder="Enter State Code" />
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

