using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BIT_Web_App
{
    public class AvailableContractors
    {
        public AvailableContractors()
        {

        }
        public static DataTable GetAllAvailableContractors(int day, int skill)
        {
            //if you compare this query with finding contractors
            //then a similar query will be required to find all available contractor for a job
            //Then what will be your query?
            string sqlStr = "SELECT st.firstname as firstname, st.lastname as lastname, " +
                "st.suburb as suburb, st.staffid as staffid " +
                "FROM Staff st, Staffskills stsk, Availability a, Skills sk, DayofWeek d, Jobrequest j " +
                "WHERE st.staffid = a.staffid AND st.staffid = stsk.staffid AND sk.skillid = j.skillid  AND " +
                "sk.skillid = stsk.skillid AND d.dayid = a.dayid AND st.stafftype = 0 " +
                "AND a.dayid = '" + day + "' AND a.isavailable = 'TRUE' AND  " +
                "stsk.skillid = " + skill + " "; 
                //+ " NOT EXIST (SELECT st.staffid, j.clientid, j.jobid " +
                //"FROM Staff st, JobRequest j, rj rejectedjob " +
                //"WHERE st.staffid = rj.staffid AND j.JobID = rj.JobID)";
                //"AND st.staff not in (SELECT st.staffid, cl.clientid, j.jobid " +
                //"FROM Staff st, Client cl, JobRequest j, RejectedJobs rj " +
                //"WHERE st.staffid = rj.staffid AND j.jobid = rj.jobid)";
            //this is where in BIT services if you are maintaining rejected Jobs
            //then you may have to write a subquery
            //  string storedProc = "usp_available
            

            SQLHelper objHelper = new SQLHelper();
            return objHelper.ExecuteSQL(sqlStr);

        }
    }


}