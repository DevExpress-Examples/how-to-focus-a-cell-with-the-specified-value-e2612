Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace FocusingCellsWithSpecifiedValue
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = New ProductList()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If grid.VisibleRowCount = 0 Then
				Return
			End If
			Dim rowHandle As Integer = view.FocusedRowHandle
			If view.FocusedColumn.FieldName = "UnitPrice" AndAlso Convert.ToDouble(grid.GetFocusedValue()) = 21 Then
				rowHandle += 1
			End If
			Do While Convert.ToDouble(grid.GetCellValue(rowHandle, "UnitPrice")) <> 21 AndAlso grid.IsValidRowHandle(rowHandle)
				rowHandle += 1
			Loop
			If grid.IsValidRowHandle(rowHandle) Then
				view.FocusedColumn = grid.Columns("UnitPrice")
				view.FocusedRowHandle = rowHandle
			End If
		End Sub
	End Class
End Namespace
