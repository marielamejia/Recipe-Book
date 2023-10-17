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
    /// Lógica de interacción para ElegirIngNutri.xaml
    /// </summary>
    public partial class ElegirIngNutri : Window
    {
        public ElegirIngNutri()
        {
            InitializeComponent();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BotonCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BotonNutriologos_Click(object sender, RoutedEventArgs e)
        {
            Nutriologo wNut = new Nutriologo();
            wNut.Show();
            this.Hide();
        }

        private void BotonIngredientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotonIngredientes_Click_1(object sender, RoutedEventArgs e)
        {
            IngredientePrincip wIng = new IngredientePrincip();
            wIng.Show();
            this.Hide();
        }
    }
}
