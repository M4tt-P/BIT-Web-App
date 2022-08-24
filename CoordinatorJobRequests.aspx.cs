using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_Web_App
{
    public partial class JobRequests : System.Web.UI.Page
    {
        DataTable availableContractors;
        int jobid;
        int dayid;
        protected void Page_Load(object sender, EventArgs e)
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

            LinkButton lnkActiveJobs = (LinkButton)Master.FindControl("lbtnActiveJobRequests");
            lnkActiveJobs.Visible = true;


            if (!IsPostBack)
            {
                if (Session["Type"] == null || Session["StaffId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["Type"].ToString() == "Coordinator" || Session["Type"].ToString() == "Admin")
                {
                    LoadRejectedJobs();
                    LoadJobRequests();
                    LoadHeadings();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void LoadHeadings()
        {
            hNoContractors.Visible = false;
            hContractors.Visible = false;
        }

        private void LoadJobRequests()
        {
            string sqlRejected = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, " +
                "j.suburb as suburb, j.postcode as postcode, j.jobdescription as jobdescription,  sk.skillname as skillname, " +
                "j.jobid as jobid, sk.skillid as skillid " +
                " FROM jobrequest j, skills sk " +
                " WHERE j.status = 'Pending' AND j.staffid IS NULL AND sk.skillid = j.skillid " +
                " ORDER by dateofjob ASC";
            SQLHelper objhelper = new SQLHelper();
            gvJobRequests.DataSource = objhelper.ExecuteSQL(sqlRejected);
            gvJobRequests.DataBind();

            if (gvJobRequests.Rows.Count > 0) //check if grid not empty
            {
                hCurrentJobs.Visible = true;
                hNoCurrentJobs.Visible = false;
                gvJobRequests.HeaderRow.Cells[6].Visible = false; //hides skill id header
            }
            else
            {
                hCurrentJobs.Visible = false;
                hNoCurrentJobs.Visible = true;
            }
        }

        private void LoadRejectedJobs()//All rejected jobs requiring re-assignment  
        {
            string sqlRejected = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, " +
                "j.suburb as suburb, j.postcode as postcode, j.jobdescription as jobdescription,  sk.skillname as skillname, " +
                "j.jobid as jobid, " +
                "sk.skillid as skillid " +
                " FROM jobrequest j, skills sk " +
                " WHERE j.status = 'Rejected' AND sk.skillid = j.skillid " +
                " ORDER by dateofjob ASC";
            SQLHelper objhelper = new SQLHelper();
            gvRejectedJobs.DataSource = objhelper.ExecuteSQL(sqlRejected);
            gvRejectedJobs.DataBind();

            if (gvRejectedJobs.Rows.Count > 0) //check if grid not empty
            {
                hNoRejectedJobs.Visible = false;
                hRejectedJobs.Visible = true;
                gvRejectedJobs.HeaderRow.Cells[6].Visible = false; //hides skill id header
            }
            else
            {
                hRejectedJobs.Visible = false;
                hNoRejectedJobs.Visible = true;
            }
        }

        private void LoadContractors()
        {
            gvAvailableContractors.DataBind();

        }



        protected void gvRejectedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if (e.CommandName == "Book")
            {
                hContractors.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRejectedJobs.Rows[rowIndex];
                DateTime jobdate = Convert.ToDateTime(row.Cells[1].Text);
                jobid = Convert.ToInt32(row.Cells[0].Text);
                Session.Add("Jobid", jobid);
                dayconverter(jobdate.ToString("dddd"));
                availableContractors =
                        AvailableContractors.GetAllAvailableContractors
                        (dayid, Convert.ToInt32(row.Cells[6].Text));
                gvAvailableContractors.DataSource = availableContractors;
                gvAvailableContractors.DataBind();

                if (gvAvailableContractors.Rows.Count > 0) //check if grid not empty
                {
                    hContractors.Visible = true;
                    hNoContractors.Visible = false;
                    gvAvailableContractors.HeaderRow.Cells[4].Visible = false; //hides job id header
                }
                else
                {
                    hContractors.Visible = false;
                    hNoContractors.Visible = true;    
                }
                //LoadActiveJobs();

            }
        }

        protected void gvAvailableContractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                jobid = Convert.ToInt32(Session["Jobid"]);
                GridViewRow row = gvAvailableContractors.Rows[rowIndex];
                int staffid = Convert.ToInt32(row.Cells[4].Text);
                string updatesql = "UPDATE JobRequest set status = 'Pending', staffid = '" + staffid + "'  where jobid = " + jobid;
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                //LoadActiveJobs();
                LoadRejectedJobs();
                LoadJobRequests();
                LoadContractors();
                LoadHeadings();
            }
        }

        protected void gvJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                jobid = Convert.ToInt32(Session["Jobid"]);
                GridViewRow row = gvJobRequests.Rows[rowIndex];
                DateTime jobdate = Convert.ToDateTime(row.Cells[1].Text);
                jobid = Convert.ToInt32(row.Cells[0].Text);
                Session.Add("Jobid", jobid);
                dayconverter(jobdate.ToString("dddd"));
                availableContractors =
                        AvailableContractors.GetAllAvailableContractors
                        (dayid, Convert.ToInt32(row.Cells[6].Text));
                gvAvailableContractors.DataSource = availableContractors;
                gvAvailableContractors.DataBind();
                if (gvAvailableContractors.Rows.Count > 0) //check if grid not empty
                {
                    hContractors.Visible = true;
                    hNoContractors.Visible = false;
                    gvAvailableContractors.HeaderRow.Cells[4].Visible = false; //hides job id header
                }
                else
                {
                    hContractors.Visible = false;
                    hNoContractors.Visible = true;
                }
            }
        }

        protected void dayconverter(string day)
        {
            switch (day)
            {
                case "Monday":
                    dayid = 1;
                    break;
                case "Tuesday":
                    dayid = 2;
                    break;
                case "Wednesday":
                    dayid = 3;
                    break;
                case "Thursday":
                    dayid = 4;
                    break;
                case "Friday":
                    dayid = 5;
                    break;
                case "Saturday":
                    dayid = 6;
                    break;
                case "Sunday":
                    dayid = 7;
                    break;
            }
        }
       
    }
}