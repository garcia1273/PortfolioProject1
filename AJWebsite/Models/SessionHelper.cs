using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AJWebsite.Models
{
   
        public static class SessionHelper
        {
            public static void LogUserIn(LoginViewModel member)
            {
                HttpContext.Current
                    .Session["UserID"] = member.Email;

            }

            public static bool IsUserLoggedIn()
            {
                if (HttpContext.Current
                        .Session["UserID"] != null)
                    return true;

                return false;
            }
        }
    
}