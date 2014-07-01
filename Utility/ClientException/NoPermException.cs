using System;

namespace Utility.ClientException
{
    public class NoPermException : Exception
    {
        public NoPermException() : base("没有该操作权限！")
        {
            
        }
    }
}
