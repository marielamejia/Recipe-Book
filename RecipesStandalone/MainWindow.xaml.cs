using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipesStandalone
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
            }
        }

        private void txtContra_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
            }
        }

        private void txtContra_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int res;
            res = Conexion.comprobarContra(txtUsuario.Text, txtContra.Text); //usamos el texto de las text boxes
            if (res == 1) //el user y password es correcto
            {
                ElegirIngNutri w = new ElegirIngNutri();
                w.Show();
                this.Hide();

            }else
               if (res == 2) //el password es incorrecto
                    MessageBox.Show("Password incorrecto");
               else
                    MessageBox.Show("Usuario incorrecto");
        }

          public static int comprobarContra(String usu, String cont)
          {
               int res = 0;
               SqlConnection con;
               SqlDataReader dr;
               SqlCommand cmd;
               try {
                    con = Conexion.agregarConexion(); //primero establecemos la conexión
                    cmd = new SqlCommand(String.Format("select contrasena from Usuario where nombre='{0}'",usu), con); //
                    //sqlCommand hace los queries, mandamos el query y la conexión
                    //ponemos StringFormat para que remplace el {0} con el usu (primer elemento en nuestra lista)
                    dr = cmd.ExecuteReader(); //ejecuta(lee datos)
                    if (dr.Read())
                         if (dr.GetString(0).Equals(cont))
                              res = 1; //password correcto
                         else
                              res = 2; //password incorrecto
                    else
                         res = 3; //no hay ese usuario
                    con.Close(); //siempre cerrar
               } catch(Exception ex) {
                    MessageBox.Show("Error" + ex);
               }
               return res;
          }
    }
}
