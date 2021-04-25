<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OceanShopping.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Karla:400,700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdn.materialdesignicons.com/4.8.95/css/materialdesignicons.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/login.css">
</head>
<body>
    <form id="form1" runat="server">
        <main class="d-flex align-items-center min-vh-100 py-3 py-md-0">
            <div class="container">
                <div class="card login-card">
                    <div class="row no-gutters">
                        <div class="col-md-5">
                            <img src="https://images.theconversation.com/files/223729/original/file-20180619-126566-1jxjod2.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=1200.0&fit=crop" alt="login" class="login-card-img">
                        </div>
                        <div class="col-md-7">
                            <div class="card-body">
                                <div class="brand-wrapper">
                                    <!--<img src="assets/images/.svg" alt="logo" class="logo">-->
                                </div>
                                <p class="login-card-description">Sign into your account </p>

                                <!--email -->
                                <div class="form-group">
                                    <label for="email" class="sr-only">Email</label>
                                    <asp:TextBox runat="server" ID="login_email" class="form-control" Placeholder="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="login_req_email" ControlToValidate="login_email" ErrorMessage="Please enter your email" ForeColor="Red" />
                                    <asp:TextBox runat="server" ID="login_password" type="password" class="form-control" Placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="login_req_password" ControlToValidate="login_password" ErrorMessage="Please enter your password" ForeColor="Red" />
                                    <p>Remember Login: <asp:CheckBox runat="server" ID="login_remember" /></p>
                                    <asp:Button runat="server" ID="login_create_account" Text="Create Account" class="btn btn-light" OnClick="login_create_account_Click" CausesValidation="false"/>
                                    <asp:Button runat="server" ID="login_submit" Text="Login" class="btn btn-light" OnClick="login_submit_Click"/>
                                    <asp:Button runat="server" ID="login_forget_button" Text="Forgot Password" class="btn btn-light" OnClick="login_forgot_password_Click" CausesValidation="false"/>
                                </div>


                                <div runat="server" id="login_forgot_password_div">
                                    <asp:Label runat="server" ID="login_forgot_password_question"></asp:Label>
                                    <asp:TextBox runat="server" ID="login_forgot_password_answer" Placeholder="Answer"></asp:TextBox>
                                    <asp:Button runat="server" ID="login_forget_cancel" Text="Cancel" class="btn btn-light" OnClick="login_forgot_password_cancel_Click" CausesValidation="false"/>
                                </div>
                            </div>
                            <div>
                                    </div>

                                <nav class="login-card-footer-nav">
                                    <a href="#!">Terms of use.</a>
                                    <a href="#!">Privacy policy</a>
                                </nav>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </form>

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</body>
</html>

<style>
    body {
  font-family: "Karla", sans-serif;
  min-height: 100vh; }

    #login_submit{

    }

.brand-wrapper {
  margin-bottom: 19px; }
  .brand-wrapper .logo {
    height: 37px; }

.login-card {
  border: 0;
  border-radius: 27.5px;
  box-shadow: 0 10px 30px 0 rgba(172, 168, 168, 0.43);
  overflow: hidden; }
  .login-card-img {
    border-radius: 0;
    position: absolute;
    width: 100%;
    height: 100%;
    -o-object-fit: cover;
       object-fit: cover; }
  .login-card .card-body {
    padding: 85px 60px 60px; }
    @media (max-width: 422px) {
      .login-card .card-body {
        padding: 35px 24px; } }
  .login-card-description {
    font-size: 25px;
    color: #000;
    font-weight: normal;
    margin-bottom: 23px; }
  .login-card form {
    max-width: 326px; }
  .login-card .form-control {
    border: 1px solid #d5dae2;
    padding: 15px 25px;
    margin-bottom: 20px;
    min-height: 45px;
    font-size: 13px;
    line-height: 15;
    font-weight: normal; }
    .login-card .form-control::-webkit-input-placeholder {
      color: #919aa3; }
    .login-card .form-control::-moz-placeholder {
      color: #919aa3; }
    .login-card .form-control:-ms-input-placeholder {
      color: #919aa3; }
    .login-card .form-control::-ms-input-placeholder {
      color: #919aa3; }
    .login-card .form-control::placeholder {
      color: #919aa3; }
  .login-card .login-btn {
    padding: 13px 20px 12px;
    background-color: #000;
    border-radius: 4px;
    font-size: 17px;
    font-weight: bold;
    line-height: 20px;
    color: #fff;
    margin-bottom: 24px; }
    .login-card .login-btn:hover {
      border: 1px solid #000;
      background-color: transparent;
      color: #000; }
  .login-card .forgot-password-link {
    font-size: 14px;
    color: #919aa3;
    margin-bottom: 12px; }
  .login-card-footer-text {
    font-size: 16px;
    color: #0d2366;
    margin-bottom: 60px; }
    @media (max-width: 767px) {
      .login-card-footer-text {
        margin-bottom: 24px; } }
  .login-card-footer-nav a {
    font-size: 14px;
    color: #919aa3; }

/*# sourceMappingURL=login.css.map */

</style>
