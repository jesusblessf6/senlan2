using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBEntity;
using System.Globalization;
using System.Data;
using Utility.ErrorManagement;
using System.ServiceModel;
using DBEntity.EnumEntity;

namespace Services.Helper.DeliveryNoFormulaHelper
{
    public class DeliveryNoFormulaHelper
    {
        public static string GetWarehouseNo(int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    string warehouseNo = "";
                    SystemParameter systemParameter = ctx.SystemParameters.FirstOrDefault(c => c.IsDeleted == false);
                    if (systemParameter != null)
                    {
                        if (systemParameter.DeliveryNoFormula == (int)DeliveryNoFormula.YYXXXX)
                        {
                            string year = DateTime.Now.ToString("yy");
                            if (string.IsNullOrEmpty(systemParameter.WarehouseOutNo))
                            {
                                warehouseNo = year + "-0001";
                            }
                            else
                            {
                                string lastY = systemParameter.WarehouseOutNo.Substring(0, 2);
                                if (Math.Abs(Convert.ToDouble(year) - Convert.ToDouble(lastY)) < double.Epsilon)
                                {
                                    string value = systemParameter.WarehouseOutNo.Substring(3);
                                    int maxValue = Convert.ToInt32(value) + 1;
                                    string maxResult = maxValue.ToString(CultureInfo.InvariantCulture);
                                    for (int i = 1; i <= (4 - maxValue.ToString(CultureInfo.InvariantCulture).Length); i++)
                                    {
                                        maxResult = ("0" + maxResult);
                                    }
                                    warehouseNo = lastY + "-" + maxResult;
                                }
                                else
                                {
                                    string nowYear = DateTime.Now.ToString("yy");
                                    warehouseNo = nowYear + "-0001";
                                }
                            }
                        }
                        else if(systemParameter.DeliveryNoFormula == (int)DeliveryNoFormula.XXXXX)
                        {
                            string value = systemParameter.WarehouseOutNo;
                            int maxValue = Convert.ToInt32(value) + 1;
                            string maxResult = maxValue.ToString(CultureInfo.InvariantCulture);
                            for (int i = 1; i <= (5 - maxValue.ToString(CultureInfo.InvariantCulture).Length); i++)
                            {
                                maxResult = ("0" + maxResult);
                            }
                            warehouseNo = maxResult;
                        }
                    }
                    return warehouseNo;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}