<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652333/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1349)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/AddDeleteRow/Window1.xaml) (VB: [Window1.xaml.vb](./VB/AddDeleteRow/Window1.xaml.vb))
* [Window1.xaml.cs](./CS/AddDeleteRow/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/AddDeleteRow/Window1.xaml.vb))
<!-- default file list end -->
# How to programmatically add or remove grid rows


<p>This example demonstrates how to intercept the Delete and Insert key presses and remove or add a new data row to the grid. Please note that rows are inserted or removed directly from the underlying data source, and the grid is automatically refreshed since the data source implements the IBindingList interface and hence sends ListChanged notifications. To check whether a view is in editing mode, use the TableView.IsEditing property.</p>

<br/>


