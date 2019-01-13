<%@ Page Title="Single Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleMail.aspx.cs" Inherits="MailMessage.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                //$("#emailTabs").tabs();
                // Apply asynchronous requests here
            }
            //$("#emailTabs").tabs();

        });

        function validatesingleemail() {  
             var sinsletoemail = document.getElementById('<%=txtsinsletoemail.ClientID%>').value;
            var singlesub = document.getElementById('<%=txtsinglesub.ClientID%>').value;
            var singlemessg = document.getElementById('<%=txtsinglemessg.ClientID%>').value;
          

            if (sinsletoemail == "") {
                alert("To Email can't be blank");
               document.getElementById('<%=txtsinsletoemail.ClientID%>').focus();
                return false;
            }
            if (singlesub == "") {
                alert("Subject can't be blank");
                document.getElementById('<%=txtsinglesub.ClientID%>').focus();
                return false;
            }
            if (singlemessg == "") {
                alert("Message Field can't be blank");
                document.getElementById('<%=txtsinglemessg.ClientID%>').focus();
                return false;
            }
            return true;
        }

    </script>

    <asp:UpdatePanel runat="server" ID="upnl_MailMarketingMaster" ChildrenAsTriggers="true"
        UpdateMode="Conditional" EnableViewState="true" ClientIDMode="Static">

        <ContentTemplate>

            <div class="container-fluid">

                <div id="Singlemail_div" runat="server" style="display: block; margin-top: 10px; border: 2px solid grey; border-radius: 5px; padding: 5px;">

                    <div class="row">

                        <div class="form-group">

                            <div class="col-md-12">

                                <label for="txtsinsletoemail" class="form-control label label-default">Email To</label>
                                <asp:TextBox ID="txtsinsletoemail" placeholder="Add recipients for eg. john@gmail.com , merry@gmail.com" runat="server"
                                    CssClass="form-control input-sm" Style="max-width: 1000px;"></asp:TextBox>

                            </div>

                        </div>

                    </div>

                    <div class="row" style="margin-top: 5px;">

                        <div class="form-group">

                            <div class="col-md-12">

                                <label for="txtsinglesub" class="label label-default form-control">Subject</label>
                                <asp:TextBox ID="txtsinglesub" runat="server" ViewStateMode="Enabled"
                                    EnableViewState="true" CssClass="form-control input-sm" Style="max-width: 1000px;"></asp:TextBox>

                            </div>

                        </div>

                    </div>

                    <div class="row" style="margin-top: 10px;">

                        <div class="form-group">

                            <div class="col-md-12">

                                <label for="txtsinglemessg" class="form-control label label-default">Message</label>
                                <asp:TextBox ID="txtsinglemessg" runat="server" TextMode="MultiLine" Height="12em"
                                    ViewStateMode="Enabled" EnableViewState="true" CssClass="form-control input-lg"
                                    Style="max-width: 1000px;"></asp:TextBox>

                            </div>

                        </div>

                    </div>

                    <div class="row" style="margin-top: 10px;">

                        <div class="col-md-2">
                            <label>Attachments :</label>
                        </div>

                        <div class="col-md-3">
                            <asp:FileUpload runat="server" ID="fileUploadAttachemnts_Single" AllowMultiple="true" />
                        </div>

                        <div class="col-md-2">
                            <asp:Button runat="server" ID="btn_Attchaments_Single" Text="Upload Attachments" CssClass="btn btn-primary"
                                ClientIDMode="Static" EnableViewState="true" ViewStateMode="Enabled" />
                        </div>

                    </div>

                    <div class="row" style="margin-top: 10px; display: none;">

                        <div class="col-md-2">
                        </div>

                    </div>

                    <div class="row" style="margin-top: 15px;">

                        <div class="col-md-5">
                            <asp:Button ID="btnsendsinglemail" runat="server" CssClass="btn btn-primary" Text="Send Email" OnClientClick="javascript:return validatesingleemail()" OnClick="btnsendsinglemail_Click" />
                        </div>

                    </div>

                    <div class="row" style="margin-top: 10px; margin-bottom: 5px;">

                        <div class="col-md-12">

                            <div style="border: 1px solid grey; padding: 10px;">

                                <span style="font-weight: bold; font-size: 13px; font-family: Verdana;">Please note it :-</span>

                                <ul style="list-style-type: square; margin-top: 10px; font-size: 12px; font-family: Verdana;">
                                    <li>Please insert only one email id..</li>
                                    <li>Use Bulk Email for more than one Email id.</li>
                                </ul>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </ContentTemplate>

        <Triggers>

            <%--<asp:AsyncPostBackTrigger ControlID="radioButton_SinglePage" EventName="CheckedChanged" />
                    <asp:AsyncPostBackTrigger ControlID="radioButton_Multipage" EventName="CheckedChanged" />--%>
            <%--<asp:PostBackTrigger ControlID="btn_upload" />--%>
        </Triggers>

    </asp:UpdatePanel>

</asp:Content>
