using System;
using System.Collections.Generic;
using System.Text;

namespace GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    interface ITemelKisiBilgi
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        string EPosta { get; set; }
        string Sifre { get; set; }
    }
}
