using System.Windows;
using System.Windows.Controls;
using Client.Base.BaseClientVM;

namespace Client.Base.BaseClient
{
    /// <summary>
    /// Base of the Home Window
    /// </summary>
    public class HomeBaseWindow : BaseWindow
    {
        #region Property

        /// <summary>
        /// Home Page对应的VM只能是HomeBaseVM类型
        /// </summary>
        public HomeBaseVM VM { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// Reset VM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Reset(object sender, RoutedEventArgs e)
        {
            VM.Reset();
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Query(object sender, RoutedEventArgs e) { }

        #endregion

        #region Method

        public override void BindData()
        {
            var findName = (Grid)FindName("rootGrid");
            if (findName != null) findName.DataContext = VM;
        }

        #endregion
    }
}
