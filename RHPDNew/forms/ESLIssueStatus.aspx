<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ESLIssueStatus.aspx.cs" Inherits="RHPDNew.Forms.ESLIssueStatus"  MasterPageFile="~/RHPD.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="boday" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <div class="container-fluid">
        <div class="container">
            <div class="row pageHeading">
                <h1>ESL Issue Status</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid form-outer forming_texting">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary id="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server"/>
                </div>
            </div>

            <%-- <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Select Status:</label>

                    <asp:DropDownList ID="ddlstatus" CssClass="col-lg-4 form-control"  runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" ></asp:DropDownList>
                     
                    </div>
            </div>--%>
            
            <div class="clear"></div>
            <div class="row marginbottom10">
                <div class="col-md-12 text-align-center">
                    <label class="form_text">Date from:</label>
                    <asp:TextBox ID="txtDatefrom" CssClass="col-lg-4 form-control" placeholder="" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="cetxMfgDate" Format="dd MMM yyyy" TargetControlID="txtDatefrom" runat="server"></asp:CalendarExtender>
                <%-- <asp:RequiredFieldValidator ID="rfvtxtunitDesc" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDatefrom"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-md-12 text-align-center">
                    <label class="form_text">Date to:</label>
                    <asp:TextBox ID="txtDateto" CssClass="col-lg-4 form-control" placeholder="" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd MMM yyyy" TargetControlID="txtDateto" runat="server"></asp:CalendarExtender>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDateto"></asp:RequiredFieldValidator>--%>
                </div>
               </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 marginbottom20">
                    <label class="form_text"></label>
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit"  OnClick="btnSubmit_Click"  />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear"   OnClick="btnClear_Click" CausesValidation="false"  /><br /> 
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
              </div>
            </div>
    <div class="container">
          <telerik:RadGrid runat="server" ID="ESLRadgrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="12" AllowFilteringByColumn="false" AllowAutomaticInserts="false" OnPageIndexChanged="ESLRadgrid_PageIndexChanged"
                 Skin="Web20">
                <MasterTableView Caption="ESL Issue List" DataKeyNames="batchId" CommandItemDisplay="None" Font-Names="Arial" Font-Size="9"  
                      ShowHeadersWhenNoRecords="false" EnableNoRecordsTemplate="true">
                   <NoRecordsTemplate>
                         <div> No Records found</div>
                     </NoRecordsTemplate>
 
                 
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                   <%-- <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>--%>
                    
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>

                                <%#Container.DataSetIndex+1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>




                        <telerik:GridTemplateColumn HeaderText="Product Name" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label ID="lblProName" runat="server" Text='<%#Eval("ProductName")+ "" +Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                          <telerik:GridTemplateColumn HeaderText="Sample Type" AllowFiltering="false">
                            <ItemTemplate>
                               
                              <asp:Label id="lblsampletype" runat="server" Text=' <%#Eval("sampleType").ToString()==""?"N/A":Eval("sampleType") %>'></asp:Label>
                                     
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="Sample Quantity" AllowFiltering="false">
                            <ItemTemplate>
                               
                              <asp:Label id="lblsamplequantity" runat="server" Text=' <%#Eval("quantity").ToString()==""?"N/A":Eval("quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <%--<telerik:GridTemplateColumn HeaderText="RemarksBynurGP" AllowFiltering="false">
                            <ItemTemplate>
                               <asp:Label id="lblRemarksBynurGP" runat="server" Text=' <%#Eval("RemarksBynurGP").ToString()==""?"N/A":Eval("RemarksBynurGP") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                       <telerik:GridTemplateColumn HeaderText="RemarksByjcoiGP" AllowFiltering="false">
                            <ItemTemplate>
                               <asp:Label id="lblRemarksByjcoiGP" runat="server" Text=' <%#Eval("RemarksByjcoiGP").ToString()==""?"N/A":Eval("RemarksByjcoiGP") %>'></asp:Label>
                           </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="RemarksByjDSO" AllowFiltering="false">
                            <ItemTemplate>
                               <asp:Label id="lblRemarksByjcoiGP" runat="server" Text=' <%#Eval("RemarksByjDSO").ToString()==""?"N/A":Eval("RemarksByjDSO") %>'></asp:Label>
                          </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="OverallRemarks" AllowFiltering="false">
                            <ItemTemplate>
                              <asp:Label id="lblOverallRemarks" runat="server" Text=' <%#Eval("OverallRemarks").ToString()==""?"N/A":Eval("OverallRemarks") %>'></asp:Label>
                 
                           
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="IssueTo" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label id="lblIssueTo" runat="server" Text=' <%#Eval("IssueTo").ToString()==""?"N/A":Eval("IssueTo") %>'></asp:Label>
                  
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                       <telerik:GridTemplateColumn HeaderText="RecievedDate" AllowFiltering="false">
                            <ItemTemplate>
                                  <asp:Label ID="lblRecievedDate" runat="server" Text='<%# Convert.ToDateTime(Eval("RecievedDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="OverallRemarks" AllowFiltering="false">
                            <ItemTemplate>
                                <%#Eval("OverallRemarks") %>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>--%>


                          <telerik:GridTemplateColumn HeaderText="Product Status" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status").ToString()==""?"N/A":Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                          <telerik:GridTemplateColumn HeaderText="Current Esl Date" DataField="EslDate" DataType="System.String" AllowFiltering="true">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblFuelOut" runat="server" Text=' <%#Convert.ToDateTime(Eval("EslDate")).ToString("dd/MMM/yyyy") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Sample Dispatch Date" DataField="dispatchDate" DataType="System.String"  AllowFiltering="true">
                            <ItemTemplate>
                                  <asp:Label ID="lblDispatchDate" runat="server" Text='<%# Convert.ToDateTime(Eval("dispatchDate")).ToString("dd/MMM/yyyy") %>'></asp:Label>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="btnValidateSample" runat="server" OnClick="btnValidateSample_Click" CommandArgument='<%#Eval("batchId").ToString() %>'>Validate Sample</asp:LinkButton>
                                
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>
        <telerik:RadWindow RenderMode="Lightweight" Visible="false" VisibleOnPageLoad="false" Height="550px" Width="1100px" Modal="true" runat="server" ID="radWindowValidateBatch" NavigateUrl="EslValidateSample.aspx"></telerik:RadWindow>
    </div>
</asp:Content>