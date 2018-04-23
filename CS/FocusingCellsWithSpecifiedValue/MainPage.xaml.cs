using System;
using System.Windows;
using System.Windows.Controls;

namespace FocusingCellsWithSpecifiedValue {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = new ProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (grid.VisibleRowCount == 0) return;
            int rowHandle = grid.View.FocusedRowHandle;
            if (grid.View.FocusedColumn.FieldName == "UnitPrice" && Convert.ToDouble(grid.GetFocusedValue()) == 21)
                rowHandle++;
            while (Convert.ToDouble(grid.GetCellValue(rowHandle, "UnitPrice")) != 21 &&
                grid.IsValidRowHandle(rowHandle)) {
                rowHandle++;
            }
            if (grid.IsValidRowHandle(rowHandle)) {
                grid.View.FocusedColumn = grid.Columns["UnitPrice"];
                grid.View.FocusedRowHandle = rowHandle;
            }
        }
    }
}
