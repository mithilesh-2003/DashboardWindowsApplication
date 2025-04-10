using System;
using System.Windows.Forms;

namespace Dashboard
{
    internal class DataGridComboBoxColumn
    {
        public string Name { get; internal set; }
        public string HeaderText { get; internal set; }
        public object Items { get; internal set; }

        public static implicit operator DataGridComboBoxColumn(DataGridViewComboBoxColumn v)
        {
            throw new NotImplementedException();
        }
    }
}