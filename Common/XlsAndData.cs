using ExcelDataReader;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public static class XlsAndData
    {

        public static DataSet XlsxToDataSet(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);


            IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);

            DataSet dataSet;
            //try
            {
                var conf = new ExcelDataSetConfiguration
                {
                    UseColumnDataType = false,
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true

                    }
                };
               
                dataSet = excelReader.AsDataSet(conf);
            }
            excelReader.Close();
            stream.Close();
            //4. DataSet - Create column names from first row
            return ToAllStringFields(dataSet);

        }

        private static DataSet ToAllStringFields(this DataSet ds)
        {
            // Clone function -> does not copy the data, but just the structure.
            var newDs = ds.Clone();
            foreach (DataTable table in newDs.Tables)
            {
                // if the column is not string type -> set as string.
                foreach (DataColumn col in table.Columns)
                {
                    if (col.DataType != typeof(string))
                        col.DataType = typeof(string);
                }
            }

            // imports all rows.
            foreach (DataTable table in ds.Tables)
            {
                var targetTable = newDs.Tables[table.TableName];
                foreach (DataRow row in table.Rows)
                {
                    targetTable.ImportRow(row);
                }
            }

            return newDs;
        }


        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.CustomAttributes.Where(c => c.AttributeType.Name == "DisplayAttribute").Select(d => d.NamedArguments.Select(b => b.TypedValue.Value.ToString()).SingleOrDefault()).SingleOrDefault());
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static XSSFWorkbook XSSFWorkbook(DataTable dt)
        {
            var workbook = new XSSFWorkbook();

            int[] arrColWidth = new int[dt.Columns.Count];

            foreach (DataColumn item in dt.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dt.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            for (int i = 0; i < arrColWidth.Length; i++)
            {
                if (arrColWidth[i] > 30)
                    arrColWidth[i] = int.Parse(Math.Round(arrColWidth[i] * 0.7, 0).ToString());
                if (arrColWidth[i] > 100)
                    arrColWidth[i] = 100;
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            sheet1.IsRightToLeft = true;

            XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            headStyle.WrapText = true;
            XSSFFont font = workbook.CreateFont() as XSSFFont;
            font.FontHeightInPoints = 10;
            font.FontName = "B Nazanin";
            font.IsBold = true;
            // font.SetColor(XSSFColor.ToXSSFColor(Color.White));
            headStyle.SetFont(font);
            headStyle.FillForegroundColor = IndexedColors.LightGreen.Index;
            headStyle.FillBackgroundColor = IndexedColors.LightGreen.Index;
            headStyle.FillPattern = FillPattern.SolidForeground;

            headStyle.BorderTop = BorderStyle.Thin;
            headStyle.TopBorderColor = IndexedColors.White.Index;

            headStyle.BorderLeft = BorderStyle.Thin;
            headStyle.LeftBorderColor = IndexedColors.White.Index;

            headStyle.BorderRight = BorderStyle.Thin;
            headStyle.RightBorderColor = IndexedColors.White.Index;

            headStyle.BorderBottom = BorderStyle.Thin;
            headStyle.BottomBorderColor = IndexedColors.White.Index;


            XSSFCellStyle Style = workbook.CreateCellStyle() as XSSFCellStyle;
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            XSSFFont fontStyle = workbook.CreateFont() as XSSFFont;
            fontStyle.FontHeightInPoints = 11;
            fontStyle.FontName = "B Nazanin";
            fontStyle.IsBold = false;
            Style.SetFont(fontStyle);
            Style.BorderTop = BorderStyle.Thin;

            Style.TopBorderColor = IndexedColors.LightGreen.Index;

            Style.BorderLeft = BorderStyle.Thin;
            Style.LeftBorderColor = IndexedColors.LightGreen.Index;

            Style.BorderRight = BorderStyle.Thin;
            Style.RightBorderColor = IndexedColors.LightGreen.Index;
            Style.BorderBottom = BorderStyle.Thin;
            Style.BottomBorderColor = IndexedColors.LightGreen.Index;

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
                cell.CellStyle = headStyle;
                sheet1.SetColumnWidth(j, (arrColWidth[j] + 1) * 200);
            }



            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    bool flag = true;
                    if (dt.Rows[i][columnName].ToString().Length > 11)
                        flag = false;
                    for (int m = 0; m < dt.Rows[i][columnName].ToString().Length; m++)
                    {
                        if (flag == false) break;
                        string s = dt.Rows[i][columnName].ToString().Substring(m, 1);

                        if (flag == true && (string.Compare(s, "0") < 0 || string.Compare(s, "9") > 0) && s != "-" && s != ".")
                        {
                            flag = false;
                            break;
                        }
                    }
                    string cellvalue = dt.Rows[i][columnName].ToString();
                    if (flag == true)
                    {
                        double d;

                        if (double.TryParse(cellvalue, out d))

                            cell.SetCellValue(d);
                        else
                            cell.SetCellValue(cellvalue);
                    }
                    else

                        cell.SetCellValue(cellvalue);

                    cell.CellStyle = Style;
                }
            }

            return workbook;
        }

        public static XSSFWorkbook XSSFWorkbook(List<DataTable> dt)
        {
            var workbook = new XSSFWorkbook();

            XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            XSSFFont font = workbook.CreateFont() as XSSFFont;
            font.FontHeightInPoints = 10;
            font.FontName = "Tahoma";
            font.IsBold = true;
            headStyle.SetFont(font);
            headStyle.FillForegroundColor = IndexedColors.Yellow.Index;
            headStyle.FillBackgroundColor = IndexedColors.Green.Index;
            headStyle.FillPattern = FillPattern.SolidForeground;

            headStyle.BorderTop = BorderStyle.Medium;
            headStyle.TopBorderColor = IndexedColors.Black.Index;

            headStyle.BorderLeft = BorderStyle.Medium;
            headStyle.LeftBorderColor = IndexedColors.Black.Index;

            headStyle.BorderRight = BorderStyle.Medium;
            headStyle.RightBorderColor = IndexedColors.Black.Index;

            headStyle.BorderBottom = BorderStyle.Medium;
            headStyle.BottomBorderColor = IndexedColors.Black.Index;


            XSSFCellStyle Style = workbook.CreateCellStyle() as XSSFCellStyle;
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            XSSFFont fontStyle = workbook.CreateFont() as XSSFFont;
            fontStyle.FontHeightInPoints = 11;
            fontStyle.FontName = "Tahoma";
            fontStyle.IsBold = false;
            Style.SetFont(fontStyle);
            Style.BorderBottom = BorderStyle.Thin;
            Style.BottomBorderColor = IndexedColors.Black.Index;
            Style.BorderTop = BorderStyle.Thin;
            Style.TopBorderColor = IndexedColors.Black.Index;

            for (int bb = 0; bb < dt.Count; bb++)

            {


                int[] arrColWidth = new int[dt[bb].Columns.Count];

                foreach (DataColumn item in dt[bb].Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dt[bb].Rows.Count; i++)
                {
                    for (int j = 0; j < dt[bb].Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dt[bb].Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }

                for (int i = 0; i < arrColWidth.Length; i++)
                {
                    if (arrColWidth[i] > 30)
                        arrColWidth[i] = int.Parse(Math.Round(arrColWidth[i] * 0.7, 0).ToString());
                }

                ISheet sheet1 = workbook.CreateSheet("Sheet " + (bb + 1).ToString());

                //make a header row
                IRow row1 = sheet1.CreateRow(0);

                sheet1.IsRightToLeft = true;



                for (int j = 0; j < dt[bb].Columns.Count; j++)
                {

                    ICell cell = row1.CreateCell(j);
                    String columnName = dt[bb].Columns[j].ToString();
                    cell.SetCellValue(columnName);
                    cell.CellStyle = headStyle;
                    sheet1.SetColumnWidth(j, (arrColWidth[j] + 1) * 220);
                }



                //loops through data
                for (int i = 0; i < dt[bb].Rows.Count; i++)
                {
                    var row = sheet1.CreateRow(i + 1);
                    for (int j = 0; j < dt[bb].Columns.Count; j++)
                    {

                        ICell cell = row.CreateCell(j);
                        String columnName = dt[bb].Columns[j].ToString();
                        bool flag = true;
                        for (int m = 0; m < dt[bb].Rows[i][columnName].ToString().Length; m++)
                        {
                            string s = dt[bb].Rows[i][columnName].ToString().Substring(m, 1);
                            if ((string.Compare(s, "0") < 0 || string.Compare(s, "9") > 0) && s != "-" && s != ".")
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag == true)
                        {
                            double d;

                            if (double.TryParse(dt[bb].Rows[i][columnName].ToString(), out d))

                                cell.SetCellValue(d);
                            else
                                cell.SetCellValue(dt[bb].Rows[i][columnName].ToString());
                        }
                        else

                            cell.SetCellValue(dt[bb].Rows[i][columnName].ToString());

                        cell.CellStyle = Style;
                    }
                }

            }
            return workbook;

        }

    }
}
