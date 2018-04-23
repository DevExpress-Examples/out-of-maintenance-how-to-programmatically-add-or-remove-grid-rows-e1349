Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.ComponentModel

Namespace AddDeleteRow
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Private list As BindingList(Of TestData)
		Private counter As Integer

		Public Sub New()
			InitializeComponent()

			list = New BindingList(Of TestData)()
			For i As Integer = 0 To 3
				counter += 1
				list.Add(New TestData() With {.Text = "Row" & counter.ToString(), .Number = counter})
			Next i

			grid.DataSource = list
			AddHandler view.KeyUp, AddressOf view_KeyUp
		End Sub

		Private Sub view_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
			If e.Key = Key.Delete Then
				DeleteRow(view.FocusedRowHandle)
			End If
			If e.Key = Key.Insert Then
				counter += 1
				Dim newData As TestData = New TestData With {.Number = counter, .Text = "New Row"}
				InsertRow(view.FocusedRowHandle, newData)
			End If
		End Sub
		Private Sub DeleteRow(ByVal rowHandle As Integer)
			Dim listIndex As Integer = grid.GetRowListIndex(rowHandle)
			If listIndex >= 0 Then
				list.RemoveAt(listIndex)
			End If
		End Sub
		Private Sub InsertRow(ByVal rowHandle As Integer, ByVal data As TestData)
			Dim listIndex As Integer = grid.GetRowListIndex(rowHandle)
			If listIndex < 0 OrElse listIndex >= list.Count Then
				listIndex = -1
			End If
			list.Insert(listIndex + 1, data)
		End Sub
	End Class

	Public Class TestData
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
	End Class
End Namespace
