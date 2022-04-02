 <%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="text-center" style="color:darkred;">State List</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="#CC0000" />
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <div>
                <asp:HyperLink runat="server" ID="hlAddState" Text="Add New State" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/State/Add" BackColor="#c0c0c0"/>
            </div><br />
            <div>
                <asp:GridView ID="gvState" runat="server" OnRowCommand="gvState_RowCommand" AutoGenerateColumns="False" Width="590px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" 
                                CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' OnClientClick = "javascript : return confirm(' are you sure you want to delete your data?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" BackColor="#ffffff" Text="Edit" CssClass="btn btn-info btn-sm" NavigateUrl='<%# "~/AdminPanel/State/Edit/" + EncodeDecode.Base64Encode(Eval("StateID").ToString().Trim()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StateID" HeaderText="State ID" />
                    <asp:BoundField DataField="CountryID" HeaderText="CountryID" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                  
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

