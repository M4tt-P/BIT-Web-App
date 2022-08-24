using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_Web_App
{
    public partial class CurrentJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this page is loaded when a customer logs in to the system
            //using the correct username and password
            //then we may want the sign up and user login link buttons to be 
            //invisible and instead we will show new Job, logout and welcome link
            LinkButton lnkJob = (LinkButton)Master.FindControl("lbtnNewJob");
            lnkJob.Visible = true;

            LinkButton lnkSignUp = (LinkButton)Master.FindControl("lbtnSignup");
            lnkSignUp.Visible = false;

            LinkButton lnkLogin = (LinkButton)Master.FindControl("lbtnLogin");
            lnkLogin.Visible = false;

            LinkButton lnkLogOut = (LinkButton)Master.FindControl("lbtnLogOut");
            lnkLogOut.Visible = true;

            LinkButton lnkHome = (LinkButton)Master.FindControl("lbtnHome");
            lnkHome.Visible = false;

            LinkButton lnkAboutUs = (LinkButton)Master.FindControl("lbtnAboutUs");
            lnkAboutUs.Visible = false;


            if (!IsPostBack)
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Client"
                    || Session["ClientId"].ToString() == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LoadJobRequests();
                } 
            }
            //this is where the current Jobs should load up
            
        }
        private void LoadJobRequests()
        {
            int clientId = Convert.ToInt32(Session["ClientId"].ToString());
            string sqlStr = "SELECT convert(varchar(10),j.dateofjob,103) as dateofjob, j.jobaddress as jobaddress, c.clientid," +
                " s.skillname AS skillname, j.jobdescription AS jobdescription, j.status AS status, j.suburb AS suburb, j.postcode AS postcode" +
                " FROM Client c, JobRequest j, Skills s" +
                " WHERE c.clientid = j.clientid AND s.skillid = j.skillid" +
                " AND s.skillid = j.skillid AND j.clientid = " + clientId + 
                " ORDER BY dateofjob ASC";

            SQLHelper objhelper = new SQLHelper();
            gvCurrentJobs.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvCurrentJobs.DataBind();

            if(gvCurrentJobs.Rows.Count > 0)
            {
                hCurrentJobs.Visible = true;
                hNoCurrentJobs.Visible = false;
            }
            else
            {
                hNoCurrentJobs.Visible = true;
                hCurrentJobs.Visible = false;
            }
        }
            
        
    }
}