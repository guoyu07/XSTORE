
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Formula.Eval;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web.UI.WebControls;

namespace DTcms.Common
{


    public class NPOIHelper
    {
        public static Stream RenderDataTableToExcel(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
            // handling header.   
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            // handling value.       
            int rowIndex = 1;
            foreach (DataRow row in SourceTable.Rows)
            {
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }
            int i = 0;
            foreach (DataColumn column in SourceTable.Columns)
            {
                sheet.AutoSizeColumn(i);
                i++;
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet = null;
            headerRow = null;
            workbook = null;
            return ms;
        }
        public static Stream RenderHtmlToExcel(ExcelStyle exStyle, string Html, string FileName)
        {
            NPOIHelper poi = new NPOIHelper();
            Stream s = poi.ExportHtmlToExcel(exStyle, Html, FileName);
            return s;
        }
        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            data = null;
            ms = null;
            fs = null;
        }
        //public static void RenderDataTableToExcel_Web(DataTable SourceTable, string FileName)
        //{
        //    MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
        //    HttpResponse Response = HttpContext.Current.Response;
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".xls"));
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.ContentType = "application/vnd.ms-excel";  
        //    Response.BinaryWrite(ms.ToArray());
        //    ms = null;
        //    Response.End();
        //}
        public static void RenderDataTableToExcel_Web(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + FileName + ".xls"));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(ms.ToArray());
            ms = null;
            Response.End();
        }
        //CSV格式
        public static void RenderDataTableToExcel_CSV(DataTable dt, string FileName)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".csv"));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            StringBuilder sb = new StringBuilder();
            //            string s=@"<html xmlns:v='urn:schemas-microsoft-com:vml'
            //            xmlns:o='urn:schemas-microsoft-com:office:office'
            //            xmlns:x='urn:schemas-microsoft-com:office:excel' 
            //            xmlns='http://www.w3.org/TR/REC-html40'><head>
            //            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
            //            </head>
            //            <body>
            //            <table>
            //            ";
            //            sb.Append(s);
            //            sb.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                //   sb.Append("<td x:str=\"'" + dt.Columns[i].ColumnName + "\">' " + dt.Columns[i].ColumnName + "</td>");
                sb.Append(dt.Columns[i].ColumnName + ",");
            }
            //sb.Append("</tr>");
            sb.Append("\r\n");

            foreach (DataRow item in dt.Rows)
            {
                //sb.Append("<tr>");
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    //sb.Append("<td x:str=\"'" + item.ItemArray[i].ToString() + "\">" + item.ItemArray[i].ToString() + "</td>");
                    sb.Append(item.ItemArray[i].ToString() + ",");
                }
                //sb.Append("</tr>");
                sb.Append("\r\n");
            }
            //sb.Append("</table></body></html>");
            Response.Write(sb.ToString());
            Response.End();
        }
        //xls格式
        public static void RenderDataTableToExcel_XLS(DataTable dt, string FileName)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".xls"));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            StringBuilder sb = new StringBuilder();
            string s=@"<html xmlns:v='urn:schemas-microsoft-com:vml'
            xmlns:o='urn:schemas-microsoft-com:office:office'
            xmlns:x='urn:schemas-microsoft-com:office:excel' 
            xmlns='http://www.w3.org/TR/REC-html40'><head>
            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
            </head>
            <body>
            <table>
            ";
            sb.Append(s);
            sb.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append("<td x:str=\"'" + dt.Columns[i].ColumnName + "\">' " + dt.Columns[i].ColumnName + "</td>");
            }
            sb.Append("</tr>");

            foreach (DataRow item in dt.Rows)
            {
                sb.Append("<tr>");
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    sb.Append("<td x:str=\"'" + item.ItemArray[i].ToString() + "\">" + item.ItemArray[i].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table></body></html>");
            Response.Write(sb.ToString());
            Response.End();
        }
        public static void RenderHtmlToExcel_Web(ExcelStyle exStyle, string Html, string FileName)
        {
            MemoryStream ms = RenderHtmlToExcel(exStyle, Html, FileName) as MemoryStream;
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".xls"));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(ms.ToArray());
            ms = null;
            Response.End();
        }
        public static void RenderHtmlToExcel_Web(ExcelStyle exStyle, Panel literal, string FileName)
        {
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            literal.RenderControl(oHtmlTextWriter);
            string ret = oStringWriter.ToString();
            ret = ret.Substring(1);
            ret = ret.Substring(0, ret.Length - "</div>".Length);
            NPOIHelper.RenderHtmlToExcel_Web(exStyle, ret, FileName);
        }
        private static string ChangeName(string input)
        {
            string s = Regex.Replace(input, @"\s+", "_", RegexOptions.IgnoreCase);
            return s;
        }
        //RenderDataTableFromExcel:来自excel文件
        //ExcelFileStream:文件流
        //SheetName 工作区名称
        //HeaderRowIndex 行头 
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);
            DataTable table = new DataTable();
            HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell != null)
                    {
                        dataRow[j] = getCellStringValue(row.GetCell(j));
                    }
                }
            }
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        //RenderDataTableFromExcel:来自excel文件
        //ExcelFileStream:文件流
        //SheetIndex 工作区
        //HeaderRowIndex 行头  
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(SheetIndex);
            DataTable table = new DataTable();
            HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell != null)
                    {
                        dataRow[j] = getCellStringValue(row.GetCell(j));
                    }
                }
                table.Rows.Add(dataRow);
            }
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        private static string getCellStringValue(ICell cell)
        {
            string cellValue = "";
            switch (cell.CellType)
            {
                case CellType.Formula:
                    cell.SetCellType(CellType.Numeric);
                    cellValue = Convert.ToString(cell.NumericCellValue);
                    //cellValue = GetFormulaText(cell);
                    break;
                case CellType.String:
                    cellValue = cell.StringCellValue;
                    if (cellValue.Trim().Equals("") || cellValue.Trim().Length <= 0)
                    {
                        cellValue = " ";
                    }
                    break;
                case CellType.Numeric:

                    // 日期型是通过数值型来替代的。
                    // Convert.ToString(cell.NumericCellValue)，只能返回数字型
                    // 为了能正确返回日期型,而使用 cell.ToString()
                    //cellValue = cell.ToString();
                    //break;
                    CellDataType cdt = GetCellDataType(cell);
                    switch (cdt)
                    {
                        case CellDataType.DateTime:
                            cellValue = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                            break;
                        case CellDataType.Date:
                            cellValue = cell.DateCellValue.ToString("yyyy-MM-dd");
                            break;
                        case CellDataType.Time:
                            cellValue = cell.DateCellValue.ToString("HH:mm:ss");
                            break;
                        default:
                            cellValue = cell.NumericCellValue.ToString();
                            break;
                    }
                    break;
                case CellType.Blank:
                    cellValue = " ";
                    break;
                default:
                    break;
            }
            return cellValue;
        }
        public enum CellDataType
        {
            Date,
            Time,
            DateTime,
            String
        }
        private static string GetFormulaText(ICell cell)
        {
            string value = null;
            switch (cell.CachedFormulaResultType)
            {
                case CellType.Error:
                    value = ErrorEval.GetText(cell.ErrorCellValue);
                    break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    break;
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                default:
                    value = cell.ToString();
                    break;
            }
            return value;
        }
        private static CellDataType GetCellDataType(ICell cell)
        {
            string dataFormatString = cell.CellStyle.GetDataFormatString();
            if (dataFormatString.ToLower().IndexOf("y") != -1 && dataFormatString.ToLower().IndexOf("h") != -1)
            {
                return CellDataType.DateTime;
            }
            else if (dataFormatString.ToLower().IndexOf("y") != -1 && dataFormatString.ToLower().IndexOf("h") == -1)
            {
                return CellDataType.Date;
            }
            else if (dataFormatString.ToLower().IndexOf("y") == -1 && dataFormatString.ToLower().IndexOf("h") != -1)
            {
                return CellDataType.Time;
            }
            else
            {
                return CellDataType.String;
            }
        }
        public class ExcelStyle
        {
            public float HeadTitleHeight = 20; /* 标题高度 */
            public int HeadTitle_FontSize = 20;/*20号字*/
            public float HeadColWidth = 6;  /* 列头宽度 */

            public float HeadRowHeight = 20; /* 列头高度 */
            public int HeadRow_FontSize = 14;/*14号字*/
            public bool HeadRow_WrapText = false; /*列头文本换行*/
            public bool HeadRow_Border = false; /*列头边框*/

            public float DataRowHeight = 20; /* 数据高度 */
            public int DataRow_FontSize = 12; /*12号字*/
            public bool DataRow_Border = false; /*数据列边框*/

            public bool CompressLast1To2 = false; /* 压缩最后行到倒数第二行空白上 */
            public int CompressLast1To2Space = 0; /* 压缩最后行到倒数第二行空白上-间距 */

            public bool IsDataBlank = true; /* 处理空白行 */

            public Hashtable ColumnWidth = null;
            public ExcelStylePageMargin PageMargin = null;
            public ExcelStyleRepeating Repeating = null;  /* 打印标题 */

            public string PaperSize = "A4"; /* 纸张大小 */
            public ExcelStyle()
            {
                this.Repeating = new ExcelStyleRepeating();
                this.PageMargin = new ExcelStylePageMargin();
                this.ColumnWidth = new Hashtable();
            }
        }
        public class ExcelStyleRepeating
        {
            public int sheetIndex = -1;
            public int startColumn = -1;
            public int endColumn = -1;
            public int startRow = -1;
            public int endRow = -1;
            public ExcelStyleRepeating()
            {
            }
            public ExcelStyleRepeating(int sheetIndex)
            {
                this.sheetIndex = sheetIndex;
            }
            public ExcelStyleRepeating(int _sheetIndex, int _startColumn, int _endColumn, int _startRow, int _endRow)
            {
                this.sheetIndex = _sheetIndex;
                this.startColumn = _startColumn;
                this.endColumn = _endColumn;
                this.startRow = _startRow;
                this.endRow = _endRow;
            }
        }
        public class ExcelStylePageMargin
        {
            public double RightMargin = 0.5;
            public double TopMargin = 1;
            public double LeftMargin = 0.5;
            public double BottomMargin = 1;
            public ExcelStylePageMargin()
            {
            }
            public ExcelStylePageMargin(double _RightMargin, double _TopMargin, double _LeftMargin, double _BottomMargin)
            {
                this.RightMargin = _RightMargin;
                this.TopMargin = _TopMargin;
                this.LeftMargin = _LeftMargin;
                this.BottomMargin = _BottomMargin;
            }
        }
        public Stream ExportHtmlToExcel(ExcelStyle exStyle, string input, string fileName)
        {
            #region 测试数据
            string table = @"
<div class='excel'>
<div class='title'>七年级2012-2013 上学期第一次月考学科成绩跟踪一览表</div>
<table width='290' border='1' cellpadding='0' cellspacing='0'>
     <tr head>
        <th rowspan=3  style='font-size:14pt'>学科</th>
        <th rowspan=3  style='font-size:14pt'>年段</th>
        <th rowspan=3  style='font-size:14pt'>班级</th>
        <th colspan=8  style='font-size:14pt'>分班成绩成绩</th>
        <th colspan=8  style='font-size:14pt'>第一次月考成绩</th>
        <th colspan=3  style='font-size:14pt'>均差变化</th>
        <th colspan=3  style='font-size:14pt'>始末均差变化</th>
    </tr>
      <tr head>
        </th>
        <th rowspan=2  style='font-size:14pt'>人数</th>
        <th colspan=3  style='font-size:14pt'>平均分</th>
        <th colspan=2  style='font-size:14pt'>优生数</th>
        <th colspan=2  style='font-size:14pt'>及格数</th>
        <th rowspan=2  style='font-size:14pt'>人数</th>
        <th colspan=3  style='font-size:14pt'>平均分</th>
        <th colspan=2  style='font-size:14pt'>优生数</th>
        <th colspan=2  style='font-size:14pt'>及格数</th>
        <th rowspan=2  style='font-size:14pt'>平均</th>
        <th rowspan=2  style='font-size:14pt'>优生</th>
        <th rowspan=2  style='font-size:14pt'>及格</th>
        <th rowspan=2  style='font-size:14pt'>平均</th>
        <th rowspan=2  style='font-size:14pt'>优生</th>
        <th rowspan=2  style='font-size:14pt'>及格</th>
    </tr>
      <tr head>
       </th>
        <th  style='font-size:14pt'>总分</th>
        <th  style='font-size:14pt'>平均</th>
        <th  style='font-size:14pt'>均差</th>
        <th  style='font-size:14pt'>人数</th>
        <th  style='font-size:14pt'>均差</th>
        <th  style='font-size:14pt'>人数</th>
        <th  style='font-size:14pt'>均差</th>
        <th  style='font-size:14pt'>总分</th>
        <th  style='font-size:14pt'>平均</th>
        <th  style='font-size:14pt'>均差</th>
        <th  style='font-size:14pt'>人数</th>
        <th  style='font-size:14pt'>均差</th>
        <th  style='font-size:14pt'>人数</th>
        <th  style='font-size:14pt'>均差</th>
    </tr>
    <tr data>
    <td  style='font-size:12pt;'>语文</td>
    <td  style='font-size:12pt;'>年段</td>
    <td  style='font-size:12pt;'>1~4</td>
    <td  style='font-size:12pt;'>200</td>
    <td  style='font-size:12pt;'>16780</td>
    <td  style='font-size:12pt;'>83.9</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>22.5</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>200</td>
    <td  style='font-size:12pt;'>16164</td>
    <td  style='font-size:12pt;'>80.8</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>13</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>0</td>
    </tr>
    <tr data>
    <td  style='font-size:12pt;'>数学</td>
    <td  style='font-size:12pt;'></td>
    <td  style='font-size:12pt;'>1</td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'>4685.5</td>
    <td  style='font-size:12pt;'>93.7</td>
    <td  style='font-size:12pt;'>-0.4</td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'>0</td>
    <td  style='font-size:12pt;'>50</td>
    <td  style='font-size:12pt;'>4052</td>
    <td  style='font-size:12pt;'>81</td>
    <td  style='font-size:12pt;'>-2.1</td>
    <td  style='font-size:12pt;'>22</td>
    <td  style='font-size:12pt;'>-5.3</td>
    <td  style='font-size:12pt;'>48</td>
    <td  style='font-size:12pt;'>-1.3</td>
    <td  style='font-size:12pt;'>-1.7</td>
    <td  style='font-size:12pt;'>-5.3</td>
    <td  style='font-size:12pt;'>-1.3</td>
    <td  style='font-size:12pt;'>-1.7</td>
    <td  style='font-size:12pt;'>-5.3</td>
    <td  style='font-size:12pt;'>-1.3</td>
    </tr>
</table>
</div>";
            #endregion
            table = table + table;

            table = input != "" ? input : table;
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet hssfSheet = hssfworkbook.CreateSheet(fileName);

            /*页面设置 */
            if (true)
            {
                /* 缩放 */
                hssfSheet.PrintSetup.Scale = 100;
                /* 纸张大小 */
                switch (exStyle.PaperSize)
                {
                    case "A4":
                        hssfSheet.PrintSetup.PaperSize = (short)9;
                        break;
                    case "8K":
                        break;
                }
                /*页边距*/
                ExcelStylePageMargin pageMargin = exStyle.PageMargin;
                hssfSheet.SetMargin(MarginType.RightMargin, (double)pageMargin.RightMargin);
                hssfSheet.SetMargin(MarginType.TopMargin, (double)pageMargin.TopMargin);
                hssfSheet.SetMargin(MarginType.LeftMargin, (double)pageMargin.LeftMargin);
                hssfSheet.SetMargin(MarginType.BottomMargin, (double)pageMargin.BottomMargin);
                /* 打印标题 */
                ExcelStyleRepeating rep = exStyle.Repeating;
                if (rep.sheetIndex != -1)
                    hssfworkbook.SetRepeatingRowsAndColumns(rep.sheetIndex, rep.startColumn, rep.endColumn, rep.startRow, rep.endRow);
            }
      
            float HeadTitleHeight, HeadRowHeight, HeadColWidth, DataRowHeight;

            HeadTitleHeight = exStyle.HeadTitleHeight; /* 标题高度 */
            HeadRowHeight = exStyle.HeadRowHeight; /* 列头高度 */
            HeadColWidth = exStyle.HeadColWidth;  /* 列头宽度 */
            DataRowHeight = exStyle.DataRowHeight; /* 数据高度 */

            List<TableExcel> tables = GetTable(table);
            int ItemIndex = 0;

            /* 初始化列头占用 */
            int max_col = 40;
            DataTable Head = new DataTable();
            InitHead(ref Head, max_col);
            DataTable Data = new DataTable();
            InitHead(ref Data, max_col);

            /*空白行*/
            DataTable DataBlank = new DataTable();
            DataBlank.Columns.Add("row", typeof(int));

            /*数据对齐*/
            DataTable DataAlignment = new DataTable();
            DataAlignment.Columns.Add("row", typeof(int));
            DataAlignment.Columns.Add("col", typeof(int));
            DataAlignment.Columns.Add("value", typeof(string));

            /* 样式 */
            NPOI.SS.UserModel.ICellStyle HeadTitleStyle = GetHeadTitleStyle(hssfworkbook, exStyle.HeadTitle_FontSize);
            NPOI.SS.UserModel.ICellStyle HeadRowStyle = GetHeadRowStyle(hssfworkbook, exStyle.HeadRow_FontSize);
            NPOI.SS.UserModel.ICellStyle DataRowStyle = GetDataRowStyle(hssfworkbook, exStyle.DataRow_FontSize);

            int table_index = 0;
            int Head_Max = 0;
            foreach (TableExcel Html in tables)
            {
                if (false)
                {
                    System.IO.StreamWriter sw = new StreamWriter(@"c:\excel_" + table_index.ToString() + ".txt");
                    sw.Write(Html.Content);
                    sw.Close();
                }
                /* 
                 * 压缩最后行到倒数第二行空白上
                 * 条件：数据表格大于2
                 */
                if (exStyle.CompressLast1To2 && tables.Count >= 2)
                {
                    if (DataBlank.Rows.Count > 0 && (table_index + 1 == tables.Count))
                    {
                        ItemIndex = ItemIndex - DataBlank.Rows.Count;
                        ItemIndex += exStyle.CompressLast1To2Space;
                    }
                }
                if (true)
                {
                    /* 每次初始化表头 */
                    Head.Rows.Clear();
                    DataAlignment.Rows.Clear();

                    /* 标题预存 */
                    int TitleIndex = 0;
                    if (Html.Title.Trim() != "")
                    {
                        TitleIndex = ItemIndex;
                        ItemIndex++;
                    }

                    /* 写入列头数据 */
                    HeadTitleStyle.WrapText = exStyle.HeadRow_WrapText;
                    WriteHeadRow(hssfSheet, ref Head, ref DataAlignment, HeadRowHeight, Html.Content, ref ItemIndex);

                    /* 写入标题数据 */
                    WriteHeadTitle(hssfSheet, Head, Head_Max, HeadTitleStyle, HeadTitleHeight, Html.Title, TitleIndex);

                    /* 设置列头宽度 */
                    int MaxCol = GetMaxCol(Head);
                    if (Head_Max < MaxCol) Head_Max = MaxCol;

                    for (int i = 0; i < MaxCol; i++)
                    {
                        if (exStyle.ColumnWidth.ContainsKey(i))
                        {
                            int width = Convert.ToInt32(exStyle.ColumnWidth[i]);
                            hssfSheet.SetColumnWidth(i, (int)width);
                        }
                        else
                        {
                            /* 自定义 */
                            if (HeadColWidth < 0) hssfSheet.SetColumnWidth(i, (int)System.Math.Abs(HeadColWidth));
                            if (HeadColWidth >= 0) hssfSheet.SetColumnWidth(i, (int)HeadColWidth * 256);
                        }
                    }
                    /* 设置列头样式 */
                    for (int i = ItemIndex - Head.Rows.Count; i < ItemIndex; i++)
                    {
                        NPOI.SS.UserModel.IRow row = NPOI.SS.Util.CellUtil.GetRow(i, hssfSheet);
                        for (int j = 0; j < MaxCol; j++)
                        {
                            try
                            {
                                ICell cell = NPOI.SS.Util.CellUtil.GetCell(row, j);
                                HeadRowStyle.WrapText = exStyle.HeadRow_WrapText;

                                /* 对齐方式 */
                                SetAlignment(cell, DataAlignment, HeadRowStyle, i, j);

                                if (!exStyle.HeadRow_Border) SetBorder(cell.CellStyle, false);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }

                    /* 数据起始位置 */
                    int StartDataIndex = ItemIndex;

                    /* 每次初始化数据行、空白行 */
                    Data.Rows.Clear();
                    DataBlank.Rows.Clear();
                    DataAlignment.Rows.Clear();

                    /* 写入行数据*/
                    WriteDataRow(hssfSheet, Head, ref Data, ref  DataAlignment, ref DataBlank, DataRowStyle, DataRowHeight, Html.Content, ref ItemIndex);

                    /* 
                     * 设置行数据样式 
                     * 结束行=当前行索引-空白行
                     * 
                     * 当表处理表为1个时候，不在处理空白大小。
                     */

                    int DataBlankSize = DataBlank.Rows.Count;
                    if (!exStyle.IsDataBlank) DataBlankSize = 0;

                    for (int i = StartDataIndex; i < ItemIndex - DataBlankSize; i++)
                    {
                        NPOI.SS.UserModel.IRow row = NPOI.SS.Util.CellUtil.GetRow(i, hssfSheet);
                        for (int j = 0; j < MaxCol; j++)
                        {
                            try
                            {
                                ICell cell = NPOI.SS.Util.CellUtil.GetCell(row, j);

                                /* 对齐方式 */
                                SetAlignment(cell, DataAlignment, DataRowStyle, i, j);

                                if (!exStyle.DataRow_Border) SetBorder(cell.CellStyle, false);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    if (false)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (DataRow var in DataBlank.Rows)
                        {
                            sb.Append(var[0].ToString() + "<br>");
                        }
                        HttpContext.Current.Response.Write("空白:" + sb.ToString());
                        HttpContext.Current.Response.End();
                    }
                }
                table_index++;
            }
            MemoryStream ms = new MemoryStream();
            hssfworkbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            hssfSheet = null;
            hssfworkbook = null;
            return ms;
        }
        /* 获取表集合 */
        private List<TableExcel> GetTable(string Htmls)
        {
            List<TableExcel> Tables = new List<TableExcel>();
            List<string> Excel = GetExcel(Htmls);
            foreach (string Html in Excel)
            {
                string title = "";
                if (true)
                {
                    Regex re = new Regex(@"<div class='title'>(?<src>[\s\S]*?)<\/div>", RegexOptions.IgnoreCase);
                    Match match = re.Match(Html);
                    if (match.Success)
                    {
                        title = match.Groups["src"].Value;
                    }
                }
                if (true)
                {
                    Regex tablere = new Regex(@"<table(?<src>[\s\S]*?)<\/table>", RegexOptions.IgnoreCase);
                    MatchCollection tablematchs = tablere.Matches(Html);
                    foreach (Match var in tablematchs)
                    {
                        TableExcel src = new TableExcel();
                        src.Title = title;
                        src.Content = var.Groups["src"].Value;
                        Tables.Add(src);
                    }
                }
            }

            return Tables;
        }
        /* 实体表 */
        public class TableExcel
        {
            public string Title = "";
            public string Content = "";
        }
        /* 获取Excel区域 */
        private List<string> GetExcel(string Html)
        {
            Regex excelre = new Regex(@"<div[^>]*>[\s\S]*?(((?'open'<div[^>]*>)[\s\S]*?)+((?'-open'</div>)[\s\S]*?)+)*(?(open)(?!))</div>", RegexOptions.IgnoreCase);
            MatchCollection excelmatchs = excelre.Matches(Html);
            List<string> excels = new List<string>();
            foreach (Match var in excelmatchs)
            {
                excels.Add(var.Value);
            }
            return excels;
        }
        /* 初始化列头 */
        private void InitHead(ref DataTable Head, int max_col)
        {
            Head = new DataTable();
            Head.Columns.Add("row", typeof(int));
            Head.Columns.Add("end", typeof(int));
            for (int i = 0; i < max_col; i++)
            {
                Head.Columns.Add("col" + i.ToString(), typeof(int)); ;
            }
        }
        /* 写入标题数据 */
        private void WriteHeadTitle(NPOI.SS.UserModel.ISheet hssfSheet, DataTable Head, int Head_Max, ICellStyle HeadTitleStyle, float headTitleHeight, string Title, int ItemIndex)
        {
            NPOI.SS.UserModel.IRow tagRow = null;
            NPOI.SS.Util.CellRangeAddress range = null;

            int firstRow, lastRow, firstCol, lastCol;

            firstRow = 0;
            lastRow = 0;
            firstCol = 0;
            lastCol = 0;

            int rowIndex = ItemIndex;
            int colIndex = 0;
            if (Title.Trim() != "")
            {
                firstRow = rowIndex;
                lastRow = rowIndex;
                firstCol = colIndex;

                tagRow = hssfSheet.CreateRow(rowIndex);
                tagRow.HeightInPoints = headTitleHeight;

                tagRow.CreateCell(colIndex).SetCellValue(Title);
                tagRow.GetCell(colIndex).CellStyle = HeadTitleStyle;

                /* 获取最大列宽 */
                int MaxCol = GetMaxCol(Head);
                if (MaxCol > 0) lastCol = MaxCol - 1;
                if (MaxCol < Head_Max) lastCol = Head_Max - 1;
                /* */
                if (firstCol != lastCol)
                {
                    range = new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
                    hssfSheet.AddMergedRegion(range);
                }
            }
        }
        /* 写入列头数据 */
        private void WriteHeadRow(NPOI.SS.UserModel.ISheet hssfSheet, ref DataTable Head, ref DataTable DataAlignment, float headRowHeight, string Html, ref int ItemIndex)
        {
            NPOI.SS.UserModel.IRow tagRow = null;
            NPOI.SS.Util.CellRangeAddress range = null;

            int firstRow, lastRow, firstCol, lastCol;

            firstRow = 0;
            lastRow = 0;
            firstCol = 0;
            lastCol = 0;

            Regex trre = new Regex(@"<tr head>(?<src>[\s\S]*?)<\/tr>", RegexOptions.IgnoreCase);
            MatchCollection trmatchs = trre.Matches(Html);
            int startIndex = ItemIndex;
            int rowIndex = startIndex;
            int item_index = 0;
            foreach (Match trvar in trmatchs)
            {
                /* 创建行 */
                tagRow = hssfSheet.CreateRow(rowIndex);
                tagRow.HeightInPoints = headRowHeight;

                int colIndex = 0;
                Regex tdre = new Regex(@"<td(?<style>.*?)>(?<src>.*?)<\/td>|<th(?<style>.*?)>(?<src>.*?)<\/th>", RegexOptions.IgnoreCase);
                MatchCollection tdmatchs = tdre.Matches(trvar.Groups["src"].Value);
                foreach (Match tdvar in tdmatchs)
                {
                    if (item_index > 0) colIndex = GetColIndex(Head, rowIndex);
                    /* 默认分配值 */
                    firstRow = rowIndex;
                    lastRow = rowIndex;
                    firstCol = colIndex;
                    lastCol = colIndex;

                    /* 创建单元格，设置该单元值 */
                    string columnName = tdvar.Groups["src"].Value;
                    if (columnName == "&nbsp;") columnName = "";
                    tagRow.CreateCell(colIndex).SetCellValue(columnName);
  
                    string style = tdvar.Groups["style"].Value;

                    bool isrange = false;
                    bool isrowspan = false;
                    bool iscolspan = false;

                    /* 对齐方式 */
                    Regex align_re = new Regex(@"align='(?<src>.*?)'|align=""(?<src>.*?)""|align=(?<src>[\w+]?)", RegexOptions.IgnoreCase);
                    Match align_match = align_re.Match(style);
                    if (align_match.Success)
                    {
                        string align = align_match.Groups["src"].Value;
                        DataRow row = DataAlignment.NewRow();
                        row[0] = rowIndex;
                        row[1] = colIndex;
                        row[2] = align;
                        DataAlignment.Rows.Add(row);
                    }

                    /* 行合并 */
                    Regex rowspan_re = new Regex(@"rowspan='(?<src>.*?)'|rowspan=""(?<src>.*?)""|rowspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                    Match rowspan_match = rowspan_re.Match(style);
                    if (rowspan_match.Success)
                    {
                        isrowspan = true;
                        isrange = true;
                        int rowspan = Convert.ToInt32(rowspan_match.Groups["src"].Value);
                        firstRow = rowIndex;
                        lastRow = rowIndex + (rowspan - 1);
                    }

                    /* 列合并  */
                    Regex colspan_re = new Regex(@"colspan='(?<src>.*?)'|colspan=""(?<src>.*?)""|colspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                    Match colspan_match = colspan_re.Match(style);
                    if (colspan_match.Success)
                    {
                        isrange = true;
                        iscolspan = true;
                        int colspan = Convert.ToInt32(colspan_match.Groups["src"].Value);
                        firstCol = colIndex;
                        lastCol = colIndex + (colspan - 1);

                        /* 下次数据填充列的位置 */
                        colIndex = lastCol;
                    }

                    /* 列头位置占用 */
                    if (isrowspan && !iscolspan)
                    {
                        /* 跨行 */
                        for (int i = firstRow; i <= lastRow; i++)
                        {
                            DataRow[] d = Head.Select("row=" + i.ToString());
                            if (d.Length > 0)
                            {
                                foreach (DataRow var in d)
                                {
                                    var["col" + colIndex] = 1;
                                }
                            }
                            else
                            {
                                DataRow r = Head.NewRow();
                                r["row"] = i;
                                r["col" + colIndex] = 1;
                                Head.Rows.Add(r);
                            }
                        }
                    }
                    else if (!isrowspan && iscolspan)
                    {
                        /* 跨列 */
                        for (int i = firstCol; i <= lastCol; i++)
                        {
                            DataRow[] d = Head.Select("row=" + rowIndex.ToString());
                            if (d.Length > 0)
                            {
                                foreach (DataRow var in d)
                                {
                                    var["col" + i.ToString()] = 1;
                                }
                            }
                            else
                            {
                                DataRow r = Head.NewRow();
                                r["row"] = rowIndex;
                                r["col" + i.ToString()] = 1;
                                Head.Rows.Add(r);
                            }
                        }
                    }
                    else if (isrowspan && iscolspan)
                    {
                        /* 跨行 跨列 */
                        for (int i = firstRow; i <= lastRow; i++)
                        {
                            DataRow[] d = Head.Select("row=" + i.ToString());
                            if (d.Length > 0)
                            {

                            }
                            else
                            {
                                DataRow r = Head.NewRow();
                                r["row"] = i;
                                for (int j = firstCol; j <= lastCol; j++)
                                {
                                    r["col" + j.ToString()] = 1;

                                }
                                Head.Rows.Add(r);
                            }
                        }
                    }
                    else
                    {
                        /* 默认 */
                        DataRow[] d = Head.Select("row=" + rowIndex.ToString());
                        if (d.Length > 0)
                        {
                            foreach (DataRow var in d)
                            {
                                var["col" + firstCol] = 1;
                            }
                        }
                        else
                        {
                            DataRow r = Head.NewRow();
                            r["row"] = rowIndex;
                            r["col" + firstCol] = 1;
                            Head.Rows.Add(r);
                        }
                    }
                    /* 合并 */
                    if (isrange)
                    {
                        range = new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
                        hssfSheet.AddMergedRegion(range);
                    }
                    colIndex++;
                }
                /* 最大列结束 */
                if (item_index == 0)
                {
                    DataRow[] d = Head.Select("row=" + startIndex.ToString());
                    if (d.Length > 0)
                    {
                        foreach (DataRow var in d)
                        {
                            var["end"] = colIndex;
                        }
                    }
                }
                rowIndex++;
                ItemIndex++;
                item_index++;
            }
        }
        /* 写入行数据 */
        private void WriteDataRow(NPOI.SS.UserModel.ISheet hssfSheet, DataTable Head, ref DataTable Data, ref DataTable DataAlignment, ref DataTable DataBlank, ICellStyle DataRowStyle, float DataRowHeight, string Html, ref int ItemIndex)
        {
            #region debug 无合并处理
            if (false)
            {
                NPOI.SS.UserModel.IRow tagRow = null;
                NPOI.SS.Util.CellRangeAddress range = null;

                Regex trre = new Regex(@"<tr data>(?<src>[\s\S]*?)<\/tr>", RegexOptions.IgnoreCase);
                MatchCollection trmatchs = trre.Matches(Html);
                int rowIndex = ItemIndex;
                foreach (Match trvar in trmatchs)
                {
                    /* 创建行 */
                    tagRow = hssfSheet.CreateRow(rowIndex);
                    tagRow.HeightInPoints = DataRowHeight;

                    int colIndex = 0;
                    Regex tdre = new Regex(@"<td(?<style>.*?)>(?<src>.*?)<\/td>|<th(?<style>.*?)>(?<src>.*?)<\/th>", RegexOptions.IgnoreCase);
                    MatchCollection tdmatchs = tdre.Matches(trvar.Groups["src"].Value);
                    foreach (Match tdvar in tdmatchs)
                    {
                        /* 创建单元格，设置该单元值 */
                        string value = tdvar.Groups["src"].Value;
                        if (value == "&nbsp;") value = "";
                        tagRow.CreateCell(colIndex).SetCellValue(value);
                        tagRow.GetCell(colIndex).CellStyle = DataRowStyle;
                        colIndex++;
                    }
                    rowIndex++;
                }
                ItemIndex = rowIndex;
            }
            #endregion
            if (true)
            {
                NPOI.SS.UserModel.IRow tagRow = null;
                NPOI.SS.Util.CellRangeAddress range = null;

                int firstRow, lastRow, firstCol, lastCol;

                firstRow = 0;
                lastRow = 0;
                firstCol = 0;
                lastCol = 0;

                Regex trre = new Regex(@"<tr data>(?<src>[\s\S]*?)<\/tr>", RegexOptions.IgnoreCase);
                MatchCollection trmatchs = trre.Matches(Html);
                int startIndex = ItemIndex;
                int rowIndex = startIndex;
                int item_index = 0;
                foreach (Match trvar in trmatchs)
                {
                    /* 创建行 */
                    tagRow = hssfSheet.CreateRow(rowIndex);
                    tagRow.HeightInPoints = DataRowHeight;

                    int colIndex = 0;
                    int colNumber = 0;
                    Regex tdre = new Regex(@"<td(?<style>.*?)>(?<src>.*?)<\/td>|<th(?<style>.*?)>(?<src>.*?)<\/th>", RegexOptions.IgnoreCase);
                    MatchCollection tdmatchs = tdre.Matches(trvar.Groups["src"].Value);
                    foreach (Match tdvar in tdmatchs)
                    {
                        if (item_index > 0) colIndex = GetColIndex(Data, rowIndex);
                        /* 默认分配值 */
                        firstRow = rowIndex;
                        lastRow = rowIndex;
                        firstCol = colIndex;
                        lastCol = colIndex;

                        /* 创建单元格，设置该单元值 */
                        string columnName = tdvar.Groups["src"].Value;
                        if (columnName == "&nbsp;")
                        {
                            /* 空白行处理 */
                            if (colNumber == 0)
                            {
                                DataRow row = DataBlank.NewRow();
                                row[0] = rowIndex;
                                DataBlank.Rows.Add(row);
                            }
                            columnName = "";
                        }
                        tagRow.CreateCell(colIndex).SetCellValue(columnName);

                        string style = tdvar.Groups["style"].Value;

                        bool isrange = false;
                        bool isrowspan = false;
                        bool iscolspan = false;

                        #region debug
                        /*
                       // 行合并 /
                        Regex rowspan_re = new Regex(@"rowspan='(?<src>.*?)'|rowspan=""(?<src>.*?)""|rowspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                        Match rowspan_match = rowspan_re.Match(style);
                        if (rowspan_match.Success)
                        {
                            isrange = true;
                            int rowspan = Convert.ToInt32(rowspan_match.Groups["src"].Value);
                            if (rowspan > 0)
                            {
                                firstRow = rowIndex;
                                lastRow = rowIndex + (rowspan - 1);
                            }
                        }
                        // 行头占用/
                        if (true)
                        {
                            for (int i = firstRow; i <= lastRow; i++)
                            {
                                DataRow[] d = Data.Select("row=" + i.ToString());
                                if (d.Length > 0)
                                {
                                    foreach (DataRow var in d)
                                    {
                                        var["col" + colIndex] = 1;
                                    }
                                }
                                else
                                {
                                    DataRow r = Data.NewRow();
                                    r["row"] = i;
                                    r["col" + colIndex] = 1;
                                    Data.Rows.Add(r);
                                }
                            }
                        }
                        // 列合并 /
                        Regex colspan_re = new Regex(@"colspan='(?<src>.*?)'|colspan=""(?<src>.*?)""|colspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                        Match colspan_match = colspan_re.Match(style);
                        if (colspan_match.Success)
                        {
                            isrange = true;
                            int colspan = Convert.ToInt32(colspan_match.Groups["src"].Value);
                            if (colspan > 0)
                            {
                                firstCol = colIndex;
                                lastCol = colIndex + (colspan - 1);

                                // 下次数据填充列的位置/
                                colIndex = lastCol;
                            }
                        }

                        // 列头占用/
                        if (true)
                        {
                            for (int i = firstCol; i <= lastCol; i++)
                            {
                                DataRow[] d = Data.Select("row=" + rowIndex.ToString());
                                if (d.Length > 0)
                                {
                                    foreach (DataRow var in d)
                                    {
                                        var["col" + i.ToString()] = 1;
                                    }
                                }
                                else
                                {
                                    DataRow r = Data.NewRow();
                                    r["row"] = rowIndex;
                                    r["col" + i.ToString()] = 1;
                                    Data.Rows.Add(r);
                                }
                            }
                        }
                        // 默认占用/
                        if (firstCol == lastCol)
                        {
                            DataRow[] d = Data.Select("row=" + rowIndex.ToString());
                            if (d.Length > 0)
                            {
                                foreach (DataRow var in d)
                                {
                                    var["col" + firstCol] = 1;
                                }
                            }
                            else
                            {
                                DataRow r = Data.NewRow();
                                r["row"] = rowIndex;
                                r["col" + firstCol] = 1;
                                Data.Rows.Add(r);
                            }
                        }
                        */
                        
                        #endregion

                        /* 对齐方式 */
                        Regex align_re = new Regex(@"align='(?<src>.*?)'|align=""(?<src>.*?)""|align=(?<src>[\w+]?)", RegexOptions.IgnoreCase);
                        Match align_match = align_re.Match(style);
                        if (align_match.Success)
                        {
                            string align = align_match.Groups["src"].Value;
                            DataRow row = DataAlignment.NewRow();
                            row[0] = rowIndex;
                            row[1] = colIndex;
                            row[2] = align;
                            DataAlignment.Rows.Add(row);
                        }

                        /* 行合并 */
                        Regex rowspan_re = new Regex(@"rowspan='(?<src>.*?)'|rowspan=""(?<src>.*?)""|rowspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                        Match rowspan_match = rowspan_re.Match(style);
                        if (rowspan_match.Success)
                        {
                            isrowspan = true;
                            isrange = true;
                            int rowspan = Convert.ToInt32(rowspan_match.Groups["src"].Value);
                            firstRow = rowIndex;
                            lastRow = rowIndex + (rowspan - 1);
                        }

                        /* 列合并  */
                        Regex colspan_re = new Regex(@"colspan='(?<src>.*?)'|colspan=""(?<src>.*?)""|colspan=(?<src>[\d+]?)", RegexOptions.IgnoreCase);
                        Match colspan_match = colspan_re.Match(style);
                        if (colspan_match.Success)
                        {
                            isrange = true;
                            iscolspan = true;
                            int colspan = Convert.ToInt32(colspan_match.Groups["src"].Value);
                            firstCol = colIndex;
                            lastCol = colIndex + (colspan - 1);

                            /* 下次数据填充列的位置 */
                            colIndex = lastCol;
                        }
                        /* 列头位置占用 */
                        if (isrowspan && !iscolspan)
                        {
                            /* 跨行 */
                            for (int i = firstRow; i <= lastRow; i++)
                            {
                                DataRow[] d = Data.Select("row=" + i.ToString());
                                if (d.Length > 0)
                                {
                                    foreach (DataRow var in d)
                                    {
                                        var["col" + colIndex] = 1;
                                    }
                                }
                                else
                                {
                                    DataRow r = Data.NewRow();
                                    r["row"] = i;
                                    r["col" + colIndex] = 1;
                                    Data.Rows.Add(r);
                                }
                            }
                        }
                        else if (!isrowspan && iscolspan)
                        {
                            /* 跨列 */
                            for (int i = firstCol; i <= lastCol; i++)
                            {
                                DataRow[] d = Data.Select("row=" + rowIndex.ToString());
                                if (d.Length > 0)
                                {
                                    foreach (DataRow var in d)
                                    {
                                        var["col" + i.ToString()] = 1;
                                    }
                                }
                                else
                                {
                                    DataRow r = Data.NewRow();
                                    r["row"] = rowIndex;
                                    r["col" + i.ToString()] = 1;
                                    Data.Rows.Add(r);
                                }
                            }
                        }
                        else if (isrowspan && iscolspan)
                        {
                            /* 跨行 跨列 */
                            for (int i = firstRow; i <= lastRow; i++)
                            {
                                DataRow[] d = Data.Select("row=" + i.ToString());
                                if (d.Length > 0)
                                {

                                }
                                else
                                {
                                    DataRow r = Data.NewRow();
                                    r["row"] = i;
                                    for (int j = firstCol; j <= lastCol; j++)
                                    {
                                        r["col" + j.ToString()] = 1;

                                    }
                                    Data.Rows.Add(r);
                                }
                            }
                        }
                        else
                        {
                            /* 默认 */
                            DataRow[] d = Data.Select("row=" + rowIndex.ToString());
                            if (d.Length > 0)
                            {
                                foreach (DataRow var in d)
                                {
                                    var["col" + firstCol] = 1;
                                }
                            }
                            else
                            {
                                DataRow r = Data.NewRow();
                                r["row"] = rowIndex;
                                r["col" + firstCol] = 1;
                                Data.Rows.Add(r);
                            }
                        }
                        /* 合并 */
                        if (isrange)
                        {
                            try
                            {
                                range = new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
                                hssfSheet.AddMergedRegion(range);
                            }
                            catch (Exception)
                            {
                                String error = "firstRow(" + firstRow + "), lastRow(" + lastRow + "), firstCol(" + firstCol + "), lastCol(" + lastCol + ")";

                                HttpContext.Current.Response.Write(error + "<br>" + trvar.Groups["src"].Value);
                                HttpContext.Current.Response.End();
                            }
                        }
                        colIndex++;
                        colNumber++;
                    }
                    /* 最大列结束 */
                    if (item_index == 0)
                    {
                        DataRow[] d = Data.Select("row=" + startIndex.ToString());
                        if (d.Length > 0)
                        {
                            foreach (DataRow var in d)
                            {
                                var["end"] = colIndex;
                            }
                        }
                    }
                    rowIndex++;
                    ItemIndex++;
                    item_index++;
                }
            }
        }
        /* 设置主题样式 */
        private NPOI.SS.UserModel.ICellStyle GetHeadTitleStyle(HSSFWorkbook hssfworkbook, int FontSize)
        {
            NPOI.SS.UserModel.ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            if (true)
            {
                cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; /* 左右居中 */
                cellStyle.VerticalAlignment = VerticalAlignment.Center; /* 垂直居中 */

                /*设置字体*/
                IFont font = hssfworkbook.CreateFont();
                font.FontName = "宋体";
                font.Boldweight = ((short)800);
                font.FontHeightInPoints = ((short)FontSize); /*20号字*/
                cellStyle.SetFont(font);
            }
            return cellStyle;
        }
        /* 设置列头样式 */
        private NPOI.SS.UserModel.ICellStyle GetHeadRowStyle(HSSFWorkbook hssfworkbook, int FontSize)
        {
            NPOI.SS.UserModel.ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            if (true)
            {
                //cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER; /* 左右居中 */
                cellStyle.VerticalAlignment = VerticalAlignment.Center; /* 垂直居中 */
                /*边框*/
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                /*边框颜色*/
                cellStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                /*设置字体*/
                IFont font = hssfworkbook.CreateFont(); 
                font.FontName = "宋体";
                font.Boldweight = ((short)800);
                font.FontHeightInPoints = ((short)FontSize); /*14号字*/
                cellStyle.SetFont(font);
            }
            return cellStyle;
        }
        /* 设置数据样式 */
        private NPOI.SS.UserModel.ICellStyle GetDataRowStyle(HSSFWorkbook hssfworkbook, int FontSize)
        {
            NPOI.SS.UserModel.ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            if (true)
            {
                cellStyle.VerticalAlignment = VerticalAlignment.Center; /* 垂直居中 */
                /*边框*/
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                /*边框颜色*/
                cellStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                /*设置字体*/
                IFont font = hssfworkbook.CreateFont();
                font.FontName = "宋体";
                font.FontHeightInPoints = ((short)FontSize); /*12号字*/
                cellStyle.SetFont(font);
            }
            return cellStyle;
        }
        /* 分配位置 */
        public int GetColIndex(DataTable head, int rowIndex)
        {
            int colIndex = 0;
            if (head.Rows.Count > 0)
            {
                int MaxCol = GetMaxCol(head);
                DataRow[] rows = head.Select("row=" + rowIndex + "");
                for (int i = 0; i < MaxCol; i++)
                {
                    try
                    {
                        /*
                        * 找到最近未使用列 
                        * 抽取位置后，使用该位置
                        */
                        if (rows[0]["col" + i.ToString()].ToString() == "")
                        {
                            colIndex = i;
                            rows[0]["col" + i.ToString()] = 1;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return colIndex;
        }
        /* 获取最大列头 */
        public int GetMaxCol(DataTable head)
        {
            int ret = 0;
            if (head.Rows.Count > 0)
            {
                //try
                //{
                DataRow init = head.Select("row>=0", "")[0];
                if (init != null)
                    ret = Convert.ToInt32(init["end"]);
                //}
                //catch (Exception)
                //{

                //}
            }
            return ret;
        }
        /* 设置单元格边框 */
        private static void SetBorder(ICellStyle cellStyle, bool flag)
        {
            NPOI.SS.UserModel.BorderStyle style = new NPOI.SS.UserModel.BorderStyle();
            if (flag) style = NPOI.SS.UserModel.BorderStyle.Thin;
            if (!flag) style = NPOI.SS.UserModel.BorderStyle.None;

            cellStyle.BorderTop = style;
            cellStyle.BorderBottom = style;
            cellStyle.BorderLeft = style;
            cellStyle.BorderRight = style;
        }
        /* 设置单元格对齐方式 */
        private void SetAlignment(ICell cell, DataTable DataAlignment, ICellStyle cellStyle, int rowIndex, int colIndex)
        {
            DataRow[] rows = DataAlignment.Select("row=" + rowIndex.ToString() + " And col=" + colIndex.ToString() + "");
            string value = "";
            if (rows.Length == 1)
            {
                cell.CellStyle.CloneStyleFrom(cellStyle);
                value = rows[0]["value"].ToString();

                switch (value.ToLower())
                {
                    case "left":
                        cell.CellStyle.Alignment = HorizontalAlignment.Left;
                        break;
                    case "center":
                        cell.CellStyle.Alignment = HorizontalAlignment.Center;
                        break;
                    case "right":
                        cell.CellStyle.Alignment = HorizontalAlignment.Right;
                        break;
                    default:
                        cell.CellStyle.Alignment = HorizontalAlignment.Center;
                        break;
                }
            }
            else
            {
                cellStyle.Alignment = HorizontalAlignment.Center;
                cell.CellStyle = cellStyle;
            }
        }
    }
}
