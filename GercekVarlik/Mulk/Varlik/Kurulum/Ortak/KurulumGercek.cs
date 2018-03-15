using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using System.Collections.Generic;
using System.Text;

namespace GercekVarlik.Mulk.Varlik.Kurulum.Ortak
{
    public class KurulumGercek
        : AbsOrtakVarlik
    {
        public override int Id { get; set; }

        public string Tip { get; set; }

        public string Ad { get; set; }

        public bool Sonuc { get; set; }
    }
}
