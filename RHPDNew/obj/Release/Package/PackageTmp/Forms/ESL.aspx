<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="ESL.aspx.cs" Inherits="RHPDNew.Forms.ESL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="container">
            <div class="row pageHeading">
                <h1>ESL</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid form-outer">
        <div class="container">
            <div class="fright depotCode">
                Code#
                <b><asp:Label ID="lblCode" runat="server"></asp:Label></b>
            </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="clear"></div>
        <div class="container forming_texting">
            <div class="row">
                <div class="col-md-12">
            <%--<div class="container">


                 <div class="row">
                    <div class="form-group-2">
                    
                            <asp:ValidationSummary id="valSum" ValidationGroup="grp"
                             DisplayMode="SingleParagraph"
                             EnableClientScript="true"
                             HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                             runat="server"/>
          </div>
                      </div>
                    </div>--%>
             <%--<div class="row">
                    <div class="form-group-2">
                        <div class="form-group-2 col-lg-6 text-align-right">   
                             Click on Submit to See ESL Last 6 Month Wise
                        </div>
                    </div>
               </div>--%>

             <%-- <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="form-group-2 col-lg-4 text-align-right">   
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit"  OnClick="btnSubmit_Click"  />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false"  /><br /> 
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                      </div>
              </div>--%>

          <%--    <asp:ObjectDataSource ID="objDepu" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="getEslData" ></asp:ObjectDataSource>--%>
                <telerik:RadGrid runat="server" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20"  OnItemDataBound="RadGrid_ItemDataBound" OnPageIndexChanged="RadGrid_PageIndexChanged"  OnNeedDataSource="RadGrid_NeedDataSource">
                    <MasterTableView DataKeyNames="BID" Caption="ESL Register"   AllowAutomaticUpdates="false"   CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8"  >
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                     <CommandItemTemplate>
                          <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                                <ItemTemplate>
                                    <div class="" style="float:left;">
                                        <%#Container.DataSetIndex+1%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                       <%-- develope by Rajbir--%>
                               <telerik:GridTemplateColumn HeaderText="Product Name" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                       <asp:Label id="lblPname" runat="server" Text=' <%#Eval("ProductName").ToString()==""?"N/A":Eval("ProductName") %>'></asp:Label>
                                   </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
  <%-- End here--%>
                            <telerik:GridTemplateColumn HeaderText="Date Of Reciept" DataField="AddedOn" DataType="System.String" UniqueName="AddedOn" Groupable="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("ReceivedDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("ReceivedDate")).ToString("dd MM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="CRV Number" DataField="CrvNo" DataType="System.String"  Groupable="false">
                                <ItemTemplate>
                                    <div style="text-transform:capitalize;">
                                        <%#Eval("CrvNo").ToString()==""?"N/A":Eval("CrvNo") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Received From" DataField="ReceivedFrom" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("ReceivedFrom").ToString()==""?"N/A":Eval("ReceivedFrom") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Supplier Name" DataField="Supplier" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("Supplier").ToString()==""?"N/A":Eval("Supplier") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                          
                              <telerik:GridTemplateColumn HeaderText="At No" DataField="AtNo" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("AtNo").ToString()==""?"N/A":Eval("AtNo") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Manufacture Date" DataField="MfgDate" DataType="System.DateTime" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("MfgDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MfgDate")).ToString("dd MM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="Batch Number" DataField="BatchNo" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                     <div class="">
                                        <%#Eval("BatchNo").ToString()==""?"N/A":Eval("BatchNo") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="ESL Date" ItemStyle-Width="70px" DataField="EslDate" DataType="System.DateTime" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                        <%#Eval("EslDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EslDate")).ToString("dd MM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="EXP Date" ItemStyle-Width="70px" DataField="EXPDate" DataType="System.DateTime" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                        <%#Eval("ExpDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("ExpDate")).ToString("dd MM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                           <%--  <telerik:GridTemplateColumn HeaderText="Product Status" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                       <asp:Label id="test" runat="server" Text=' <%#Eval("ProductStatus").ToString()==""?"N/A":Eval("ProductStatus") %>'></asp:Label>
                                     
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                         <%-- developed by rajbir--%>
                            <telerik:GridTemplateColumn HeaderText="Product Status" DataField="Status" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                       <asp:Label id="lblPstatus" runat="server" Text=' <%#Eval("Status").ToString()==""?"N/A":Eval("Status") %>'></asp:Label>
                                   </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                              <telerik:GridTemplateColumn HeaderText="Action" ItemStyle-Width="130px" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                          <asp:LinkButton ID="lnkbtnAvtion" runat="server" PostBackUrl='<%#"../Forms/ESLIssueForwardingNote.aspx?Id="+Eval("BID") %>'>Prepare Forward Note </asp:LinkButton>
                                    </div>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
   <%--       End--%>
                            <%--<telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">

                                      <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("BID")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp; 
                                           
                                        <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()%>' CausesValidation="false" CommandName="Active" CommandArgument='<%#Eval("IsActive").ToString()%>'></asp:LinkButton>
                                          
                                        <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("Depu_Id")+"< "+Eval("Depu_Name")+"< "+Eval("Depu_Location")+"< "+ Eval("IsActive").ToString()+"<"+Eval("Depot_Code")+"<"+Eval("IsParent")%>'></asp:LinkButton>
                                      
                                    </div>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>--%>


                        </Columns>

                        <Columns>
                          
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
         </div>
            </div>
        </div>
</asp:Content>