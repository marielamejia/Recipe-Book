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
    /// Lógica de interacción para BuscarNutriologo.xaml
    /// </summary>
    public partial class BuscarNutriologo : Window
    {
        public BuscarNutriologo()
        {
            InitializeComponent();
            ClaseNutriologo n = new ClaseNutriologo();
            List<ClaseNutriologo> lista = n.NutriologoSearch();
            DGBuscarNutriologo.ItemsSource = lista;
        }

        private void RegresarBus_Click(object sender, RoutedEventArgs e)
        {
            Nutriologo w = new Nutriologo();
            w.Show();
            this.Hide();
        }

        private void BuscarBus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuBus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGBuscarNutriologo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
    }
}
