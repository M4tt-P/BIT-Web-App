<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientCurrentJobs.aspx.cs" Inherits="BIT_Web_App.CurrentJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                             <div class="col">
                                 <div style="text-align:center">
                                    <h4 runat="server" id="hCurrentJobs">Current Jobs</h4>
                                    <h4 runat="server" id="hNoCurrentJobs">No Current Jobs</h4>
                                 </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:GridView ID="gvCurrentJobs"
                                    CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="false" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                        <asp:TemplateField HeaderText="Job Address">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Skill Required" DataField="skillname" />
                                        <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                        <asp:BoundField HeaderText="Job Status" DataField="status" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
