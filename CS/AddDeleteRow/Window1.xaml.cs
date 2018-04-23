using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace AddDeleteRow {
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window {
		BindingList<TestData> list;
        int counter;

		public Window1() {
			InitializeComponent();
            
            list = new BindingList<TestData>();
            for(int i = 0; i < 4; i++) {
                counter++;
                list.Add(new TestData() { Text = "Row" + counter.ToString(), Number = counter });
            }
			
            grid.DataSource = list;
            view.KeyUp += new KeyEventHandler(view_KeyUp);
		}

        void view_KeyUp(object sender, KeyEventArgs e) {
            if(e.Key == Key.Delete) {
                DeleteRow(view.FocusedRowHandle);
            }
            if(e.Key == Key.Insert) {
                counter++;
                TestData newData = new TestData { Number = counter, Text = "New Row" };
                InsertRow(view.FocusedRowHandle, newData);
            }
        }
        private void DeleteRow(int rowHandle) {
            int listIndex = grid.GetRowListIndex(rowHandle);
            if(listIndex >= 0)
                list.RemoveAt(listIndex);
        }
        private void InsertRow(int rowHandle, TestData data) {
            int listIndex = grid.GetRowListIndex(rowHandle);
            if(listIndex < 0 || listIndex >= list.Count) listIndex = -1;
            list.Insert(listIndex + 1, data);
        }
    }

	public class TestData {
		public int Number { get; set; }
		public string Text { get; set; }
	}
}
