using StulKnihovna;
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

namespace StulProgramy
{
    /// <summary>
    /// Interaction logic for StavComboBox.xaml
    /// </summary>
    public partial class StavComboBox : UserControl
    {
        StavPixelu Stav
        {
            get
            {
                return (StavPixelu)comboBox.SelectedIndex;
            }
            set
            {
                comboBox.SelectedIndex = (int)value;
            }
        }

        public event SelectionChangedEventHandler? SelectionChanged;

        public StavComboBox()
        {
            InitializeComponent();
            comboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(sender, e);
        }
    }
}
