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
using System.Windows.Shapes;

namespace WpfApp_Garage.View
{
    /// <summary>
    /// Logique d'interaction pour ChiffreAffaire.xaml
    /// </summary>
    public partial class ChiffreAffaire : Window
    {
        private ViewModel.VM_ChiffreAffaire Local;
        
        public ChiffreAffaire()
        {
            InitializeComponent();
            Local = new ViewModel.VM_ChiffreAffaire();
            DataContext = Local;
        }
    }
}
