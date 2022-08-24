<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorBookedJobs.aspx.cs" Inherits="BIT_Web_App.bookedsessions" %>
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

                        <%-- Pending Job Request --%>
                        <%-- Pending Job Request Heading --%>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> &nbsp;</h4>
                                </div>
                                <div style="text-align:center">
                                    <h4 runat="server" id="hPendingJobs"> Pending Job Requests</h4>
                                    <h4 style="color:green" runat="server" id="hNoPendingJobs"> No Current Pending Job Requests</h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        <!-- Pending Job Request Gridview  -->
                            <div class ="col-12">
                                <asp:GridView ID="gvPendingJobRequests"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false" 
                                    runat="server" OnRowCommand="gvPendingJobRequests_RowCommand" >
                                    <Columns>
                                        <asp:BoundField Headertext="Job ID" DataField="jobid" />
                                        <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                        <asp:TemplateField HeaderText="Client Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%#Eval("firstname")+ " " + Eval("lastname")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Skill Needed" DataField="skillname" />
                                        <asp:BoundField HeaderText="Job Description" DataField="jobdescription" /> 
                                        <asp:TemplateField HeaderText="Job Address">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="skillid" ItemStyle-CssClass="invisible"/>
                                        <asp:BoundField DataField="clientid" ItemStyle-CssClass="invisible"/>--%>
                                        <asp:TemplateField HeaderText="Accept Job">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAccept" runat="server" CommandName="Accept"
                                                Height="40px" Text="Accept" Width="80px"
                                                CommandArgument="<%#Container.DataItemIndex %>"/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reject Job">
                                        <ItemTemplate>
                                            <asp:Button ID="btnReject" runat="server" CommandName="Reject"
                                                Height="40px" Text="Reject" Width="80px"
                                                CommandArgument="<%#Container.DataItemIndex %>"/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <%-- Accepted Job Requests --%>
                        <%-- Accepeted Job Requests Heading --%>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4 runat="server" id="hAcceptedJobs"> Accepted Job Requests </h4>
                                    <h4 style="color:green" runat="server" id="hNoAccepetedJobs">All Job Requests have been Completed</h4>
                                </div>
                            </div>
                        </div>
                        <%-- Accepted Job Requests Gridview --%>
                         <div class="row">
                            <div class ="col-12">
                                <asp:GridView ID="gvAcceptedJobs"
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                                    runat="server" OnRowCommand="gvAcceptedJobs_RowCommand" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Job ID" DataField="jobid" />
                                        <asp:BoundField HeaderText="Date of Job" DataField="dateofjob" />
                                        <asp:TemplateField HeaderText="Client Name">
                                             <ItemTemplate>
                                                 <asp:Label runat="server" Text='<%#Eval("firstname")+ " " + Eval("lastname")%>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:BoundField HeaderText="Skill Needed" DataField="skillname" />
                                        <asp:BoundField HeaderText="Job Description" DataField="jobdescription" />
                                        <asp:TemplateField HeaderText="Job Address">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%#Eval("jobaddress")+ ", " + Eval("suburb") + " " + Eval("postcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="skillid" ItemStyle-CssClass="invisible"/>
                                        <asp:BoundField DataField="clientid" ItemStyle-CssClass="invisible"/>--%>
                                        <asp:TemplateField HeaderText="Kilometers Travelled">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtKilometers" runat="server" TextMode="Number" 
                                                    Height="40px" Text="0" Width="60px" />                                        
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Complete Job">
                                            <ItemTemplate>
                                                <asp:Button ID="btnComplete" runat="server" CommandName="Complete"
                                                    Height="40px" Text="Complete" Width="80px"
                                                    CommandArgument="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
