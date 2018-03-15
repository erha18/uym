using System;
using Microsoft.AspNetCore.Mvc;
using SuretVarlik.Genel.Enum.Ortak;
using Web.Models.Kayit;
using WebBirim.GenelIslem.Basic.Uye;
using WebBirim.GenelIslem.Sistem;

namespace Web.Controllers
{
    public class UyeController
        : OrtakController
    {
        private KayitOlModel _kom;
        private bool _disposed { get; set; }


        public IActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UyeOl(KayitOlModel _kom)
        {
            if (ModelState.IsValid)
            {
                _kom = OyleBirKisiVarMi(_kom);

                if (ModelState.IsValid)
                {
                    _kom = IslemBosAlanlariDoldur(_kom);

                    if (ModelState.IsValid)
                    {
                        if (KisiKaydet(_kom))
                        {
                            ViewBag.Script = "$(function () {$('#exampleModal').modal('show');});";
                            ViewBag.Sonuc = "<div class='modal fade' id='exampleModal' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'>"
                                            + "<div class='modal-dialog' role='document'>"
                                                + "<div class='modal-content'>"
                                                    + "<div class='modal-header'>"
                                                        + "<h5 class='modal-title' id='exampleModalLabel'>Kayıt Başarılı</h5>"
                                                            + "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>"
                                                                + "<span aria-hidden='true'>&times;</span>"
                                                            + "</button>"
                                                    + "</div>"
                                                    + "<div class='modal-body'> Başarılı bir şekilde kayıt oldunuz. Telefonunuza gelen doğrulama kodu ile üye girişi yapabilirsiniz. </div>"
                                                    + "<div class='modal-footer'>"
                                                        + "<a href='javascript:base.GeriGit();' class='btn btn-secondary'>Geri Git</a>"
                                                        + "<a href='javascript:base.AnaSayfaGit();' class='btn btn-primary'>Ana Sayfa</a>"
                                                    + "</div>"
                                                + "</div>"
                                            + "</div>"
                                         + "</div>";
                        }
                        else
                        {
                            ViewBag.Script = "$(function () {$('#exampleModal').modal('show');});";
                            ViewBag.Sonuc = "<div class='modal fade' id='exampleModal' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'>"
                                            + "<div class='modal-dialog' role='document'>"
                                                + "<div class='modal-content'>"
                                                    + "<div class='modal-header'>"
                                                        + "<h5 class='modal-title' id='exampleModalLabel'>Kayıt Başarısız</h5>"
                                                            + "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>"
                                                                + "<span aria-hidden='true'>&times;</span>"
                                                            + "</button>"
                                                    + "</div>"
                                                    + "<div class='modal-body'> Sistem servis dışı.. Lütfen daha sonra tekrar deneyiniz. </div>"
                                                    + "<div class='modal-footer'>"
                                                        + "<a href='javascript:base.GeriGit();' class='btn btn-secondary'>Geri Git</a>"
                                                        + "<a href='javascript:base.AnaSayfaGit();' class='btn btn-primary'>Ana Sayfa</a>"
                                                    + "</div>"
                                                + "</div>"
                                            + "</div>"
                                         + "</div>";
                        }

                        return View("MesajVer");
                    }
                }
            }

            return View(_kom);
        }

        private bool KisiKaydet(KayitOlModel _kom)
        {
            throw new NotImplementedException();
        }

        private KayitOlModel OyleBirKisiVarMi(KayitOlModel _kom)
        {
            using (UyeKayitIslem uk = new UyeKayitIslem())
            {
                switch (uk.EPostaVarMi(_kom.email))
                {
                    case VarYok.Yok:
                        break;
                    case VarYok.Var:
                        ModelState.AddModelError("", "Bu EPosta adresi alınmış. Başka bir tane deneyin..");
                        break;
                    default:
                        throw new ApplicationException("Kayıt olurken deger gelmedi");
                }
            }

            return _kom;
        }

        private KayitOlModel IslemBosAlanlariDoldur(KayitOlModel _kom)
        {
            using (HazirSistemIslem sis = new HazirSistemIslem())
            {
                _kom.KayitTarihi = sis.TarihGetir();

                _kom.MacAdr = sis.MacAdresGetir();

                _kom.IpAdr = sis.IpAdrGetir();
            }

            return _kom;
        }

        public IActionResult Kayit()
        {
            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }
        public IActionResult OrnekForm()
        {
            return View();
        }
        public IActionResult UyeGiris()
        {
            return View();
        }
        public IActionResult SifremiUnuttum()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _kom != null) _kom.Dispose();

            if (!_disposed) _disposed = true;

            base.Dispose(disposing);
        }
    }

}