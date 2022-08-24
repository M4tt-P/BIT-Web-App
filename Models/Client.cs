using BIT_Web_App;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace BIT_Web_App
{
    public class Client
    {
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Suburb { get; set; }

        public string PhoneNumber { get; set; }

        public string Postcode { get; set; }

        public string State { get; set; }


        private SQLHelper _db;

        public Client()
        {
            _db = new SQLHelper();
        }

        public int InsertClient()
        {
            int returnValue = -1;
            string sqlStr = "insert into Client(firstname, lastname, email, password, address, suburb, phone, state, " +
                "postcode) values(@FName, @LName, @Email, @Password, @Address, @Suburb, @PNumber, @State, @Postcode)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[9];

            objParams[0] = new SqlParameter("@FName", DbType.String);
            objParams[0].Value = FirstName;

            objParams[1] = new SqlParameter("@LName", DbType.String);
            objParams[1].Value = LastName;

            objParams[2] = new SqlParameter("@Email", DbType.String);
            objParams[2].Value = Email;

            objParams[3] = new SqlParameter("@Password", DbType.String);
            objParams[3].Value = Password;

            objParams[4] = new SqlParameter("@Address", DbType.String);
            objParams[4].Value = Address;

            objParams[5] = new SqlParameter("@Suburb", DbType.String);
            objParams[5].Value = Suburb;

            objParams[6] = new SqlParameter("@PNumber", DbType.String);
            objParams[6].Value = PhoneNumber;

            objParams[7] = new SqlParameter("@State", DbType.String);
            objParams[7].Value = State;

            objParams[8] = new SqlParameter("@Postcode", DbType.String);
            objParams[8].Value = Postcode;

            returnValue = _db.ExecuteNonQuery(sqlStr, objParams);
            return returnValue;
        }
    }
}