<%@ Page Language="C#"  MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="MonitoringTool.aspx.cs" Inherits="RHPDNew.StockOutPanel.MonitoringTool" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
       <script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
       
       <script src="js/monitoring.js"></script>
       
       <style>
           table,  td ,th {
      border: 3px solid black;
      background-color: seashell;
      padding: 12px;
}

 p.thicker {
    font-weight: bold;
}
       </style>
      
           
                <div class="row">
                 <label class="col-lg-2">Set Quarter for this Financial Year</label>
                
             <asp:DropDownList ID="ddlQuarter" runat="server" CssClass="col-lg-4 form-control">
                
                  <asp:ListItem Text="----Select Quarter-----" Value="0" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="2" Value="1"></asp:ListItem>
                 <asp:ListItem Text="3" Value="2"></asp:ListItem>
                 <asp:ListItem Text="4" Value="3"></asp:ListItem>
                 <asp:ListItem Text="6" Value="4"></asp:ListItem>
            </asp:DropDownList>&nbsp;
                    </div>
              <br />
       <br />


     

         <div class="row">
                 <label class="col-lg-2">Select Product</label>
                
             <asp:DropDownList ID="ddlProduct" runat="server" CssClass="col-lg-4 form-control" >
                   <asp:ListItem Text="----Select Quarter-----" Value="0" Selected="True"></asp:ListItem>
            </asp:DropDownList>&nbsp;
                    </div>
       <br />
       <br />
       <div id="monitoringtoolGrid" runat="server" style="width:100%">
       
   <%--     <div id="monitoringtoolGrid" runat="server">
             <asp:GridView ID="monitoringtoolGrid_" runat="server" EmptyDataText="No data found !" CssClass="monitoringtoolGrid_css"  BorderWidth="6" BorderColor="Green" HeaderStyle-Height="30px"
                        AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" style="display:none"
                        PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
                        Width="50%"
                       >--%>
                   <asp:GridView ID="monitoringtoolGrid_" runat="server" EmptyDataText="No data found !" CssClass="grdbachwithproductqtycss"  BorderWidth="6" BorderColor="Green" HeaderStyle-Height="30px" OnRowDataBound="monitoringtoolGrid__RowDataBound"
                        AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                        PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
                        Width="100%"
                       >
                        <PagerStyle CssClass="gridpager" HorizontalAlign="Center" />

                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblperiod" runat="server"  CssClass="lblsno"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lbproductName" runat="server" Text='<% #Eval("ProductName")%>' CssClass="lblProductName"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="10%" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Stock Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                   <asp:Label ID="lblstockquan" runat="server" Text='<% #Eval("StockQty")%>' CssClass="lbltotalQty"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="10%" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Unit" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                   <asp:Label ID="lblminimumquantity" runat="server" Text='<% #Eval("productUnit")%>' CssClass="lblprdunit"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="10%" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="GS Reservre Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                   <asp:Label ID="lblGSreserver" runat="server" Text='<% #Eval("GSreservre")%>' CssClass="lblGsreserve"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="10%" />
                            </asp:TemplateField>
                              

                             <asp:TemplateField HeaderText="Minimum Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="White">
                                 <HeaderTemplate>
                                       <asp:DropDownList ID="ddlCountry" runat="server" style="background-color:white;color:black">
            <asp:ListItem Text = "---Select Dipu----" Value = "0"></asp:ListItem>
            <asp:ListItem Text = "DIPU-1"  Value = "1"></asp:ListItem>
            <asp:ListItem Text = "DIPU-2" Value = "2"></asp:ListItem>
            <asp:ListItem Text = "DIPU-3" Value = "3"></asp:ListItem>
            <asp:ListItem Text = "DIPU-4" Value = "4"></asp:ListItem>
            </asp:DropDownList>
                                 </HeaderTemplate>
                                <ItemTemplate>
                                   <asp:Label ID="lblappend" runat="server" CssClass="lblappendrow"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="5%" />
                            </asp:TemplateField>



                             



                        </Columns>
                        <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
                        <RowStyle CssClass="stm_dark" />
                        <HeaderStyle CssClass="stm_head" />
                    </asp:GridView>
        </div>










   </asp:Content>
