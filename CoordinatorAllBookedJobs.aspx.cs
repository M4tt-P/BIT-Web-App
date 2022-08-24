using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BIT_Web_App
{
    public partial class allbookedjobs : System.Web.UI.Page
    {
        //DataTable availableContractors;
        int jobid;
        //int dayid;
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

            LinkButton lnkPendingJobs = (LinkButton)Master.FindControl("lbtnPendingJobRequests");
            lnkPendingJobs.Visible = true;


            if (!IsPostBack)
            {
                if (Session["Type"] == null || Session["StaffId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if(Session["Type"].ToString() == "Coordinator" || Session["Type"].ToString() == "Admin")
                {
                    LoadActiveJobs();
                    LoadCompletedJobs();
                    //LoadRejectedJobs();
                    //LoadJobRequests();
                    //LoadHeadings();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
        //private void LoadHeadings() {
        //    hNoContractors.Visible = false;
        //    hContractors.Visible = false;
        //}

        // J.Status key: 0 = rejected, 1 = pending acceptance, 2 = accepted, 3 = completed, 4 = verified

        private void LoadActiveJobs() // All Pending and Accepted Jobs
        {
            string sqlStr = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, " +
                "j.suburb as suburb, st.firstname as confirstname, st.lastname as conlastname, j.postcode as postcode, " +
                "j.jobdescription as jobdescription, j.status as status, sk.skillname as skillname, j.jobid as jobid, " +
                "sk.skillid as skillid, cl.firstname as clfirstname, cl.lastname as cllastname " +
                " FROM jobrequest j, skills sk, staff st, client cl " +
                " WHERE sk.skillid = j.skillid AND (j.status = 'Accepted' OR j.status = 'Pending') AND st.staffid = j.staffid" +
                " AND cl.clientid = j.clientid " +
                " ORDER by dateofjob ASC";
            SQLHelper objhelper = new SQLHelper();
            gvAllActiveJobs.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvAllActiveJobs.DataBind();

            if (gvAllActiveJobs.Rows.Count > 0) //check if grid not empty
            {
                hActiveJobs.Visible = true;
                hNoActiveJobs.Visible = false;
                gvAllActiveJobs.HeaderRow.Cells[8].Visible = false; //hides skill id header
            }
            else
            {
                hNoActiveJobs.Visible = true;
                hActiveJobs.Visible = false;
            }

        }

        private void LoadCompletedJobs() //Loads All completed Jobs
        {
            string sqlCompleted = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, j.suburb as suburb, " +
                " j.postcode as postcode, j.jobdescription as jobdescription, sk.skillname as skillname, j.jobid as jobid, sk.skillid as skillid, " +
                " j.kilometers as kilometers, st.firstname as confirstname, st.lastname as conlastname, cl.firstname as clfirstname, cl.lastname as cllastname " +
                " FROM jobrequest j, skills sk, staff st, client cl " +
                " WHERE j.status = 'Completed' AND sk.skillid = j.skillid AND st.staffid = j.staffid AND cl.clientid = j.clientid " +
                " ORDER by dateofjob ASC";
            SQLHelper objhelper = new SQLHelper();
            gvCompletedJobs.DataSource = objhelper.ExecuteSQL(sqlCompleted);
            gvCompletedJobs.DataBind();

            if (gvCompletedJobs.Rows.Count > 0)
            {
                hCompletedJobs.Visible = true;
                hNoCompletedJobs.Visible = false;
            }
            else
            {
                hCompletedJobs.Visible = false;
                hNoCompletedJobs.Visible = true;
            }

        }
        //private void LoadRejectedJobs()//All rejected jobs requiring re-assignment  
        //{
        //    string sqlRejected = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, j.suburb as suburb, " +
        //        " j.postcode as postcode, j.jobdescription as jobdescription,  sk.skillname as skillname, j.jobid as jobid, sk.skillid as skillid " +
        //        " FROM jobrequest j, skills sk " +
        //        " WHERE j.status = 'Rejected' AND sk.skillid = j.skillid " +
        //        " ORDER by dateofjob ASC";
        //    SQLHelper objhelper = new SQLHelper();
        //    gvRejectedJobs.DataSource = objhelper.ExecuteSQL(sqlRejected);
        //    gvRejectedJobs.DataBind();

        //    if (gvRejectedJobs.Rows.Count > 0) //check if grid not empty
        //    {
        //        hNoRejectedJobs.Visible = false;
        //        hRejectedJobs.Visible = true;
        //        gvRejectedJobs.HeaderRow.Cells[6].Visible = false; //hides skill id header
        //    }
        //    else
        //    {
        //        hRejectedJobs.Visible = false;
        //        hNoRejectedJobs.Visible = true;
        //    }
        //}

        //private void LoadContractors()
        //{
        //    gvAvailableContractors.DataBind();

        //}
    
        //private void LoadJobRequests()
        //{
        //    string sqlRejected = "Select convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, j.suburb as suburb, " +
        //        " j.postcode as postcode, j.jobdescription as jobdescription,  sk.skillname as skillname, j.jobid as jobid, sk.skillid as skillid " +
        //        " FROM jobrequest j, skills sk " +
        //        " WHERE j.status = 'Pending' AND j.staffid IS NULL AND sk.skillid = j.skillid " +
        //        " ORDER by dateofjob ASC";
        //    SQLHelper objhelper = new SQLHelper();
        //    gvJobRequests.DataSource = objhelper.ExecuteSQL(sqlRejected);
        //    gvJobRequests.DataBind();
            
        //    if (gvJobRequests.Rows.Count > 0) //check if grid not empty
        //    {
        //        hCurrentJobs.Visible = true;
        //        hNoCurrentJobs.Visible = false;
        //        gvJobRequests.HeaderRow.Cells[6].Visible = false; //hides skill id header
        //    }
        //    else
        //    {
        //        hCurrentJobs.Visible = false;
        //        hNoCurrentJobs.Visible = true;
        //    }
        //}
        protected void gvCompletedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                
                GridViewRow row = gvCompletedJobs.Rows[rowIndex];
                jobid = Convert.ToInt32(row.Cells[0].Text);
                string updatesql = "UPDATE JobRequest SET status = 'Verified' WHERE jobid = " + jobid;
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                LoadCompletedJobs();
            }
        }

        //protected void gvRejectedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Book")
        //    {
        //        hContractors.Visible = true;
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = gvRejectedJobs.Rows[rowIndex];
        //        DateTime jobdate = Convert.ToDateTime(row.Cells[1].Text);
        //        jobid = Convert.ToInt32(row.Cells[0].Text);
        //        Session.Add("Jobid", jobid);
        //        dayconverter(jobdate.ToString("dddd"));
        //        availableContractors =
        //                AvailableContractors.GetAllAvailableContractors
        //                (dayid, Convert.ToInt32(row.Cells[6].Text));
        //        gvAvailableContractors.DataSource = availableContractors;
        //        gvAvailableContractors.DataBind();

        //        if (gvAvailableContractors.Rows.Count > 0) //check if grid not empty
        //        {
        //            hContractors.Visible = true;
        //            hNoContractors.Visible = false;
        //            gvAvailableContractors.HeaderRow.Cells[4].Visible = false; //hides job id header
        //        }
        //        else
        //        {
        //            hContractors.Visible = false;
        //            hNoContractors.Visible = true;    
        //        }
        //        LoadActiveJobs();

        //    }
        //}

        //protected void gvAvailableContractors_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Confirm")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        jobid = Convert.ToInt32(Session["Jobid"]);
        //        GridViewRow row = gvAvailableContractors.Rows[rowIndex];
        //        int staffid = Convert.ToInt32(row.Cells[4].Text);
        //        string updatesql = "UPDATE JobRequest set status = 'Pending', staffid = '" + staffid + "'  where jobid = " + jobid;
        //        SQLHelper helper = new SQLHelper();
        //        helper.ExecuteNonQuery(updatesql);
        //        LoadActiveJobs();
        //        LoadRejectedJobs();
        //        LoadJobRequests();
        //        LoadContractors();
        //        LoadHeadings();
        //    }
        //}

        //protected void gvJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Book")
        //    {

        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        jobid = Convert.ToInt32(Session["Jobid"]);
        //        GridViewRow row = gvJobRequests.Rows[rowIndex];
        //        DateTime jobdate = Convert.ToDateTime(row.Cells[1].Text);
        //        jobid = Convert.ToInt32(row.Cells[0].Text);
        //        Session.Add("Jobid", jobid);
        //        dayconverter(jobdate.ToString("dddd"));
        //        availableContractors =
        //                AvailableContractors.GetAllAvailableContractors
        //                (dayid, Convert.ToInt32(row.Cells[6].Text));
        //        gvAvailableContractors.DataSource = availableContractors;
        //        gvAvailableContractors.DataBind();
        //        if (gvAvailableContractors.Rows.Count > 0) //check if grid not empty
        //        {
        //            hContractors.Visible = true;
        //            hNoContractors.Visible = false;
        //            gvAvailableContractors.HeaderRow.Cells[4].Visible = false; //hides job id header
        //        }
        //        else
        //        {
        //            hContractors.Visible = false;
        //            hNoContractors.Visible = true;
        //        }
        //    }
        //}

        //protected void dayconverter(string day)
        //{
        //    switch (day)
        //    {
        //        case "Monday":
        //            dayid = 1;
        //            break;
        //        case "Tuesday":
        //            dayid = 2;
        //            break;
        //        case "Wednesday":
        //            dayid = 3;
        //            break;
        //        case "Thursday":
        //            dayid = 4;
        //            break;
        //        case "Friday":
        //            dayid = 5;
        //            break;
        //        case "Saturday":
        //            dayid = 6;
        //            break;
        //        case "Sunday":
        //            dayid = 7;
        //            break;
        //    }
        //}
    }
}