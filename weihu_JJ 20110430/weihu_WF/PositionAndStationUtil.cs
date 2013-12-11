using System;
using System.Collections.Generic;
using System.Text;

namespace weihu_fx
{
    class PositionAndStationUtil
    {
        #region 属性

        static DateTime[] dt_Wind_position_begin = new DateTime[] {DateTime.Parse("2010-07-27 00:00:00"),
            DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"), 
            DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"),
            DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"),
            DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"), DateTime.Parse("2010-07-27 00:00:00"),
            };

        string[] str_Wind_position_Name = new string[] {
            "JJF0007","JJF0012","JJF0025","JJF0036","JJF0044",
            "JJF0058","JJF0066","JJF0076","JJF0091","JJF0097",
            "JJF0103","JJF0112"};

        string[] str_Wind_position_K = new string[] {       
            "K6+531","K12+397","K25+833","K36+643","K43+657",
            "K57+141","K65+846","K76+494","K91+088","K97+394",
            "K102+404","K112+123"};

        string[] str_Wind_AlarmLevel = new string[] { "正常", "限速300", "限速200", "限速120", "停车" };

        string[] str_YW_postion_name = new string[] {
            "JJY0004","JJY0095","JJY0107","JJY0110","JJY0117"};

        string[] str_YW_postion_bridge_name = new string[] {
            "玉蜓桥","112国道桥","南仓道立交桥","普济河道立交桥","金纬路立交桥"};

        string[] str_YW_postion_K = new string[] {
            "K2+893","K93+649","K105+490","K108+416","K114+769"};

        //异物基站编号
        string[] str_YW_Station_Num = new string[] {
            "BJ-YZ02","WQ-TJ04","WQ-TJ08","WQ-TJ09","BTS-TJ"};

        //风基站编号
        string[] str_Wind_Station_Num = new string[] {
            "BJ-YZ03","BJ-YZ06","YZ-YL01","YZ-YL04","YZ-YL06",
            "YL-WQ03","YL-WQ05","YL-WQ05","WQ-TJ02","WQ-TJ04",
            "WQ-TJ06","WQ-TJ10"};

        public static string[] windPositionName = new string[]{ "全部" , 
            "JJF0007","JJF0012","JJF0025","JJF0036","JJF0044",
            "JJF0058","JJF0066","JJF0076","JJF0091","JJF0097",
            "JJF0103","JJF0112" };

        public static string[] dropPositionName = new string[]{ "全部",  
            "JJY0004","JJY0095","JJY0107","JJY0110","JJY0117" };

        public static string[] bridge_name = new string[] { "全部",
            "玉蜓桥","112国道桥","南仓道立交桥","普济河道立交桥","金纬路立交桥"};

        private static int[] dropPositionNameAtStationKIndex = new int[] { 0,1,2,3,4,5 };

        private static int[] dropPositionNameAtGridType = new int[] { 5,1,1,1,1,1};

        private static int[] dropPositionNameAtIOType = new int[] { 3,1,1,1,1,1};

        public static string[] allStationK = new string[]{  "全部", 
            "BJ-YZ02","BJ-YZ03","BJ-YZ06","YZ-YL01","YZ-YL04","YZ-YL06",
            "YL-WQ03","YL-WQ05","YL-WQ05","WQ-TJ02","WQ-TJ04",
            "WQ-TJ06","WQ-TJ08","WQ-TJ09","WQ-TJ10","BTS-TJ"};

        public static string[] windStationK = new string[] { "全部", 
            "BJ-YZ03","BJ-YZ06","YZ-YL01","YZ-YL04","YZ-YL06",
            "YL-WQ03","YL-WQ05","YL-WQ05","WQ-TJ02","WQ-TJ04",
            "WQ-TJ06","WQ-TJ10"};

        public static string[] dropStationK = new string[] { "全部", 
            "BJ-YZ02","WQ-TJ04","WQ-TJ08","WQ-TJ09","BTS-TJ"};

        public static string[] windPositionK = new string[]{ "全部" ,
            "JJK6+531","JJK12+397","JJK25+833","JJK36+643","JJK43+657",
            "JJK57+141","JJK65+846","JJK76+494","JJK91+088","JJK97+394",
            "JJK102+404","JJK112+123" };

        public static string[] dropPositionK = new string[] { "全部", 
            "K2+893","K93+649","K105+490","K108+416","K114+769"};

        public static string[] windPositionStartK = new string[]{ "" ,
            "JJK6+531","JJK12+397","JJK25+833","JJK36+643","JJK43+657",
            "JJK57+141","JJK65+846","JJK76+494","JJK91+088","JJK97+394",
            "JJK102+404","JJK112+123"};

        public static string[] windPositionEndK = new string[]{ "" , 
            "JJK6+531","JJK12+397","JJK25+833","JJK36+643","JJK43+657",
            "JJK57+141","JJK65+846","JJK76+494","JJK91+088","JJK97+394",
            "JJK102+404","JJK112+123" };

        //public static string[] str_DZ_postion_name = new string[] { "全部",
        //    "BJ-YZ06","YZ-YL04","YL-WQ08","WQ-TJ09","WQ-TJ04",
        //    "TSS1(亦庄)","亦庄站","ATS2","永乐保养点","ATS3",
        //    "ATS4","TSS2(武清)","武清站","ATS6" };
        public static string[] str_DZ_postion_name = new string[] { "全部",
            "BJ-YZ06","TSS1(亦庄)","亦庄站","ATS2","YZ-YL04",
            "永乐保养点","ATS3","ATS4","YL-WQ08","TSS2(武清)",
            "武清站","WQ-TJ04","ATS6","WQ-TJ09" };

        //public static string[] earthQuakeStationK = new string[] { "全部", 
        //    "JJK12+397", "JJK36+643", "JJK76+483", "JJK110+553", "JJK97+389", 
        //    "JJK19+767", "JJK22+200", "JJK34+887", "JJK47+583", "JJK48+677", 
        //    "JJK61+997", "JJK81+395", "JJK84+346", "JJK103+060"};

        public static string[] earthQuakeStationK = new string[] { "全部", 
            "JJK12+397", "JJK19+767", "JJK22+200", "JJK34+887", "JJK36+643", 
            "JJK47+583", "JJK48+677", "JJK61+997", "JJK76+483", "JJK81+395", 
            "JJK84+346", "JJK97+389", "JJK103+060", "JJK110+553"};

        #endregion

        #region 方法

        //根据监测点里程计算监测点名
        public static string getPositionNameByK(string strType, string strPositionK)
        {
            string strPositionName = "";
            if ("wind".Equals(strType))
            {
                for (int i = 0; i < windPositionK.Length; i++)
                {
                    if (strPositionK.Equals(windPositionK[i]))
                    {
                        strPositionName = windPositionName[i];
                        break;
                    }
                }
            }
            else if ("drop".Equals(strType))
            {
                for (int i = 0; i < dropPositionK.Length; i++)
                {
                    if (strPositionK.Equals(dropPositionK[i]))
                    {
                        strPositionName = dropPositionName[i];
                        break;
                    }
                }
            }

            return strPositionName;
        }

        //根据监测点名计算监测点里程
        public static string getPositionKByName(string strType, string strPositionName)
        {
            string strPositionK = "";
            if ("wind".Equals(strType))
            {
                for (int i = 0; i < windPositionName.Length; i++)
                {
                    if (strPositionName.Equals(windPositionName[i]))
                    {
                        strPositionK = windPositionK[i];
                        break;
                    }
                }
            }
            else if ("drop".Equals(strType))
            {
                for (int i = 0; i < dropPositionK.Length; i++)
                {
                    if (strPositionName.Equals(dropPositionName[i]))
                    {
                        strPositionK = dropPositionK[i];
                        break;
                    }
                }
            }
            return strPositionK;
        }

        //异物报警类型
        public static int getDropPositionGridType(string positionName)
        {
            for (int i = 0; i < dropStationK.Length; i++)
            {
                if (positionName.Equals(dropStationK[i]))
                {
                    return dropPositionNameAtGridType[i];
                }
            }

            return -1;
        }

        public static int getDropPositionIOType(string positionName)
        {
            for (int i = 0; i < dropStationK.Length; i++)
            {
                if (positionName.Equals(dropStationK[i]))
                {
                    return dropPositionNameAtIOType[i];
                }
            }

            return -1;
        }

        public static string getStationDropKByPositionName(string positionName)
        {
            for (int i = 0; i < dropPositionName.Length; i++)
            {
                if (positionName.Equals(dropPositionName[i]))
                {
                    return dropStationK[dropPositionNameAtStationKIndex[i]];
                }
            }
            return null;
        }

        public static int getWindPositionIndex(string positionName)
        {
            for (int i = 1; i < windPositionName.Length; i++)
            {
                if (positionName.ToUpper().Equals(windPositionName[i].ToUpper()))
                {
                    return i;
                }
            }
            return -1;
        }


        //是否是基站K
        public static bool isBaseStationK(int type, string stationK)
        {
            if (type == 1)
            {
                for (int i = 0; i < windStationK.Length; i++)
                {
                    if (windStationK[i].Equals(stationK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 2)
            {
                for (int i = 0; i < earthQuakeStationK.Length; i++)
                {
                    if (earthQuakeStationK[i].Equals(stationK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 3)
            {
                for (int i = 0; i < dropStationK.Length; i++)
                {
                    if (dropStationK[i].Equals(stationK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 4)
            {
                for (int i = 0; i < allStationK.Length; i++)
                {
                    if (allStationK[i].Equals(stationK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //是否是监测点K里程
        public static bool isPositionK(int type, string positionK)
        {
            if (type == 1)
            {
                for (int i = 1; i < windPositionK.Length; i++)
                {
                    if (windPositionK[i].Equals(positionK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 3)
            {
                for (int i = 1; i < dropPositionK.Length; i++)
                {
                    if (dropPositionK[i].Equals(positionK))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        //是否是监测点名
        public static bool isPositionName(int type, string positionName)
        {
            if (type == 1)
            {
                for (int i = 1; i < windPositionName.Length; i++)
                {
                    if (windPositionName[i].Equals(positionName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (type == 3)
            {
                for (int i = 1; i < bridge_name.Length; i++)
                {
                    if (bridge_name[i].Equals(positionName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static string getDropKByBridgeName(string bridgeName)
        {
            for (int i = 0; i < bridge_name.Length; i++)
            {
                if (bridgeName.Equals(bridge_name[i]))
                {
                    return dropStationK[i];
                }
            }

            return null;
        }

        public static string getEarthQuakeKByEarthQuakeName(string name)
        {
            for (int i = 0; i < str_DZ_postion_name.Length; i++)
            {
                if (str_DZ_postion_name[i].Equals(name))
                {
                    return earthQuakeStationK[i];
                }
            }

            return null;
        }

        public static string getBridgeNameByDropK(string dropK)
        {
            for (int i = 0; i < dropStationK.Length; i++)
            {
                if (dropK.Equals(dropStationK[i]))
                {
                    return bridge_name[i];
                }
            }

            return null;
        }

        public static string getEarthQuakeNameByEarthQuakeK(string earthQuakeK)
        {
            for (int i = 0; i < earthQuakeStationK.Length; i++)
            {
                if (earthQuakeK.Equals(earthQuakeStationK[i]))
                {
                    return str_DZ_postion_name[i];
                }
            }

            return null;
        }

        public static DateTime getWindBeginDateTime(string positionName)
        {
            for (int i = 0; i < windPositionName.Length; i++)
            {
                if (windPositionName[i].Equals(positionName))
                {
                    return dt_Wind_position_begin[i];
                }
            }

            return DateTime.Now;
        }

        #endregion

    }
}
