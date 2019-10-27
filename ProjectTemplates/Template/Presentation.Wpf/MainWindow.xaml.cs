using System;
using System.Windows;
using $ext_safeprojectname$.Application.RequestHandling.System;
using MediatR;
using Newtonsoft.Json;
using $ext_safeprojectname$.Application.Contracts;
using $ext_safeprojectname$.Domain.Entities;

namespace $safeprojectname$
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource tokenSource;
        public MainWindow()
        {
            tokenSource = new CancellationTokenSource();
            InitializeComponent();
            $if$ ($ext_addServiceBus$ == True)
            App.Get<IServiceBus>().ListenAsync<MyEntity>(Constants.ServiceBusQueues.TestQueue, entity =>
            {
                MessageBox.Show(JsonConvert.SerializeObject(entity));
            }, tokenSource.Token);
            $endif$
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var version = await App.Get<IMediator>().Send(new GetVersion.Request());
            label1.Text = $@"Version: {version.Application}; {version.Runtime}; {version.System} ({DateTime.Now})";

            $if$ ($ext_addServiceBus$ == True)
            $if$ ($ext_addSignalR$ == True)
            await App.Get<IMediator>().Send(new SendToServiceBus.Request
            {
                Queue = Constants.ServiceBusQueues.ClientEventQueue,
                Content = new ClientEvent(TargetClient.All, "TestFromWpf", new { Runtime = version.Runtime })
            });
            $endif$
            $endif$
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            tokenSource.Cancel();
        }

    }
}
