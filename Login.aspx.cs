using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT_Web_App;

/* This login page for BIT is the entry point for the stakeholders 
 * Clients, Contractors and Co-ordinators
 * right now to begin with this login page we will only work with Client/Stakeholder
 * Assumer : user is email and passwords are stored in the same table 
 * for client
 * Please do not use Ids s a username (NOT RECOMMENDED)
 */

namespace BIT_Web_App
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;


            string sql = "select * from client where email = @Email and password = @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String);
            objParams[0].Value = txtEmail.Text;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = txtPassword.Text;

            //string sql = "select clientid, email, password from client where email = '" + username + "' and " +
            //    "password = '" + password + "'";

            SQLHelper helper = new SQLHelper();
            DataTable recordsRead = helper.ExecuteSQL(sql, objParams);

            //client login checker
            if (recordsRead.Rows.Count >= 1)
            {
                int clientid = Convert.ToInt32(recordsRead.Rows[0][0].ToString());
                /* when currentJobs.cs is redirected we are not
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
                Session.Add("ClientId", clientid);
                Session.Add("Type", "Client");
                Response.Redirect("clientcurrentjobs.aspx");
            }
            else
            {
                //contractor login checker
                string sqlContractor = "SELECT * from Staff WHERE email = @Email AND password=@Password AND stafftype = 0";
                objParams[0] = new SqlParameter("@Email", DbType.String);
                objParams[0].Value = txtEmail.Text;
                objParams[1] = new SqlParameter("@Password", DbType.String);
                objParams[1].Value = txtPassword.Text;

                DataTable contractorRecordsRead = helper.ExecuteSQL(sqlContractor, objParams);
                if (contractorRecordsRead.Rows.Count >= 1) 
                {
                    int staffid = Convert.ToInt32(contractorRecordsRead.Rows[0][0].ToString());
                    //Remember : Session is actually a Collection at the server level
                    //so keep on adding as many sessions you need it
                    //First parameter to Add() is a string and acts as a key
                    //and next parameter is an object a value to that key
                    Session.Add("StaffID", staffid);
                    Session.Add("Type", "Contractor");
                    Response.Redirect("contractorbookedjobs.aspx");
                }
                else //in future you will be also checking if the staff has logged 
                {
                    //coordinator login checker
                    string sqlCoordinator = "SELECT * from Staff WHERE email = @Email AND password=@Password AND stafftype = 1";
                    objParams[0] = new SqlParameter("@Email", DbType.String);
                    objParams[0].Value = txtEmail.Text;
                    objParams[1] = new SqlParameter("@Password", DbType.String);
                    objParams[1].Value = txtPassword.Text;

                    DataTable coordinatorRecordsRead = helper.ExecuteSQL(sqlCoordinator, objParams);
                    if (coordinatorRecordsRead.Rows.Count >= 1) 
                    {
                        int staffid = Convert.ToInt32(coordinatorRecordsRead.Rows[0][0].ToString());
                        //Remember : Session is actually a Collection at the server level
                        //so keep on adding as many sessions you need it
                        //First parameter to Add() is a string and acts as a key
                        //and next parameter is an object a value to that key
                        Session.Add("StaffID", staffid);
                        Session.Add("Type", "Coordinator");
                        Response.Redirect("coordinatorallbookedjobs.aspx");
                    }
                    else
                    {
                        //admin login checker
                        string sqlAdmin = "SELECT * from Staff WHERE email = @Email AND password=@Password AND stafftype = 2";
                        objParams[0] = new SqlParameter("@Email", DbType.String);
                        objParams[0].Value = txtEmail.Text;
                        objParams[1] = new SqlParameter("@Password", DbType.String);
                        objParams[1].Value = txtPassword.Text;

                        DataTable staffRecordsRead = helper.ExecuteSQL(sqlAdmin, objParams);
                        if (staffRecordsRead.Rows.Count >= 1) 
                        {
                            int staffid = Convert.ToInt32(staffRecordsRead.Rows[0][0].ToString());
                            //Remember : Session is actually a Collection at the server level
                            //so keep on adding as many sessions you need it
                            //First parameter to Add() is a string and acts as a key
                            //and next parameter is an object a value to that key
                            Session.Add("StaffID", staffid);
                            Session.Add("Type", "Admin");
                            Response.Redirect("coordinatorallbookedjobs.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Username or password is incorrect')</script>");
                        }
                    }
                }
            }
        }
    }
}