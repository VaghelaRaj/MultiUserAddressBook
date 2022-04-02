<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 style="color:darkred">City Add Edit Page</h2>
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
                    State
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-md-4">
                    City Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" placeholder="Enter City Name" />
                </div>
            </div><br />
            <div class="row">
                <div class="col-md-4">
                    STD Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control" placeholder="Enter STD Code" />
                </div>
            </div>
             <br/>
            <div class="row">
                <div class="col-md-4">
                    Pin Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" placeholder="Enter Pin Code" />
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

