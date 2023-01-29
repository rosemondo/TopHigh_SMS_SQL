﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Log_in_Portal.aspx.vb" Inherits="Top_High_Schools.Log_in_Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TopHigh School Management System</title>

    <script src="jquery-3.5.1.slim.min.js"></script>



    <script>

        $(document).ready(function () {
            function disableBack() { window.history.forward() }

            window.onload = disableBack();
            window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
        });

    </script>


    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>

    <style>
        container {
            margin: auto;
            width: 100%;
            padding: 10px;
        }

        .card-header {
            background-color: #16b60e;
        }

        .card-title {
            color: white;
        }

        .card {
            overflow: hidden;
            border: 0 !important;
            border-radius: 20px !important;
            box-shadow: 0 0.5rem 1rem 0 rgba(0, 0, 0, 0.1);
        }



        .card-body {
            padding: 2rem;
        }

        .title {
            margin-bottom: 2rem;
        }

        .form-input {
            position: relative;
        }

            .form-input input {
                width: 100%;
                height: 45px;
                padding-left: 40px;
                margin-bottom: 20px;
                box-sizing: border-box;
                box-shadow: none;
                border: 1px solid #00000020;
                border-radius: 50px;
                outline: none;
                background: transparent;
            }

            .form-input span {
                position: absolute;
                top: 10px;
                padding-left: 15px;
                color: #007bff;
            }

            .form-input input::placeholder {
                color: black;
                padding-left: 0px;
            }

            .form-input input:focus, .form-input input:valid {
                border: 2px solid #007bff;
            }

                .form-input input:focus::placeholder {
                    color: #454b69;
                }

        .custom-checkbox .custom-control-input:checked ~ .custom-control-label::before {
            background-color: #007bff !important;
            border: 0px;
        }

        .form-box button[type="submit"] {
            margin-top: 10px;
            border: none;
            cursor: pointer;
            border-radius: 50px;
            background: #007bff;
            color: #fff;
            font-size: 90%;
            font-weight: bold;
            letter-spacing: .1rem;
            transition: 0.5s;
            padding: 12px;
        }

            .form-box button[type="submit"]:hover {
                background: #0069d9;
            }

        .forget-link, .register-link {
            color: #007bff;
            font-weight: bold;
        }

            .forget-link:hover, .register-link:hover {
                color: #0069d9;
                text-decoration: none;
            }

        .form-box .btn-social {
            color: white !important;
            border: 0;
            font-weight: bold;
        }

        .form-box .btn-facebook {
            background: #4866a8;
        }

        .form-box .btn-google {
            background: #da3f34;
        }

        .form-box .btn-twitter {
            background: #33ccff;
        }

        .form-box .btn-facebook:hover {
            background: #3d578f;
        }

        .form-box .btn-google:hover {
            background: #bf3b31;
        }

        .form-box .btn-twitter:hover {
            background: #2eb7e5;
        }
    </style>

</head>
<body style="background: url('/GettyImages_1026679008.jpg'); height: 100vh; background-size: cover; display: flex; flex-direction: column; align-items: center; justify-content: center;">
    <div class="container">
        <div class="row px-3">
            <div class="col-lg-10 col-xl-9 card flex-row mx-auto px-0">
                <div class="img-left d-none d-md-flex" style="background-position: inherit center; background-image: url('schoolbooks.jpg'); width: 45%; background-size: cover; background-attachment: inherit; background-repeat: inherit;"></div>
                
                <div class="card-body">
                    <h4 class="title text-center mt-4">Login</h4>
                    <form class="form-box px-3" runat="server">
                        <div class="form-input">
                            <label for="inputEmail">Parent Phone Number</label>
                            <asp:TextBox ID="txtusers" runat="server" CssClass="form-control" placeholder="Enter your number" required="true"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="btnsignin" runat="server" class="btn btn-primary" Text="Sign in" OnClick="btnsignin_Click" />
                        </div>


                        <div class="text-right">
                            <a href="#" class="forget-link">Forget Password?
                            </a>
                        </div>

                        <div class="text-center mb-3">
                            or login with
                        </div>

                        <div class="row mb-3">
                            <div class="col-4">
                                <a href="#" class="btn btn-block btn-social btn-facebook">facebook
                                </a>
                            </div>

                            <div class="col-4">
                                <a href="#" class="btn btn-block btn-social btn-google">google
                                </a>
                            </div>

                            <div class="col-4">
                                <a href="#" class="btn btn-block btn-social btn-twitter">twitter
                                </a>
                            </div>
                        </div>

                        <hr class="my-4">

                        <div class="text-center mb-2">
                            Don't have an account?
              <a href="#" class="register-link">Register here
              </a>
                        </div>

                        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtrole" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtuser" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtlocation" runat="server" Visible="false"></asp:TextBox>

                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
