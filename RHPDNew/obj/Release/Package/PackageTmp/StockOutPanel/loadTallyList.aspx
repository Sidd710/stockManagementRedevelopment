<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="loadTallyList.aspx.cs" Inherits="Demo1.loadTallyList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Issued Vehicle List</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/siachen-20.jpg) no-repeat;background-size:cover;}
        </style>

<div class="container-fluid">
    <div class="container">
             <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>
        <div id="VechileListGrid" runat="server">
            <asp:GridView OnRowDataBound="VechileListGrid__RowDataBound" ID="VechileListGrid_" runat="server" EmptyDataText="No data found !" CssClass="grdloadtallylist"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
                AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                PagerStyle-Font-Size="16px" PagerStyle-HorizontalAlign="Right"
                Width="100%">
                <PagerStyle CssClass="gridpager" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <asp:Label ID="lblperiod" runat="server" Text='<%#Container.DataItemIndex+1 %>' CssClass="clsrno"></asp:Label>
                        </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="DDOrCHT" runat="server" Text='<%#Eval("DDOrCHT")%>' ></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Army No">
                        <ItemTemplate>
                            <asp:Label ID="ArmyNo" runat="server" Text='<%#Eval("ArmyNo")%>' ></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Driver Name">
                        <ItemTemplate>
                            <asp:Label ID="DriverName" runat="server" Text='<%#Eval("DriverName")%>' ></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Fully Occupied" Visible="false">
                        <ItemTemplate>
                            <asp:Label Text='<%#Convert.ToBoolean(Eval("FullOccupied"))==true?"Yes":"No" %>' runat="server" ID="lblFO"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vechile No">
                        <ItemTemplate>
                            <%--  <asp:LinkButton ID="lblvechileName" runat="server" Text='<% #Eval("VehicleNo")%>' style="color:orange"></asp:LinkButton>--%>
                            <asp:HyperLink ForeColor="Black" Font-Bold="true" ID="lnkgenratevoucher" Text='<% #Eval("VehicleNo")%>' runat="server" NavigateUrl='<%# string.Format("loadTally.aspx?VehicleNo={0}&IssueOrderId={1}",HttpUtility.UrlEncode(Eval("VehicleNo").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString())) %>'></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                           
                    <asp:TemplateField HeaderText="No. of Products">
                        <ItemTemplate>
                            <asp:Label ID="lblprdquantity" runat="server" Text='<%#Convert.ToDouble(Eval("StockQuantity")).ToString("0.000")%>' ></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                               <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                               <asp:HyperLink Visible='<%#(Eval("Status").ToString()=="0"?true:false) %>' ForeColor="blue" Font-Bold="true" ID="HyperLink1" Text="Load Tally Generated" runat="server" NavigateUrl='<%# string.Format("loadTally.aspx?VehicleNo={0}&IssueOrderId={1}",HttpUtility.UrlEncode(Eval("VehicleNo").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString())) %>'></asp:HyperLink>
                            <asp:HyperLink Visible='<%#(Eval("Status").ToString()=="0"?false:true) %>' ForeColor="blue" Font-Bold="true" ID="genTL" Text="Generate Load Tally" runat="server" NavigateUrl='<%# string.Format("loadTally.aspx?VehicleNo={0}&IssueOrderId={1}",HttpUtility.UrlEncode(Eval("VehicleNo").ToString()), HttpUtility.UrlEncode(Eval("IssueOrderId").ToString())) %>'></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                       
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
                <RowStyle CssClass="stm_dark" />
                <HeaderStyle CssClass="stm_head" />
            </asp:GridView>
        </div>
                                          </ContentTemplate></asp:UpdatePanel>
    </div>
</div>
    
</asp:Content>