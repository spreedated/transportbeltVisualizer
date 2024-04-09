using BelttransportVisualizerWpf.ViewModels;
using System.Windows;

namespace BelttransportVisualizerWpf.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ((MainWindowViewModel)this.DataContext).Instance = this;
        }
    }
}