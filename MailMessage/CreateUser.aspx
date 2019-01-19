<%@ Page Title="Create User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="MailMessage.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validate() {
            var Fname = document.getElementById('<%=txtFname.ClientID%>').value;
            var Lname = document.getElementById('<%=txtLname.ClientID%>').value;
            var email = document.getElementById('<%=txtEmail.ClientID%>').value;
            var userid = document.getElementById('<%=txtuserid.ClientID%>').value;
            var pwd = document.getElementById('<%=txtPwd.ClientID%>').value;
            var PhoneNo = document.getElementById('<%=txtPhoneNo.ClientID%>').value;
            var EmailLimit = document.getElementById('<%=txtEmailLimit.ClientID%>').value;
            if (Fname == "") {
                alert("please enter First Name!!");
               document.getElementById('<%=txtFname.ClientID%>').focus();
                return false;
            }
            if (Lname == "") {
                alert("please enter Last Name!!");
                document.getElementById('<%=txtLname.ClientID%>').focus();
                return false;
            }
            if (email == "") {
                alert("please enter Email!!");
               document.getElementById('<%=txtEmail.ClientID%>').focus();
                return false;
            }
            if (userid == "") {
                alert("please enter UserId!!");
               document.getElementById('<%=txtuserid.ClientID%>').focus();
                return false;
            }
            if (pwd == "" ) {
                alert("please enter Password!!");
                document.getElementById('<%=txtPwd.ClientID%>').focus();
                return false;
            }
            if (pwd.length <8 ) {
                alert("Password length should be from 8 to 20 !!");
                document.getElementById('<%=txtPwd.ClientID%>').focus();
                return false;
            }
            
            if (PhoneNo == "") {
                alert("please enter Phone!!");
               document.getElementById('<%=txtPhoneNo.ClientID%>').focus();
                return false;
            }
            if (EmailLimit == "") {
                alert("please enter Email Limit!!");
                document.getElementById('<%=txtEmailLimit.ClientID%>').focus();
                return false;
            }
            return true;
        }
    </script>
    <div class="jumbotron">

        <div>
            <label for="txtFname" class="form-control label label-default">First Name</label>
            <asp:TextBox ID="txtFname" CssClass="form-control input-sm" runat="server" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div>
            <label for="txtLname" class="form-control label label-default">Last Name</label>
            <asp:TextBox ID="txtLname" CssClass="form-control input-sm" runat="server" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div>
            <label for="txtEmail" class="form-control label label-default">EmailId</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control input-sm" runat="server" TextMode="Email"></asp:TextBox>
        </div>
         <div>
            <label for="txtuserid" class="form-control label label-default">UserId</label>
            <asp:TextBox ID="txtuserid" CssClass="form-control input-sm" runat="server" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div>
            <label for="txtPwd" class="form-control label label-default">Password</label>
            <asp:TextBox ID="txtPwd" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <label for="txtPhoneNo" class="form-control label label-default">Phone Number</label>
            <asp:TextBox ID="txtPhoneNo" CssClass="form-control input-sm" runat="server" TextMode="Phone"></asp:TextBox>
        </div>
        <div>
            <label for="rblRole" class="form-control label label-default">Role</label>
            <asp:RadioButtonList ID="rblRole" runat="server">
                <asp:ListItem Text="User" Value="User" Selected="True">
                </asp:ListItem>
                <asp:ListItem Text="ReSeller" Value="Admin" />
            </asp:RadioButtonList>

        </div>
        <div>
            <label for="txtEmailLimit" class="form-control label label-default">Email Limit</label>
            <asp:TextBox ID="txtEmailLimit" CssClass="form-control input-sm" runat="server"></asp:TextBox>
        </div>

        <asp:Button ID="btncreateuser" runat="server" CssClass="btn btn-primary" Text="Create User" OnClientClick="javascript:return validate()" OnClick="btncreateuser_Click" />
    </div>
</asp:Content>
