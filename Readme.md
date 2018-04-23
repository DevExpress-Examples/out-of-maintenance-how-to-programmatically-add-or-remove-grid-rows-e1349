# How to programmatically add or remove grid rows


<p>This example demonstrates how to intercept the Delete and Insert key presses and remove or add a new data row to the grid. Please note that rows are inserted or removed directly from the underlying data source, and the grid is automatically refreshed since the data source implements the IBindingList interface and hence sends ListChanged notifications. To check whether a view is in editing mode, use the TableView.IsEditing property.</p>

<br/>


