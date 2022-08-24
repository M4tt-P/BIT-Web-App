using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BIT_Web_App;

/*
 * Extend the add client to db to check if the email
 * address used for registration is already registred with BIT
 */

namespace BIT_Web_App
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            bool isFilledIn = true;
            int i = 0;

            //Input Checker
            while (isFilledIn && i <=9)
            {
                i++;
                switch (i)
                {
                    case 1:
                        if (txtFName.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 2:
                        
                        if (txtLName.Text == "" )
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 3:
                        if (txtPassword.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 4:
                        if (txtPhone.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 5:
                        if (txtAddress.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 6:
                        if (ddlState.Text == "select")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 7:
                        if (txtSuburb.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 8:
                        if (txtPostcode.Text == "")
                        {
                            isFilledIn = false;
                        }
                        break;

                    case 9://Future -  use regex
                        if (txtEmail.Text == "")
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
                Client newCustomer = new Client()
                {
                    FirstName = txtFName.Text,
                    LastName = txtLName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Suburb = txtSuburb.Text,
                    PhoneNumber = txtPhone.Text,
                    State = ddlState.Text,
                    Postcode = txtPostcode.Text
                };

                int returnValue = newCustomer.InsertClient();
                if (returnValue <= 1)
                {
                    Response.Write("<script>alert('Client Registration Successful');window.location = 'login.aspx';</script>");
                }
                else
                {
                    Response.Write("Sign Up Error. Could Not Sign Up");
                }
            }
        }
    }
}