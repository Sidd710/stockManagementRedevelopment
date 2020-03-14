<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="ESLStatus.aspx.cs" Inherits="RHPDNew.Forms.ESLStatus" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">

     <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>

</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
      <script type="text/javascript">
          $("#btnSubmit").click(function (event) {
              var statusValue = $("#ddlstatus option:selected").text();
              var rdpDateFrom = $find("dpDateFrom");
              var rdpDateTo = $find("dpDateTo");
              var dateFrom = rdpDateFrom.get_selectedDate();
              var dateTo = rdpDateTo.get_selectedDate();
              if (statusValue != "Fit" || statusValue != "UnFit" || statusValue != "Pending") {
                  alert("Please select a valid status!");
                  event.preventDefault();
                  event.stopPropagation();
                  return false;
              }
              else if (dateFrom == null) {
                  alert("Please select the Date From!");
                  event.preventDefault();
                  event.stopPropagation();
                  return false;
              }
              else if (dateTo == null) {
                  alert("Please select the Date To!");
                  event.preventDefault();
                  event.stopPropagation();
                  return false;
              }
              else if (dateTo <= dateFrom)
              {
                  alert("Date To cann't be less than or equal to Date From!");
                  event.preventDefault();
                  event.stopPropagation();
                  return false;
              }
          });
      </script>
    <div class="container-fluid">
        <div class="container">
            <div class="row pageHeading">
                <h1>ESL Issue Status</h1>
            </div>
        </div>
    </div>

    <div class="container-fluid form-outer">
        <div class="container forming_texting">
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary id="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server"/>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Select Status:</label>
                    <asp:DropDownList ID="ddlstatus" CssClass="form-control"  runat="server" AutoPostBack="false" Width="280px"></asp:DropDownList>                                            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlstatus"></asp:RequiredFieldValidator>
                </div>
                <div class="col-five">
                    <label class="form_text">Date from:</label>
                    <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="dpDateFrom" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                              </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="dpDateFrom"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Date to:</label>
                    <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="dpDateTo" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                              </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="dpDateTo"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                        <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear"  CausesValidation="false"  /><br /> 
                        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
               </div>
            </div>
        <div class="container">
            <telerik:RadGrid runat="server" ID="ESLRadgrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="12" AllowFilteringByColumn="false" AllowAutomaticInserts="false" 
                 Skin="Web20"  >
                <MasterTableView Caption="ESL Issue Status" DataKeyNames="FnId" CommandItemDisplay="None" Font-Names="Arial" Font-Size="9"  
                      ShowHeadersWhenNoRecords="false" EnableNoRecordsTemplate="true"  >
                  
                   <NoRecordsTemplate>
                         <div> No Records found</div>
                     </NoRecordsTemplate>
 
                 
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                            <ItemTemplate>
                                <%#Container.DataSetIndex+1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="Product Name" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Batch Number" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label ID="lblBatchNumber" runat="server" Text='<%#Eval("BatchNumber")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>                       

                          <telerik:GridTemplateColumn HeaderText="Category" AllowFiltering="false">
                            <ItemTemplate>                               
                              <asp:Label id="lblCategory" runat="server" Text=' <%#Eval("Category").ToString()==""?"N/A":Eval("Category") %>'></asp:Label>                                     
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                                                
                          <telerik:GridTemplateColumn HeaderText="Current Esl" AllowFiltering="false">
                            <ItemTemplate>
                                   <asp:Label ID="lblCurEsl" runat="server" Text='<%#Eval("CurEsl").ToString()==""?"N/A":Convert.ToDateTime(Eval("CurEsl")).ToString("dd MMM yyyy") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        
                         <telerik:GridTemplateColumn HeaderText="Status" AllowFiltering="false">
                            <ItemTemplate>                               
                              <asp:Label id="lblStatus" runat="server" Text=' <%#Eval("batchStatus").ToString()==""?"N/A":Eval("batchStatus") %>'></asp:Label>                                     
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="Previous Esl" AllowFiltering="false">
                            <ItemTemplate>
                                  <asp:Label ID="lblPreEsl" runat="server" Text='<%#Eval("PreEsl").ToString()==""?"N/A": Convert.ToDateTime(Eval("PreEsl")).ToString("dd MMM yyyy") %>'></asp:Label>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn HeaderText="Status Update Date" AllowFiltering="false">
                            <ItemTemplate>
                                  <asp:Label ID="lblModDate" runat="server" Text='<%#Eval("ModDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("ModDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Forward Note Number" AllowFiltering="false">
                            <ItemTemplate>
                                  <asp:Label ID="lblFnNumber" runat="server" Text='<%#Eval("FnNumber")%>'></asp:Label>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Details" AllowFiltering="false">
                            <ItemTemplate>
                                  <asp:LinkButton ID="btnViewDetails" runat="server" Text="View Details" OnClick="btnViewDetails_Click" CommandArgument='<%#Eval("FnId").ToString() %>'></asp:LinkButton>
                            </ItemTemplate>
                         </telerik:GridTemplateColumn>

                    </Columns>
                </MasterTableView>

            </telerik:RadGrid> 
            <telerik:RadWindow RenderMode="Lightweight" Visible="false" VisibleOnPageLoad="false" Height="550px" Width="1100px" Modal="true" runat="server" ID="radWindowViewDetails" NavigateUrl="EslViewDetails.aspx"></telerik:RadWindow>
        </div>
    </div>
</asp:Content>
