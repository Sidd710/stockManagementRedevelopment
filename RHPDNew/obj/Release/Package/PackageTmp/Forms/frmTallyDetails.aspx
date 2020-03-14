<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmTallyDetails.aspx.cs" Inherits="RHPDNew.Forms.frmTallyDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
      <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    
<%--         <asp:ObjectDataSource ID="objIndent" runat="server" TypeName="RHPDComponent.TallySheetComponent" SelectMethod="GetResultTallydetails"></asp:ObjectDataSource>--%>
    <telerik:RadGrid runat="server"  ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" >
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


                       <telerik:GridTemplateColumn HeaderText="IDT Name" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">

                                <asp:Label ID="lblDepotName" runat="server" Text='<%#Eval("IndentName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn HeaderText="Load Tally" DataType="System.String"  Groupable="false">
                                <ItemTemplate>
                                    <div class="">
                                       <asp:LinkButton ID="lkgenrate" runat="server" Text="Load Tally"  PostBackUrl='<%# String.Format("~/Forms/ManageTallySheets.aspx?id={0}", Eval("Id"))%>'></asp:LinkButton>
                                    </div>
                          </ItemTemplate>

                    </telerik:GridTemplateColumn>


                </Columns>
            </MasterTableView>

        </telerik:RadGrid>
    <br />

       <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="form-group-2 col-lg-4 text-align-right">   
<%--              <asp:Button ID="btnGetDetail" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Approve" OnClick="btnGetDetail_Click" Visible="true"  />--%>
<%--                         <asp:Button ID="btnReject" CssClass="btn btn-warning"  runat="server" Text="Reject" OnClick="btnReject_Click"  />--%>
                <asp:HiddenField ID="hfid" runat="server" />
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                      

    </div>
                    </div>

</asp:Content>

