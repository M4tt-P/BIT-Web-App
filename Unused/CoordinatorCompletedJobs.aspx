<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorCompletedJobs.aspx.cs" Inherits="BIT_Web_App.CompletedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class ="card-body">
                        <style type="text/css">
                            .invisible{
                                display:none;
                            }
                        </style>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> All Completed Jobs </h4>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvCompletedJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns ="False"
                                    runat="server" OnRowCommand ="gvCompletedJobs_RowCommand" >
                                       <Columns>
                                           <asp:BoundField HeaderText="JobID" DataField="jobid"/>
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnConfirm" runat="server" CommandName="Confirm"
                                                     Height="40px" Text="Verify" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                           <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                           <asp:BoundField HeaderText="Skill Requested" DataField="skillname" />
                                           <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                           <asp:BoundField HeaderText="Job Address" DataField="jobaddress"/>
                                           <asp:BoundField HeaderText="Suburb" DataField="suburb"/>
                                           <asp:BoundField HeaderText="Postcode" DataField="postcode"/>
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
