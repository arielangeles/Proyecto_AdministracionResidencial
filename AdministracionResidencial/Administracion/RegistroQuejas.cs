using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public static class RegistroQuejas
    {
        public static List<Quejas> ListaQuejas;
       

        static RegistroQuejas()
        {
            ListaQuejas = new List<Quejas>();
        }
        
        public static void AddComplaints(Quejas quejas)
        {
            ListaQuejas.Add(quejas);
        }

        public static short contadorQueja = 0;
        public static bool startQueja = true, startRespuesta = true, RespuestaValida = false;
        public static int seleccion;
        public static void AgregarQuejas(bool startComplaint)
        {

            Residente residente = new Residente();
                
                Console.Write("\nVive en apartamento o casa? ");
                string vivienda = Console.ReadLine();
                if (vivienda == "apartamento")
                {
                    residente.Tipo = TipoResidente.ResEdificio;
                }
                else if (vivienda == "casa")
                {
                    residente.Tipo = TipoResidente.ResCasa;
                }
                else
                {
                    Console.WriteLine("Ingrese una opcion valida");
                    Console.ReadKey();
                    startComplaint = true;
       
                }
         

            Console.Write("Ingrese su nombre: ");
            residente.Nombre = Console.ReadLine();
            Console.Write("Ingrese la calle donde vive: ");
            residente.Calle = Console.ReadLine();
            Console.Write("Ingrese el numero de residencia: ");
            residente.NumeroCasaApt = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("-----Centro de Quejas-----\n");
            Console.Write("Ingrese el asunto: ");
            residente.Asunto = Console.ReadLine();
            Console.Write("Ingrese la descripcion: ");
            residente.Descripcion = Console.ReadLine();
  
            contadorQueja++;
            residente.NumeroQueja += contadorQueja;
            residente.Respondida = false;

            AddComplaints(residente);
            Residencial.AgregarResidente(residente);

            Program.startComplaint = true;
        }
        public static void MostrarQuejas(bool startComplaint)
        {
            Console.Clear();
            if(ListaQuejas.Count == 0)
            {
                Console.WriteLine("No hay lista\nPresione cualquier tecla para volver atras..");
                Console.ReadLine();
                startComplaint = false;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("No. de Queja \t|Asunto \t\t\t\t|Descripcion \t\t\t\t\t|Respondida ");
                foreach (Residente residente in ListaQuejas)
                {
                    Console.WriteLine($"{residente.NumeroQueja} \t\t|{residente.Asunto} \t\t|{residente.Descripcion} \t\t|{residente.RespondidaYN}");
                }
                Console.ReadKey();
            }
            
        }

        public static void ResponderQueja(bool startComplaint)
        {
            List<Quejas> QuejaRespondida = new List<Quejas>();
            Residente residenteNO = new Residente();
                Console.Write("\nSeleccione el No. de la queja: ");
                short numero = short.Parse(Console.ReadLine());

                AgregarQuejasRespondidas(QuejaRespondida, numero);

                if (RespuestaValida == true)
                {
                    Console.WriteLine("No. Queja \t|Asunto \t|Descripcion \t\t|Respondida\t");
                    foreach (Residente residente in QuejaRespondida)
                    {
                        Console.WriteLine($"{residente.NumeroQueja}\t|{residente.Asunto}\t|{residente.Descripcion}\t\t|{residente.RespondidaYN}\t");

                        residente.Respondida = true;
                        Console.Write("\nInserte su respuesta: ");
                        string resp = Console.ReadLine();
                        resp = residente.Respuesta;
                    }

                    Console.ReadKey();

                    Console.WriteLine($"\nQueja No.{numero} respondida!");

                }
                else
                {
                    Console.WriteLine("Inserte un numero valido");
                   
                    startComplaint = true;
                }
            
            Console.ReadKey();
            
        }
        public static void AgregarQuejasRespondidas(List<Quejas> queja, short numero)
        {

            foreach (Residente residente in ListaQuejas)
            {
                
                if (residente.NumeroQueja == numero)
                {
                    queja.Add(residente);
                }
                RespuestaValida = true;

            }
        }

        public static void EliminarQueja()
        {
            Console.Write("\nInserte el No. de Queja que desea eliminar: ");
            seleccion = int.Parse(Console.ReadLine());


            int eliminado = ListaQuejas.RemoveAll(BuscarQueja);
            if (eliminado > 0)
            {
                Console.WriteLine($"\nLa queja No.{seleccion} ha sido eliminado");
            }
            else
            {
                Console.WriteLine("Ese No. de queja no existe");
            }
            Console.ReadKey();
        }
        public static bool BuscarQueja(Quejas queja)
        {
            if (queja.NumeroQueja == seleccion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}
