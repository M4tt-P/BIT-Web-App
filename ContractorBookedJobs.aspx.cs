using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT_Web_App;


namespace BIT_Web_App
{
    public partial class bookedsessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//!IsPostBack is a condition that you instructing your page to be loaded with the same
                            //data if a button on the page is clicked
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Contractor")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {   
                    LinkButton lnkJob = (LinkButton)Master.FindControl("lbtnNewJob");
                    lnkJob.Visible = false;

                    LinkButton lnkSignUp = (LinkButton)Master.FindControl("lbtnSignup");
                    lnkSignUp.Visible = false;

                    LinkButton lnkLogin = (LinkButton)Master.FindControl("lbtnLogin");
                    lnkLogin.Visible = false;

                    LinkButton lnkHome = (LinkButton)Master.FindControl("lbtnHome");
                    lnkHome.Visible = false;

                    LinkButton lnkAboutUs = (LinkButton)Master.FindControl("lbtnAboutUs");
                    lnkAboutUs.Visible = false;

                    LinkButton lnkLogOut = (LinkButton)Master.FindControl("lbtnLogOut");
                    lnkLogOut.Visible = true;

                    RefreshBookedDataGrid();
                    RefreshAcceptedDataGrid();
                }
            }
        }

        protected void gvPendingJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //if e.CommandName is Complete then 
        //update the status of that Job id to "Completed" and update the number of kilometers to what has 
        //been typed in that textbox
            if (e.CommandName == "Accept")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPendingJobRequests.Rows[rowIndex];
                string updatesql = "update jobrequest set status = 'Accepted' " +
                    " where jobid = " + Convert.ToInt32(row.Cells[0].Text);
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                RefreshBookedDataGrid();
                RefreshAcceptedDataGrid();
                //we must also update the grid
            }
            else if (e.CommandName == "Reject")
            {
                int contractorId = Convert.ToInt32(Session["StaffID"].ToString());
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPendingJobRequests.Rows[rowIndex];
                
                //rejection table WORK IN PROGRESS
                //string insertsql = "insert rejectedjobs(staffid, jobid) VALUES (" + contractorId + ", " +
                //    Convert.ToInt32(row.Cells[0].Text) + ")";
                //SQLHelper helper = new SQLHelper();
                //helper.ExecuteNonQuery(insertsql);

                string updatesql = "update jobrequest set status = 'Rejected' " +
                     "where jobid = " + Convert.ToInt32(row.Cells[0].Text);
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                
                RefreshBookedDataGrid();

                
                //Future addition - rejection table

                //int ContractorID = Convert.ToInt32(Session["StaffID"].ToString());
                //string insertsql = "insert into Rejectedjobs(staffid, jobid, skillid, clientid) values (" + ContractorID + ", " +
                //     Convert.ToInt32(row.Cells[11].Text) + ", " + Convert.ToInt32(row.Cells[].Text) + ", " + Convert.ToInt32(row.Cells[7].Text) + ")";

                //helper.ExecuteNonQuery(insertsql);

                //DateTime jobdate = Convert.ToDateTime(row.Cells[3].Text)

                /* Old reject table insert statement w/ jobaddress + dateofjob
                string insertsql = "insert into RejectedJobs(staffid, jobid, jobaddress, skillid, clientid) values( " + ContractorID + ", " +
                    Convert.ToInt32(row.Cells[2].Text) + ", '" + (row.Cells[10].Text).ToString() + "', " + 
                    jobdate.ToString("dd/MM/yyyy") + "', " + Convert.ToInt32(row.Cells[4].Text) + ", " + Convert.ToInt32(row.Cells[7].Text)+ ")";
                */


            }
        }

        protected void gvAcceptedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Complete")
            {
                bool isCompleted = true;

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAcceptedJobs.Rows[rowIndex];
                int kilometers = Convert.ToInt32(((TextBox)row.FindControl("txtKilometers")).Text.Trim());

                if (kilometers == 0)
                {
                    isCompleted = false;
                }

                if (isCompleted)
                {
                    string updatesql = "update jobrequest set status = 'Completed', kilometers = " + kilometers +
                                    " where jobid = " + Convert.ToInt32(row.Cells[0].Text);
                    SQLHelper helper = new SQLHelper();
                    helper.ExecuteNonQuery(updatesql);
                    RefreshAcceptedDataGrid();
                }
                else
                {
                    Response.Write("Please fill in Kilometers Traveled");
                }
            }
        }


        private void RefreshBookedDataGrid()
        {
            int contractorId = Convert.ToInt32(Session["StaffID"].ToString());
            string sqlStr = "SELECT j.jobid as jobid, convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, j.suburb as suburb, cl.clientid as clientid, " +
                " j.jobdescription as jobdescription,  sk.skillname as skillname, cl.firstname as firstname, cl.lastname as lastname, sk.skillid as skillid, j.postcode as postcode " +
                " FROM jobrequest j, client cl, skills sk, staff st " +
                " WHERE st.staffid = j.staffid AND cl.clientid = j.clientid AND sk.skillid = j.skillid " + 
                " AND j.staffid = " + contractorId + " AND j.status = 'Pending' " +
                " ORDER BY dateofjob ASC";
            
            SQLHelper objhelper = new SQLHelper();
            gvPendingJobRequests.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvPendingJobRequests.DataBind();
            if (gvPendingJobRequests.Rows.Count > 0) //check if grid not empty
            {
                //Shows the Correct Heading
                hNoPendingJobs.Visible = false;
                hPendingJobs.Visible = true;

                //hides ids
                //gvPendingJobRequests.HeaderRow.Cells[7].Visible = false;
                //gvPendingJobRequests.HeaderRow.Cells[6].Visible = false;
            }
            else
            {
                hNoPendingJobs.Visible = true;
                hPendingJobs.Visible = false;
            }
        }

        private void RefreshAcceptedDataGrid()
        {
            int contractorId = Convert.ToInt32(Session["StaffID"].ToString());
            string sqlStr = "SELECT j.jobid as jobid,convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, " +
                " j.suburb as suburb, cl.clientid as clientid, j.jobdescription as jobdescription,  sk.skillname as skillname," +
                " cl.firstname as firstname, cl.lastname as lastname, sk.skillid as skillid, j.jobid as jobid, j.postcode as postcode " +
                " FROM jobrequest j, client cl, skills sk, staff st " +
                " WHERE st.staffid = j.staffid AND cl.clientid = j.clientid AND sk.skillid = j.skillid " +
                " AND j.staffid = " + contractorId + " AND j.status = 'Accepted' " +
                " ORDER BY dateofjob ASC";
            SQLHelper objhelper = new SQLHelper();
            gvAcceptedJobs.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvAcceptedJobs.DataBind();
            if (gvAcceptedJobs.Rows.Count > 0) //check if grid not empty
            {
                hAcceptedJobs.Visible = true;
                hNoAccepetedJobs.Visible = false;
                //Hides ID
                //gvAcceptedJobs.HeaderRow.Cells[8].Visible = false;
                //gvAcceptedJobs.HeaderRow.Cells[9].Visible = false;
            }
            else
            {
                hAcceptedJobs.Visible = false;
                hNoAccepetedJobs.Visible = true;
            }
        }
    }
}