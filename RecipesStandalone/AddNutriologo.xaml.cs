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

namespace RecipesStandalone
{
    /// <summary>
    /// Lógica de interacción para AddNutriologo.xaml
    /// </summary>
    public partial class AddNutriologo : Window
    {
        public AddNutriologo()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuAd_Click(object sender, RoutedEventArgs e)
        {
            Nutriologo w = new Nutriologo();
            w.Show();
            this.Hide();
        }
    }
}
