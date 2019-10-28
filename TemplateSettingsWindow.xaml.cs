using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace VSIX_CCA_ProjectTemplate
{
    /// <summary>
    /// Interaction logic for TemplateSettingsWindow.xaml
    /// </summary>
    public partial class TemplateSettingsWindow : Window
    {
        public Dictionary<string, string> Parameters { get; set; }
        public ObservableCollection<string> SinglePageApps { get; set; }

        public TemplateSettingsWindow()
        {
            SinglePageApps = new ObservableCollection<string>(new []{"React", "Vue"});
            DataContext = this;
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(251, 251, 251)); // TODO: Find Visual Studio Resource for that
        }

        public TemplateSettingsWindow(Dictionary<string, string> parameters) : this()
        {
            Parameters = new Dictionary<string, string>(parameters);
            DataContext = null;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TemplateSettingsWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
