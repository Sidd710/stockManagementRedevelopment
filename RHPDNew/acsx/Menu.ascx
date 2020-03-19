<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="RHPDNew.acsx.Menu1" %>


<div id="throbber" style="display: none; min-height: 120px;"></div>
<div id="noty-holder"></div>
<div id="wrapper">
    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="http://cijulenlinea.ucr.ac.cr/dev-users/">
                <img src="../assets/logo/logo.png" style="height: 50px;" alt="LOGO">
            </a>
        </div>
        <!-- Top Menu Items -->
        <ul class="nav navbar-right top-nav">
            <%--<li><a href="#" data-placement="bottom" data-toggle="tooltip" href="#" data-original-title="Stats"><i class="fa fa-bar-chart-o"></i>--%>
            </a>
            </li>
            <li class="dropdown">
                <a id="Logout" style="color: white  !important" runat="server" href="~/logout.aspx">Log out <b></b></a>
                <%--<ul class="dropdown-menu">
                    <li><a href="#"><i class="fa fa-fw fa-user"></i>Edit Profile</a></li>
                    <li><a href="#"><i class="fa fa-fw fa-cog"></i>Change Password</a></li>
                    <li class="divider"></li>
                    <li><a href="#"><i class="fa fa-fw fa-power-off"></i>Logout</a></li>
                </ul>--%>
            </li>
        </ul>
        <!-- Sidebar Menu Items - These collapse to the responsive navigation menu on small screens -->
        <div class="collapse navbar-collapse navbar-ex1-collapse">
            <ul class="nav navbar-nav side-nav">
                <li>
                    <a href="../Forms/Home.aspx"><i class="fa fa-fw fa-user-plus"></i>Dashboard</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-fw fa-user-plus"></i>Shed Wise Monitoring</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-fw fa-search"></i>Items</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-fw fa-search"></i>ESL</a>
                </li>

                <li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-0"><i class="fa fa-fw fa-search"></i>Officer Board <i class="fa fa-fw fa-angle-down pull-right"></i></a>
                    <ul id="submenu-0" class="collapse">
                        <li><a href="#"><i class="fa fa-angle-double-right"></i>Central Purchase</a></li>
                        <li><a href="#"><i class="fa fa-angle-double-right"></i>Local Purchase</a></li>
                        <li><a href="#"><i class="fa fa-angle-double-right"></i>IDT IN</a></li>
                        <li><a href="#"><i class="fa fa-angle-double-right"></i>IDT OUT</a></li>
                    </ul>
                </li>
                   <li>
                    <a href="#"><i class="fa fa-fw fa-search"></i>MOT</a>
                </li>
                <li>

                    <a href="#" data-toggle="collapse" data-target="#submenu-1"><i class="fa fa-fw fa-search"></i>Master <i class="fa fa-fw fa-angle-down pull-right"></i></a>
                    <ul id="submenu-1" class="collapse">
                        <%--<li><a href="../Forms/FrmCommandMaster.aspx"><i class="fa fa-angle-double-right"></i>Command Master</a></li>
                        <li><a href="../Forms/ManageFormation.aspx"><i class="fa fa-angle-double-right"></i>Manage Formation</a></li>
                        <li><a href="../Forms/AddDepu.aspx"><i class="fa fa-angle-double-right"></i>Manage Depot</a></li>
                        <li><a href="../Forms/AddUnit.aspx"><i class="fa fa-angle-double-right"></i>Manage Unit</a></li>--%>
                        <li><a href="../Forms/AddCategorytype.aspx"><i class="fa fa-angle-double-right"></i>Manage Category Type</a></li>
                        <li><a href="../Forms/categorymaster.aspx"><i class="fa fa-angle-double-right"></i>Manage Category</a></li>
                        <li><a href="../Forms/addproduct.aspx"><i class="fa fa-angle-double-right"></i>Manage Product</a></li>
                        <%--<li><a href="../Forms/SupplierMgmt.aspx"><i class="fa fa-angle-double-right"></i>Manage Supplier</a></li>
                        <li><a href="../Forms/frmOriginalManufacture.aspx"><i class="fa fa-angle-double-right"></i>Manage Original Manufacture</a></li>
                        <li><a href="../StockOutPanel/Vechilemaster.aspx"><i class="fa fa-angle-double-right"></i>Manage Vehicle</a></li>
                        <li><a href="../Forms/frmPMName.aspx"><i class="fa fa-angle-double-right"></i>Manage PM Name</a></li>
                        <li><a href="../Forms/frmPMCapacity.aspx"><i class="fa fa-angle-double-right"></i>Manage PM Capacity</a></li>
                        <li><a href="../Forms/frmPMGrade.aspx"><i class="fa fa-angle-double-right"></i>Manage PM Grade</a></li>
                        <li><a href="../Forms/frmPMCondition.aspx"><i class="fa fa-angle-double-right"></i>Manage PM Condition</a></li>--%>
                        <li><a href="../Forms/frmWarehouse.aspx"><i class="fa fa-angle-double-right"></i>Manage Warehouse</a></li>
                        <li><a href="../Forms/frmSection.aspx"><i class="fa fa-angle-double-right"></i>Manage Warehouse Sections</a></li>
                        <%--<li><a href="../Forms/frmPMContainerMaster.asp"><i class="fa fa-angle-double-right"></i>Manage PM & Containers</a></li>
                        <li><a href="../Forms/frmAddPMContainer.aspx"><i class="fa fa-angle-double-right"></i>Add PM & Containers</a></li>--%>
                    </ul>
                </li>
                <%--  <li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-2"><i class="fa fa-fw fa-search"></i>Users <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-2" class="collapse">


                        <li><a href="../Forms/DepartmentMaster.aspx"><i class="fa fa-angle-double-right"></i>Manage Group/Section</a></li>
                        <li><a href="../Forms/AddRole.aspx"><i class="fa fa-angle-double-right"></i>Manage Role</a></li>
                        <li><a href="../Forms/AddUser.aspx"><i class="fa fa-angle-double-right"></i>Manage User</a></li>
                    </ul>
                </li>--%>

                <li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-3"><i class="fa fa-fw fa-search"></i>Stock <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-3" class="collapse">
                        <li><a href="../Forms/StockInMonitor.aspx"><i class="fa fa-angle-double-right"></i>Stock In</a></li>
                        <li><a href="../Forms/StockOutMonitor.aspx"><i class="fa fa-angle-double-right"></i>Stock Out</a></li>
                        <%--        <li><a href="../Forms/Stock.aspx"><i class="fa fa-angle-double-right"></i>Stock In</a></li>
                        <li><a href="../Forms/CRVLIST.aspx"><i class="fa fa-angle-double-right"></i>CRV List</a></li>
                        <li><a href="../Forms/frmPMList.aspx"><i class="fa fa-angle-double-right"></i>PM List</a></li>
                        <li><a href="../Forms/frmExpenseVoucherList.aspx"><i class="fa fa-angle-double-right"></i>Expense Voucher List</a></li>
                        <li><a href="../StockOutPanel/frmMonitoringStock.aspx"><i class="fa fa-angle-double-right"></i>Stock Out Monitoring</a></li>--%>
                    </ul>
                </li>
                <%--<li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-4"><i class="fa fa-fw fa-search"></i>ESL <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-4" class="collapse">

                        <li><a href="../Forms/ESL.aspx"><i class="fa fa-angle-double-right"></i>Pending Esl</a></li>
                        <li><a href="../Forms/ESLIssueStatus.aspx"><i class="fa fa-angle-double-right"></i>Manage ESL</a></li>
                        <li><a href="../Forms/ESLStatus.aspx"><i class="fa fa-angle-double-right"></i>Esl List</a></li>



                    </ul>
                </li>--%>
                <%-- <li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-5"><i class="fa fa-fw fa-search"></i>Issue Order <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-5" class="collapse">

                        <li><a href="../StockOutPanel/IssueOrderList.aspx"><i class="fa fa-angle-double-right"></i>Issue Order List</a></li>



                    </ul>
                </li>--%>
                <%--<li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-6"><i class="fa fa-fw fa-search"></i>Issue Voucher <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-6" class="collapse">

                        <li><a href="../StockOutPanel/IssueVoucherList.aspx"><i class="fa fa-angle-double-right"></i>Issue Voucher List</a></li>



                    </ul>
                </li>--%>
                <%--<li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-7"><i class="fa fa-fw fa-search"></i>Load Tally <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-7" class="collapse">

                        <li><a href="../StockOutPanel/loadTallyList.aspx"><i class="fa fa-angle-double-right"></i>Load Tally</a></li>
                           <li><a href="../StockOutPanel/loadtallyNumberlist.aspx"><i class="fa fa-angle-double-right"></i>Load Tally List</a></li>



                    </ul>
                </li>--%>
                <%--<li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-8"><i class="fa fa-fw fa-search"></i>Gate <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-8" class="collapse">

                        <li><a href="../Forms/GateRegister.aspx"><i class="fa fa-angle-double-right"></i>Register Gat In/Out</a></li>
                           <li><a href="../Forms/GatRegisterList.aspx"><i class="fa fa-angle-double-right"></i>Issued Gat In/Out</a></li>



                    </ul>
                </li>--%>
                <%-- <li>
                    <a href="#" data-toggle="collapse" data-target="#submenu-9"><i class="fa fa-fw fa-search"></i>Authority <i class="fa fa-fw fa-angle-down pull-right"></i></a>

                    <ul id="submenu-9" class="collapse">

                        <li><a href="../StockOutPanel/Authoritymaster.aspx"><i class="fa fa-angle-double-right"></i>Manage Authority</a></li>
                           


                    </ul>
                </li>--%>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </nav>
    <%--<img src="Logo/logo1.png" style="height: 60px; width: 60px;margin-right:107px;margin-bottom:-64px;float:right;margin-top:-66px;" />
<div style="margin-top: 0px;border:1px solid blue">--%>










    <!-- Nav end -->
