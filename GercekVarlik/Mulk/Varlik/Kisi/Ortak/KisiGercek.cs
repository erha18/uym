﻿using GercekVarlik.Mulk.Varlik.Ortak;

namespace GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    public class KisiGercek
        : AbsOrtakVarlik, ITemelKisiBilgi
    {
        public override int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
    }
}
