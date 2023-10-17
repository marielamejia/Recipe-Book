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
    /// Lógica de interacción para IngredientePrincip.xaml
    /// </summary>
    public partial class IngredientePrincip : Window
    {
        public IngredientePrincip()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AgregarIngrediente w = new AgregarIngrediente();
            w.Show();
            this.Hide();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            EliminaIngrediente w = new EliminaIngrediente();
            w.Show();
            this.Hide();
        }

        private void btModify_Click(object sender, RoutedEventArgs e)
        {
            ModificarIngrediente w = new ModificarIngrediente();
            w.Show();
            this.Hide(); 
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            BuscarIngrediente w = new BuscarIngrediente();
            w.Show();
            this.Hide(); 
        }

        private void btList_Click(object sender, RoutedEventArgs e)
        {
            ListarIngredientes w = new ListarIngredientes();
            w.Show();
            this.Hide();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            this.Hide(); 
        }
    }
}
