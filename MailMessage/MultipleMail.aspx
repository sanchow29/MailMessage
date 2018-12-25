<%@ Page Title="Multiple Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultipleMail.aspx.cs" Inherits="MailMessage.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <style type="text/css">

        #div_MultiEmailGrid table
        {
            border:0;
        }

        #div_MultiEmailGrid table td 
        {
            border: 0;
        }

    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                //$("#emailTabs").tabs();
                // Apply asynchronous requests here
            }

            //$("#emailTabs").tabs();
            //$("#Multipleemailupd").filestyle({

            //    buttonName: 'btn-success',
            //    buttonText: 'Select File'

            //});

        });

        function validatemultipleemail() {

            if (document.getElementById("txtmultipletoemail").value == "") {
                alert("To email can not be blank");
                document.getElementById("<%=txtmultipletoemail.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("txtmulsub").value == "") {
                alert("Subject can't be blank");
                document.getElementById("txtmulsub").focus();
                return false;
            }
            if (document.getElementById("txtmultiplemessg").value == "") {
                alert("Message Field can't be blank");
                document.getElementById("txtmultiplemessg").focus();
                return false;
            }

            return true;

        }

    </script>

    <asp:UpdatePanel runat="server" ID="upnl_MailMarketingMaster" ChildrenAsTriggers="true"
        UpdateMode="Conditional" EnableViewState="true" ClientIDMode="Static">

        <ContentTemplate>

            <div class="container-fluid">

                <div id="Multipleemail_div" runat="server" style="display: block; margin-top: 10px; border: 2px solid grey; border-radius: 5px; padding: 5px;">

                    <div class="row">

                        <div class="col-md-9">

                            <div class="row">

                                <div class="col-md-3">
                                    <label>Upload Email IDs :</label>
                                </div>

                                <div class="col-md-4">

                                    <asp:FileUpload ID="Multipleemailupd" runat="server" AllowMultiple="false" EnableViewState="true" />
                                    <asp:Button runat="server" ToolTip="Download Sample Upload Format" ID="btn_bulkSampleExcel" Text="Check Sample Excel Format"
                                        CssClass="btn btn-link" EnableViewState="true" ViewStateMode="Enabled" Style="text-decoration: underline;position:relative;right:11px;" OnClick="btn_bulkSampleExcel_Click" />

                                </div>

                                <div class="col-md-3">

                                    <asp:Button ID="btn_upload" runat="server" CssClass="btn btn-primary" Text="Upload" OnClick="btn_upload_Click" style="padding:14px;" />

                                </div>

                            </div>

                            <div class="row" style="margin-top: 5px; display: none;">

                                <div class="col-md-3">
                                </div>

                            </div>

                            <div class="row" style="margin-top: 5px; display: none;">

                                <div class="col-md-3">
                                    <label>Sender List :</label>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtmultipletoemail" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>

                            </div>

                            <div class="row" style="margin-top: 5px;">

                                <div class="form-group">

                                    <div class="col-md-12">

                                        <label for="txtmulsub" class="label label-default form-control">Subject</label>

                                        <asp:TextBox ID="txtmulsub" runat="server" CssClass="form-control input-sm" style="max-width:1000px;"></asp:TextBox>

                                    </div>

                                </div>

                            </div>

                            <div class="row" style="margin-top: 5px;">

                                <div class="form-group">
                                    <div class="col-md-12">

                                        <label for="txtmultiplemessg" class="label label-default form-control">Body</label>

                                        <asp:TextBox ID="txtmultiplemessg" runat="server" TextMode="MultiLine"
                                            CssClass="form-control input-lg" style="height:11em;max-width:1000px;"></asp:TextBox>

                                    </div>
                                </div>

                            </div>

                            <div class="row" style="margin-top: 10px;">

                                <div class="col-md-3">
                                    <label>Attachments :</label>
                                </div>

                                <div class="col-md-4">
                                    <asp:FileUpload runat="server" ID="fileuploadAttachments_Multiple" AllowMultiple="true" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Button runat="server" ID="btn_uploadAttachments_Multiple" CssClass="btn btn-primary"
                                        EnableViewState="true" ViewStateMode="Enabled" Text="Upload Attachments" />
                                </div>

                            </div>

                            <div class="row" style="margin-top: 5px; display: none;">

                                <div class="col-md-3">
                                </div>

                            </div>

                            <div class="row" style="margin-top: 15px;">

                                <div class="col-md-4">
                                    <asp:Button ID="btnsendmultipleemail" runat="server" CssClass="btn btn-primary" Text="Send Multiple Email"
                                        OnClientClick="javascript:return validatemultipleemail()" OnClick="btnsendmultipleemail_Click" />
                                </div>

                            </div>

                        </div>

                        <div class="col-md-3" id="Displaygrid_Div" style="display:none;" runat="server">
                            
                            <label>Uploaded Email IDs :</label>

                            <div id="div_MultiEmailGrid" style="border:2px solid grey;padding:5px;border-radius:5px;max-height:450px;overflow-y:scroll;overflow-x:scroll;">

                                <asp:GridView runat="server" AutoGenerateColumns="false" 
                                    ViewStateMode="Enabled" EnableViewState="true" ID="grdview_MultiEmail"
                                     CssClass="table table-bordered table-condensed table-hover table-responsive">

                                    <Columns>

                                        <asp:BoundField DataField="PersonMailID" HeaderText="Member Mail ID" />

                                    </Columns>

                                </asp:GridView>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </ContentTemplate>

        <Triggers>

            <%--<asp:AsyncPostBackTrigger ControlID="radioButton_SinglePage" EventName="CheckedChanged" />
                    <asp:AsyncPostBackTrigger ControlID="radioButton_Multipage" EventName="CheckedChanged" />--%>
            <asp:PostBackTrigger ControlID="btn_upload" />

        </Triggers>

    </asp:UpdatePanel>

</asp:Content>
