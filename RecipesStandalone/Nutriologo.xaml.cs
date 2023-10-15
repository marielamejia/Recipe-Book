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
    /// Lógica de interacción para Nutriologo.xaml
    /// </summary>
    public partial class Nutriologo : Window
    {
        public Nutriologo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNutriologo w = new AddNutriologo();
            w.Show();
            this.Hide();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            ElliminarNutriologo w = new ElliminarNutriologo();
            w.Show();
            this.Hide();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarNutriologo w = new BuscarNutriologo();
            w.Show();
            this.Hide();

        }

        private void BotonVolver_Click (object sender, RoutedEventArgs e)
        {
            ElegirIngNutri w = new ElegirIngNutri();
            w.Show();
            this.Hide();
        }
    }
}
