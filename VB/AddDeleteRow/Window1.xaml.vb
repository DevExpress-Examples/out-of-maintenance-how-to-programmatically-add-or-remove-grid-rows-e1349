Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.ComponentModel

Namespace AddDeleteRow

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Public Partial Class Window1
        Inherits Window

        Private list As BindingList(Of TestData)

        Private counter As Integer

        Public Sub New()
            Me.InitializeComponent()
            list = New BindingList(Of TestData)()
            For i As Integer = 0 To 4 - 1
                counter += 1
                list.Add(New TestData() With {.Text = "Row" & counter.ToString(), .Number = counter})
            Next

            Me.grid.ItemsSource = list
            AddHandler Me.view.KeyUp, New KeyEventHandler(AddressOf view_KeyUp)
        End Sub

        Private Sub view_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.Key = Key.Delete Then
                Me.DeleteRow(Me.view.FocusedRowHandle)
            End If

            If e.Key = Key.Insert Then
                counter += 1
                Dim newData As TestData = New TestData With {.Number = counter, .Text = "New Row"}
                Me.InsertRow(Me.view.FocusedRowHandle, newData)
            End If
        End Sub

        Private Sub DeleteRow(ByVal rowHandle As Integer)
            Dim listIndex As Integer = Me.grid.GetRowListIndex(rowHandle)
            If listIndex >= 0 Then list.RemoveAt(listIndex)
        End Sub

        Private Sub InsertRow(ByVal rowHandle As Integer, ByVal data As TestData)
            Dim listIndex As Integer = Me.grid.GetRowListIndex(rowHandle)
            If listIndex < 0 OrElse listIndex >= list.Count Then listIndex = -1
            list.Insert(listIndex + 1, data)
        End Sub
    End Class

    Public Class TestData

        Public Property Number As Integer

        Public Property Text As String
    End Class
End Namespace
