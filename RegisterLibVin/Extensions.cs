using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public static class Extensions
    {
        /// <summary>
        /// Copy du lieu cua datarow tra ve 1 datarow moi, datarow moi duoc taoj tu toDt
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="toDt"></param>
        /// <returns></returns>
        public static DataRow CloneDataRow(this DataRow dataRow, DataTable toDt)
        {
            DataRow newRow = toDt.NewRow();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                newRow[column.ColumnName] = dataRow[column.ColumnName];
            }
            return newRow;
        }

        public static DataTable CreateNewDataTable(this DataTable dataTable)
        {
            DataTable dtNew = new DataTable();
            foreach (DataColumn column in dataTable.Columns)
            {
                dtNew.Columns.Add(column.ColumnName);
            }
            return dtNew;
        }

        public static void ToggleDoubleBuffered<TControl>(this TControl control, bool isOn) where TControl : Control
        {
            PropertyInfo pi = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            if (pi != null)
                pi.SetValue(control, isOn, null);
        }
    }
}
