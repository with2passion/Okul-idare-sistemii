using Microsoft.AspNetCore.Mvc;
using OkulProje.data;
using OkulProje.Models;
using System.Diagnostics;

namespace OkulProje.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly ILogger<OgrenciController> _logger;
        private OkulDBContext _okulDBContext;

        public OgrenciController(ILogger<OgrenciController> logger, OkulDBContext okulDBContext)
        {
            _logger = logger;
            _okulDBContext = okulDBContext;
        }

        public IActionResult Index()
        {
            OgrenciModel ogrenciModel = new OgrenciModel();
            ogrenciModel.OgrenciList = new List<Ogrenci>();
            var data = _okulDBContext.OgrenciTabs.ToList();
            foreach (var item in data)
            {
                ogrenciModel.OgrenciList.Add(new Ogrenci
                {
                    Id = item.Id,
                    AdSoyad = item.AdSoyad,
                    KayitTarih = item.KayitTarih,
                    OgrenciNo = item.OgrenciNo,
                    Dtarih = item.Dtarih,
                    Bolum = item.Bolum

                });
            }

            return View(ogrenciModel);
        }

        [HttpGet]
        public IActionResult Kaydet()
        {
            Ogrenci ogrenci = new Ogrenci();
            return View(ogrenci);
        }
        [HttpPost]
        public IActionResult Kaydet(Ogrenci ogrenci)
        {
            try
            {
                var ogrenciveri = new OgrenciTab()
                {
                    Id = ogrenci.Id,
                    AdSoyad = ogrenci.AdSoyad,
                    KayitTarih = ogrenci.KayitTarih,
                    OgrenciNo = ogrenci.OgrenciNo,
                    Dtarih = ogrenci.Dtarih,
                    Bolum = ogrenci.Bolum
                };
                _okulDBContext.OgrenciTabs.Add(ogrenciveri);
                _okulDBContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            }
            catch (Exception ex)
            {
                TempData["SaveStatus"] = 0;
            }
            return RedirectToAction("Index", "Ogrenci");
        }
        [HttpGet]
        public IActionResult Guncelle(int Id = 0)
        {
            Ogrenci ogrenci = new Ogrenci();
            var data = _okulDBContext.OgrenciTabs.Where(m => m.Id == Id).FirstOrDefault();
            if (data != null)
            {
                ogrenci.Id = data.Id;
                ogrenci.AdSoyad = data.AdSoyad;
                ogrenci.KayitTarih = data.KayitTarih;
                ogrenci.OgrenciNo = data.OgrenciNo;
                ogrenci.Dtarih = data.Dtarih;
                ogrenci.Bolum = data.Bolum;
            }
            return View(ogrenci);
        }
        [HttpPost]
        public IActionResult Guncelle(Ogrenci ogrenci)
        {
            try
            {
                var data = _okulDBContext.OgrenciTabs.Where(m => m.Id == ogrenci.Id).FirstOrDefault();
                data.AdSoyad = ogrenci.AdSoyad;
                data.KayitTarih = ogrenci.KayitTarih;
                data.OgrenciNo = ogrenci.OgrenciNo;
                data.Dtarih = ogrenci.Dtarih;
                data.Bolum = ogrenci.Bolum;
                _okulDBContext.SaveChanges();
                TempData["UpdateStatus"] = 1;
            }
            catch
            {
                TempData["UpdateStatus"] = 0;
            }
            return RedirectToAction("Index", "Ogrenci");
        }
        [HttpGet]
        public IActionResult Sil(int Id = 0)
        {
            try
            {
                var data = _okulDBContext.OgrenciTabs.Where(m => m.Id == Id).FirstOrDefault();
                if (data != null)
                {
                    _okulDBContext.OgrenciTabs.Remove(data);
                    _okulDBContext.SaveChanges();
                }
                TempData["DeleteStatus"] = 1;

            }
            catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "Ogrenci");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}