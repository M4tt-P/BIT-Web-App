using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BIT_Web_App
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.Aspx");
        }

        protected void lbtnNewJob_Click(object sender, EventArgs e)
        {

            ////collecting client id from query string
            //int clientId = Convert.ToInt32(Session["ClientId"].ToString());

            ////Direct user to currentJobs.aspx with new QueryString
            Response.Redirect("ClientNewJob.aspx");

        }

        protected void lbtnCurrentJobs_Click(object sender, EventArgs e)
        {
            ////collecting client id from query string
            //int clientId = Convert.ToInt32(Session["ClientId"].ToString());

            ////Direct user to currentJobs.aspx with new QueryString
            Response.Redirect("ClientCurrentJobs.aspx");

        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
         
            Response.Redirect("HomePage.aspx");
        }

        protected void lbtnPendingJobRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoordinatorJobRequests.aspx");
        }


        protected void lbtnActiveJobRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoordinatorAllBookedJobs.aspx");
        }
    }
}