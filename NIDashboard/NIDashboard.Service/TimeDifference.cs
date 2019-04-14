using System;
using System.Collections.Generic;
using System.Text;

namespace NIDashboard.Service
{
    public class TimeDifference
    {
        public string PostTimeDifference(DateTime datePosted)
        {
            TimeSpan ts = DateTime.Now - datePosted;
            string result;
            if (ts.TotalMinutes < 60)
            {
                if (ts.TotalMinutes < 1)
                {
                    result = "now.";
                }
                else if ((int)ts.TotalMinutes == 1)
                {
                    result = "1 minute ago.";
                }
                else
                {
                    result = ts.Minutes.ToString() + " minutes ago.";
                }
            }
            else if (ts.TotalHours < 24)
            {
                if ((int)ts.TotalHours == 1)
                {
                    result = "1 hour ago.";
                }
                else
                {
                    result = ts.Hours.ToString() + " hours ago.";
                }
            }
            else
            {
                if ((int)ts.TotalDays == 1)
                {
                    result = "1 day ago.";
                }
                else
                {
                    result = ((int)ts.TotalDays).ToString() + " days ago.";
                }
            }

            return result;
        }
    }
}
