using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Residencial
    {
        private string sector;
        private TipoResidencia tipoResidencia;
        private string seguridad;
        private int cantidadResidentes;
        private int cantidadResidenciales;
        private int gastosMantenimiento;
        private double montoAPagar;

        private static List<Residente> listaResidentes;
        private List<Casa> listaCasas;
        private List<Edificio> listaEdificio;

        public Residencial()
        {
            listaResidentes = new List<Residente>();
            this.listaEdificio = new List<Edificio>();
            this.listaCasas = new List<Casa>();
        }

        public short cantidadApt { get; set; } // Cantidad de apartamentos
        public short cantidadCasas { get; set; } // Cantidad de casas
        public short cantidadAreaComun {get; set;} // Cantidad de areas comunes

        public static short cantidadSeguridad; // Contador para agregar seguridad


        // Gastos predeterminados //
        
        private int gMAreaComun = 1000; // Gasto de mantenimiento de cada area comun
        public int GMAReaComun { get; set; }

        private int gMApt = 4000; // Gasto de mantenimiento de cada apartamento
        public int GMApt { get; set; }

        private int gMCasa = 5300; // Gasto de mantenimiento de cada casa
        public int GMCasa { get; set; }

        private int gMSeg = 20000; // Gasto de mantenimiento de la seguridad 
        public int GMSeg { get; set; }



        public int CantidadResidenciales
        {
            get
            {
                return this.cantidadResidenciales;
            }
            set
            {
                this.cantidadResidenciales = value;
            }

        }
        public int GastosMantenimiento
        {
            get
            {
                int GMPAreaComun = cantidadAreaComun * gMAreaComun;
                int GMPCasa = cantidadCasas * gMCasa;
                int GMPApt = cantidadApt * gMApt;
                int GMPSeg = cantidadSeguridad * gMSeg;
                
                return GMPApt + GMPCasa + GMPAreaComun + GMPSeg;
            }
        }

       
        public string Sector
        {
            get
            {
                return this.sector;
            }
            set
            {
                this.sector = value;
            }
        }
        public TipoResidencia TipoResidencia
        {
            get
            {
                return this.tipoResidencia;
            }
            set
            {
                this.tipoResidencia = value;
            }
        }
        public string Seguridad
        {
            get
            {
                return this.seguridad;
            }
            set
            {
                this.seguridad = value;
            }

        }

        public int CantidadResidentes
        {
            get
            {
                return cantidadCasas + cantidadApt;
            }
        }
        public double MontoAPagar
        {
            get
            {
                return this.GastosMantenimiento / this.CantidadResidentes;
            }
        }

        public static TipoResidencia AgregarTipoResidencia(string tipo)
        {
            if (tipo == "casa" || tipo == "1")
            {
                return TipoResidencia.Casa;
            }
            else if (tipo == "edificio" || tipo == "2")
            {
                return TipoResidencia.Edificio;
            }
            else if (tipo == "variada" || tipo == "3")
            {
                return TipoResidencia.Variado;
            }
            else
            {
                Console.WriteLine("Tipo de residencia no valida");
                Console.ReadKey();

                return 0;
                
            }
        }

        public static void AgregarResidente(Residente residente)
        {
            listaResidentes.Add(residente);
        }

        public void RemoverResidente(Residente residente)
        {
            listaResidentes.Remove(residente);
        }

    }
}
