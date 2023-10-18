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

        private void NombreText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AgregarAd_Click(object sender, RoutedEventArgs e)
        {
            int res;
            ClaseNutriologo n = new ClaseNutriologo(Int32.Parse(CedulaText.Text), NombreText.Text);
            res = n.addNutriologo(n);
            if (res > 0)
            {
                MessageBox.Show("Alta exitosa");
            }
            else
                MessageBox.Show("No se pudo dar alta ");
        }

    }
}
