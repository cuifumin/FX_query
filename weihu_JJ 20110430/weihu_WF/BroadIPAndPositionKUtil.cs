using System;
using System.Collections.Generic;
using System.Text;

namespace weihu_fx
{
    class BroadIPAndPositionKUtil
    {
        #region 京津信息

        public static string[] getWindIPString()
        {
            string[] windIP = new string[2] { "192.168.1.120", "192.168.1.101" };
            return windIP;
        }

        public static string[][] getWindStationK()
        {
            string[][] windStationK = new string[2][] { new string[] { "K6+531","K12+397","K25+833","K36+643","K43+657",
                                                                                                "K57+141","K65+846","K76+494","K91+088","K97+394",
                                                                                                "K102+404","K112+123" }, 
                                                                           new string[] { "K6+531","K12+397","K25+833","K36+643","K43+657",
                                                                                                "K57+141","K65+846","K76+494","K91+088","K97+394",
                                                                                                "K102+404","K112+123" } };

            return windStationK;
        }

        public static int[][] getWindPositionNum()
        {
            int[][] windPositionNum = new int[2][] { new int[] { 1,1,1,1,1,1,1,1,1,1,1,1 }, new int[] { 1,1,1,1,1,1,1,1,1,1,1,1 } };

            return windPositionNum;
        }

        public static string[] getDropIPString()
        {
            string[] dropIP = new string[2] { "192.168.1.102", "192.168.1.103" };
            return dropIP;
        }

        public static string[][] getDropStationK()
        {
            string[][] dropStationK = new string[2][] { new string[] { "BJ-YZ02","WQ-TJ04","WQ-TJ08","WQ-TJ09","BTS-TJ" },
                                                                            new string[] { "BJ-YZ02","WQ-TJ04","WQ-TJ08","WQ-TJ09","BTS-TJ" } };

            return dropStationK;
        }

        #endregion
    }
}
