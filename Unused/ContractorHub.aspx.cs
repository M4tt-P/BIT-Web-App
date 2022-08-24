using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_Web_App
{
    public partial class contractorhub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllUpcomingJobs();   
        }
        private void LoadAllUpcomingJobs()
        {
            string sqlstr = "Select j.dateofjob as dateofjob, c.firstname as clientfirstname, " +
                "c.lastname as clientlastname, sk.skillname as skillname, j.suburb as suburb " +
                "FROM jobrequest j, skills sk, client c, staff st " +
                "WHERE sk.skillid = j.skillid AND c.clientid = j.clientid " +
                "AND j.status = 'Accepted'";
            SQLHelper objhelper = new SQLHelper();
            gvUpcomingJobs.DataSource = objhelper.ExecuteSQL(sqlstr);
            gvUpcomingJobs.DataBind();
        }
    }
}