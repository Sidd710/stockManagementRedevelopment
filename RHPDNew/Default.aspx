<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RHPDNew._Default" %>

<!DOCTYPE >

<html >
<head runat="server">
    <title>ZEALOUS REFUELERS</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    
    <script src="assets/js/jquery.min.js"  type="text/javascript"></script>
    <script src="assets/js/bootstrap.js" type="text/javascript"></script>

    <%--<style>
        body{background:url(assets/images/warehouseasc.jpg) no-repeat;background-size:cover;}
    </style>--%>
    <script type="text/javascript" src="assets/js/background.cycle.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("body").backgroundCycle({
                imageUrls: [
                    'assets/images/flag.jpg',
                    'assets/images/warehouseasc.jpg',
                    'assets/images/siachen-19.jpg',
                     'assets/images/flag.jpg',
                    'assets/images/warehouseasc.jpg',                   
                    'assets/images/siachen-19.jpg'
                ],
                fadeSpeed: 2000,
                duration: 5000,
                backgroundSize: SCALING_MODE_COVER
            });
        });
    </script>
</head>
<body>
    <div class="container-fluid">
        <div class="container">
             <div id="logod" style="float:left;form-group-2">
               <%-- <span>RHPD</span><br />--%>
                <%--<img src="Images/logo.png"  style="height:120px;width:100px"/>--%>

               <%-- Logo Here--%>
            </div>
            
            <div id="logo" class="pull-right">
               <%-- <span>RHPD</span><br />--%>
                <%--<img src="Images/logo1.png"  style="height:120px;width:100px"/>--%>

               <%-- Logo Here--%>
            </div>
        </div>
    </div>
    
    <div class="container-fluid">
        <div class="container">
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row">
                    <div class="container">
                        <div class="row">
                            <div class="loginBox">
                                <div class="welcome_note">
                                    <h1>Welcome to RHPD</h1>
                                </div>
                                <div class="loginPageOuter">
                                    
                                    <asp:TextBox Style="font-size: 13px !important;
    margin: 54px -20px 10px !important;
    padding: 11px !important;color: #000 !important;width:400px !important;height:37.2px !important" runat="server" ID="UserName" placeholder="Username" ></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                   
                                       
                                     <div class="clear" style="margin-bottom:0px;"></div>
                                    <asp:TextBox Style="font-size: 13px !important;    margin: -16px -20px 10px !important; padding: 11px !important;color: #000 !important;
                                       width:400px !important;height:38.2px !important" runat="server" TextMode="Password" ID="Password" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-12" style="color:#fff;margin-top:19px !important;margin-left:-3px !important;"">
                                     <asp:CheckBox runat="server" Text="Remember Me" ID="RememberMe"></asp:CheckBox>
                                     <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </div>

                                <div class="col-md-12" style="margin-top:-10px !important;margin-left:148px !important;">
                                    <asp:Button style="background-color:darkslategray !important;border-color:darkslategray !important;"  runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton" OnClick="LoginButton_Click"></asp:Button>
                                    <%--<asp:Button style="background-color:darkolivegreen !important;border-color:white !important;"  runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton" OnClick="LoginButton_Click"></asp:Button>--%>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
          
                   <div style="float:right;width:50% !important">
                         <div class="clearfix"></div>
                        <%--<img src="Images/DSC.jpg" style="height:100%;width:100%; float:right;" />--%>
                    </div>

                </div>
            </form>
        </div>
    </div>
</body>
</html>
