using System.Windows;

namespace CSharpTask2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(NameText, SurnameText, EmailText, BirthDateText, IsAdultText, SunSignText, ChineseSignText, IsBirthdayText);
        }
    }
}
