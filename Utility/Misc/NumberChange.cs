using System;
using System.Globalization;

namespace Utility.Misc
{
    public static class NumberChange
    {
        private const String CNNumber = "零壹贰叁肆伍陆柒捌玖";
        private const String CNUnit = "分角元拾佰仟万拾佰仟亿拾佰仟兆拾佰仟";


        // 以下是货币金额中文大写转换方法
        public static string GetCnString(string moneyString)
        {
            String[] tmpString = moneyString.Split('.');
            String intString = moneyString;   // 默认为整数
            String decString = "";            // 保存小数部分字串
            String rmbCapital = "";            // 保存中文大写字串

            if (tmpString.Length > 1)
            {
                intString = tmpString[0];             // 取整数部分
                decString = tmpString[1];             // 取小数部分
            }
            decString += "00";
            decString = decString.Substring(0, 2);   // 保留两位小数位
            intString += decString;

            try
            {
                int k = intString.Length - 1;
                if (k > 0 && k < 18)
                {
                    for (int i = 0; i <= k; i++)
                    {
                        int j = intString[i] - 48;
                        int n = i + 1 >= k ? intString[k] - 48 : intString[i + 1] - 48;
                        if (j == 0)
                        {
                            if (k - i == 2 || k - i == 6 || k - i == 10 || k - i == 14)
                            {
                                rmbCapital += CNUnit[k - i];
                            }
                            else
                            {
                                if (n != 0)
                                {
                                    rmbCapital += CNNumber[j];
                                }
                            }
                        }
                        else
                        {
                            rmbCapital = rmbCapital + CNNumber[j] + CNUnit[k - i];
                        }
                    }

                    rmbCapital = rmbCapital.Replace("兆亿万", "兆");
                    rmbCapital = rmbCapital.Replace("兆亿", "兆");
                    rmbCapital = rmbCapital.Replace("亿万", "亿");
                    rmbCapital = rmbCapital.TrimStart('元');
                    rmbCapital = rmbCapital.TrimStart('零');

                    return rmbCapital;
                }
                
                return "";   // 超出转换范围时，返回零长字串
            }
            catch
            {
                return "";   // 含有非数值字符时，返回零长字串
            }
        }

        /// <summary>
        /// 获得金额大写
        /// </summary>
        /// <param name="moneyString"></param>
        /// <returns></returns>
        public static string GetNumberChange(string moneyString)
        {
            string money = GetCnString(moneyString);
            if (string.IsNullOrEmpty(money))
            {
                money = "零元整";
            }
            else {
                money += "整";
            }
            return money;
        }

        /// <summary>
        /// 获得数量大写
        /// </summary>
        /// <param name="strQuantity"></param>
        /// <returns></returns>
        public static string GetQuantityChange(string strQuantity)
        {
            string quantity = ConvertSum(strQuantity);
            return quantity;
        }

        /// <summary>
        /// 获得数字大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertSum(string str)
        {
            var ch = new char[1];
            ch[0] = '.'; //小数点
            string[] splitstr = str.Split(ch[0]);
            if (splitstr.Length == 1) //只有整数部分
                return ConvertData(str);
            
            string rstr = ConvertData(splitstr[0]);
            rstr += ConvertXiaoShu(splitstr[1]);//转换小数部分
            return rstr;
        }

        /// 
        /// 转换数字（整数）
        /// 
        /// 需要转换的整数数字字符串
        /// 转换成中文大写后的字符串
        public static string ConvertData(string str)
        {
            string rstr = "";
            int strlen = str.Length;
            if (strlen <= 4)//数字长度小于四位
            {
                rstr = ConvertDigit(str);

            }
            else
            {
                string tmpstr;
                if (strlen <= 8)//数字长度大于四位，小于八位
                {
                    tmpstr = str.Substring(strlen - 4, 4);//先截取最后四位数字
                    rstr = ConvertDigit(tmpstr);//转换最后四位数字
                    tmpstr = str.Substring(0, strlen - 4);//截取其余数字
                    //将两次转换的数字加上萬后相连接
                    rstr = String.Concat(ConvertDigit(tmpstr) + "萬", rstr);
                    rstr = rstr.Replace("零萬", "萬");
                    rstr = rstr.Replace("零零", "零");

                }
                else
                    if (strlen <= 12)//数字长度大于八位，小于十二位
                    {
                        tmpstr = str.Substring(strlen - 4, 4);//先截取最后四位数字
                        rstr = ConvertDigit(tmpstr);//转换最后四位数字
                        tmpstr = str.Substring(strlen - 8, 4);//再截取四位数字
                        rstr = String.Concat(ConvertDigit(tmpstr) + "萬", rstr);
                        tmpstr = str.Substring(0, strlen - 8);
                        rstr = String.Concat(ConvertDigit(tmpstr) + "億", rstr);
                        rstr = rstr.Replace("零億", "億");
                        rstr = rstr.Replace("零萬", "零");
                        rstr = rstr.Replace("零零", "零");
                        rstr = rstr.Replace("零零", "零");
                    }
            }
            strlen = rstr.Length;
            if (strlen >= 2)
            {
                switch (rstr.Substring(strlen - 2, 2))
                {
                    case "佰零": rstr = rstr.Substring(0, strlen - 2) + "佰"; break;
                    case "仟零": rstr = rstr.Substring(0, strlen - 2) + "仟"; break;
                    case "萬零": rstr = rstr.Substring(0, strlen - 2) + "萬"; break;
                    case "億零": rstr = rstr.Substring(0, strlen - 2) + "億"; break;

                }
            }

            return rstr;
        }
        /// 
        /// 转换数字（小数部分）
        /// 
        /// 需要转换的小数部分数字字符串
        /// 转换成中文大写后的字符串
        public static string ConvertXiaoShu(string str)
        {
            int strlen = str.Length;
            string rstr = "";
            if (strlen > 0)
            {
                rstr = "点" + ConvertChinese(str[0].ToString(CultureInfo.InvariantCulture));
                if (str.Length > 1)
                    rstr += ConvertChinese(str[1].ToString(CultureInfo.InvariantCulture));
                if (str.Length > 2)
                    rstr += ConvertChinese(str[2].ToString(CultureInfo.InvariantCulture));
                if (str.Length > 3)
                    rstr += ConvertChinese(str[3].ToString(CultureInfo.InvariantCulture));
            }
            return rstr;
        }

        /// 
        /// 转换数字
        /// 
        /// 转换的字符串（四位以内）
        /// 
        public static string ConvertDigit(string str)
        {
            int strlen = str.Length;
            string rstr = "";
            switch (strlen)
            {
                case 1: rstr = ConvertChinese(str); break;
                case 2: rstr = Convert2Digit(str); break;
                case 3: rstr = Convert3Digit(str); break;
                case 4: rstr = Convert4Digit(str); break;
            }
            rstr = rstr.Replace("拾零", "拾");

            return rstr;
        }


        /// 
        /// 转换四位数字
        /// 
        public static string Convert4Digit(string str)
        {
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string str4 = str.Substring(3, 1);
            string rstring = "";
            rstring += ConvertChinese(str1) + "仟";
            rstring += ConvertChinese(str2) + "佰";
            rstring += ConvertChinese(str3) + "拾";
            rstring += ConvertChinese(str4);
            rstring = rstring.Replace("零仟", "零");
            rstring = rstring.Replace("零佰", "零");
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }
        /// 
        /// 转换三位数字
        /// 
        public static string Convert3Digit(string str)
        {
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string rstring = "";
            rstring += ConvertChinese(str1) + "佰";
            rstring += ConvertChinese(str2) + "拾";
            rstring += ConvertChinese(str3);
            rstring = rstring.Replace("零佰", "零");
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }
        /// 
        /// 转换二位数字
        /// 
        public static string Convert2Digit(string str)
        {
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string rstring = "";
            rstring += ConvertChinese(str1) + "拾";
            rstring += ConvertChinese(str2);
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }
        /// 
        /// 将一位数字转换成中文大写数字
        /// 
        public static string ConvertChinese(string str)
        {
            //"零壹贰叁肆伍陆柒捌玖拾佰仟萬億圆整角分"
            string cstr = "";
            switch (str)
            {
                case "0": cstr = "零"; break;
                case "1": cstr = "壹"; break;
                case "2": cstr = "贰"; break;
                case "3": cstr = "叁"; break;
                case "4": cstr = "肆"; break;
                case "5": cstr = "伍"; break;
                case "6": cstr = "陆"; break;
                case "7": cstr = "柒"; break;
                case "8": cstr = "捌"; break;
                case "9": cstr = "玖"; break;
            }
            return (cstr);
        }
    }
}
