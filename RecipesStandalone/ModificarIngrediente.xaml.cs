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
    /// Lógica de interacción para ModificarIngrediente.xaml
    /// </summary>
    public partial class ModificarIngrediente : Window
    {
        public ModificarIngrediente()
        {
            InitializeComponent();
        }

        private void btModify_Click(object sender, RoutedEventArgs e)
        {
            Ingredient a = new Ingredient();
            int res = a.modify(Int16.Parse(txID.Text), Decimal.Parse(txAvgPrice.Text));
            if (res > 0)
                MessageBox.Show("Modificación exitosa");
            else
                MessageBox.Show("Clave no válida");
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            IngredientePrincip w = new IngredientePrincip();
            w.Show();
            this.Hide(); 
        }
    }
}
