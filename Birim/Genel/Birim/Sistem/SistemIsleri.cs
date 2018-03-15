using System;
using System.Collections.Generic;
using System.Text;

namespace Birim.Genel.Birim.Sistem
{
    public class SistemIsleri
            : ISistemIsleri
    {
        public static ISistemIsleri OrnekVer()
        {
            return new SistemIsleri();
        }

        private bool disposed { get; set; }

        ~SistemIsleri()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                //if (_ornek != null) _ornek = null;

            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DateTime TarihGetir()
        {
            throw new NotImplementedException();
        }

        public string MacAdresGetir()
        {
            throw new NotImplementedException();
        }

        public string IpAdrGetir()
        {
            throw new NotImplementedException();
        }
    }
}
