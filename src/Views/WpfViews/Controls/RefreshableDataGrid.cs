using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModels;

namespace WpfViews.Controls
{
    public class RefreshableDataGrid : DataGrid, IRefreshable
    {
        public void Refresh() => Items.Refresh();
    }

}
