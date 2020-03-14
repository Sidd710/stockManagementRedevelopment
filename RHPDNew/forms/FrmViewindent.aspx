<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="FrmViewindent.aspx.cs" Inherits="RHPDNew.Forms.FrmViewindent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ObjectDataSource ID="objIndent" runat="server" TypeName="RHPDComponent.IndentComponent" SelectMethod="GetResultIndentdetails">

             <SelectParameters>
                                    <asp:ControlParameter ControlID="RadGrid" PropertyName="SelectedValue" Name="indetntid" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                                </SelectParameters>
      </asp:ObjectDataSource>
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="RHPDComponent.IndentComponent" SelectMethod="GetResultIndent"></asp:ObjectDataSource>
    <telerik:RadGrid runat="server" DataSourceID="ObjectDataSource1" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" >
            <MasterTableView DataKeyNames="Id" Caption="IDT List" AllowAutomaticUpdates="false" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                <CommandItemTemplate>
                    <asp:Button ID="btnExcel" runat="server" Text="Export to Excel"  CssClass="myExcelbtn" />
                </CommandItemTemplate>
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                        <ItemTemplate>
                            <div class="" style="float: left;">
                                <%#Container.DataSetIndex+1%>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                     <telerik:GridTemplateColumn HeaderText="Indent Name" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblIndentName" runat="server" Text='<%#Eval("IndentName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    
                        <telerik:GridTemplateColumn HeaderText="Depot Name" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblDepotName" runat="server" Text='<%#Eval("DepotName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Product Name" DataField="ProductName" DataType="System.String" UniqueName="ProductName" Groupable="false" Visible="false">
                        <ItemTemplate>
                            <div class="">
                                <%#Eval("ProductName").ToString()==""?"N/A":Eval("ProductName") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Category Type" DataField="CategoryType" DataType="System.String" UniqueName="CategoryType" Groupable="false" Visible="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("CategoryType").ToString()==""?"N/A":Eval("CategoryType") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                       <telerik:GridTemplateColumn HeaderText="Qty Issued" AllowFiltering="false" Visible="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblQtyIssued" runat="server" Text='<%#Eval("QtyIssued") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Unit" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblunittype" runat="server" Text='<%#Eval("UnitType").ToString()==""?"N/A":Eval("UnitType") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                       


                      <telerik:GridTemplateColumn HeaderText="Status" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblIsapproved" BackColor="YellowGreen" runat="server" Text='<%#Eval("Isapproved").ToString()=="" ?"Waiting":Eval("Isapproved") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>




                    <telerik:GridTemplateColumn HeaderText="Status" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">

                                <a class="button-green margin-top" href="frmIndentDetails.aspx?iID=<%#Eval("IndentId")%>" >View Details</a>
                            
                            </div>
                        </ItemTemplate>

                    </telerik:GridTemplateColumn>
                   

                </Columns>
            </MasterTableView>

        </telerik:RadGrid>

</asp:Content>
