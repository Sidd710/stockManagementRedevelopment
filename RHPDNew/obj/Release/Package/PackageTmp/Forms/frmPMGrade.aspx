<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmPMGrade.aspx.cs" Inherits="RHPDNew.Forms.frmPMGrade" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script>
        function name() {
            alert('Name is already exists');
        }
    </script>
    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage PM Grade</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>


    
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
                    <label class="form_text">Grade :</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtGrade" />
                    <asp:RequiredFieldValidator ID="rfvGradeTextBox" runat="server" Text="*"
                        Display="Dynamic" ValidationGroup="grp" ControlToValidate="txtGrade" ErrorMessage="*"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
          
            <div class="row marginbottom10">
                
                <div class="col-five">   <label class="form_text">Is Active</label><asp:CheckBox ID="cbxActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
       </div>
                </div>

            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <asp:Button ID="btnSubmit" ValidationGroup="grp" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" ValidationGroup="validation" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="true" ForeColor="Green"></asp:Label>
                </div>
            </div>
            
          
            <telerik:RadGrid runat="server"  ID="rgdName" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="rgdName_ItemCommand">
                <MasterTableView DataKeyNames="Id" Caption="PM Grade List" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                        <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click"  CssClass="myExcelbtn" />
                        </CommandItemTemplate>
                        
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                               
                                    <%#Container.DataSetIndex+1%>
                               
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         
                        <telerik:GridTemplateColumn HeaderText="Grade" DataField="Grade" DataType="System.String" UniqueName="Grade" Groupable="false">
                            <ItemTemplate>
                                
                                    <%#Eval("Grade")%>
                                
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                       
                                <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("ID")+"< "+Eval("Grade")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="pEdit" 
                                        CommandArgument='<%# Eval("ID")+"< "+Eval("Grade")
                                    +"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>


