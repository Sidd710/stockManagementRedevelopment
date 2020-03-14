<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rhpd.ascx.cs" Inherits="RHPDNew.StockOutPanel.rhpd" %>
               <style>
table, th, td {
    border: 1px solid black;
    padding: 9px
}


.button-success {
            background: blue; /* this is a green */
             border-radius: 8px;
            text-shadow: 0 2px 2px rgba(0, 0, 0, 0.2);
        }
          </style>
 
        <table style="width:100%" align="center" class="customers" >

        <tr>
            <td >
<label class="thicker" >
   <b> Financial Year :</b>
</label>
            

       
            <asp:DropDownList runat="server" ID="ddlyear" AutoPostBack="true" CssClass="dropdown" style="height: 35px;width: 160px;" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"  >
                <asp:ListItem Value="0">--Select--</asp:ListItem>
            </asp:DropDownList>
      </td>
            
            <td>

       <label class="thicker" >
   <b> Order Type:</b>
</label>
            <asp:DropDownList runat="server" ID="ddlordertype" AutoPostBack="true" CssClass="dropdown" style="height: 35px;width: 160px;" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged" >
                <asp:ListItem Value="0">--Select--</asp:ListItem>
            </asp:DropDownList>
      </td>
            </tr>
            <tr style="display:none">
            <td colspan="1">
          <table style="width:35%;background-color:greenyellow" align="center">
    <tr>
        <td>
            <asp:Label ID="lbltext" runat="server" style="font-size: xx-large;"></asp:Label>
        </td>
    </tr>
</table>
           </td>
            </tr>
            </table>


     