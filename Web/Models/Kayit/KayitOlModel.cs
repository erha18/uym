﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Kayit
{
    public class KayitOlModel
        : IDisposable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Adınızı 3-30 karakter arasında girebilirsiniz.")]
        [MaxLength(30, ErrorMessage = "Adınızı max 30 karakter girebilirsiniz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Soyadınızı 3-30 karakter arasında girebilirsiniz.")]
        [MaxLength(30, ErrorMessage = "Soyadınızı max 30 karakter girebilirsiniz.")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresinizi geçerli bir formatta giriniz.")]
        [MaxLength(100, ErrorMessage = "E-Posta adresiniz max 100 karakter girebilirsiniz.")]
        [EmailAddress(ErrorMessage = "Lütfen  e-posta adresinizi geçerli bir formatta giriniz.")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen parolanızı giriniz.")]
        [StringLength(26, MinimumLength = 8, ErrorMessage = "Parolanızı 8-25 karakter arasında girebilirsiniz.")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen parolanızı tekrar giriniz.")]
        [Compare("password", ErrorMessage = "Parola veya parola tekrarı aynı giriniz.")]
        public string passwordre { get; set; }

        [KesinDogruDoner(ErrorMessage = "Kullanıcı Sözleşmemizi ve Gizlilik Politikamızı okuyup kabul etmeniz gerekiyor.")]
        public bool sonay { get; set; }

        public bool remember { get; set; }

        ~KayitOlModel()
        {
            Dispose(false);
        }

        private bool _disposed { get; set; }
        public string IpAdr { get; internal set; }
        public string MacAdr { get; internal set; }
        public DateTime KayitTarihi { get; internal set; }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {

            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
