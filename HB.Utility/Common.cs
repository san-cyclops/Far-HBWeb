﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Utility
{
    public static class Common
    {
        public static DateTime ToDateTime(this string datetime, char dateSpliter = '-', char timeSpliter = ':', char millisecondSpliter = ',')
        {
            try
            {
                datetime = datetime.Trim();
                datetime = datetime.Replace("  ", " ");
                string[] body = datetime.Split(' ');
                string[] date = body[0].Split(dateSpliter);
                // int year = Convert.ToInt32(date[2]);
                int year,month,day;
                Int32.TryParse(date[2],out year);
                Int32.TryParse(date[0],out month);
                Int32.TryParse(date[1],out day);

             //   int month = Convert.ToInt32(date[0]);
              //  int day = Convert.ToInt32(date[1]);
                int hour = 0, minute = 0, second = 0, millisecond = 0;
                if (body.Length == 2)
                {
                    string[] tpart = body[1].Split(millisecondSpliter);
                    string[] time = tpart[0].Split(timeSpliter);
                    hour = Convert.ToInt32(time[0]);
                    minute = Convert.ToInt32(time[1]);
                    if (time.Length == 3) second = Convert.ToInt32(time[2]);
                    if (tpart.Length == 2) millisecond = Convert.ToInt32(tpart[1]);
                }
                // return new DateTime(year, month, day, hour, minute, second, millisecond);
                return new DateTime( year,month, day, hour, minute, second);
            }
            catch (Exception ex)
             {
                return new DateTime();
            }
        }

    }

}