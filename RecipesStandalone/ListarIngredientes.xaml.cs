﻿using System;
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
    /// Lógica de interacción para ListarIngredientes.xaml
    /// </summary>
    public partial class ListarIngredientes : Window
    {
        public ListarIngredientes()
        {
            InitializeComponent();
            Ingredient a = new Ingrdient(txName.Text);
            txInfo.ItemsSource = a.IngredientNames();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            IngredientePrincip w = new IngredientePrincip();
            w.Show();
            this.Hide();
        }
    }
}
