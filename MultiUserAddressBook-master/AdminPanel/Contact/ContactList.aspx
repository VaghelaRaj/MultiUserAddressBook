<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2 class="text-center" style="color:darkred;">Contact List</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="#CC0000" />
        </div>
    </div>
     <div class="row" style="overflow:scroll">
        <div class="col-md-12">
            <div>
                <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/Contact/Add" BackColor="#c0c0c0"/>
            </div><br />
            <div>
                <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="False" Height="265px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" 
                                    CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' OnClientClick = "javascript : return confirm(' are you sure you want to delete your data?')"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" BackColor="#ffffff" CssClass="btn btn-info btn-sm" NavigateUrl='<%# "~/AdminPanel/Contact/Edit/" + EncodeDecode.Base64Encode(Eval("ContactID").ToString().Trim()) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                        <asp:BoundField DataField="CountryName" HeaderText="ContryName" />
                        <asp:BoundField DataField="StateName" HeaderText="StateName" />
                        <asp:BoundField DataField="CityName" HeaderText="CityName" />
                        <asp:BoundField DataField="ContactCategoryNames" HeaderText="ContactCategoryName"/>

                        <asp:BoundField DataField="ContactName" HeaderText="Contact" />
                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                        <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsApp No" />
                        <asp:BoundField DataField="BirthDate" DataFormatString="{0:dd'/'MM'/'yyyy}" HeaderText="Birth Date" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                        <asp:BoundField DataField="FacebookID" HeaderText="FacebookID" />
                        <asp:BoundField DataField="LinkedINID" HeaderText="LinkedinID" />
                        <asp:TemplateField HeaderText ="Photo" >
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgPhoto" ImageUrl= '<%# Eval("ContactPhotoPath") %> ' Height="50" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

