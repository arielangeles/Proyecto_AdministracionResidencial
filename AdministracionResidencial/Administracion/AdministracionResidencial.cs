using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public static class AdministracionResidencial
    {
        private static List<Residencial> listaResidencial;

        static AdministracionResidencial()
        {
            listaResidencial = new List<Residencial>();
        }

        public static int seleccion, contadorResidencial;
        public static string registro;
        public static bool startSecurity;

        public static void MostrarResidenciales(bool start)
        {
            if (listaResidencial.Count == 0)
            {
                Console.WriteLine("No hay lista\nPresione cualquier tecla para volver atras..");
                Console.ReadLine();
                start = false;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("{0,-10} {1,9} {2,16} {3,24} {4,34} {5,24}","No.  "+"Sector", "Tipo", "Seguridad", "No. de residentes", "Monto a pagar de c/residente", "Total de gastos");
                foreach (Residencial residencial in listaResidencial)
                {
                    Console.WriteLine("{0,-10} {1,9} {2,16} {3,24} {4,34} {5,24}", $"{residencial.CantidadResidenciales}- " + residencial.Sector, residencial.TipoResidencia, residencial.Seguridad, residencial.CantidadResidentes, residencial.MontoAPagar, residencial.GastosMantenimiento);
                }
                Console.ReadKey();
            }
            
        }
        public static bool BuscarResidencial (Residencial res)
        {
            if (res.CantidadResidenciales == seleccion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void AgregarListaResidencial(Residencial residencial)
        {
            listaResidencial.Add(residencial);
        }
       

        public static void AgregarResidencial(bool startResidence)
        {
            Residencial residencial = new Residencial();
            
            Console.Write("\nEscriba el sector: ");
            residencial.Sector = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1. Residencial de casas\n2. Residencial de apartamentos\n3. Residencial variado");
            Console.Write("\nSeleccione el tipo de Residencia: ");
            string tipo = Console.ReadLine().ToLower();
            residencial.TipoResidencia = Residencial.AgregarTipoResidencia(tipo);

            Console.WriteLine("\nDesea registrar los gastos? ");
            registro = Console.ReadLine();
            AgregarGastos(registro, residencial);

            AgregarSeguridad(residencial, startSecurity);
            
            Console.WriteLine("\n");
            if (residencial.TipoResidencia == TipoResidencia.Casa)
            {
                AgregarResidencialCasas(residencial);
            }
            else if (residencial.TipoResidencia == TipoResidencia.Edificio)
            {
                AgregarResidencialEdificio(residencial);
            }
            else if (residencial.TipoResidencia == TipoResidencia.Variado)
            {
                AgregarResidencialVariado(residencial);
            }
            else
            {
                Program.startResidence = true;
            }

            contadorResidencial++;
            residencial.CantidadResidenciales += contadorResidencial;

            AgregarListaResidencial(residencial);
            Program.start = true;
        }
        public static void EliminarResidencial()
        {
            Console.Write("\nInserte el No. de Residencial que desea eliminar: ");
            seleccion = int.Parse(Console.ReadLine());


            int eliminado = listaResidencial.RemoveAll(BuscarResidencial);
            if (eliminado > 0)
            {
                Console.WriteLine($"\nEl Residencial No.{seleccion} ha sido eliminado");
            }
            else
            {
                Console.WriteLine("Ese No. de Residencial no existe");
            }
            Console.ReadKey();
        }

        public static void AgregarResidencialCasas(Residencial residencial)
        {
    
            Console.Write("Indique la cantidad de casas que posee: ");
            residencial.cantidadCasas = byte.Parse(Console.ReadLine());

            Console.Write("Indique la cantidad de areas comunes: ");
            residencial.cantidadAreaComun = byte.Parse(Console.ReadLine());

            Console.WriteLine("\nListo! Residencial de casas agregado");
            Console.ReadKey();
        }
        public static void AgregarResidencialEdificio(Residencial residencial)
        {
           
            Console.Write("Indique la cantidad de edificios que posee: ");
            residencial.cantidadApt = short.Parse(Console.ReadLine());

            Console.Write("Indique la cantidad de areas comunes: ");
            residencial.cantidadAreaComun = byte.Parse(Console.ReadLine());

            Console.WriteLine("\nListo! Residencial de edificios agregado");
            Console.ReadKey();
        }
        public static void AgregarResidencialVariado(Residencial residencial)
        {
            Console.Write("Indique la cantidad de edificios que posee: ");
            residencial.cantidadApt = short.Parse(Console.ReadLine());

            Console.Write("Indique la cantidad de casas que posee: ");
            residencial.cantidadCasas = short.Parse(Console.ReadLine());

            Console.Write("Indique la cantidad de areas comunes: ");
            residencial.cantidadAreaComun = short.Parse(Console.ReadLine());


            Console.WriteLine("\nListo! Residencial variado agregado");
            Console.ReadKey();

        }

        public static void AgregarSeguridad(Residencial residencial, bool startSecurity)
        {
            do
            {
                Console.WriteLine("\nDesea agregar seguridad? ");
                residencial.Seguridad = Console.ReadLine();
                if (residencial.Seguridad.ToLower() == "si")
                {
                    
                    Console.Write("Indique el gasto de mantenimiento para la seguridad: ");
                    residencial.GMSeg = int.Parse(Console.ReadLine());
                    Residencial.cantidadSeguridad++;
                    startSecurity = false;
                }
                else if(residencial.Seguridad.ToLower() == "no") {

                    Console.WriteLine("Se registraran los gastos predeterminados");
                }
                else
                {
                    Console.WriteLine("Respuesta no valida");
                    Console.ReadKey();
                    startSecurity = true;
                }

            } while (startSecurity);
            

        }

        public static void AgregarGastos(string registro, Residencial residencial)
        {
          
            if (registro.ToLower() == "si")
            {
                if (residencial.TipoResidencia == TipoResidencia.Edificio)
                {
                    AgregarGastoMantEd(residencial);
                  
                }
                else if (residencial.TipoResidencia == TipoResidencia.Casa)
                {
                    AgregarGastoMantCasa(residencial);
                }
                else if(residencial.TipoResidencia == TipoResidencia.Variado)
                {
                    AgregarGastoMantCasa(residencial);
                    AgregarGastoMantEd(residencial);

                }
                Console.Write("Indique el gasto de mantenimiento por area comun: ");
                residencial.GMAReaComun = int.Parse(Console.ReadLine());
            }
            else if(registro.ToLower() == "no") {
                Console.WriteLine("Se registraran los gastos predeterminados");
            }
            else
            {
                Console.WriteLine("Respuesta invalida");
                Console.ReadKey();
                Program.startResidence = true;
            }
 
        }
        public static void AgregarGastoMantCasa(Residencial residencial)
        {
            Console.Write("Indique el gasto de mantenimiento por casa: ");
            residencial.GMCasa = int.Parse(Console.ReadLine());
        } //Agregar gastos de mantenimiento por casa
        public static void AgregarGastoMantEd(Residencial residencial)
        {
            Console.Write("Indique el gasto de mantenimiento por apartamento: ");
            residencial.GMApt = int.Parse(Console.ReadLine());
        } // Agregar gastos de mantenimiento por apartamento
  
    }
}
