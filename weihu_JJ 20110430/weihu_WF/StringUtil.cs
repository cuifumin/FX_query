using System;
using System.Collections.Generic;
using System.Text;

namespace weihu_fx
{
    class StringUtil
    {
        private static StringBuilder tableNamePrefix = new StringBuilder("feng_lishi_");

        private static StringBuilder tableNameSuffixBasic = new StringBuilder("_year_month_suffix");

        private static StringBuilder[] replaceTableNameStr = new StringBuilder[3] { new StringBuilder("year"), new StringBuilder("month"), new StringBuilder("suffix") };

        private static StringBuilder[] suffixs = new StringBuilder[3] { new StringBuilder("early"), new StringBuilder("mid"), new StringBuilder("late"), };


        public static string[] getAllHistoryTableName(string positionName, int positionType, DateTime datetime)
        {
            StringBuilder[] result = new StringBuilder[3] { new StringBuilder(), new StringBuilder(), new StringBuilder() };

            for (int i = 0; i < 3; i++)
            {
                if (positionType == 0)
                {
                    result[i].Append(tableNamePrefix[0]).Append(positionName);
                }
                else
                {
                    result[i].Append(tableNamePrefix[1]).Append(positionName);
                }

                result[i].Append(tableNameSuffixBasic)
                    .Replace(replaceTableNameStr[0].ToString(), datetime.Year + replaceTableNameStr[0].ToString())
                    .Replace(replaceTableNameStr[1].ToString(), datetime.Month + replaceTableNameStr[1].ToString())
                    .Replace(replaceTableNameStr[2].ToString(), suffixs[i].ToString());

            }

            return convertToString(result);
        }

        public static string getHistoryTableName(string positionName, DateTime datetime, int suffixsIndex)
        {
            StringBuilder result = new StringBuilder();
            result.Append(tableNamePrefix).Append(positionName).Append(tableNameSuffixBasic)
                .Replace(replaceTableNameStr[0].ToString(), datetime.Year + replaceTableNameStr[0].ToString())
                .Replace(replaceTableNameStr[1].ToString(), datetime.Month + replaceTableNameStr[1].ToString())
                .Replace(replaceTableNameStr[2].ToString(), getMonthType(suffixsIndex).ToString());

            return result.ToString();
        }

        public static string getHistoryTableName(string positionName, DateTime datetime)
        {
            StringBuilder result = new StringBuilder();
            result.Append(tableNamePrefix).Append(positionName).Append(tableNameSuffixBasic)
                .Replace(replaceTableNameStr[0].ToString(), datetime.Year + replaceTableNameStr[0].ToString())
                .Replace(replaceTableNameStr[1].ToString(), datetime.Month + replaceTableNameStr[1].ToString())
                .Replace(replaceTableNameStr[2].ToString(), getMonthType(datetime).ToString());

            return result.ToString();
        }

        private static string[] convertToString(StringBuilder[] sbs)
        {
            string[] result = new string[sbs.Length];

            for (int i = 0; i < sbs.Length; i++)
            {
                result[i] = sbs[i].ToString();
            }

            return result;
        }

        public static StringBuilder getMonthType(DateTime datetime)
        {
            int day = datetime.Day;

            if (day >= 0 && day <= 10)
            {
                return suffixs[0];
            }
            else if (day > 10 && day <= 20)
            {
                return suffixs[1];
            }
            else
            {
                return suffixs[2];
            }

        }

        public static StringBuilder getMonthType(int suffixsIndex)
        {
            if (suffixsIndex >= 0 && suffixsIndex <= 2)
            {
                return suffixs[suffixsIndex];
            }

            return null;
        }

        public static int getSuffixsIndex(DateTime time)
        {
            int day = time.Day;

            if (day >= 0 && day <= 10)
            {
                return 0;
            }
            else if (day > 10 && day <= 20)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
