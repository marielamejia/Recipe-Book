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
    /// Lógica de interacción para EliminaIngrediente.xaml
    /// </summary>
    public partial class EliminaIngrediente : Window
    {
        public EliminaIngrediente()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            IngredientePrincip w = new IngredientePrincip();
            w.Show();
            this.Hide();
        }
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Ingredient a = new Ingredient();
            int res = a.deleteIngredient(Int16.Parse(txDelete.Text));
            if (res > 0)
                MessageBox.Show("Ingrediente eliminado");
            else
                MessageBox.Show("Clave no válida");
        }
    }
}
