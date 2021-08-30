using EchoLinkDataModel.Models;
using EchoLinkDataModel.Services;
using EchoLinkDataModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLinkDataModel.Controllers
{
    public class AdressController : Controller
    {
        IGenric<User> sd;
        IGenric<Adress> ad;

        public AdressController(IGenric<User> _sd, IGenric<Adress> _ad)
        {
            sd = _sd;
            ad = _ad;
        }
        public IActionResult Index()
        {
            var user = new SelectList(sd.GetAll(),"Name");
            ViewBag.user = user;
            return View(ad.GetAll());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var user = new SelectList(sd.GetAll(),"ID", "Name");
            ViewBag.user = user;
            return View();
        }
        public IActionResult Details(int id)
        {
            var user = new SelectList(sd.GetAll(), "Name");
            ViewBag.user = user;
            return View(ad.GetById(id));
        }
        [HttpPost]
        public IActionResult Insert(UserAdressViewModels useradress)
        {
                Adress objadress = new Adress
                {
                    Street = useradress.Street,
                    District = useradress.District,
                    City = useradress.City,
                    UserID = useradress.ID
                };
                ad.Insert(null, objadress);

                return RedirectToAction("index");
        }
            
    }
}
