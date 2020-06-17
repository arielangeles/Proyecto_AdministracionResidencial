using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Pagos
    {
        private TipoGastoPago tipoPago;
        
        public TipoGastoPago Tipo
        {
            get
            {
                return this.tipoPago;
            }
            set
            {
                this.tipoPago = value;
            }

        }

        
    }
}
