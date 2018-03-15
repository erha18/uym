using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using SuretVarlik.Genel.Enum.Ortak;
using SuretVarlik.Genel.Suret.Kisi;
using System;
using System.Collections.Generic;
using Veri.Kaynak;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Birim.Genel.Birim.Kisi
{
    public class KisiIsleri
          : IKisiIsleri
    {
        private bool disposed { get; set; }

        ~KisiIsleri()
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

        public static IKisiIsleri OrnekVer()
        {
            return new KisiIsleri();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public VarYok EPostaVarMi(string email)
        {
            bool islemIptalMi = new bool();

            VarYok donenDeger = new VarYok();

            try
            {
                using (var vt = new YpmSebil())
                using (var islem = vt.Database.BeginTransaction())
                {
                    try
                    {

                        var miBiri = vt.KisiTbl.Where(x => x.EPosta == email).FirstOrDefault();

                        if (miBiri != null) donenDeger = VarYok.Var;
                        else donenDeger = VarYok.Yok;
                    }
                    catch (Exception ex)
                    {
                        islemIptalMi = true;
                    }
                    finally
                    {
                        if (islemIptalMi) islem.Rollback();
                        else islem.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                islemIptalMi = true;
            }

            return donenDeger;
        }

    }
}
