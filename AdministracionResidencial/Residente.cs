using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public class Residente : Quejas
    {
        private string nombre;
        private string numeroCasaApt;
        private string calle;
        private TipoResidente tipo;
        private double montoAPagar; //Monto a pagar de cada residente 

        public string Nombre {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }

        }
        public string NumeroCasaApt
        {
            get
            {
                return this.numeroCasaApt;
            }
            set
            {
                this.numeroCasaApt = value;
            }

        }
        public string Calle
        {
            get
            {
                return this.calle;
            }
            set
            {
                this.calle = value;
            }
        }
        public TipoResidente Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

       
    }
}
