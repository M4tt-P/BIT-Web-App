using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_Web_App
{
    public partial class NewJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LinkButton lnkCurrentJob = (LinkButton)Master.FindControl("lbtnCurrentJobs");
                lnkCurrentJob.Visible = true;

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
                
            }

                string sqlStr = "select skillname, skillid from Skills";
                SQLHelper objhelper = new SQLHelper();

                ddlSkillNeeded.DataSource = objhelper.ExecuteSQL(sqlStr);
                ddlSkillNeeded.DataBind();
                ddlSkillNeeded.DataValueField = "skillid";
                ddlSkillNeeded.DataTextField = "skillname";
                ddlSkillNeeded.DataBind();
                
            }



        }


        protected void btnCreateJob_Click(object sender, EventArgs e)
        {
            //collecting client id from query string
            int clientId = Convert.ToInt32(Session["ClientId"].ToString());

            //Checking textboxes that they are filled
            bool isFilledIn = true;
            int i = 0;

            while (isFilledIn && i !=5)
            {
                i++;
                switch(i){
                    case 1:
                        if (txtAddress.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 2:
                        if (txtJobDescription.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 3:
                        if (txtPostcode.Text == "" || txtPostcode.Text.Length != 4)
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 4:
                        if (txtSuburb.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                }
            }

            if (!isFilledIn)
            {
                Response.Write("Please fill in all the text boxs correctly");
            }
            else
            {


                Job newJob = new Job()
                {
                    JobAddress = txtAddress.Text.ToString(),
                    JobDescription = txtJobDescription.Text.ToString(),
                    Postcode = txtPostcode.Text.ToString(),
                    Suburb = txtSuburb.Text.ToString(),
                    ClientID = clientId,
                    DateOfJob = Convert.ToDateTime(cldDateOfJob.Text),
                    SkillID = Convert.ToInt32(ddlSkillNeeded.SelectedValue),
                    Status = "Pending"

                };

                int returnValue = newJob.InsertJob();
                if (returnValue <= 1)
                {
                    Response.Write("<script>alert('Job Request Successfully Submitted');window.location = 'clientcurrentjobs.aspx';</script>");
                }
                else
                {
                    Response.Write("Job Request Failed");
                }

                //if time available, add a tickbox to make residentual address job address etc

            }
        }

    }
    
}