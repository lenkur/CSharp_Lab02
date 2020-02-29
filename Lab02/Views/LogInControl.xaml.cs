using System.Windows.Controls;

namespace KMA.CSharp2020.Lab02
{
    /// <summary>
    /// Interaction logic for LogInControl.xaml
    /// </summary>
    public partial class LogInControl : UserControl
    {
        public LogInControl()
        {
            InitializeComponent();
            DataContext = new LogInViewModel();
        }
    }
}