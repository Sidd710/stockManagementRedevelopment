<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="issueidtList.aspx.cs" Inherits="RHPDNew.StockOutPanel.issueidtList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
     @media print {

th, td {
    font-family: Verdana, Arial, Helvetica, sans-serif;
    font-size: 18px;
    color: #000000;
}
tr {
    border: 1px solid gray;
}
td {
    width: 200px;
    padding: 3px;
}
th {
    background-color: #D2E0E8;
    color: #003366
}
table {
    border: 1pt solid gray;
    text-align: center;
}
}


@media screen {

th, td {
    font-family: Verdana, Arial, Helvetica, sans-serif;
    font-size: 18px;
    color: #000000;
}
tr {
    border: 1px solid gray;
}
td {
    width: 200px;
    padding: 3px;
}
th {
    background-color: #D2E0E8;
    color: #003366
}
table {
    border: 1pt solid gray;
    text-align: center;
}
}
</style>
      <div class="heading-bg" align="center" >
        <div class="container">
            <h1  style="background-color:skyblue;color:white">Issue Idt List</h1>
        </div>
    </div>
     <br />
     <br />
     <asp:GridView ID="IssueIDTgrid_" runat="server" EmptyDataText="No data found !" CssClass="grdloadtallylist"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
                        AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                        PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
                        Width="100%" >
                        <PagerStyle CssClass="gridpager" HorizontalAlign="Center" />

                        <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate>
                                    <asp:Label ID="lblperiod" runat="server" Text='<%#Container.DataItemIndex+1 %>' CssClass="clsrno"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch Name" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate>
                                    <asp:Label ID="lblvechileName" CssClass="lblvechileNameclass" runat="server" Text='<% #Eval("BatchName")%>' style="color:blue"></asp:Label>
                                   <%-- <asp:HyperLink ID="lnkgenratevoucher" Text='<% #Eval("VehicleNo")%>' runat="server" NavigateUrl='<%# string.Format("loadTally.aspx?VehicleNo={0}&IssueOrderId={1}",HttpUtility.UrlEncode(Eval("VehicleNo").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString())) %>'></asp:HyperLink>--%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" width="40%" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Issue Idt Quantity" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate>
                                   <asp:Label ID="lblprdquantity" runat="server" Text='<% #Eval("issueqty")%>' ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Product Name" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate>
                                   <asp:Label ID="lblprdquantity" runat="server" Text='<% #Eval("product_name")%>' ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="Depu Name" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate>
                                   <asp:Label ID="lblprdquantity" runat="server" Text='<% #Eval("Depu_Name")%>' ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
                        <RowStyle CssClass="stm_dark" />
                        <HeaderStyle CssClass="stm_head" />
                    </asp:GridView>

     </asp:Content>