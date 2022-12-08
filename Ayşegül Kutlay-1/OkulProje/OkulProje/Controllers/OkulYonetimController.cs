using Microsoft.AspNetCore.Mvc;
using OkulProje.data;
using OkulProje.Models;
using System.Diagnostics;

namespace OkulProje.Controllers
{
    public class OkulYonetimController : Controller
    {
        private readonly ILogger<OkulYonetimController> _logger;
        private OkulDBContext _okulDBContext;

        public OkulYonetimController(ILogger<OkulYonetimController> logger, OkulDBContext okulDBContext)
        {
            _logger = logger;
            _okulDBContext = okulDBContext;
        }

        public IActionResult Index()
        {
            OkulYonetimModel okulYonetimModel = new OkulYonetimModel();
            okulYonetimModel.OkulYonetimList = new List<OkulYonetim>();
            var data = _okulDBContext.OkulYonetimTabs.ToList();
            foreach (var item in data)
            {
                okulYonetimModel.OkulYonetimList.Add(new OkulYonetim
                {
                    Id = item.Id,
                    AdSoyad = item.AdSoyad,
                    Gorevi = item.Gorevi,
                    YonetimTip= item.YonetimTip
                });
            }

            return View(okulYonetimModel);
        }

        [HttpGet]
        public IActionResult Kaydet()
        {
            OkulYonetim okulYonetim = new OkulYonetim();
            return View(okulYonetim);
        }
        [HttpPost]
        public IActionResult Kaydet(OkulYonetim okulYonetim)
        {
            try
            {
                var okulYonetimVeri = new OkulYonetimTab()
                {
                    Id = okulYonetim.Id,
                    AdSoyad = okulYonetim.AdSoyad,
                    Gorevi = okulYonetim.Gorevi,
                    YonetimTip = okulYonetim.YonetimTip
                    
                };
                _okulDBContext.OkulYonetimTabs.Add(okulYonetimVeri);
                _okulDBContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            }
            catch (Exception ex)
            {
                TempData["SaveStatus"] = 0;
            }
            return RedirectToAction("Index", "OkulYonetim");
        }
        [HttpGet]
        public IActionResult Guncelle(int Id = 0)
        {
            OkulYonetim okulYonetim = new OkulYonetim();
            var data = _okulDBContext.OkulYonetimTabs.Where(m => m.Id == Id).FirstOrDefault();
            if (data != null)
            {
                okulYonetim.Id = data.Id;
                okulYonetim.AdSoyad = data.AdSoyad;
                okulYonetim.Gorevi = data.Gorevi;
                okulYonetim.YonetimTip= data.YonetimTip;
            }
            return View(okulYonetim);
        }
        [HttpPost]
        public IActionResult Guncelle(OkulYonetim okulYonetim)
        {
            try
            {
                var data = _okulDBContext.OkulYonetimTabs.Where(m => m.Id == okulYonetim.Id).FirstOrDefault();
                data.AdSoyad = okulYonetim.AdSoyad;
                data.Gorevi = okulYonetim.Gorevi;
                data.YonetimTip = okulYonetim.YonetimTip;
                
                _okulDBContext.SaveChanges();
                TempData["UpdateStatus"] = 1;
            }
            catch
            {
                TempData["UpdateStatus"] = 0;
            }
            return RedirectToAction("Index", "OkulYonetim");
        }
        [HttpGet]
        public IActionResult Sil(int Id = 0)
        {
            try
            {
                var data = _okulDBContext.OkulYonetimTabs.Where(m => m.Id == Id).FirstOrDefault();
                if (data != null)
                {
                    _okulDBContext.OkulYonetimTabs.Remove(data);
                    _okulDBContext.SaveChanges();
                }
                TempData["DeleteStatus"] = 1;

            }
            catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "OkulYonetim");
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