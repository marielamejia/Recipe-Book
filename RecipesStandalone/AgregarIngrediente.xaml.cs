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
    /// Lógica de interacción para AgregarIngrediente.xaml
    /// </summary>
    public partial class AgregarIngrediente : Window
    {
        public AgregarIngrediente()
        {
            InitializeComponent();
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            int res;
            Ingredient i = new Ingredient(txName.Text, Int32.Parse(txAvgPrice.Text));
            res = i.addIngredient(i);
            if (res > 0) //da > 0 si se pudo dar de alta
                MessageBox.Show("Alta exitosa");
            else
                MessageBox.Show("No se pudo dar de alta");
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            IngredientePrincip w = new IngredientePrincip();
            w.Show();
            this.Hide();
        }
    }
}
