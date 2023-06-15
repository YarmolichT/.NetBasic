using ClassLibrary2;
using System.Windows;


namespace WPFGreetingApp_Modul1_
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

        private void btnShowGreeting_Click(object sender, RoutedEventArgs e)
        {
            var name = txtUserName.Text;
            var greetingMessage = ($" Hello, {name}!");

            AddTime addTime = new AddTime();
            string TimeGreeting = addTime.ConcatenateString(greetingMessage);

            lblUserGreeting.Content = TimeGreeting;

            txtUserName.Clear();
        }
    }
}
