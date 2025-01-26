<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Surch_data.aspx.cs" Inherits="EMarket_Project.Surch_data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        #search{
            background-color:darkgray;
        }
        .auto-style4 {
            width: 5px;
        }
        h3{
           background-color:forestgreen;
           color:white;
        }
    </style>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
           <h3><asp:Image ID="imglogo2" runat="server" ImageUrl="~/Logo/logo3.jpg" Width="40px" Height="40px"/>  Market Details </h3>
            <table class="auto-style1">               
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td id="search">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="SEARCH" class="btn btn-success" />
&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="CLEAR" class="btn btn-dark" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
           
        </div>
    </form>
</body>
</html>
