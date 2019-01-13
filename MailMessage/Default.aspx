<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MailMessage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       <h2>Mail Dashboard</h2> 
      <div class="row"> 
          <div style="margin-top: 10px;" class="col-md-8" >
              <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                  <RowStyle BackColor="White" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView>
          </div>

        <div class="col-md-4" >
          <h2>Email Count</h2>  
            <div>
                <h4> Used Count:</h4><asp:Label ID="lblUsedcount" runat="server" ></asp:Label>
            </div>
            <div>
                 <h4> Asigned Count:</h4> <asp:Label ID="lblAsignedcount" runat="server" ></asp:Label>
            </div>
        </div>
          </div>
    </div>

      
</asp:Content>
