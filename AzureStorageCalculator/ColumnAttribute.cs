using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageCalculator
{
    /// <summary>
    /// Use the ColumnAttribute to decorate properties on classes you want to read/write to excel. 
    /// </summary>
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// This is the column name used in the header when creating excel files
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// This is the position (1 based)
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// When reading an excel workbook we need to read throw each line, 
        /// we know when we have reached the end of the workbook when the column marked as primary is empty.
        /// </summary>
        public bool Primary { get; set; }

        public ColumnAttribute()
        {

        }

        public ColumnAttribute(int ordinal, string name, bool primary = false)
        {
            Ordinal = ordinal;
            ColumnName = name;
            Primary = primary;
        }
    }
}
