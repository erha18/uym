using System;
using System.Collections.Generic;
using System.Text;
using Birim.Genel.Birim.Sistem;

namespace WebBirim.GenelIslem.Sistem
{
    public class HazirSistemIslem
        : IDisposable
    {
        private static readonly ISistemIsleri _sistem = SistemIsleri.OrnekVer();

        public bool _disposed { get; private set; }


        ~HazirSistemIslem()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {

            }
            _disposed = true;

        }


        public DateTime TarihGetir()
        {
            return _sistem.TarihGetir();
        }

        public string MacAdresGetir()
        {
            return _sistem.MacAdresGetir();
        }

        public string IpAdrGetir()
        {
            return _sistem.IpAdrGetir();
        }
    }
}
