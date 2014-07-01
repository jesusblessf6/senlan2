using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;

namespace Utility.Misc
{
    public class RenderToExcel
    {
        public List<object> Headers { get; set; }

        #region 导出Excel（适合没有分组和明细行的DataGrid,且没有特殊格式，否则使用下边的DataTable导出成Excel）

        public void DataGridRenderToExcel(DataGrid dataGrid, string filePath)
        {
            IWorkbook book = new HSSFWorkbook();
            ISheet sheet = book.CreateSheet();
            IRow header = sheet.CreateRow(0);


            var columns = dataGrid.Columns;
            int columnNum = 0;
            foreach (var column in columns)
            {
                if (column.Visibility == System.Windows.Visibility.Visible)
                {
                    ICell cell = header.CreateCell(columnNum);
                    cell.SetCellValue(column.Header.ToString());
                    columnNum++;
                }
            }

            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                IRow excelRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < columnNum; j++)
                {
                    string value = GetValue(dataGrid, i, j);
                    excelRow.CreateCell(j).SetCellValue(value);
                }
            }

            MemoryStream ms = new MemoryStream();
            FileStream fs;
            if (!File.Exists(filePath))
            {
                fs = new FileStream(filePath, FileMode.CreateNew);

            }
            else
            {
                fs = new FileStream(filePath, FileMode.Create);
            }
            try
            {

                book.Write(ms);
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
            catch (Exception)
            {
                throw new Exception("导出错误");
            }
            finally
            {
                fs.Close();
                fs.Dispose();
                ms.Close();
                ms.Dispose();
            }
        }

        #endregion

        private string GetValue(DataGrid dataGrid, int row, int col)
        {
            var value = dataGrid.Columns[col].GetCellContent(dataGrid.Items[row]) as TextBlock;
            return value.Text;
        }

        #region DataTable导出excel

        public void DataTableToExcel(DataTable dt, string filePath)
        {
            IWorkbook book = new HSSFWorkbook();
            ISheet sheet = book.CreateSheet();
            //IRow header = sheet.CreateRow(0);

            //int columnNum = 0;

            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    ICell cell = header.CreateCell(columnNum);
            //    cell.SetCellValue(dt.Columns[i].ColumnName);
            //    columnNum++;
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow excelRow = sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string value = dt.Rows[i][j].ToString();
                    excelRow.CreateCell(j).SetCellValue(value);
                }
            }

            if (filePath.LastIndexOf(".xls") == -1)
            {
                filePath += ".xls";
            }

            MemoryStream ms = new MemoryStream();
            FileStream fs;
            if (!File.Exists(filePath))
            {
                fs = new FileStream(filePath, FileMode.CreateNew);

            }
            else
            {
                fs = new FileStream(filePath, FileMode.Create);
            }
            try
            {

                book.Write(ms);
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
            catch (Exception)
            {
                throw new Exception("导出错误");
            }
            finally
            {
                fs.Close();
                fs.Dispose();
                ms.Close();
                ms.Dispose();
            }
        }

        #endregion
    }
}
