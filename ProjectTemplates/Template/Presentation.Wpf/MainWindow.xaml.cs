using System;
using System.Windows;
using $ext_safeprojectname$.Application.RequestHandling.System;
using MediatR;

namespace $safeprojectname$
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var version = await App.Get<IMediator>().Send(new GetVersion.Request());

            label1.Text = $@"Version: {version.Application}; {version.Runtime}; {version.System} ({DateTime.Now})";
        }
    }
}
