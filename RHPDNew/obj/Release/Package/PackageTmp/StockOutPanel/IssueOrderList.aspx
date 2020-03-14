<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="IssueOrderList.aspx.cs" Inherits="RHPDNew.StockOutPanel.IssueOrderList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Issue Order List</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/siachencollage.jpg) no-repeat;background-size:cover;}
        </style>
       <div class="container-fluid">
            <div class="container">
               <div id="searchArea" runat="server" class="idtTable marginbottom15">
                    <asp:DropDownList runat="server" ID="ddlcategory" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
               </div>
               <div id="issordergrid" runat="server">
                   <asp:GridView ID="issueorderlistgrid" runat="server" EmptyDataText="No data found !" CssClass="grdIssueOrderCss"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
                                AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                                PagerStyle-Font-Size="16px" PagerStyle-HorizontalAlign="Right" Width="100%" OnRowDataBound="issueorderlistgrid_RowDataBound">
                        <Columns> 
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblsno" CssClass="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>' ItemStyle-HorizontalAlign="Center" > </asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Panel Type">
                                <ItemTemplate>
                                   <asp:Label ID="type" runat="server" Text='<%# Eval("IDTICTAWS") %>' CssClass="lblPrdName">
                                    </asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Order Number">
                                <ItemTemplate>
                                   <asp:Label ID="lblissueorderNo" runat="server" Text='<%# Eval("IssueOrderNo") %>' CssClass="lblPrdName">
                                    </asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Authority">
                                <ItemTemplate>
                                    <asp:Label ID="lblunit"   runat="server" Text='<%# Eval("Authority") %>'  CssClass="lblunit">
                                    </asp:Label>
                                </ItemTemplate>
                             
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Quantity" ItemStyle-HorizontalAlign="Center"   >
                                <ItemTemplate>
                                    <asp:Label ID="lblissueqty"  runat="server" Text='<%# Eval("issuequantity") %>' CssClass="lblissueqty">
                                    </asp:Label>
                        
                                </ItemTemplate>
                               
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategory"  runat="server" Text='<%# Eval("Category_Name") %>' CssClass="lblissueqty">
                                    </asp:Label>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                             <%-- <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblprdt"  runat="server" Text='<%# Eval("Product_Name") %>' CssClass="lblissueqty">
                                    </asp:Label>
                                </ItemTemplate>
                              
                            </asp:TemplateField>--%>
                              <asp:TemplateField HeaderText="Issue Order Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblissueorderdate"  runat="server" Text='<%# Eval("issueorder_date") %>' CssClass="lblissueqty">
                                    </asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Created On">
                                <ItemTemplate>
                                    <asp:Label ID="lbcrterdate"  runat="server" Text='<%# Eval("CreateDate") %>' CssClass="lblissueqty">
                                    </asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Issue Voucher Number" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                                <ItemTemplate>
                                    <asp:Label ID="vno"  runat="server" Text='<%# Eval("IssueVoucherStatus").ToString()=="0"?"Pending":Eval("IssueVoucherNo") %>' CssClass="lblissueqty">
                                    </asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                   
                                    <asp:HyperLink Visible='<%#Eval("IssueVoucherStatus").ToString()=="0"?false:true %>' ID="ksdksdm" Text="Issue Voucher Generated" runat="server" NavigateUrl='<%# string.Format("frmIssueVoucher.aspx?Category_Id={0}&IssueOrderId={1}&Status={2}",HttpUtility.UrlEncode(Eval("Category_Id").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString()),HttpUtility.UrlEncode("1")) %>'></asp:HyperLink>
                                    <asp:HyperLink Visible='<%#Eval("IssueVoucherStatus").ToString()=="0"?true:false %>' ID="lnkgenratevoucher" Text="Genrate Issue Voucher" runat="server" NavigateUrl='<%# string.Format("frmIssueVoucher.aspx?Category_Id={0}&IssueOrderId={1}",HttpUtility.UrlEncode(Eval("Category_Id").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString())) %>'></asp:HyperLink>
                                  
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
                        <RowStyle CssClass="stm_dark" />
                        <HeaderStyle CssClass="stm_head" />
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>
