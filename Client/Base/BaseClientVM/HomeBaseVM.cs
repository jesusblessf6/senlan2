using System.Collections.Generic;
using Utility.QueryManagement;

namespace Client.Base.BaseClientVM
{
    /// <summary>
    /// base VM for Home Page/Window
    /// </summary>
    public abstract class HomeBaseVM : BaseVM
    {
        /// <summary>
        /// Reset the VM
        /// </summary>
        public virtual void Reset()
        {

        }

        /// <summary>
        /// 根据查询类型获取查询语句的要素
        /// 抽象方法，派生类各自实现
        /// </summary>
        /// <param name="queryType"></param>
        /// <returns></returns>
        public abstract List<QueryElement> GetQueryElements(object queryType = null);
    }
}
