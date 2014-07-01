using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Utility.Controls
{
    public class CurrencyTextBox : TextBox
    {
        private int _selection;

        public CurrencyTextBox()
        {
            InputMethod.SetIsInputMethodEnabled(this, false);
        }

        /// <summary>
        /// 是否是正数
        /// </summary>
        public bool IsPositiveNumber { get; set; }

        public bool IsInteger { get; set; }

        public new String Text
        {
            get
            {
                string txt = base.Text.Replace(",", "");

                return txt == string.Empty ? null : txt;
            }
            set { base.Text = GetTxt(value); }
        }

        /// <summary>
        /// 文本框TextChanged事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            string txt = Text == null ? string.Empty : Text.Trim();
            if (txt == string.Empty)
            {
                base.Text = null;
                return;
            }
            if (txt == "-")
            {
                return;
            }
            if (txt == "")
                return;
            if (txt == ".")
            {
                txt = "0.";
                base.Text = txt;
                SelectionStart = base.Text.Length;
                return;
            }
            if (txt.Substring(txt.Length - 1) == ".")
            {
                return;
            }
            if (SelectionStart == 0)
            {
                //当鼠标移开currencyTextBox的时候 在前台会格式化一次 加上类似(.0000) 但是此时光标已经移开 无法获得光标再此文本框的位置 所以记录的还是未移开时的位置 所以计算光标位置的时候 要把加的(.0000)去掉
                int iden = 0;
                if (base.Text.Trim().Contains("."))
                {
                    int index = base.Text.Trim().IndexOf(".");
                    string lastTxt = base.Text.Trim().Substring(index + 1);

                    if (Convert.ToDecimal(lastTxt) == 0)
                    {
                        iden = base.Text.Substring(0, index).Length - base.Text.Substring(0, index).Replace(",", "").Length;
                    }
                    else
                    {
                        iden = base.Text.Length - base.Text.Replace(",", "").Length;
                    }
                }
                else
                {
                    iden = base.Text.Length - base.Text.Replace(",", "").Length;
                }
                if (txt.Trim().Contains("."))
                {
                    int index = txt.Trim().IndexOf(".");
                    string lastTxt = txt.Trim().Substring(index + 1);

                    if (Convert.ToDecimal(lastTxt) == 0)
                    {
                        if ((txt.Substring(0, index).Length - _selection + iden) > 0)
                            SelectionStart = txt.Substring(0, index).Length - _selection + iden;
                    }
                    else
                    {
                        if ((txt.Length - _selection + iden) > 0)
                            SelectionStart = txt.Length - _selection + iden;
                    }
                }
                else
                {
                    if ((txt.Length - _selection + iden) > 0)
                        SelectionStart = txt.Length - _selection + iden;
                }
                
            }
            else
            {
                if (base.Text.Trim().Contains("."))
                {
                    int index = base.Text.Trim().IndexOf(".");
                    string lastTxt = base.Text.Trim().Substring(index + 1);

                    if (Convert.ToDecimal(lastTxt) == 0)
                    {
                        if (base.Text.Substring(0, index).Length != 0 && (base.Text.Substring(0, index).Length - SelectionStart) > 0)
                            _selection = base.Text.Substring(0, index).Length - SelectionStart;
                    }
                    else
                    {
                        if (base.Text.Length != 0 && (base.Text.Length - SelectionStart) > 0)
                            _selection = base.Text.Length - SelectionStart;
                    }
                }
                else
                {
                    if (base.Text.Length != 0 && (base.Text.Length - SelectionStart) > 0)
                        _selection = base.Text.Length - SelectionStart;
                }
               
                //if (base.Text.Length != 0 && (base.Text.Length - SelectionStart) > 0)
                //    _selection = base.Text.Length - SelectionStart;
            }

            base.Text = GetTxt(txt);
        }

        /// <summary>
        /// 文本框KeyDown事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            string txt = Text == null ? string.Empty : Text.Trim();
            if (e.Key == Key.OemComma)
            {
                e.Handled = true;
                return;
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                if (IsPositiveNumber)
                {
                    e.Handled = true;
                    return;
                }
                if (txt.Contains("-"))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (e.Key == Key.OemPeriod || e.Key==Key.Decimal)
            {
                if (IsInteger)
                {
                    e.Handled = true;
                }
            }
            else if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt.Contains(".") && e.Key == Key.Decimal)
                {
                    
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) &&
                     e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (e.Key == Key.Tab)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 设置符合格式的text
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private string GetTxt(string txt)
        {
            decimal d;
            string formatStr = string.Empty;

            if (decimal.TryParse(txt, out d))
            {
                int index = txt.IndexOf(".", StringComparison.Ordinal);
                if (index != -1 && index != 0)
                {
                    string beginStr = txt.Substring(0, index == 1 ? 1 : index);

                    if (beginStr.Replace("-", "").Length <= 3)
                    {
                        formatStr = txt;
                        return formatStr;
                    }
                    if (beginStr.Length > 3)
                    {
                        beginStr = Convert.ToDecimal(beginStr).ToString("C0").Substring(1);
                    }
                    string endStr = txt.Substring(index);
                    formatStr = beginStr + endStr;
                }
                else if (index == 0)
                {
                    formatStr = txt;
                }
                else
                {
                    formatStr = Convert.ToDecimal(txt).ToString("C0").Substring(1);
                }
            }
            else
            {
                if (txt.Length > 1)
                {
                    txt = txt.Substring(0, txt.Length - 1);
                    if (decimal.TryParse(txt, out d))
                    {
                        formatStr = txt;
                    }
                }
            }

            return formatStr;
        }
    }
}