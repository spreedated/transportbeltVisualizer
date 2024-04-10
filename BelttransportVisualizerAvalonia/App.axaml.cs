using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using BelttransportVisualizerAvalonia.ViewModels;
using BelttransportVisualizerAvalonia.Views;

namespace BelttransportVisualizerAvalonia
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (base.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };

                ((MainWindowViewModel)desktop.MainWindow.DataContext).Instance = desktop.MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}