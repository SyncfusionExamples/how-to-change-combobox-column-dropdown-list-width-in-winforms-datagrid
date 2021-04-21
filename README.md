# How to change Combobox column dropdown list width in WinForms DataGrid (SfDataGrid)?

## About the sample
This example illustrates how to change Combobox column dropdown list width in [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid)?

[WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) does not provide the direct support to change Combobox column dropdown list width. You can change ComboBox column dropdown list width by overriding [OnInitializeEditElement](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridComboBoxCellRenderer.html#Syncfusion_WinForms_DataGrid_Renderers_GridComboBoxCellRenderer_OnInitializeEditElement_Syncfusion_WinForms_DataGrid_DataColumnBase_Syncfusion_WinForms_GridCommon_ScrollAxis_RowColumnIndex_Syncfusion_WinForms_ListView_SfComboBox_) method in [GridComboBoxCellRenderer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridComboBoxCellRenderer.html).

```C#

this.sfDataGrid1.CellRenderers.Remove("ComboBox");
this.sfDataGrid1.CellRenderers.Add("ComboBox", new GridComboBoxCellRendererExt());

public class GridComboBoxCellRendererExt : GridComboBoxCellRenderer
{
        protected override void OnInitializeEditElement(DataColumnBase column, RowColumnIndex rowColumnIndex, SfComboBox uiElement)
        {
            base.OnInitializeEditElement(column, rowColumnIndex, uiElement);
            IEnumerable comboboxSource = (IEnumerable)uiElement.DataSource;
            var comboboxlist = comboboxSource.Cast<object>().ToList();

            int maxWidth = 0;
            int temp = 0;
            foreach (var item in comboboxlist)
            {
                temp = TextRenderer.MeasureText(item.ToString(), uiElement.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            //set the combo box drop down width based on content contains in combo Box list
            uiElement.DropDownListView.ItemWidth = maxWidth;
        }
}

```

![ComboBox dropdown width changed in SfDataGrid](ComboBoxColumnDropDownWidth.gif)

Take a moment to peruse the [WinForms DataGrid - Column Sizing](https://help.syncfusion.com/windowsforms/datagrid/columns#column-sizing) documentation, where you can find about Column Sizing with code examples.

## Requirements to run the demo
Visual Studio 2015 and above versions
