<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logout.aspx.vb" Inherits="Top_High_Schools.Logout" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="jquery-1.9.1.js"></script>

    <script type="text/javascript" language="javascript">

        window.history.forward();

        function noBack() {

            window.history.forward();

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
        </div>
    </form>
</body>
</html>
