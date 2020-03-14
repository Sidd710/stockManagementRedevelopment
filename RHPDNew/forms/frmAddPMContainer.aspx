<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmAddPMContainer.aspx.cs" Inherits="RHPDNew.Forms.frmAddPMContainer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
     <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>

     <telerik:RadAjaxManager ID="rdProduct" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                <UpdatedControls>                    
                    <telerik:AjaxUpdatedControl ControlID="apPMC" LoadingPanelID="RadAjaxLoadingPanel1"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Add PM & Container</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>
    <div class="container-fluid form-outer">
       
        <div class="clear"></div>
        <div class="container forming_texting">
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>
           
                <div class="row marginbottom10"> <div class="col-five">
                    <asp:HiddenField ID="hdnPMC" runat="server" />
                    <label class="form_text">PM/Container Name:</label>
                    <telerik:RadAutoCompleteBox Delimiter="," style="width:500px;    margin-left: 223px;"    RenderMode="Lightweight" runat="server" ID="apPMC"  EmptyMessage="Please type PM/Container Name here...."
                DataSourceID="sqlPMC"  DataTextField="PMC" DataValueField="Id" InputType="Text" TokensSettings-AllowTokenEditing="false"   Width="500"  DropDownWidth="500px" TextSettings-SelectionMode="Single"  AllowCustomEntry="false">
            </telerik:RadAutoCompleteBox>
                    <%--<asp:RequiredFieldValidator ID="rfPMC" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="apPMC"></asp:RequiredFieldValidator>--%>
              <asp:SqlDataSource ID="sqlPMC" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="select pmc.MaterialName+'_' +pmc.Capacity+'_'+pmc.Grade+'_'+pmc.Condition as PMC, pmc.Id from PMandContainerMaster pmc order by pmc.MaterialName">
                                        
                                    </asp:SqlDataSource>
                </div>
                  <div class="col-five" style="margin-left:224px;"><asp:Label CssClass="form_text" runat="server" ID="lblPMC" ForeColor="Blue"></asp:Label></div>
            </div>
             <div class="row marginbottom10">   <div class="col-five">

                 <label class="form_text">Category :</label>
                    <asp:ObjectDataSource ID="odsCategory" runat="server" TypeName="RHPDComponent.AddProductComp" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlselectCat"  OnDataBound="ddlselectCat_DataBound" CssClass="form-control" runat="server" DataSourceID="odsCategory" DataTextField="Category_Name" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlselectCat" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-- Select --" SetFocusOnError="true" ControlToValidate="ddlselectCat"></asp:RequiredFieldValidator>
       

                                                </div> <div class="col-five">
                    <label class="form_text">Date of Receival:</label>
                   <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtReceivedDate"  runat="server" DateInput-DateFormat="dd-MMM-yyyy">
        </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtReceivedDate"></asp:RequiredFieldValidator>
                   
                </div>
              </div>
             <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Quantity:</label>
                    <telerik:RadNumericTextBox Height="35" Width="290"  Value="0"  CssClass="form-control" NumberFormat-DecimalDigits="3" runat="server" ID="txtQty"  ></telerik:RadNumericTextBox>
           
                
                </div>
                  <div class="col-five">  <label class="form_text"></label>
                 
                </div>
               
            </div>
            
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <input type="hidden" id="visiblelblmsg" value="" runat="server" />
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit"  OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" CausesValidation="false" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="true" ForeColor="Green"></asp:Label>
                </div>
                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

            </div>
        </div>
        <script>
            function confirm() {
                var r = confirm("Press a button");
                if (r == true) {
                    return true;
                } else {
                    return false;
                }
            }
        </script>
        <div class="container">
            <div class="tableDiv">
                   
                <asp:GridView ID="grdFormation" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false
                " OnRowCommand="grdFormation_RowCommand">
                <Columns>

                    <asp:TemplateField AccessibleHeaderText="Name">
                        <HeaderTemplate>
                            Sr.No
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="" style="float: left;">
                                <%#Container.DisplayIndex+1%>
                            </div>
                        </ItemTemplate>

                    </asp:TemplateField>
                     <asp:TemplateField AccessibleHeaderText="Category_Name">
                        <HeaderTemplate>
                           Category 
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="cat" runat="server" Text='<%# Eval("CategoryMaster.Category_Name") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                     
                    
                    <asp:TemplateField AccessibleHeaderText="Material Name">
                        <HeaderTemplate>
                            Material Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("PMandContainerMaster.MaterialName") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                      <asp:TemplateField AccessibleHeaderText="Capacity">
                        <HeaderTemplate>
                           Capacity
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("PMandContainerMaster.Capacity") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Grade">
                        <HeaderTemplate>
                            Grade
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("PMandContainerMaster.Grade") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Condition">
                        <HeaderTemplate>
                           Condition
                        </HeaderTemplate>
                        <ItemTemplate>

                           <asp:Label ID="lblCondition" runat="server" Text='<%# Eval("PMandContainerMaster.Condition") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                     <asp:TemplateField AccessibleHeaderText="Quantity">
                        <HeaderTemplate>
                           Quantity
                        </HeaderTemplate>
                        <ItemTemplate>

                           <asp:Label  ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                     <asp:TemplateField AccessibleHeaderText="DateOfReceival">
                        <HeaderTemplate>
                           Date Of Receival
                        </HeaderTemplate>
                        <ItemTemplate>

                           <asp:Label ID="DateOfReceival" runat="server" Text='<%#Convert.ToDateTime( Eval("DateOfReceival").ToString()).ToString("dd-MMM-yyyy") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Active/In-Active">
                        <HeaderTemplate>
                            Action
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Edit" CommandName="UpdateRecord" /> &nbsp;|&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Delete"  CommandName="DeleteRecord"  />

                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#EFF3FB"></RowStyle>

                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            </div>
        </div>
    </div>

</ContentTemplate></asp:UpdatePanel>
</asp:Content>

