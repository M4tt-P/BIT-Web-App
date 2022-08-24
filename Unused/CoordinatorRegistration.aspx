<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorRegistration.aspx.cs" Inherits="BIT_Web_App.CoordinatorRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row ">
            <div class="col-12" >
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <img width="100px" src="Images/user.jpg"/>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col">
                                 <div style="text-align:center">
                                    <h4>Coordinator Registration</h4>

                                 </div>
                            </div>
                        </div>
                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>First Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFName"
                                    runat="server" placeholder="First Name"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Last Name</label>
                                        <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtLName"
                                            runat="server" placeholder="Last Name"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                <div class="col-md-6">
                                    <label>Password</label>
                                        <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtPassword"
                                            runat="server" placeholder="Password"></asp:TextBox>
                                        </div>
                                    </div>

                                <div class="col-md-6">
                                    <label>Contact No</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPhone"
                                    runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                <div class="row">
                                     <div class="col-md-6">
                                        <label>Address Line (Example: 3, George Street)</label>
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="txtAddress"
                                        runat="server" placeholder="Address Line" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <label>State</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="ddlState"
                                        runat="server">
                                            <asp:ListItem Text="Select" Value="select" />
                                            <asp:ListItem Text="NSW" Value="NSW" />
                                            <asp:ListItem Text="ACT" Value="ACT" />
                                            <asp:ListItem Text="WA" Value="WA" />
                                            <asp:ListItem Text="QLD" Value="QLD" />
                                            <asp:ListItem Text="TAS" Value="TAS" />
                                            <asp:ListItem Text="NT" Value="NT" />
                                            <asp:ListItem Text="VIC" Value="VIC" />
                                            <asp:ListItem Text="SA" Value="SA" />

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Suburb</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="txtSuburb"
                                            runat="server" placeholder="Suburb"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Post Code</label>
                                            <div class="form-group">
                                            <asp:TextBox class="form-control" ID="txtPostCode"
                                            runat="server" placeholder="Postcode" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Email ID</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtEmail"
                                            runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 mx-auto">
                                        <center>
                                            <div class="form-group">
                                            <asp:Button class="btn btn-success btn-block btn-lg"
                                            ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click"></asp:Button>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="homepage.aspx"><< Back to Homepage><br><br></a>
                    </div>

                </div>
            </div>
</asp:Content>
