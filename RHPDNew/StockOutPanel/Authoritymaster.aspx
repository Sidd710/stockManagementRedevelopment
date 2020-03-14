<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="Authoritymaster.aspx.cs" Inherits="RHPDNew.StockOutPanel.Authoritymaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
table, th, td {
    border: 1px solid black;
    padding: 9px
}
        </style>
    <br />
    <br />
    <br />
    <br />
     <div class="heading-bg" align="center" >
        <div class="container">
            <h1  style="background-color:skyblue;color:white">Authority Master</h1>
            
        </div>
    </div>
    <br />
    <br />
    <div id="divbuttonaddathurity" runat="server">
        <asp:Button ID="btnclick" runat="server" Text="Click to Add Authority"  CssClass="btn btn-primary" OnClick="btnclick_Click" ToolTip="Click here to Add Authority" style="float:right;padding: 10px;
    margin-right: 795px;
    background-color: green;" />
    </div>
     <br />
    <br />

    <div id="athoritypanel" runat="server">

                <table style="width:65%" align="center" class="customers" >

        <tr>
            <td height="50">
<label class="thicker" style="font-size:large">
   <b> Select Financial Year:</b>
</label>
            </td>

            <td height="50">

       
            <asp:DropDownList runat="server" ID="ddlyear" AutoPostBack="true" CssClass="dropdown" style="height: 35px;width: 160px;" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"  >
                <asp:ListItem Value="0">Select Financial Year</asp:ListItem>
            </asp:DropDownList>
      </td>
            </tr>
            </table>
       <br />
       <br />
      
  <table style="width:65%" align="center" class="customers" >

        <tr>
            <td height="50">
<label class="thicker" style="font-size:large">
   <b> Select Order Type:</b>
</label>
            </td>

            <td height="50">

       
            <asp:DropDownList runat="server" ID="ddlordertype" AutoPostBack="true" CssClass="dropdown" style="height: 35px;width: 160px;" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged" >
                <asp:ListItem Value="0">Select Order Type</asp:ListItem>
            </asp:DropDownList>
      </td>
            </tr>
            </table>

         <br />
       <br />


          <table width="100%" runat="server" id="Table1" class="idtTable">
                    <tr>
                        <td colspan="4">
                            <asp:RadioButtonList ID="rdoBtnLstQuarters" Width="100%" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="4"   runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
              </table>
        
         <br />
       <br />
          <table style="width:65%" align="center" class="customers" >

        <tr>
            <td height="50">
<label class="thicker" style="font-size:large">
   <b> Enter Authority:</b>
</label>
            </td>
             <td height="50">
                 <asp:TextBox ID="txtAuthority" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>

            </td>
        </tr>
           <tr>
                 <td height="50">
<label class="thicker" style="font-size:large">
   <b> Mark Active/Inactive:</b>
</label>
            </td>
               <td>
                   <asp:CheckBox ID="chkactive" runat="server" />
               </td>
               
           </tr>
        </table>
    
     
       <br />
       <br />
     <div align="center">
             <asp:Button ID="btnaddAuthority" runat="server" Text="Add Authority" class="btadd" CssClass="btn btn-primary" style="padding: 7px 22px;font-size: 18px;" OnClick="btnaddAuthority_Click"/>
         <asp:Button ID="btncamnce" runat="server" Text="Cancel" class="btadd" CssClass="btn btn-primary" style="padding: 7px 22px;font-size: 18px; background-color:red" OnClick="btncamnce_Click"/>
            </div>
        </div>
     <br />
       <br />
     <div id="GridAuth_" runat="server" >

         <asp:GridView ID="grdAuth" runat="server" EmptyDataText="No data found !" CssClass="grdvechileCss"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
                        AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                        PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
                        Width="100%" OnRowCommand="grdAuth_RowCommand" 
                       >

            <Columns> 
                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblsno" CssClass="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>' ItemStyle-HorizontalAlign="Center" > </asp:Label>
                    </ItemTemplate>
                     <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Authority" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblAuthority" runat="server" Text='<%# Eval("AuthorityName") %>' CssClass="lblthr" Font-Bold="true">
                        </asp:Label>
                      
                    </ItemTemplate>
                     <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblCreateddate" runat="server" Text='<%# Eval("Createddate") %>' CssClass="lblvec">
                        </asp:Label>
                       
                    </ItemTemplate>
                     <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modified Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblModifieddate"   runat="server" Text='<%# Eval("modifieddate") %>' CssClass="lbldrv">
                        </asp:Label>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />

                </asp:TemplateField>

               <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblstatus"   runat="server" Text='<%# Eval("Active") %>' CssClass="lbldrv">
                        </asp:Label>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Financial Year" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblfynyear"   runat="server" Text='<%# Eval("Fyear") %>' CssClass="lbldrv">
                        </asp:Label>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />

                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Order Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblordertype"   runat="server" Text='<%# Eval("AttributeName") %>' CssClass="lbldrv" Font-Bold="true">
                        </asp:Label>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit Here" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Highlight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit"   runat="server" Text="Edit Record" CommandName="editAuthority" CommandArgument='<%# Eval("Auid") %>' ToolTip="click here to edit" CssClass="lbldrv" Font-Bold="true">
                        </asp:LinkButton>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />

                </asp:TemplateField>
             
            </Columns>
            <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
            <RowStyle CssClass="stm_dark" />
            <HeaderStyle CssClass="stm_head" />
        </asp:GridView>
         </div>
</asp:Content>
