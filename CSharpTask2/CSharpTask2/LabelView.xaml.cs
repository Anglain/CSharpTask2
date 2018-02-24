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

namespace CSharpTask2
{
    /// <summary>
    /// Логика взаимодействия для LabelView.xaml
    /// </summary>
    public partial class LabelView : UserControl
    {
        public LabelView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PropertyValueProperty = DependencyProperty.Register
        (
            "PropertyValue",
            typeof(string),
            typeof(LabelView),
            new PropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register
        (
            "PropertyName",
            typeof(string),
            typeof(LabelView),
            new PropertyMetadata(string.Empty)
        );
        public string PropertyValue
        {
            get { return (string)GetValue(PropertyValueProperty); }
            set { SetValue(PropertyValueProperty, value); }
        }

        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }
    }
}
