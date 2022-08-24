<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorHub.aspx.cs" Inherits="BIT_Web_App.contractorhub" %>
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
                            <div style="text-align:center">
                                <h4> Contractor Hub</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="row" style="">
                        <div class="col-md-6">
                            <div class="card"></div>
                                <div class="card-column">
                                    <div style="text-align:center">
                                    <h4> Upcoming Jobs </h4>
                                </div>
                                <asp:GridView ID="gvUpcomingJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="true"
                                                runat="server">

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
