<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication19.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    fokeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" style="text-align: center"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="deconnect" />
        </div>
        <div style="text-align: left">
            <asp:TextBox ID="TextBox1" runat="server" Height="47px" Width="254px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dms2ConnectionString %>" SelectCommand="SELECT * FROM [share] WHERE ([id] = @id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label2" Name="id" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                    <asp:BoundField DataField="shared" HeaderText="shared" SortExpression="shared" />
                </Columns>
            </asp:GridView>
            <br />
            
            <br />
        </div>
    tahttttttttttttttttttttttttt
   </asp:Content>
