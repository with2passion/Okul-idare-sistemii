using Microsoft.AspNetCore.Mvc;
using OkulProje.data;
using OkulProje.Models;
using System.Diagnostics;

namespace OkulProje.Controllers
{
    public class DersController : Controller
    {
        private readonly ILogger<DersController> _logger;
        private OkulDBContext _okulDBContext;

        public DersController(ILogger<DersController> logger, OkulDBContext okulDBContext)
        {
            _logger = logger;
            _okulDBContext = okulDBContext;
        }

        public IActionResult Index()
        {
            DersModel dersModel = new DersModel();
            dersModel.DersList = new List<Ders>();
            var data = _okulDBContext.DersTabs.ToList();
            foreach (var item in data)
            {
                dersModel.DersList.Add(new Ders
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Kredi = item.Kredi,
                    OkulYonetimId = item.OkulYonetimId
                });
            }

            return View(dersModel);
        }

        [HttpGet]
        public IActionResult Kaydet()
        {
            Ders ders = new Ders();
            return View(ders);
        }
        [HttpPost]
        public IActionResult Kaydet(Ders ders)
        {
            try
            {
                var dersVeri = new DersTab()
                {
                    Id = ders.Id,
                    Ad = ders.Ad,
                    Kredi = ders.Kredi,
                    OkulYonetimId = ders.OkulYonetimId

                };
                _okulDBContext.DersTabs.Add(dersVeri);
                _okulDBContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            }
            catch (Exception ex)
            {
                TempData["SaveStatus"] = 0;
            }
            return RedirectToAction("Index", "Ders");
        }
        [HttpGet]
        public IActionResult Guncelle(int Id = 0)
        {
            Ders ders = new Ders();
            var data = _okulDBContext.DersTabs.Where(m => m.Id == Id).FirstOrDefault();
            if (data != null)
            {
                ders.Id = data.Id;
                ders.Ad = data.Ad;
                ders.Kredi = data.Kredi;
                ders.OkulYonetimId = data.OkulYonetimId;
            }
            return View(ders);
        }
        [HttpPost]
        public IActionResult Guncelle(Ders ders)
        {
            try
            {
                var data = _okulDBContext.DersTabs.Where(m => m.Id == ders.Id).FirstOrDefault();
                ders.Ad = ders.Ad;
                ders.Kredi = ders.Kredi;
                data.OkulYonetimId = ders.OkulYonetimId;

                _okulDBContext.SaveChanges();
                TempData["UpdateStatus"] = 1;
            }
            catch
            {
                TempData["UpdateStatus"] = 0;
            }
            return RedirectToAction("Index", "Ders");
        }
        [HttpGet]
        public IActionResult Sil(int Id = 0)
        {
            try
            {
                var data = _okulDBContext.DersTabs.Where(m => m.Id == Id).FirstOrDefault();
                if (data != null)
                {
                    _okulDBContext.DersTabs.Remove(data);
                    _okulDBContext.SaveChanges();
                }
                TempData["DeleteStatus"] = 1;

            }
            catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "Ders");
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