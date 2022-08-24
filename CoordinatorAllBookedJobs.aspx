
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorAllBookedJobs.aspx.cs" Inherits="BIT_Web_App.allbookedjobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <div style="text-align:center">
                <h1>BIT Active Job Request Management</h1>
            </div>
        </div>
    </div>
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

                        <%--All Active Job Requests--%>
                        <%--Active Jobs Heading--%>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hActiveJobs"> All Active Jobs </h4>
                                    <h4 style="color:green" runat="server" id="hNoActiveJobs">No Pending Active Jobs</h4>
                                </div>
                            </div>
                        </div>
                        <%--Active Jobs Gridview--%>
                         <div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvAllActiveJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                                    runat="server">
                                     <Columns>
                                         <asp:BoundField HeaderText="Job ID" DataField="jobid" />
                                         <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                         <asp:TemplateField HeaderText="Assigned Contractor">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("conFirstname")+ " " + Eval("conLastname")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Client's Name">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("clFirstname")+ " " + Eval("clLastname")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField HeaderText="Skill Requested" DataField="skillname" />
                                         <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                         <asp:TemplateField HeaderText="Job Address">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("Suburb") + " " + Eval("postcode")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField HeaderText="Status" DataField="status" />
                                         <asp:BoundField DataField="skillid" ItemStyle-CssClass="invisible"/>
                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>

                        <%--Completed jobs that needing verfication --%>
                        <%--Completed Jobs Heading --%>
                         <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hCompletedJobs"> All Completed Jobs </h4>
                                    <h4 style="color:green" runat="server" id="hNoCompletedJobs">No Pending Completed Jobs</h4>
                                </div>
                            </div>
                        </div>
                        <%--Completed Jobs Gridview --%>
                         <div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvCompletedJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns ="False"
                                    runat="server" OnRowCommand ="gvCompletedJobs_RowCommand" >
                                       <Columns>
                                            <asp:BoundField HeaderText="JobID" DataField="jobid"/>
                                            <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                            <asp:TemplateField HeaderText="Assigned Contractor">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("confirstname")+ " " + Eval("conlastname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Client's Name">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("clfirstname")+ " " + Eval("cllastname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Skill Requested" DataField="skillname" />
                                            <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                            <asp:TemplateField HeaderText="Job Address">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%--<asp:BoundField HeaderText="Job Address" DataField="jobaddress"/>
                                           <asp:BoundField HeaderText="Suburb" DataField="suburb"/>
                                           <asp:BoundField HeaderText="Postcode" DataField="postcode"/>--%>
                                           <asp:BoundField HeaderText="Kilometers Traveled" DataField="kilometers" />
                                           <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnConfirm" runat="server" CommandName="Confirm"
                                                     Height="40px" Text="Verify" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                        </Columns>
                                 </asp:GridView>
                            </div>
                        </div>

                        <%--All Pending Job Requests --%>
                        <%--Pending Job Requests Heading --%>
                        <%--<div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hCurrentJobs"> All Job Requests </h4>
                                    <h4 style="color:green" runat="server" id="hNoCurrentJobs"> No Pending Job Requests </h4>
                                </div>
                            </div>
                        </div>--%>
                        <%--Pending Job Request Gridview --%>
                         <%--<div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvJobRequests"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                                    runat="server" OnRowCommand="gvJobRequests_RowCommand" >
                                       <Columns>
                                           <asp:BoundField HeaderText="Job ID" DataField="jobid" />
                                           <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                           <asp:BoundField HeaderText="Skill Requested" DataField="skillname" />
                                           <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                           <asp:TemplateField HeaderText="Job Address">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Action">
                                                 <ItemTemplate>
                                                 <asp:Button ID="btnBook" runat="server" CommandName="Book"
                                                     Height="40px" Text="Book" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField DataField="skillid" ItemStyle-CssClass="invisible"/>

                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>--%>

                        <%--Rejected Job Requests--%>
                        <%--Rejected Job Requests Heading --%>
                        <%--<div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hRejectedJobs"> All Rejected Jobs </h4>
                                    <h4 style="color:green" runat="server" id="hNoRejectedJobs"> No Pending Rejected Job Requests </h4>
                                </div>
                            </div>
                        </div>--%>
                        
                        <%--Rejected Job Request Gridview --%>
                       <%-- <div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvRejectedJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                                    runat="server" OnRowCommand="gvRejectedJobs_RowCommand" >
                                       <Columns>
                                           <asp:BoundField HeaderText="Job ID" DataField="jobid" />
                                           <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                           <asp:BoundField HeaderText="Skill Requested" DataField="skillname" />
                                           <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                           <asp:TemplateField HeaderText="Job Address">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnReBook" runat="server" CommandName="Book"
                                                     Height="40px" Text="Re-Book" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                           <asp:BoundField DataField="skillid" ItemStyle-CssClass="invisible"/>
                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>--%>

                        <%-- Job Request Contractor Assignment --%>
                        <%-- Available Contracotr Heading --%>
                        <%-- <div class="row">
                            <div class ="col-12">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hContractors"> Available Contractors </h4>
                                    <h4 style="color:darkred" runat="server" id="hNoContractors"> No Available Contractors</h4>
                                </div>
                            </div>
                        </div>--%>
                        <%-- Available Contractor GridView --%>
                       <%-- <div class="row">
                            <div class ="col-12">
                                 <asp:GridView ID="gvAvailableContractors"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                                    runat="server" OnRowCommand="gvAvailableContractors_RowCommand" >
                                     <Columns>
                                         <asp:BoundField HeaderText="First Name" DataField="firstname" />
                                         <asp:BoundField HeaderText="Last Name" DataField="lastname" />
                                         <asp:BoundField HeaderText="Suburb" DataField="suburb" />
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnConfirm" runat="server" CommandName="Confirm"
                                                     Height="40px" Text="Confirm" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField DataField="staffid" ItemStyle-CssClass="invisible"/>
                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
