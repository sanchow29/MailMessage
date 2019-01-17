<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MailMessage._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }

            table th {
                background-color: #B8DBFD;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
                text-align: center;
            }

            table, table table td {
                border: 0px solid #ccc;
            }
    </style>
    <div class="col-md-12">

        <%-- <h2>Mail Dashboard</h2>--%>
        <div class="col-md-12">

            <div class="col-md-6" style="margin-top=10px">
                <%--<div class="row">--%>
                <%-- <div style="margin-top: 10px;" class="col-md-8">--%>
                <%--  <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>--%>
                <h2>Detailed View</h2>
                <div id="dvGrid" style="padding: 10px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                DataKeyNames="Name"
                                PageSize="8" AllowPaging="true" OnPageIndexChanging="OnPaging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Count" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailId" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailLimit" runat="server" Text='<%# Eval("Role") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <%--</div>--%>


                <%-- </div>--%>
                <div class="row">
                    <h2>Count View</h2>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Used Count:" CssClass="lbl-primary"></asp:Label>
                        <asp:Label ID="lblUsedcount" runat="server" CssClass="btn-danger"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Asigned Count:" CssClass="lbl-primary"></asp:Label>
                        <asp:Label ID="lblAsignedcount" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="col-md-6" style="margin-top:10px">

                <h2>Graph View</h2>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Select Chart:" CssClass="lbl-primary"></asp:Label>

                    <asp:DropDownList ID="ddlChart" AutoPostBack="true" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddlChart_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="col-md-6">
                    <%-- <h2>Email Count</h2>--%>
                    <asp:Chart ID="Chart1" runat="server" Width="500px" Height="500px">
                        <%--<Titles>
                                <asp:Title Text="Email Count"></asp:Title>
                            </Titles>--%>
                        <Series>
                            <asp:Series Name="Series1" ChartArea="ChartArea1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="Date Time"></AxisX>
                                <AxisY Title="Email Count"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
