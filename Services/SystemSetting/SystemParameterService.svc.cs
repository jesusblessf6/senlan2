using Services.Base;
using DBEntity;
using System.IO;
using System.Collections.Generic;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SystemParameterService" in code, svc and config file together.
    public class SystemParameterService :  BaseService<SystemParameter>, ISystemParameterService
    {
        public List<string> GetDiskNameList()
        {
            List<string> diskNameList = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives(); // 获取所有驱动器信息。。
            foreach (DriveInfo drive in drives)
            {
                // 判断是否为硬盘
                if (drive.DriveType == DriveType.Fixed)
                {
                    diskNameList.Add(drive.Name);
                }
            }
            diskNameList.Insert(0, "");

            return diskNameList;
        }
    }
}
