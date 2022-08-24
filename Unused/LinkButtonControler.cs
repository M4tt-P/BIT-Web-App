using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT_Web_App;


namespace BIT_Web_App
{
    public class LinkButtonController: System.Web.UI.Page
    {
        public void Staff()
        {
            LinkButton lnkBooking = (LinkButton)Master.FindControl("lbtnNewBooking");
            lnkBooking.Visible = false;

            LinkButton lnkSignUp = (LinkButton)Master.FindControl("lbtnSignup");
            lnkSignUp.Visible = false;

            LinkButton lnkLogin = (LinkButton)Master.FindControl("lbtnLogin");
            lnkLogin.Visible = false;

            LinkButton lnkHello = (LinkButton)Master.FindControl("lbtnHello");
            lnkHello.Visible = false;

            LinkButton lnkHome = (LinkButton)Master.FindControl("lbtnHome");
            lnkHome.Visible = false;

            LinkButton lnkAboutUs = (LinkButton)Master.FindControl("lbtnAboutUs");
            lnkAboutUs.Visible = false;

            LinkButton lnkTerms = (LinkButton)Master.FindControl("lbtnTerms");
            lnkTerms.Visible = false;

            LinkButton lnkLogOut = (LinkButton)Master.FindControl("lbtnLogOut");
            lnkLogOut.Visible = true;
        }
    }
}