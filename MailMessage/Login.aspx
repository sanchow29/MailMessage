<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MailMessage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mail Marketing Campaign</title>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
        #div_loginContainer {
            border: 2px solid grey;
            border-radius: 5px;
            max-width: 500px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
        }
    </style>
       <script type="text/javascript">

           function validate() {
            
            var Fname = document.getElementById('<%=UserName.ClientID%>').value;
            var Lname = document.getElementById('<%=Password.ClientID%>').value;
               if (Fname == "") {
                alert("please enter User Id to proceed!!");
                document.getElementById('<%=UserName.ClientID%>').focus();
                return false;
            }
            if (Lname == "") {
                alert("please enter Password to proceed!!");
                document.getElementById('<%=Password.ClientID%>').focus();
                return false;
            }
            
            return true;
            
           }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">

            <%--<div class="navbar navbar-inverse navbar-fixed-top">

                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server" href="~/">Mail Messaging</a>
                    </div>
                    
                </div>

            </div>--%>

            <%--<asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">

                <LayoutTemplate>--%>

                    <div class="container" id="div_loginContainer">

                        <div class="row">

                            <div class="col-md-12" style="text-align: center;">

                                <h1 style="background-color: #101010; color: #9d9d9d; padding: 10px; border: 2px solid #101010; border-radius: 5px;">Please Login</h1>
                                <hr />

                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-12" style="text-align: center;">
                                
                                <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-lg"
                                    placeholder="User Id"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>--%>

                            </div>

                        </div>

                        <div class="row" style="margin-top:15px;">

                            <div class="col-md-12" style="text-align: center;">
                                 
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control input-lg"
                                    placeholder="Password"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>--%>

                            </div>

                        </div>

                        <div class="row" style="margin-bottom: 10px;margin-top:15px;">

                            <div class="col-md-12">

                                <asp:Button ID="LoginButton" runat="server" CommandName="Login"
                                    Text="Log In" OnClientClick="javascript:return validate()" ValidationGroup="Login1" CssClass="btn btn-primary form-control" OnClick="LoginButton_Click" />

                            </div>

                        </div>

                        <%--<div class="row">

                            <div class="col-md-12">
                                <p>&copy; 2018 - Mail Marketing Campaign</p>
                            </div>

                        </div>--%>
                    </div>

                <%--</LayoutTemplate>

            </asp:Login>--%>

            <div style="position: fixed; bottom: 0; left: 50%; transform: translate(-50%,-50%);">

                <p>&copy; <%: DateTime.Now.Year %> - Mail Marketing Campaign</p>

            </div>

        </div>
    </form>
</body>
</html>
