using System;
using System.Collections.Generic;
using System.Text;

namespace weihu_fx
{
    class ConvertToChina
    {
        #region 公共翻译

        public static string getPanelState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("主控板1," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("1".Equals(byteNum))
            {
                result.Append("主控板2," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("14".Equals(byteNum))
            {
                result.Append("专用电源1," + utilPanel14To15(bitNum, stateNum));
            }
            else if ("15".Equals(byteNum))
            {
                result.Append("专用电源2," + utilPanel14To15(bitNum, stateNum));
            }
            else
            {
                result.Append("  ,  ,  ");
            }

            return result.ToString();
        }

        public static string utilPanel0To1(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("主/备状态," + isPrimary(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("网络通讯状态," + isException(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("电源1状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("电源2状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilPanel0To1New(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("主/备状态," + isPrimary(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("网络通讯状态," + isException(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("备板状态," + isBreadDown(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("电源1状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("电源2状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilPanel14To15(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("设备状态," + isWarning(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("设备通讯状态," + isException(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("外电输入状态," + isInput(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("电池状态," + isBattery(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilPanel14To15New(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("2".Equals(bitNum))
            {
                result.Append("外电输入状态," + isInput(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("电池状态," + isBattery(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        #endregion

        #region 风/雨翻译

        public static string getWindStationOnOffState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("主控板1," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("1".Equals(byteNum))
            {
                result.Append("主控板2," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("2".Equals(byteNum))
            {
                result.Append("气象板1A," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("3".Equals(byteNum))
            {
                result.Append("气象板1B," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("4".Equals(byteNum))
            {
                result.Append("气象板2A," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("5".Equals(byteNum))
            {
                result.Append("气象板2B," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("6".Equals(byteNum))
            {
                result.Append("气象板3A," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("7".Equals(byteNum))
            {
                result.Append("气象板3B," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("8".Equals(byteNum))
            {
                result.Append("气象板4A," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("9".Equals(byteNum))
            {
                result.Append("气象板4B," + utilWindStationOnOff2To9(bitNum, stateNum));
            }
            else if ("10".Equals(byteNum))
            {
                result.Append("气象传感器状态," + utilWindStationOnOff10(bitNum, stateNum));
            }
            else
            {
                result.Append("  ,  , ");
            }
            return result.ToString();
        }

        public static string utilWindStationOnOff2To9(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("1".Equals(bitNum))
            {
                result.Append("设备通讯状态," + isException(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("数据状态," + isEfficacious(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("传感器通讯状态," + isException(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("电源1状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilWindStationOnOff10(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("数据状态," + isEfficacious(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("数据2状态," + isEfficacious(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("数据3状态," + isEfficacious(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("数据4状态," + isEfficacious(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        #endregion

        #region 异物翻译

        public static string getDropAlarmState1(string byteNum, string bitNum, string stateNum, int inputType)
        {
            StringBuilder result = new StringBuilder();

            if (inputType == 1)
            {
                if ("10".Equals(byteNum))
                {
                    result.Append("异物调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("12".Equals(byteNum))
                {
                    result.Append("异物电网状态," + utilDropStationOnOffByte12Bit0To1(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else if (inputType == 2)
            {
                if ("11".Equals(byteNum))
                {
                    result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("12".Equals(byteNum))
                {
                    result.Append("异物1-2电网状态," + utilDropStationOnOffByte12Bit0To1(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropAlarmState2(string byteNum, string bitNum, string stateNum, int inputType)
        {
            StringBuilder result = new StringBuilder();

            if (inputType == 1)
            {
                if ("10".Equals(byteNum))
                {
                    result.Append("异物1调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("12".Equals(byteNum))
                {
                    result.Append("异物1-2电网状态," + utilDropStationOnOffByte12Bit4To5(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else if (inputType == 2)
            {
                if ("11".Equals(byteNum))
                {
                    result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("12".Equals(byteNum))
                {
                    result.Append("异物1-2电网状态," + utilDropStationOnOffByte12Bit4To5(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropAlarmState3(string byteNum, string bitNum, string stateNum, int inputType)
        {
            StringBuilder result = new StringBuilder();

            if (inputType == 1)
            {
                if ("10".Equals(byteNum))
                {
                    result.Append("异物1调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("13".Equals(byteNum))
                {
                    result.Append("异物3-4电网状态," + utilDropStationOnOffByte13Bit0To1(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else if (inputType == 2)
            {
                if ("11".Equals(byteNum))
                {
                    result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("13".Equals(byteNum))
                {
                    result.Append("异物3-4电网状态," + utilDropStationOnOffByte13Bit0To1(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropAlarmState4(string byteNum, string bitNum, string stateNum, int inputType)
        {
            StringBuilder result = new StringBuilder();

            if (inputType == 1)
            {
                if ("10".Equals(byteNum))
                {
                    result.Append("异物1调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("13".Equals(byteNum))
                {
                    result.Append("异物3-4电网状态," + utilDropStationOnOffByte13Bit4To5(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else if (inputType == 2)
            {
                if ("11".Equals(byteNum))
                {
                    result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
                }
                else if ("13".Equals(byteNum))
                {
                    result.Append("异物3-4电网状态," + utilDropStationOnOffByte13Bit4To5(bitNum, stateNum));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropAlarmState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("10".Equals(byteNum))
            {
                result.Append("异物调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
            }
            else if ("11".Equals(byteNum))
            {
                result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
            }
            else if ("12".Equals(byteNum))
            {
                result.Append("异物电网状态," + utilDropStationOnOff12(bitNum, stateNum));
            }
            else if ("13".Equals(byteNum))
            {
                result.Append("异物3-4电网状态," + utilDropStationOnOff13(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropOutputState1(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("异物调度输出," + utilDropStationOnOffOutput(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropOutputState2(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("1".Equals(byteNum))
            {
                result.Append("异物2调度输出," + utilDropStationOnOffOutput(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropOutputState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("异物调度输出," + utilDropStationOnOffOutput(bitNum, stateNum));
            }
            else if ("1".Equals(byteNum))
            {
                result.Append("异物2调度输出," + utilDropStationOnOffOutput(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string getDropStationOnOffState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("主控板1," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("1".Equals(byteNum))
            {
                result.Append("主控板2," + utilPanel0To1(bitNum, stateNum));
            }
            else if ("2".Equals(byteNum))
            {
                result.Append("异物1电网板" + utilDropStationOnOff2To5(bitNum, stateNum));
            }
            else if ("3".Equals(byteNum))
            {
                result.Append("异物2电网板" + utilDropStationOnOff2To5(bitNum, stateNum));
            }
            else if ("4".Equals(byteNum))
            {
                result.Append("异物3电网板" + utilDropStationOnOff2To5(bitNum, stateNum));
            }
            else if ("5".Equals(byteNum))
            {
                result.Append("异物4电网板" + utilDropStationOnOff2To5(bitNum, stateNum));
            }
            else if ("7".Equals(byteNum))
            {
                result.Append("异物电源," + utilDropStationOnOff7(bitNum, stateNum));
            }
            else if ("8".Equals(byteNum))
            {
                result.Append("异物调度板" + utilDropStationOnOff8To9(bitNum, stateNum));
            }
            else if ("9".Equals(byteNum))
            {
                result.Append("异物2调度板" + utilDropStationOnOff8To9(bitNum, stateNum));
            }
            else if ("10".Equals(byteNum))
            {
                result.Append("异物调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
            }
            else if ("11".Equals(byteNum))
            {
                result.Append("异物2调度输入," + utilDropStationOnOff10To11(bitNum, stateNum));
            }
            else if ("12".Equals(byteNum))
            {
                result.Append("异物电网状态," + utilDropStationOnOff12(bitNum, stateNum));
            }
            else if ("13".Equals(byteNum))
            {
                result.Append("异物3-4电网状态," + utilDropStationOnOff13(bitNum, stateNum));
            }
            else
            {
                result.Append("  ,  ,  ");
            }

            return result.ToString();
        }

        public static string utilDropStationOnOff2To5(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append(",主/备状态," + isPrimary(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("A,设备通讯状态," + isException(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("A,电网检测状态," + isBreadDown(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("A,输出接口状态," + isBreadDown(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("B,设备通讯状态," + isException(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("B,电网检测状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("B,输出接口状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilDropStationOnOff7(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("4".Equals(bitNum))
            {
                result.Append("异物电源1状态," + isBreadDown(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("异物电源2状态," + isBreadDown(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("异物电源3状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("异物电源4状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilDropStationOnOff8To9(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append(",主/备状态," + isPrimary(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("A,设备通讯状态," + isException(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("A,输入接口状态," + isBreadDown(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("A,输出接口状态," + isBreadDown(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("B,设备通讯状态," + isException(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("B,输入接口状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("B,输出接口状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilDropStationOnOff10To11(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("现场恢复状态," + isRestore(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("调度恢复状态," + isRestore(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("上行临时通车状态," + isTemporary(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("下行临时通车状态," + isTemporary(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("行车状态," + isStop(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilDropStationOnOff12(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("1电网1断线状态," + isCut(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("电网断线状态," + isCut(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("2电网1断线状态," + isCut(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("2电网2断线状态," + isCut(stateNum));
            }

            return result.ToString();
        }

        public static string utilDropStationOnOffByte12Bit0To1(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("1电网1断线状态," + isCut(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("1电网2断线状态," + isCut(stateNum));
            }
            return result.ToString();
        }

        public static string utilDropStationOnOffByte12Bit4To5(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("4".Equals(bitNum))
            {
                result.Append("2电网1断线状态," + isCut(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("2电网2断线状态," + isCut(stateNum));
            }
            return result.ToString();
        }

        public static string utilDropStationOnOff13(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("3电网1断线状态," + isCut(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("3电网2断线状态," + isCut(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("4电网1断线状态," + isCut(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("4电网2断线状态," + isCut(stateNum));
            }

            return result.ToString();
        }

        public static string utilDropStationOnOffByte13Bit0To1(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("3电网1断线状态," + isCut(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("3电网2断线状态," + isCut(stateNum));
            }

            return result.ToString();
        }

        public static string utilDropStationOnOffByte13Bit4To5(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("4".Equals(bitNum))
            {
                result.Append("4电网1断线状态," + isCut(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("4电网2断线状态," + isCut(stateNum));
            }

            return result.ToString();
        }

        public static string utilDropStationOnOffOutput(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("现场恢复状态," + isRestore(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("调度恢复状态," + isRestore(stateNum));
            }
            else if ("2".Equals(bitNum))
            {
                result.Append("上行临时通车状态," + isTemporary(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("下行临时通车状态," + isTemporary(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("试验输出," + isOutput(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        #endregion

        #region 地震翻译

        public static string getEarthQuakeStationOnOffState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("主控板1," + utilPanel0To1New(bitNum, stateNum));
            }
            else if ("1".Equals(byteNum))
            {
                result.Append("主控板2," + utilPanel0To1New(bitNum, stateNum));
            }
            else if ("2".Equals(byteNum))
            {
                result.Append("地震A板," + utilEarthQuakeStationOnOff2_5_1(bitNum, stateNum));
            }
            else if ("3".Equals(byteNum))
            {
                result.Append("地震A板," + utilEarthQuakeStationOnOff2_5_2(bitNum, stateNum));
            }
            else if ("4".Equals(byteNum))
            {
                result.Append("地震B板," + utilEarthQuakeStationOnOff2_5_1(bitNum, stateNum));
            }
            else if ("5".Equals(byteNum))
            {
                result.Append("地震B板," + utilEarthQuakeStationOnOff2_5_2(bitNum, stateNum));
            }
            else if ("6".Equals(byteNum))
            {
                result.Append("主控板1," + utilEarthQuakeStationOnOff6_7(bitNum, stateNum));
            }
            else if ("7".Equals(byteNum))
            {
                result.Append("主控板2," + utilEarthQuakeStationOnOff6_7(bitNum, stateNum));
            }
            else if ("9".Equals(byteNum))
            {
                result.Append("地震电源," + utilEarthQuakeStationOnOff9(bitNum, stateNum));
            }
            else if ("12".Equals(byteNum))
            {
                result.Append("地震回采," + utilEarthQuakeStationOnOff12(bitNum, stateNum));
            }
            else if ("13".Equals(byteNum))
            {
                result.Append("地震回采," + utilEarthQuakeStationOnOff13(bitNum, stateNum));
            }
            else if ("14".Equals(byteNum))
            {
                result.Append("专用电源1," + utilPanel14To15New(bitNum, stateNum));
            }
            else if ("15".Equals(byteNum))
            {
                result.Append("专用电源2," + utilPanel14To15New(bitNum, stateNum));
            }
            else
            {
                result.Append("  ,  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff2_5_1(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("主/备状态," + isPrimary(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("设备通讯状态," + isException(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("输出接口状态," + isBreadDown(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("电源1状态," + isBreadDown(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("电源2状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("电源3状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff2_5_2(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("3".Equals(bitNum))
            {
                result.Append("报警状态," + isAlarm(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("传感器状态," + isAlarm(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff6_7(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("COM1," + isCom1(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("COM1," + isCom2(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff9(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("2".Equals(bitNum))
            {
                result.Append("电源1状态," + isBreadDown(stateNum));
            }
            else if ("3".Equals(bitNum))
            {
                result.Append("电源2状态," + isBreadDown(stateNum));
            }
            else if ("4".Equals(bitNum))
            {
                result.Append("电源3状态," + isBreadDown(stateNum));
            }
            else if ("5".Equals(bitNum))
            {
                result.Append("电源4状态," + isBreadDown(stateNum));
            }
            else if ("6".Equals(bitNum))
            {
                result.Append("电源5状态," + isBreadDown(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("电源6状态," + isBreadDown(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff12(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("控车状态," + isStop3(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("控电状态," + isStop2(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOff13(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("6".Equals(bitNum))
            {
                result.Append("控车状态," + isEfficacious(stateNum));
            }
            else if ("7".Equals(bitNum))
            {
                result.Append("控电状态," + isEfficacious(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string getEarthQuakeAlarmState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("12".Equals(byteNum))
            {
                result.Append("地震回采," + utilEarthQuakeStationOnOff12(bitNum, stateNum));
            }
            else if ("3".Equals(byteNum))
            {
                result.Append("地震A板," + utilEarthQuakeStationOnOffAlarm(bitNum, stateNum));
            }
            else if ("5".Equals(byteNum))
            {
                result.Append("地震B板," + utilEarthQuakeStationOnOffAlarm(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOffAlarm(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("3".Equals(bitNum))
            {
                result.Append("报警状态," + isAlarm(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        public static string getEarthQuakeOutputState(string byteNum, string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(byteNum))
            {
                result.Append("地震调度输出," + utilEarthQuakeStationOnOffOutput(bitNum, stateNum));
            }
            else
            {
                return null;
            }

            return result.ToString();
        }

        public static string utilEarthQuakeStationOnOffOutput(string bitNum, string stateNum)
        {
            StringBuilder result = new StringBuilder();

            if ("0".Equals(bitNum))
            {
                result.Append("控车状态," + isTestStop(stateNum));
            }
            else if ("1".Equals(bitNum))
            {
                result.Append("控电状态," + isTestStop2(stateNum));
            }
            else
            {
                result.Append("  ,  ");
            }

            return result.ToString();
        }

        #endregion

        #region 状态翻译

        public static string isPrimary(string msg)
        {
            if ("0".Equals(msg))
            {
                return "备用";
            }
            else if ("1".Equals(msg))
            {
                return "主用";
            }
            else
            {
                return "  ";
            }
        }

        public static string isException(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "异常";
            }
            else
            {
                return "  ";
            }
        }

        public static string isBreadDown(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "故障";
            }
            else
            {
                return "  ";
            }
        }

        public static string isCom1(string msg)
        {
            if ("1".Equals(msg))
            {
                return "使用";
            }
            else if ("0".Equals(msg))
            {
                return "未使用";
            }
            else
            {
                return "  ";
            }
        }

        public static string isCom2(string msg)
        {
            if ("1".Equals(msg))
            {
                return "启用";
            }
            else if ("0".Equals(msg))
            {
                return "未启用";
            }
            else
            {
                return "  ";
            }
        }

        public static string isEfficacious(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "无效";
            }
            else
            {
                return "  ";
            }
        }

        public static string isWarning(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "故障报警";
            }
            else
            {
                return "  ";
            }
        }

        public static string isAlarm(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "报警";
            }
            else
            {
                return "  ";
            }
        }

        public static string isBattery(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "欠压";
            }
            else
            {
                return "  ";
            }
        }

        public static string isRestore(string msg)
        {
            if ("0".Equals(msg))
            {
                return "未恢复";
            }
            else if ("1".Equals(msg))
            {
                return "已恢复";
            }
            else
            {
                return "  ";
            }
        }

        public static string isTemporary(string msg)
        {
            if ("0".Equals(msg))
            {
                return "未临时通车";
            }
            else if ("1".Equals(msg))
            {
                return "临时通车";
            }
            else
            {
                return "  ";
            }
        }

        public static string isStop(string msg)
        {
            if ("0".Equals(msg))
            {
                return "停车";
            }
            else if ("1".Equals(msg))
            {
                return "正常";
            }
            else
            {
                return "  ";
            }
        }

        public static string isStop3(string msg)
        {
            if ("1".Equals(msg))
            {
                return "停车";
            }
            else if ("0".Equals(msg))
            {
                return "正常";
            }
            else
            {
                return "  ";
            }
        }

        public static string isStop2(string msg)
        {
            if ("1".Equals(msg))
            {
                return "停电";
            }
            else if ("0".Equals(msg))
            {
                return "正常";
            }
            else
            {
                return "  ";
            }
        }

        public static string isCut(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "断线";
            }
            else
            {
                return "  ";
            }
        }

        public static string isOutput(string msg)
        {
            if ("0".Equals(msg))
            {
                return "未输出";
            }
            else if ("1".Equals(msg))
            {
                return "输出";
            }
            else
            {
                return "  ";
            }
        }

        public static string isWork(string msg)
        {
            if ("online".Equals(msg.ToLower()))
            {
                return "工作";
            }
            else if ("offline".Equals(msg.ToLower()))
            {
                return "不工作";
            }
            else
            {
                return "  ";
            }
        }

        public static string isPort(string msg)
        {
            if ("e1000g1".Equals(msg.ToLower()))
            {
                return "端口1";
            }
            else if ("e1000g0".Equals(msg.ToLower()))
            {
                return "端口0";
            }
            else
            {
                return "  ";
            }
        }

        public static string isInput(string msg)
        {
            if ("0".Equals(msg))
            {
                return "正常";
            }
            else if ("1".Equals(msg))
            {
                return "无输入";
            }
            else
            {
                return "  ";
            }
        }

        public static string isTestStop(string msg)
        {
            if ("5".Equals(msg))
            {
                return "停车";
            }
            else if ("0".Equals(msg))
            {
                return "正常";
            }
            else
            {
                return "无效";
            }
        }

        public static string isTestStop2(string msg)
        {
            if ("5".Equals(msg))
            {
                return "停电";
            }
            else if ("0".Equals(msg))
            {
                return "正常";
            }
            else
            {
                return "无效";
            }
        }

        #endregion
    
    }
}
