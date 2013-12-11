using System;
using System.Collections.Generic;
using System.Text;

namespace weihu_fx
{
    class ConvertUtil
    {
        public static string byteToString(byte data)
        {
            StringBuilder result = new StringBuilder();

            while (data > 1)
            {
                if (data % 2 == 0)
                {
                    result.Insert(0, "0");
                }
                else
                {
                    result.Insert(0, "1");
                }
                data /= 2;
            }
            if (data == 1)
            {
                result.Insert(0, "1");
            }
            else
            {
                result.Insert(0, "0");
            }

            while (result.Length < 8)
            {
                result.Insert(0, "0");
            }

            return result.ToString();
        }

        public static string[] byteToStringArray(byte data)
        {
            string[] result = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
            int position = 7;

            while (data > 1)
            {
                if (data % 2 == 0)
                {
                    result[position] = "0";
                }
                else
                {
                    result[position] = "1";
                }
                data /= 2;
                position--;
            }

            if (data == 1)
            {
                result[position] = "1";
            }
            else
            {
                result[position] = "0";
            }
            myStringReplace(result);

            return result;
        }

        private static void myStringReplace(string[] str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                string temp = str[i];
                str[i] = str[str.Length - 1 - i];
                str[str.Length - 1 - i] = temp;
            }
        }

        public static int bytesToInt(string low, string high)
        {
            byte[] bytes = new byte[4];

            bytes[0] = Convert.ToByte(low);
            bytes[1] = Convert.ToByte(high);
            bytes[2] = 0;
            bytes[3] = 0;

            return System.BitConverter.ToInt32(bytes, 0);
        }

        public static uint bytesToUInt(string low, string high)
        {
            byte[] bytes = new byte[4];

            bytes[0] = Convert.ToByte(low);
            bytes[1] = Convert.ToByte(high);
            bytes[2] = 0;
            bytes[3] = 0;

            return System.BitConverter.ToUInt32(bytes, 0);
        }

    }
}
