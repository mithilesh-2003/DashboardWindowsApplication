using System.Collections.Generic;

namespace Dashboard
{
    internal class EmployeeListBox
    {
        public static Employee SelectedItem { get; internal set; }
        public static object Items { get; internal set; }
        public static List<Employee> DataSource { get; internal set; }
        public static string DisplayMember { get; internal set; }
        public static string ValueMember { get; internal set; }
    }
}