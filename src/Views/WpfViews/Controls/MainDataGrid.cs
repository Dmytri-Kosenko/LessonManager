using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfViews.Controls
{
    public class MainDataGrid : RefreshableDataGrid
    {
        public MainDataGrid()
        {
            SelectionMode = System.Windows.Controls.DataGridSelectionMode.Single;
            AutoGenerateColumns = false;
            IsReadOnly = true;
        }
    }
}
