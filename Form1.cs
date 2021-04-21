using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.ListView;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        ObservableCollection<OrderInfo> list = new ObservableCollection<OrderInfo>();

        ObservableCollection<string> collection = new ObservableCollection<string>();
        public Form1()
        {
            InitializeComponent();

            collection.Add("Germany");
            collection.Add("Mexico");
            collection.Add("The United Kingdom, made up of England,Scotland, Wales and Northern Ireland, is an island nation in northwestern Europe.");
            collection.Add("Sweden");
            collection.Add("France");
            collection.Add("Spain");
      

            list.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", new DateTime(2020,06,12)));
            list.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.",null));
            list.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1004, "Thomas Hardy", "Spain", "AROUT", "London", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid",null));
            list.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille",null));
            list.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Germany", "BOTTM", "Tsawassen", new DateTime(2020, 06, 12)));
            this.sfDataGrid1.AutoGenerateColumns = false;

            this.sfDataGrid1.DataSource = list;

            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name" });
            this.sfDataGrid1.Columns.Add(new GridComboBoxColumn() { MappingName = "Country", HeaderText = "Country",DataSource = collection});

            this.sfDataGrid1.CellRenderers.Remove("ComboBox");
            this.sfDataGrid1.CellRenderers.Add("ComboBox", new GridComboBoxCellRendererExt());

        }        
    }

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
}


