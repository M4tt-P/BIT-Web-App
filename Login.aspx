<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BIT_Web_App.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
 <div class="row">
    <div class="col-md-6 mx-auto">
        <div class="card">
            <div class="card-body">
                <div class="row">
                <div class="col">
                    <div style="text-align:center">
                        <img width="150px" src="Images/user.png" />
                    </div>
                </div>
                </div>
                <div class="row">
                 <div class="col">
                     <center>
                     <h3>User Login</h3>
                     </center>
                 </div> 
                 </div>
                 <div class="row">
                     <div class="col">
                     <hr>
                     </div>
                 </div>
                <div class="row">
                    <div class="col">
                       <label>Email</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtEmail"
                        runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                            <label>Password</label>
                        <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtPassword"
                            runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                                <asp:Button class="btn btn-success btn-block btn-lg"
                                ID="btnMemberLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                        <div class="form-group">
                            <a href="clientregistration.aspx"><input class="btn btninfo btn-block btn-lg" 
                                id="Button2" type="button" value="Sign Up" /></a>
                        </div>
                    </div>
                 </div>
                </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
        </div>
     </div>
</asp:Content>
