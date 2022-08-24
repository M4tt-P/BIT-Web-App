<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientNewJob.aspx.cs" Inherits="BIT_Web_App.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="containter-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div style="text-align: center">
                                    <img width="100px" src="Images/AdminUser.png" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="text-align: center">
                                    <h4>New Job</h4>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Address Line (Example: 3, George Street)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"
                                        placeholder="Job Address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Suburb</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSuburb" runat="server"
                                        placeholder="Suburb"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Postcode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Number" MaxLength="4" ID="txtPostcode" runat="server"
                                        placeholder="Postcode"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Support Type</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control"
                                        ID="ddlSkillNeeded" placeholder="Select Skill" runat="server">  
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-9">
                                <label>Job Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtJobDescription" runat="server"
                                        placeholder="Job Description"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Date of Job</label>
                                <div class="form-group">
                                    <asp:TextBox ID="cldDateOfJob" TextMode="Date" CssClass="form-control" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <div style="text-align:center">
                                    <asp:Button class="btn btn-success btn-block btn-lg"
                                        ID="btnCreateJob" OnClick="btnCreateJob_Click" runat="server" Text="Create Jobs"></asp:Button>
                                </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

    
</asp:Content>
