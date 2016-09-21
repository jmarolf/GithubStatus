using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GithubStatus.UI.ViewModel;
using ReactiveUI;

namespace GithubStatus.UI.View
{
    /// <summary>
    /// Interaction logic for OpenUserIssuesView.xaml
    /// </summary>
    public partial class OpenUserIssuesView : Page, IViewFor<IOpenUserIssuesViewModel>
    {
        public OpenUserIssuesView()
        {
            InitializeComponent();
            ViewModel = new OpenUserIssuesViewModel();
            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
        }

        public IOpenUserIssuesViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as IOpenUserIssuesViewModel; }
        }
    }
}
