using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BIT_Web_App.App_Code
{
    public static class PageUtility
    {
        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", " alert('" + strMsg + "')", true);
        }
    }

    
}