<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="Vechilemaster.aspx.cs" Inherits="RHPDNew.StockOutPanel.Vechilemaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script src="js/vechilemaster.js"></script>
       <script src="JSpath/jquery-1.8.3.min.js"></script>
        <style>
            body{background:url(../assets/images/tankview.jpg) no-repeat;background-size:cover;}
        </style>
        <style>
table, th, td {
    border: 1px solid black;
    padding: 9px
}
            .marginVM {
                margin-left:70px;
                margin-right:70px;
            }
.showpopup {
            opacity: 1;
            position: fixed;
            left: 10%;
            top: 5%;
            background: none repeat scroll 0 0 #fff;
            border: 10px solid #8CBF26;
            border-radius: 5px;
            box-shadow: 0 0 30px rgba(0, 0, 0, 0.32);
            color: #000;
            font-family: sans-serif;
            min-height: 850px;
            height: auto!important;
            width: 85%;
            z-index: 99999999999;
            padding-bottom: 20px;
            position: fixed; 
            overflow-y:scroll
        }

.button-success {
            background: blue; /* this is a green */
             border-radius: 8px;
            text-shadow: 0 2px 2px rgba(0, 0, 0, 0.2);
        }
          </style>
      <script src="JSpath/jquery-1.8.3.min.js"></script>
   <script src="JSpath/jquery-ui.js"></script>
       <link href="JSpath/jquery-ui.css" rel="stylesheet" />
 


   <script>
       $(function () {
           $("#ctl00_ContentPlaceHolder1_txtsearchbydate").datepicker();
       });
 </script>
  
       <br />
         <div class="heading-bg" align="center" >
        <div class="container">
            <h1  style="background-color:skyblue;color:white">Vechile Master</h1>
        </div>
    </div>
       <br />
      
        <table style="width:65%" align="center" class="customers" >

        <tr>
            <td height="50">
<label class="thicker" style="font-size:large">
   <b> Enter Through:</b>
</label>
            </td>
             <td height="50">
                 <asp:TextBox ID="txtthrough" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>

            </td>
        </tr>
        </table>
      
       <br />
        <table class="table table-bordered">
    <thead>
      <tr>
           <td>
                 <label><b>Select Vechile Type</b></label>  
          </td>
          <td>
           <asp:RadioButton ID="rdDD" Text="DD" runat="server" Checked="true" GroupName="Vechtype" />
           <asp:RadioButton ID="rdCHT" Text="CHT" runat="server"  GroupName="Vechtype"/>
            </td>
          </tr>
       </thead>
            </table>
        <br />
      
        <div align="center">
             <asp:Button ID="btnaddvechile" runat="server" Text="Add Vehicle" class="btadd" CssClass="btn btn-primary" style="padding: 7px 22px;font-size: 18px;"/>
            </div>
      <div id="divvechileaddmaster" class="showpopup" style="text-align: center; display: none">
     </div>
     
       <br />
         <table style="width:65%" align="center" class="customers" >

        <tr>
            <td height="50">
<label class="thicker" style="font-size:large">
   <b> Search By Date:</b>
</label>
            </td>
             <td height="50">
                 <asp:TextBox ID="txtsearchbydate" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>
                 <asp:Button ID="btnsearch" runat="server" Text="Search" class="btadd" CssClass="btn btn-primary" style="padding: 7px 22px;font-size: 18px;margin-left: 70px" OnClick="btnsearch_Click"/>
            </td>
        </tr>
        </table>
    <%--   <div id="serchareabydate" runat="server" align="center">
    <asp:TextBox ID="txtsearchbydate" runat="server" ></asp:TextBox>
       </div>--%>
       <br />
      

       <div id="Gridvechile_" runat="server" >
           <telerik:RadGrid ID="rgdVehicleMaster" runat="server" AutoGenerateColumns="False"
               Width="90%" CssClass="marginVM" EnableAJAX="True" Skin="Office2010Black" OnNeedDataSource="rgdVehicleMaster_NeedDataSource"> 
             <MasterTableView DataKeyNames="Id" GridLines="None"> 
               <GroupByExpressions>
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Through" HeaderValueSeparator=": " SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Through" HeaderText="Through" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Vtypename" HeaderValueSeparator=": " SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Vtypename" HeaderText="Vehicle Type" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                             <FooterTemplate>
                                <asp:Label runat="server" ID="lblCountLabel">Count:</asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>

                      <telerik:GridTemplateColumn Visible="false" HeaderText="Id" DataField="Id" DataType="System.Int32" UniqueName="Id">
                            <ItemTemplate>                               
                                 <%#Eval("Id") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn   HeaderText="Vehicle Number" DataField="VechileNumber" DataType="System.String" UniqueName="VechileNumber">
                                    <ItemTemplate>
                                           <asp:Label runat="server" ID="nn" Text='<%#Eval("VechileNumber") %>' Style="height:100%;width:105px;word-wrap:break-word;display:block"></asp:Label>                                         
                                    </ItemTemplate>                          
                                </telerik:GridTemplateColumn> 

                    <telerik:GridTemplateColumn   HeaderText="Driver Name" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                            <ItemTemplate><%#Eval("DriverName") %></ItemTemplate>
                        </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn   HeaderText="License Number" DataField="LicenseNo" DataType="System.String" UniqueName="LicenseNo">
                            <ItemTemplate><%#Eval("LicenseNo").ToString()==""?"Not Applicable":Eval("LicenseNo") %></ItemTemplate>
                        </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn   HeaderText="Army Rank" DataField="Rank" DataType="System.String" UniqueName="Rank">
                            <ItemTemplate><%#Eval("Rank").ToString()==""?"Not Applicable":Eval("Rank") %></ItemTemplate>
                        </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn   HeaderText="Army Number" DataField="ArmyNo" DataType="System.String" UniqueName="ArmyNo">
                            <ItemTemplate><%#Eval("ArmyNo").ToString()==""?"Not Applicable":Eval("ArmyNo") %></ItemTemplate>
                        </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn   HeaderText="Unit Number" DataField="unitNo" DataType="System.String" UniqueName="unitNo">
                            <ItemTemplate><%#Eval("unitNo").ToString()==""?"Not Applicable":Eval("unitNo") %></ItemTemplate>
                        </telerik:GridTemplateColumn>

                </Columns>
         </MasterTableView>
      </telerik:RadGrid>
   </div>
 </asp:Content>
