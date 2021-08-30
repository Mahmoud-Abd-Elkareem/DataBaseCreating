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
    public class UserController : Controller
    {
        IGenric<User> sd;
        IGenric<Adress> ad;

        public UserController(IGenric<User> _sd , IGenric<Adress> _ad)
        {
            sd = _sd;
            ad = _ad;
        }
        public IActionResult Index()
        {
            var Adress = new List<Adress>(ad.GetAll());
            ViewBag.Adresses = Adress;
            return View(sd.GetAll());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            UserAdressViewModels useradress = new UserAdressViewModels();
            return View(useradress);
        }
        public IActionResult Details(int id)
        {
            List<Adress> add = ad.GetAll().Where(a => a.UserID == id).ToList<Adress>();
            ViewBag.Adresses = add;
            return View(sd.GetById(id));
        }
        [HttpPost]
        public IActionResult Insert(UserAdressViewModels useradress)
        {
            if (!ModelState.IsValid)
            {
                return View(useradress);
            }
                User objuser = new User
            {
                Name = useradress.Name,
                PhoneNumber = useradress.PhoneNumber,
                Email = useradress.Email,
                Information = useradress.Information,
            };
            sd.Insert(null, objuser);
                useradress.ID = objuser.ID;
            var objadress = new List<Adress>()
            {
                new Adress()
                {
                Street = useradress.Street,
                District = useradress.District,
                City = useradress.City,
                UserID = useradress.ID,
                } ,
                new Adress()
                {
                Street = useradress.Street2,
                District = useradress.District2,
                City = useradress.City2,
                UserID = useradress.ID,
                }
            };
             ad.Insert(objadress , null);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            User us = sd.GetById(id);
            List<Adress> add = ad.GetAll().Where(a=>a.UserID==id).ToList(); 
            UserAdressViewModels useradress = new UserAdressViewModels();
            useradress.ID = us.ID;
            useradress.Name = us.Name;
            useradress.Email = us.Email;
            useradress.PhoneNumber = us.PhoneNumber;
            useradress.Information = us.Information;
            foreach(var address in add)
            {
                useradress.City = address.City;
                useradress.Street = address.Street;
                useradress.District = address.District;
            }

            return View();
        }
        [HttpPost]
        public IActionResult Update(UserAdressViewModels useradress)
        {
            if (!ModelState.IsValid)
            {
                return View(useradress);
            }

            User objuser = sd.GetById(useradress.ID);
            objuser.Name = useradress.Name;
            objuser.PhoneNumber = useradress.PhoneNumber;
            objuser.Email = useradress.Email;
            objuser.Information = useradress.Information;
            sd.Update(null ,objuser);
            useradress.ID = objuser.ID;
            Adress[] addlist = ad.GetAll().Where(a => a.UserID == objuser.ID).ToArray();
            addlist[0].UserID = useradress.ID;
            addlist[0].Street = useradress.Street;
            addlist[0].District = useradress.District;
            addlist[0].City = useradress.City;
            addlist[1].UserID = useradress.ID;
            addlist[1].Street = useradress.Street2;
            addlist[1].District = useradress.District2;
            addlist[1].City = useradress.City2;
            ad.Update(addlist, null);
            return RedirectToAction("Index");
        }
    }
}
