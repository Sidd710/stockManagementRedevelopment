<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printesl.aspx.cs" Inherits="RHPDNew.Forms.printesl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                   
                   <telerik:RadGrid runat="server" ID="RadGrid" Width="100%"  AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand" OnItemDataBound="RadGrid_ItemDataBound">
                    <MasterTableView DataKeyNames="ID" Caption="Category List"  CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                         <CommandItemTemplate>
                          <asp:Button ID="btnExcel" runat="server" CausesValidation="false" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                        <Columns>
                            <%-- <telerik:GridTemplateColumn HeaderText="Id" DataType="System.String" Groupable="false" HeaderStyle-CssClass="text-center GridHeader_Sunset">
                                                                            <ItemTemplate>
                                                                                <div class="">
                                                                                    <asp:Label ID="lkesdfdit" runat="server" Text='<%# Eval("ImgId")%>'></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Container.DataSetIndex+1%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>



                            <telerik:GridTemplateColumn HeaderText="Type" DataField="Type" DataType="System.String" UniqueName="Type" Groupable="false">
                                <ItemTemplate>
                                    <div style="text-transform:capitalize;">
                                        <%#Eval("Type").ToString()==""?"N/A":Eval("Type") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false"  >
                                <ItemTemplate>
                                    <div style="text-transform:capitalize;">
                                        <%-- <asp:Image ID="img" runat="server" class="table-img" ImageUrl='<%#"~/Upload/Banner/"+ Eval("ImageUrl")%>' />--%>
                                        <asp:Label ID="lblCategoryDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <%--   <telerik:GridTemplateColumn HeaderText="Image Description" DataField="ImgDescription" DataType="System.String" UniqueName="ImgDescription" Groupable="false" HeaderStyle-CssClass="text-center GridHeader_Sunset">
                                                                            <ItemTemplate>
                                                                                <div class="">
                                                                                    <%#Eval("ImgDescription").ToString()==""?"N/A":Eval("ImgDescription") %>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>

                            <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">

                                        <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Id")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                                 <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("ID")+"< "+Eval("Type")+"< "+Eval("Description")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                        <%--   <asp:Label ID="lblDelete" Visible="false" Text='<%# Bind("Id")%>' runat="server"></asp:Label> 
                                                                            <asp:LinkButton ID="lbldel" class="button thonerow pad-right-nonein red-gradient glossy tiny" runat="server" CommandName="Delete" CommandArgument='<%# Bind("Id")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')"   Text="Delete"></asp:LinkButton>
                                        --%>
                                    </div>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>


                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>   
    </div>
    </form>
</body>
</html>
