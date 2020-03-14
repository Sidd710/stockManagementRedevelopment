<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RHPDNew.Forms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-wrapper">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row" id="main">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="card" style="width: 20rem;">
                                <%--<img class="card-img-top img-responsive" src="http://beta.iopan.co.uk/articles/images/cards/sans-serif.jpg" alt="Sans &amp; Sans-Serif">--%>
                                <div class="card-body">
                                    <h4 class="card-title">Shed 1</h4>
                                    <p class="card-text">3 Category types are available with 100 quantity</p>
                                    <a href="#" class="btn btn-primary">Get Details</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="card" style="width: 20rem;">
                                <%--<img class="card-img-top img-responsive" src="http://beta.iopan.co.uk/articles/images/cards/measure.jpg" alt="Measure">--%>
                                <div class="card-body">
                                    <h4 class="card-title">Stock Available</h4>
                                    <p class="card-text">Total quantity 125kg is available</p>
                                    <a href="#" class="btn btn-primary">Get Details</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="card" style="width: 20rem;">
                                <%--<img class="card-img-top img-responsive" src="http://beta.iopan.co.uk/articles/images/cards/tracking-kerning.jpg" alt="Tracking &amp; Kerning">--%>
                                <div class="card-body">
                                    <h4 class="card-title">Available Products</h4>
                                    <p class="card-text">75</p>
                                    <a href="#" class="btn btn-primary">Get Details</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12  ">
                            <div class="card" style="width: 20rem;">
                                <%--<img class="card-img-top img-responsive" src="http://beta.iopan.co.uk/articles/images/cards/leading.jpg" alt="Leading">--%>
                                <div class="card-body">
                                    <h4 class="card-title">Shed</h4>
                                    <p class="card-text">5</p>
                                    <a href="#" class="btn btn-primary">Get Details</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <style>
            .card {
                box-shadow: 0 4px 8px 0 rgba(0,0,0,0.4);
                transition: 0.3s;
                margin: 6%;
            }

                .card:hover {
                    box-shadow: 0 8px 16px 0 rgba(0,0,0,0.8);
                }

            .card-body {
                padding: 8px;
            }
        </style>
</asp:Content>
