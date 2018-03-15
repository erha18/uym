using Birim.Genel.Birim.Kisi;
using SuretVarlik.Genel.Enum.Ortak;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBirim.GenelIslem.Basic.Uye
{
    public class UyeKayitIslem
        : IDisposable
    {
        private static readonly IKisiIsleri _kisi = KisiIsleri.OrnekVer();

        public bool _disposed { get; private set; }


        ~UyeKayitIslem()
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

        public VarYok EPostaVarMi(string email)
        {
            return _kisi.EPostaVarMi(email);
        }
    }
}
