using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AzureStorageCalculator
{

    /// <summary>
    /// This class does the heavy lifting when reading/writing to excel
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// Turn a collection of objects into an excel sheet
        /// </summary>
        /// <typeparam name="T">The type of object that should be a row in the sheet</typeparam>
        /// <param name="file">the destination file to fill</param>
        /// <param name="sheet">the destination sheet to fill</param>
        /// <param name="rows">the source dataset</param>
        public static void RenderDetail<T>(ExcelPackage package, string sheet, IEnumerable<T> rows)
            where T : new()
        {
            var columns = typeof(T).GetProperties().ToList();

            //Ensure that we have something to output
            if (!columns.SelectMany(x => x.GetCustomAttributes(false).OfType<ColumnAttribute>()).Any())
            {
                throw new Exception("The Destination type must have properties decorated with the Column Attributes.");
            }

            if (package.Workbook.Worksheets[sheet] != null)
                throw new Exception(string.Format("Destination sheet '{0}' already exists", sheet));

            int rowNumber = 1;
            ExcelWorksheet currentWorksheet = package.Workbook.Worksheets.Add(sheet);

            //write out the Header Row
            foreach (var column in columns)
            {
                var attribute = column.GetCustomAttributes(false)
                    .OfType<ColumnAttribute>().FirstOrDefault();

                if (attribute != null)
                {
                    currentWorksheet.Cells[rowNumber, attribute.Ordinal].Value = attribute.ColumnName;
                }
            }
            rowNumber++;

            //write out the Body Rows
            foreach (var row in rows)
            {
                foreach (var column in columns)
                {
                    var attribute = column.GetCustomAttributes(false)
                        .OfType<ColumnAttribute>().FirstOrDefault();
                    var val = column.GetValue(row);

                    if (attribute != null && val != null)
                    {
                        var cell = currentWorksheet.Cells[rowNumber, attribute.Ordinal];
                        cell.Value = val;
                    }
                }
                rowNumber++;
            }

            //update the column widths to autofit based on the data we just added
            currentWorksheet.Cells[1, 1, rowNumber - 1, columns.Count()].AutoFitColumns();
            currentWorksheet.Cells[1, 1, rowNumber - 1, columns.Count()].AutoFilter = true;
        }
    }
}
