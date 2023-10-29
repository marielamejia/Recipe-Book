# Recipe-Book

"Sabor a salud" recipe book platform created using C# and Microsoft SQL.

This project is built around an SQL database aided by a standalone application so that data can be used for a web app. 

The purpose is to provide people with common dietary restrictions (or who simply trying to eat healthy) a platform where they can find a variety of nutritionist-curated recipes that suit their necessities.

The standalone app is used for the management (insertion, modification and deletion) of core data. The web app is designed for users to browse recipes, add them to a weekly plan and save a groceries shopping list. Aditionally, the web app allows our certified nutricionists to create and update recipes.

# How to use

1. Open SQL Managment studio and download the file SQL_ProyectoRecetas.sql
2. Execute all the queries as indicated by the comments on the file
3. Open visual studio (microsoft) and clone the repository with the repository link (make sure to remember the path)
4. Once the repository is cloned, close visual studio and find the folder in your machine
5. There will be to big folders inside "RecipesWeb" and "RecipesStandalone"
6. Open the folder of the application you would like to use
7. Open the .sln of that folder
8. It should open in visual studio. Within the solution establish a new data source (the data base you created in step 2)
9. This way, should get a Data Source String
10. Create a class called "Conexion" It should say "Conexion.cs"
11. Add the following method WITH YOUR OWN DATA SOURCE
    
 public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=");
                cnn.Open();
                //MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                cnn = null;
            }
            return cnn;
        }
        
12. Execute the program and have fun testing it out!
