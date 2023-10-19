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
    /// Lógica de interacción para ElliminarNutriologo.xaml
    /// </summary>
    public partial class ElliminarNutriologo : Window
    {
        public ElliminarNutriologo()
        {
            InitializeComponent();
        }

        private void RegresarDel_Click(object sender, RoutedEventArgs e)
        {
            Nutriologo w = new Nutriologo();
            w.Show();
            this.Hide();
        }

        private void EliminarDel_Click(object sender, RoutedEventArgs e)
        {
            Nutriologo a = new Nutriologo();
            int res = a.deleteNutriologo(Int16.Parse(txDelete.Text));
            if (res > 0)
                MessageBox.Show("Nutriologo eliminado");
            else
                MessageBox.Show("Cédula Profesional no válida");
        }
    }
}
