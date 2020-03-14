<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu1.ascx.cs" Inherits="RHPDNew.acsx.Menu" %>

<!------ Navigation Starts ----->
<%--<div class="navbar navbar-inverse navbar-fixed-top sticky">
    <div class="container">
        <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <div class="collapse navbar-collapse navHeaderCollapse nav-cont">
            <ul class="nav navbar-nav pull-right">
                <li class="dropdown">
                    <a id="home" runat="server" href="../Forms/Home.aspx" class="dropdown-toggle">HOME </a>
                </li>
                <li>
                    <a href="#" id="managemaster" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE MASTER <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/FrmCommandMaster.aspx">Manage Command</a></li>
                        <li><a href="../Forms/ManageFormation.aspx">Manage Formation</a></li>
                        <li><a href="../Forms/AddDepu.aspx">Depot</a></li>
                        <li><a href="../Forms/AddUnit.aspx">Unit</a></li>
                        <li><a href="../Forms/AddCategorytype.aspx">Category Type</a></li>
                        <li><a href="../Forms/categorymaster.aspx">Category</a></li>
                        <li><a href="../Forms/addproduct.aspx">Product</a></li>
                        <li><a href="../Forms/SupplierMgmt.aspx">Manage Supplier</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" id="manageuser" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE USERS <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/DepartmentMaster.aspx">Group/Section</a></li>
                        <li><a href="../Forms/AddRole.aspx">Role</a></li>
                        <li><a href="../Forms/AddUser.aspx">User</a></li>

                    </ul>
                </li>
                <li>
                    <a id="managestock" runat="server" href="../Forms/Stock.aspx">MANAGE STOCK</a>
                </li>
                 <li>
                    <a id="A1" runat="server" href="../Forms/CRVLIST.aspx">CRV LIST</a>
                </li>

                <li>
                    <a href="#" id="manageesl" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE ESL <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/ESL.aspx">Pending Esl</a></li>
                        <li><a href="../Forms/ESLIssueStatus.aspx">Manage ESL</a></li>
                        <li><a href="../Forms/ESLStatus.aspx">Esl List</a></li>
                    </ul>
                </li>
                <li>
                    <a id="stockissue" runat="server" href="../Forms/StockTransformation.aspx">STOCK ISSUE</a>
                </li>
                <li>
                    <a id="approvstock" runat="server" href="../Forms/FrmViewIndent.aspx">APPROV STOCK</a>
                </li>

                <li>
                    <a href="#" id="managevoucher" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE VOUCHER<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/IssueVoucherList.aspx">Generate Issue Voucher</a></li>
                        <li><a href="../Forms/IssuedVoucherList.aspx">Issued Voucher List</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" id="managetally" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE TALLY<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/frmTallyDetails.aspx">Generate Tally List</a></li>
                        <li><a href="../Forms/ManageTallyList.aspx">Issued Tally List</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" id="managegate" runat="server" data-toggle="dropdown" class="dropdown-toggle">MANAGE GATE<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/GateRegister.aspx">Register Gat In/Out</a></li>
                        <li><a href="../Forms/GatRegisterList.aspx">Issued Gat In/Out</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" data-toggle="dropdown" class="dropdown-toggle">ISSUED PRODUCTS <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../Forms/IssueVoucherList.aspx">Issue Voucher List</a></li>
                         <li><a href="../Forms/IssueVoucherGenrate.aspx">Generate Issue Voucher</a> </li>
                        <li><a href="../Forms/frmTallyDetails.aspx">Issue Tally List </a></li>
                          <li><a href="../Forms/ManageTallyDetails.aspx"></a> Manage Tally Sheet</li>
                        <li><a href="../Forms/GateIssuedVoucherList.aspx">Register Voucher List </a></li>
                        <li><a href="../Forms/GateIssuedVoucherList.aspx"></a> Gate In/out Register </li>
                         <li><a href="../Forms/GateRegister.aspx">Gate In/Out</a></li>
                    </ul>
                </li>
                 <li>
                    <a href="#" data-toggle="dropdown" class="dropdown-toggle">Print Product <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li> <a href="../Forms/IssuedVoucherList.aspx"> Issued Voucher List</a></li>
                         <li><a href="../Forms/IssueVoucherGenrate.aspx">Generate Issue Voucher</a> </li>

                        <li><a href="../Forms/ManageTallyList.aspx">Manage Tally List</a></li>
                          <li><a href="../Forms/ManageTallyDetails.aspx"></a> Manage Tally Sheet</li>
                        
                        <li><a href="../Forms/GatRegisterList.aspx">Gat Register List</a></li>
                        <li><a href="../Forms/GateIssuedVoucherList.aspx"></a> Gate In/out Register </li>
                    </ul>
                </li>
                <li>
                    <a id="crv" runat="server" href="../Forms/CRV.aspx">CRV</a>
                </li>

                <li>
                    <a href="#" id="contact" runat="server" visible="false">CONTACT US</a>
                </li>
                <li>
                    <a id="Logout" runat="server" href="~/logout.aspx">LOG OUT</a>
                </li>
                <li>
                    <a href="../StockOutPanel/frmMonitoringStock.aspx">STOCKOUT MONITORING</a>
                </li>
                <li>
                    <a href="../StockOutPanel/IssueOrderList.aspx">ISSUE ORDER LIST</a>
                </li>
                <li>
                    <a href="../StockOutPanel/IssueVoucherList.aspx">ISSUE VOUCHER LIST</a>
                </li>
                <li>
                    <a href="../StockOutPanel/loadTallyList.aspx">LOAD TALLY</a>
                </li>
                <li>
                    <a href="../StockOutPanel/loadtallyNumberlist.aspx">LOAD TALLY LIST</a>
                </li> 
                <li>
                    <a href="../StockOutPanel/Vechilemaster.aspx">VEHICLE MASTER</a>
                </li>
                <li>
                     <a href="../StockOutPanel/frmMonitoringStock.aspx">STOCKOUT MONITORING<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="../StockOutPanel/frmMonitoringStock.aspx">STOCKOUT MONITORING</a></li>
                        <li> <a href="../StockOutPanel/IssueOrderList.aspx">ISSUE ORDER LIST</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</div>--%>

<div id="nav">
    <div id="nav_wrapper">
        <ul>
            <li><a href="#">item #1</a>
            </li>
            <li> <a href="#">item #2</a>
            </li>
            <li> <a href="#">dropdown #1</a>

                <ul>
                    <li><a href="#">dropdown #1 item #1</a>
                    </li>
                    <li><a href="#">dropdown #1 item #2</a>
                    </li>
                    <li><a href="#">dropdown #1 item #3</a>
                    </li>
                </ul>
            </li>
            <li> <a href="#">dropdown #2</a>

                <ul>
                    <li><a href="#">dropdown #2 item #1</a>
                    </li>
                    <li><a href="#">dropdown #2 item #2</a>
                    </li>
                    <li><a href="#">dropdown #2 item #3</a>
                    </li>
                </ul>
            </li>
            <li> <a href="#">item #3</a>
            </li>
        </ul>
    </div>
    <!-- Nav wrapper end -->
</div>
<!-- Nav end -->
<style>
#nav {
    background-color: #222;
}
#nav_wrapper {
    width: 960px;
    margin: 0 auto;
    text-align: left;
}
#nav ul {
    list-style-type: none;
    padding: 0;
    margin: 0;
    position: relative;
    min-width: 200px;
}
#nav ul li {
    display: inline-block;
}
#nav ul li:hover {
    background-color: #333;
}
#nav ul li a, visited {
    color: #CCC;
    display: block;
    padding: 15px;
    text-decoration: none;
}
#nav ul li:hover ul {
    display: block;
}
#nav ul ul {
    display: none;
    position: absolute;
    background-color: #333;
    border: 5px solid #222;
    border-top: 0;
    margin-left: -5px;
}
#nav ul ul li {
    display: block;
}
#nav ul ul li a:hover {
    color: #699;
}
</style>

<!----- Navigation Ends ----->