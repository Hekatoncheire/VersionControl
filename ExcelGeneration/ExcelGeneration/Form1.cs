using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExcelGeneration
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();

        List<Flat> flats;

        object[,] values;
        string[] headers;

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWB = xlApp.Workbooks.Add(Missing.Value);

                xlSheet = xlWB.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            headers = new string[]
            {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                "Négyzetméter ár (mFt/m2)"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            values = new object[flats.Count, headers.Length];

            int counter = 0;
            foreach (Flat flat in flats)
            {
                values[counter, 0] = flat.Code;
                values[counter, 1] = flat.Vendor;
                values[counter, 2] = flat.Side;
                values[counter, 3] = flat.District;
                values[counter, 4] = flat.Elevator;
                values[counter, 5] = flat.NumberOfRooms;
                values[counter, 6] = flat.FloorArea;
                values[counter, 7] = flat.Price;
                values[counter, 8] = flat.Price / flat.FloorArea;

                counter++;
            }

            xlSheet.get_Range(GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;

            FormatWorkSheet();


        }

        private void FormatWorkSheet()
        {
            FormatHeaders();
            FormatContent();
        }

        private void FormatContent()
        {
            Excel.Range firstCol = xlSheet.get_Range(GetCell(2,1),GetCell(1 + values.GetLength(0),1));
            Excel.Range contentRange = xlSheet.get_Range(GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1)));
            Excel.Range lastCol = xlSheet.get_Range(GetCell(2, values.GetLength(1)), GetCell(1 + values.GetLength(0), values.GetLength(1)));

            firstCol.Font.Bold = true;
            firstCol.Interior.Color = Color.LightYellow;
            lastCol.Interior.Color = Color.LightGreen;
            lastCol.NumberFormat = "0.00";
            contentRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
        }

        private void FormatHeaders()
        {
            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
        }

        private void LoadData()
        {
            flats = context.Flat.ToList();
        }

        string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
