﻿using System;
using System.Globalization;

namespace Utility.Misc
{
    public class IdCardNoValidation
    {
        public static bool Validate(string idNo)
        {
            var len = idNo.Length;
            bool result = true;

            if (len != 15 && len != 18)
            {
                return false;
            }

            switch (len)
            {
                case 15:
                    result = Validate15(idNo);
                    break;
                case 18:
                    result = Validate18(idNo);
                    break;
            }

            return result;
        }

        private static bool Validate15(string idNo)
        {
            long n;
            if (long.TryParse(idNo, out n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNo.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            string birth = idNo.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }

        private static bool Validate18(string idNo)
        {
            long n;
            if (long.TryParse(idNo.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(idNo.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNo.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            string birth = idNo.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] ai = idNo.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString(CultureInfo.InvariantCulture));
            }
            int y;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNo.Substring(17, 1).ToLower())
            {
                return false; //校验码验证
            }
            return true; //符合GB11643-1999标准
        }
    }
}
