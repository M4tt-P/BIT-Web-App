using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace BIT_Web_App
{
    public class Job
    {
        public int ClientID { get; set; }
        public int StaffID { get; set; }
        public string JobAddress { get; set; }
        public string SkillName { get; set; }
        public string JobDescription { get; set; }
        public DateTime DateOfJob { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public int SkillID { get; set; }
        public string Status { get; set; }
        
        private SQLHelper _db;

        public Job()
        {
            _db = new SQLHelper();
        }

        public int InsertJob()
        {
            int returnValue = -1; //Check with Chaitali
            string sqlStr = "insert into JobRequest(jobaddress, clientid, jobdescription, skillid, dateofjob, suburb, postcode, status) " +
                "values (@JAddress, @ClientID, @JDescription, @SkillID, @DOJ, @Suburb, @Postcode, @Status) ";
                //"from JobRequest j, Client c, Staff s" +
                //"where c.clientid = j.clientid and s.skillid = j.skillid and s.skillid = j.skillid";

            SqlParameter[] objParams;
            objParams = new SqlParameter[8];


            objParams[0] = new SqlParameter("@JAddress", DbType.String);
            objParams[0].Value = JobAddress;

            objParams[1] = new SqlParameter("@ClientID", DbType.Int32);
            objParams[1].Value = ClientID;

            objParams[2] = new SqlParameter("@JDescription", DbType.String);
            objParams[2].Value = JobDescription;

            objParams[3] = new SqlParameter("@SkillID", DbType.Int32);
            objParams[3].Value = SkillID;

            objParams[4] = new SqlParameter("@DOJ", DbType.DateTime);
            objParams[4].Value = DateOfJob;

            objParams[5] = new SqlParameter("@Suburb", DbType.String);
            objParams[5].Value = Suburb;

            objParams[6] = new SqlParameter("@Postcode", DbType.String);
            objParams[6].Value = Postcode;

            objParams[7] = new SqlParameter("@Status", DbType.String);
            objParams[7].Value = Status;

            returnValue = _db.ExecuteNonQuery(sqlStr, objParams);
            return returnValue;
        }

        
    }
}