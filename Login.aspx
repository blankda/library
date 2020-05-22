<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtName"
                ErrorMessage="账号不能为空"></asp:RequiredFieldValidator>
            <br />
            密码：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
            <br />
            用户类型：<asp:RadioButtonList ID="RadioButtonList1" runat="server" DataTextField="type" DataValueField="type" RepeatDirection="Horizontal">
                <asp:ListItem>reader</asp:ListItem>
                <asp:ListItem>admin</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click"/>
        &nbsp
        <asp:Button ID="Button2" runat="server" Text="取消" />
        <br />
    </form>
</body>
</html>
