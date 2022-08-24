using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BIT_Web_App
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnALogin_Click(object sender, EventArgs e)
        {
            
            string username = txtAUsername.Text;
            string password = txtAPassword.Text;
            /*controlled redidancy - De-normalisation
                * one of the biggest de-normalisation process people in development is getting 
                * rid of 1:1 relationships
                */

            string sql = "select staffid, email, password from Staff where email = '" + username + "' and " +
                "password = '" + password + "'";

            SQLHelper helper = new SQLHelper();
            DataTable recordsRead = helper.ExecuteSQL(sql);
            

            if (recordsRead.Rows.Count >= 1)
            {
                int staffid = Convert.ToInt32(recordsRead.Rows[0][0].ToString());
                /* when currentbookings.cs is redirected we are not
                    * passing the customerid from here to the next page
                    * Web is stateless, we want to add the state
                    * to determine who is logged in
                    * QuearyString is the easiest way to pass data between
                    * two pages: HTML -> ASPX or ASPX _> ASPX beacause
                    * QuearyString is an ASP.NET Object
                    * like Response, Request
                    * page.ext?sessionid=oasdfadsf
                    * no limitations on how much you can pass as a quearystring(QuearyString
                    * in ASP.Net is a collection of (data, value) pair
                    * the only issue is if you are thinking of passing a particular data 
                    * between multiple pages then you need to keep on passing this value again and again
                    * for all other pages
                    */
                Session.Add("StaffId", staffid);
                Session.Add("Type", "Staff");
                Response.Redirect("JobRequests.aspx");
            }
            else
            {
                Response.Write("alert(Username or password is incorrect)");
            }


            
        }
    }
}