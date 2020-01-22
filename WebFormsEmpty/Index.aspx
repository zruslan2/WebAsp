<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebFormsEmpty.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="+" />
                    <asp:BoundField DataField="Id" HeaderText="Код страны" />
                    <asp:BoundField DataField="Name" HeaderText="Страна" />
                    <asp:BoundField DataField="Capital" HeaderText="Столица" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#FFFFCC" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <%--<asp:Button ID="btAdd" runat="server" Text="Добавить" OnClick="btAdd_Click" />--%>
        </div>

         <br />
        <div>
            <asp:Button ID="btnAdd" runat="server" Text="Добавить" OnClick="btnAdd_Click" />
            <asp:Button ID="btnRemove" runat="server" Text="Удалить" OnClick="btnRemove_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Обновить" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnFind" runat="server" Text="Найти" OnClick="btnFind_Click" />
        </div>
        <br />
        <table>
            <tr>
                <td><span>Код</span></td>
                <td>  <asp:TextBox ID="tbxId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span>Страна</span></td>
                <td><asp:TextBox ID="tbxCountry" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span>Сталица</span> </td>
                <td><asp:TextBox ID="tbxCapital" runat="server"></asp:TextBox></td>
            </tr>
        </table>
    </form>
</body>
</html>
