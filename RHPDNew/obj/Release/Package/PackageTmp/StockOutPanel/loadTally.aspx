<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="loadTally.aspx.cs" Inherits="Demo1.loadTally" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 90px;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            width: 135px;
        }
        .auto-style4 {
            height: 50px;
            width: 135px;
        }
        .auto-style5 {
            height: 90px;
            width: 135px;
        }
        .auto-style6 {
            width: 135px;
            height: 30px;
        }
        .auto-style7 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../Scripts/jquery-1.10.2.intellisense.js"></script>
<script src="../Scripts/jquery-1.10.2.js"></script>

<script src="../Scripts/jquery-1.10.2.min.js"></script>
<link href="abcc.css" rel="stylesheet" />
<link href="vv.css" rel="stylesheet" />
<link href="b.css" rel="stylesheet" />
<script src="Scripts/jquery-1.10.2.min.js"></script>
<link href="css/s.css" rel="stylesheet" />
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
<%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />
<script src="http://code.jquery.com/jquery-1.8.3.js"></script>
<script src="http://code.jquery.com/ui/1.10.0/jquery-ui.js"></script>--%>
      <script src="JSpath/jquery-1.8.3.min.js"></script>
   <script src="JSpath/jquery-ui.js"></script>
       <link href="JSpath/jquery-ui.css" rel="stylesheet" />
<link rel="stylesheet" href="/resources/demos/style.css" />
<script>
    $(function () {
        $("#ctl00_ContentPlaceHolder1_txtdate").datepicker();
    });
</script>
    <script type="text/javascript">
        function valid() {
            if (document.getElementById('<%=txtldTno.ClientID %>').value.trim() == "") {
            alert("Please enter load tally number NO!");
            document.getElementById('<%=txtldTno.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=lbldriverName.ClientID %>').value.trim() == "") {
            alert("Please enter Driver Name!");
            document.getElementById('<%=lbldriverName.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtRank.ClientID %>').value.trim() == "") {
            alert("Please enter Rank!");
            document.getElementById('<%=txtRank.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtunitNo.ClientID %>').value.trim() == "") {
            alert("Please enter Unit No!");
            document.getElementById('<%=txtunitNo.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtdate.ClientID %>').value.trim() == "") {
            alert("Please enter Date!");
            document.getElementById('<%=txtdate.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtauthority.ClientID %>').value.trim() == "") {
            alert("Please enter Authority!");
            document.getElementById('<%=txtauthority.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtthrough.ClientID %>').value.trim() == "") {
            alert("Please enter Through!");
            document.getElementById('<%=txtthrough.ClientID %>').focus();
            return false;
        }
    }
</script>
   
<div class="container-fluid">
    <div class="container">
        <div class="row pageHeading">
            <h1>Load Tally</h1>
        </div>
    </div>
</div>
<div class="container-fluid">
    <div class="container">
        <table style="width:100%" align="center" >
      <tr> 
          <td height="50">
                        <label class="thicker" align="center">
                    <b>Vehicle no :</b>
                </label>
              </td>
          <td height="50">
      <asp:TextBox ID="txtvechileno" runat="server" Enabled="false" CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"></asp:TextBox>
              </td>
          </tr>
        <tr>
            <td height="50">
        <label class="thicker">
    <b>Authority no:</b>
</label></td> <td height="50">
        <asp:TextBox ID="txtauthority" runat="server" CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"></asp:TextBox></td>
       </tr>  
        <tr>
            <td height="50">
  <label class="thicker">
    <b>Through :</b>
</label>
            </td>
             <td height="50">
               <asp:TextBox ID="txtthrough" runat="server" CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"></asp:TextBox>
            </td>
        </tr>
    
       
        </table>
        <div class="marginbottom15"></div>
        <div id="loadTallyGrid" runat="server">
             <div id="VechileListGrid" runat="server">
                <asp:GridView ID="loadTallyGrid_" runat="server" EmptyDataText="No data found !" CssClass="grdloadtallylist"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
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
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product name">
                            <ItemTemplate>
                                <asp:Label ID="lblprdname" runat="server" Text='<% #Eval("product_name")%>' style="color:blue"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Packaging material">
                            <ItemTemplate>
                                <asp:Label ID="lblpmaterial" runat="server" Text='<%#Eval("PackingMaterial") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Packaging material Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblpmquantity" runat="server" Text='<% #Convert.ToBoolean(Eval("IsEmptyPM"))==false && Convert.ToBoolean(Eval("IsDW"))==false && Convert.ToBoolean(Eval("IsWithoutPacking"))==false?(Eval("PMQtyFull").ToString()!=""?Eval("PMQtyLoose").ToString()==""?Eval("PMQtyFull"):Convert.ToDouble(Eval("PMQtyFull"))+Convert.ToDouble(Eval("PMQtyLoose")): Eval("PMQtyLoose")):""%>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>

                         
                            <asp:TemplateField HeaderText="Product Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblprdquantity" runat="server" Text='<% #Convert.ToDouble(Eval("StockQuantity")).ToString("0.000")%>' ></asp:Label>&nbsp; <asp:Label ID="lblau" runat="server" Text='<% #Eval("productUnit")%>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Cost">
                            <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<% #Convert.ToDouble(Eval("Cost")).ToString("0.00")%>' ></asp:Label>
                    
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Weight">
                            <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<% #Convert.ToDouble(Eval("Weight")).ToString("0.000")%>' ></asp:Label>&nbsp; <asp:Label ID="lblWeightUnt" runat="server" Text='<% #Eval("WeightUnit")%>' ></asp:Label>
                    
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Full">
                            <ItemTemplate>
                                    <%#Eval("FormatFull") %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Loose/DW/Others">
                            <ItemTemplate>
                                   <%#Eval("FormatLoose") %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
                    <RowStyle CssClass="stm_dark" />
                    <HeaderStyle CssClass="stm_head" />
                </asp:GridView>
              
                 
                   <div class="marginbottom15">
                       <asp:Label runat="server" ID="lblTotalWeight" Text="Total Weight: " Style=" float:right;font:bold;font-size:large" ></asp:Label>
                   </div>
                <table style="width:50%" align="center">
                   <tr> 
                      <td height="50" class="auto-style3">
                        <label class="thicker">
                            <b>Load Tally No.:</b>
                        </label>
                      </td>
                      <td height="50">
                        <asp:TextBox ID="txtldTno" runat="server" Enabled="false" CssClass="form-control" style="top: 0px;left: 56px; width:100%"></asp:TextBox>
                      </td>
                   </tr>
                   <tr>
                        <td class="auto-style6">
                            <label class="thicker">
                                <b>Driver name:</b>
                            </label>
                        </td>
                        <td class="auto-style7">
                            <asp:TextBox ID="lbldriverName" runat="server" CssClass="form-control" style="top: 0px;left: 56px; width:100%" ></asp:TextBox>
                        </td>
                   </tr>
                   <tr>
                        <td class="auto-style4">
                            <label class="thicker">
                                <b>Rank:</b>
                            </label>
                        </td>
                       <td class="auto-style2">
                           <asp:TextBox ID="txtRank" runat="server" CssClass=" form-control" Style="top: 0px; left: 56px; width: 100%" OnTextChanged="txtRank_TextChanged1"></asp:TextBox>
                       </td>
                    </tr>
                   <tr>
                        <td class="auto-style5">
                            <label class="thicker">
                                <b>Unit no:</b>
                            </label>
                       </td>
                       <td class="auto-style1">
                            <asp:TextBox ID="txtunitNo" runat="server" CssClass=" form-control" style="top: 0px;left: 56px; width:100%"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                        <td height="50" class="auto-style3">
                            <label class="thicker">
                               <b> Generate Date:</b>
                            </label>
                        </td>
                         <td height="50">
                             <asp:TextBox ID="txtdate" runat="server" CssClass=" form-control" style="top: 0px;left: 56px; width:100%"></asp:TextBox>
                     <%--    <asp:CalendarExtender ID="CalendarExtender2" Format="dd MM yyyy" TargetControlID="txtdate" runat="server"></asp:CalendarExtender>
 --%>      
                              </td>
                    </tr>
                       <tr>
                        <td height="50" class="auto-style3">
                            <label class="thicker">
                                <b>Remarks(If any):</b>
                            </label>
                       </td>
                       <td height="50">
                            <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass=" form-control" style="top: 0px;left: 56px; width:100%"></asp:TextBox>
                       </td>
                   </tr>
                </table>
                <div class="marginbottom15"></div>
                <div align="center">
                    <asp:Button ID="btnGenrateLoadTally" runat="server" Text="Genrate Load Tally" CssClass="btn btn-primary" align="center" OnClientClick="return valid();" OnClick="btnGenrateLoadTally_Click"/>
                </div>
            </div>
        </div>
    </div>
</div>


    </asp:Content>
