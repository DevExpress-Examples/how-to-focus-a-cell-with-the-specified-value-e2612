using System;
using System.Windows;
using System.Windows.Controls;

namespace FocusingCellsWithSpecifiedValue {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = new ProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (grid.VisibleRowCount == 0) return;
            int rowHandle = view.FocusedRowHandle;
            if (view.FocusedColumn.FieldName == "UnitPrice" && Convert.ToDouble(grid.GetFocusedValue()) == 21)
                rowHandle++;
            while (Convert.ToDouble(grid.GetCellValue(rowHandle, "UnitPrice")) != 21 &&
                grid.IsValidRowHandle(rowHandle)) {
                rowHandle++;
            }
            if (grid.IsValidRowHandle(rowHandle)) {
                view.FocusedColumn = grid.Columns["UnitPrice"];
                view.FocusedRowHandle = rowHandle;
            }
        }
    }
}
