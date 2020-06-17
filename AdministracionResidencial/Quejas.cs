using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public class Quejas
    {
        private string asunto;
        private string descripcion;
        private bool respondida;
        private string respondidaYN;
        private short numeroQueja;
        private string respuesta;
        
        
        public Quejas()
        {

        } 
  
        public string Asunto
        {
            get
            {
                return this.asunto;
            }
            set
            {
                this.asunto = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public bool Respondida
        {
            get
            {
                return this.respondida;
                
            }
            set
            {
                this.respondida = value;
            }
        }
        public string RespondidaYN
        {
            get
            {
                if (this.respondida == true)
                {
                    return "Si";
                }
                else return "No";
            }
        }

        public short NumeroQueja
        {
            get
            {
                return this.numeroQueja;
            }
            set
            {
                this.numeroQueja = value;
            }
        }

        public string Respuesta
        {
            get
            {
                return this.respuesta;
            }
            set
            {
                this.respuesta = value;
            }
        }
    }
}
