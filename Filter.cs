using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Diabetikus
{
    public enum FilterType
    {
        None,
        Text,
        Numceric,
        DateTime
    }
    public static class Filter
    {
        public static string filterStartToScalar(DateTime date, double days)
        {
            DateTime otherDate = date.AddDays(days);
            if(otherDate < date)
                return filterStartToEndDate(otherDate, date);
            else return filterStartToEndDate(date, otherDate);
        }

        public static string filterStartToEndDate(DateTime startDate, DateTime endDate)
        {
            return $"Datum >= '{startDate:dd.MM.yyyy}' AND Datum <= '{endDate:dd.MM.yyyy}'";
        }

        public static string filterValue(string v, string text)
        {
            return $"{v} = '{text}'";
        }
    }
}
