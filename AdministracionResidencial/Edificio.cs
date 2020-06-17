using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Edificio : Residente
    {
        private string apartamento;
        
        public string Apartamento
        {
            get
            {
                return this.apartamento;
            }
            set
            {
                this.apartamento = value;
            }
        }
    }
}
