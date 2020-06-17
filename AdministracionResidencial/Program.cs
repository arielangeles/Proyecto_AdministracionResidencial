using System;
using System.Collections.Generic;
using System.Threading;

namespace AdmRes
{
    class Program
    {
        public static bool start = true, startComplaint = true, startResidence = true;
        public static short menu;
        public static void DefaultOption(bool start)
        {       
            Console.WriteLine("\nIngrese un numero que se encuentre en las opciones");
            start = true;
            Console.ReadKey();

        }
        public static void MenuOption()
        {
            Console.Write("\nInserte la opcion deseada: ");
            menu = Int16.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            //ComprobarLogin();  // Sistema de log-in
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================================");
                Console.WriteLine("\tBienvenido a la Administracion de Residenciales FS");
                Console.WriteLine("==============================================================");
                Console.WriteLine("1. Lista de Residenciales\n2. Registro de Residenciales\n3. Registro de Quejas\n4. Salir");
                MenuOption();

                Console.Clear();

                switch (menu)
                {
                    case 1:
                        AdministracionResidencial.MostrarResidenciales(start);
                        break;

                    case 2:
                        RegistroDeResidencial();
                        break;
                    case 3:
                        RegistroDeQuejas();
                        break;
                    case 4:
                        start = false;
                        break;
                    default:
                        DefaultOption(start);
                        break;
                }
            } while(start);

        }
        public static void ComprobarLogin()
        {
            Console.Clear();
            if (Administrador.Login() == true)
            {
                start = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
         
        public static void RegistroDeResidencial()
        {
            do
            {
                Console.Clear();
                startResidence = false;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("\tBienvenido al registro de Residencial");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("1. Registrar un residencial\n2. Eliminar un residencial\n3. Volver al inicio");
                MenuOption();

                switch (menu)
                {
                    case 1:
                        AdministracionResidencial.AgregarResidencial(startResidence);
                        break;
                    case 2:
                        AdministracionResidencial.EliminarResidencial();
                        break;
                    case 3:
                        startResidence = false;
                        break;
                    default:
                        DefaultOption(startResidence);
                        break;
                }
            } while (startResidence);

        }
        public static void RegistroDeQuejas()
        {
            do
            {
                Console.Clear();
                startComplaint = true;
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\tBienvenido al registro de quejas");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Mostrar lista de quejas\n2. Registrar una queja\n3. Responder una queja\n4. Eliminar una queja\n5. Volver al inicio");
                MenuOption();

                switch (menu)
                {
                  
                    case 1:
                        RegistroQuejas.MostrarQuejas(startComplaint);
                        break;

                    case 2:
                        RegistroQuejas.AgregarQuejas(startComplaint);
                        break;

                    case 3:
                        RegistroQuejas.ResponderQueja(startComplaint);
                        break;
                    case 4:
                        RegistroQuejas.EliminarQueja();
                        break;
                    case 5:
                        startComplaint = false;
                        break;
                    default:
                        DefaultOption(startComplaint);
                        break;
                }

            } while (startComplaint);
            
        }
        

        
      
    }
}
