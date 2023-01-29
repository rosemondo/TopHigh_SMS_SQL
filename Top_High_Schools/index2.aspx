<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index2.aspx.vb" Inherits="Top_High_Schools.index2" %>

<%@Import Namespace="System.Web.Security" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Top-High School Management System</title>

    <script src="../jquery-3.5.1.slim.min.js"></script>
    <link href="../font-awesome.min_2.css" rel="stylesheet" />
    <link href="../bootstrap.min.css" rel="stylesheet" />
    <link href="../style.css" rel="stylesheet" />

 <script src="jquery-1.9.1.js"></script>

    <script type="text/javascript" language="javascript">

        window.history.forward();

        function noBack() {

            window.history.forward();

        }

    </script>


    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/bootstrap.bundle.min.js"></script>

    <style>
        container {
            margin: auto;
            width: 100%;
            padding: 10px;
        }

        .card-header {
            background-color: navy;
        }

        .card-title {
            color: white;
        }

        .responsive {
    width: 100%;
    height: auto;
}
    </style>

</head>
<body>
    <div class="container">
        <div id="header">
            <div class="title">
                <img src="../Images/omad7banner.png" alt="banner" class="responsive"/>
            </div>
        </div>
        <div class="row px-3">
            <div class="col-lg-10 col-xl-9 card flex-row mx-auto px-0">
                <div class="img-left d-none d-md-flex"></div>

                <div class="card-body">
                    <h4 class="title text-center mt-4">Login</h4>
                    <form class="form-box px-3" runat="server">
                        <div class="form-input">
                            <label for="inputEmail" class="col-sm-3 col-form-label">Username</label>
                            <asp:TextBox ID="txtusername" runat="server" cssclass="form-control" placeholder="Username" required="true"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <label for="inputPassword" class="col-sm-3 col-form-label">Password</label>
                            <asp:TextBox ID="txtpassword" Type="password" runat="server" class="form-control" placeholder="Password" required="true"></asp:TextBox>
                        </div>


                        <div class="mb-3">
                            <asp:Button ID="btnsignin" runat="server" class="btn btn-primary" Text="Sign in" />
                        </div>

                        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtrole" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtuser" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtphonenum"  runat="server" Visible="false"></asp:TextBox>

                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
