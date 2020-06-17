using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Gastos 
    {

        private TipoGastoPago tipoGasto;
        private Pagos pago;

      

        public TipoGastoPago TipoGasto
        {
            get
            {
                return this.tipoGasto;
            }
            set
            {
                this.tipoGasto = value;
            }
        }
        public Pagos Pago
        {
            get
            {
                return this.pago;
            }
            set
            {
                this.pago = value;
            }
        }

    }
}
