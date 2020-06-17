using System;
using System.Collections.Generic;
using System.Text;

namespace AdmRes
{
    public sealed class Casa : Residente
    {
        private string casaRes;

        public string CasaRes
        {
            get
            {
                return this.casaRes;
            }
            set
            {
                this.casaRes = value;
            }
        }
    }
}
