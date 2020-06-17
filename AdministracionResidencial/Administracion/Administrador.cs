using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Administrador
    {
        private static string username = "arielangeles";
        private static string password = "angeles9564";

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
        public static bool Login()
        {
            Console.Write("Inserte su nombre de usuario: ");
            string user = Console.ReadLine();

            if (user == username)
            {
                Console.Write("Inserte su contraseña: ");
                string pass = Console.ReadLine();

                if (pass == password)
                {
                    
                    Console.WriteLine($"\n\tBienvenido, {user}");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Contraseña/usuario no valido");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Usuario no valido");
                return false;

            }
  
          

        }
    }
}
