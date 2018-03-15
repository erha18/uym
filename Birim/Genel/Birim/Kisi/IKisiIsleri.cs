using System;
using System.Collections.Generic;
using System.Text;
using SuretVarlik.Genel.Enum.Ortak;
using SuretVarlik.Genel.Suret.Kisi;

namespace Birim.Genel.Birim.Kisi
{
    public interface IKisiIsleri
              : IDisposable
    {
        VarYok EPostaVarMi(string email);
    }
}
