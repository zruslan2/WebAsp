using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebFormsEmpty.Models;

namespace WebFormsEmpty
{

    public class CountSession
    {
        public int Count { get; set; } = 0;       
    }

    public class Global : System.Web.HttpApplication
    {
        CountSession countSession = new CountSession();

        public int Count = 0;
        protected void Application_Start(object sender, EventArgs e)
        {
            Repos repos = new Repos();  
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            countSession.Count++;

            //Session["cnt"] = ++Count;
            //Session["countSession"] = countSession;

            Session["DateTime_Now"] = DateTime.Now;
            Session["Date_now"] = DateTime.Today;
        }
    }
}