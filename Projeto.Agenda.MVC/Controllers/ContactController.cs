using AutoMapper;
using Projeto.Agenda.Application.Interface;
using Projeto.Agenda.Domain.Entities;
using Projeto.Agenda.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Projeto.Agenda.MVC.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactAppService _contactApp;
        private readonly IClassificationAppService _classificationApp;
        private readonly IAddressAppService _addressApp;
        private readonly IPhoneAppService _phoneApp;


        public ContactController(IContactAppService contactApp, IClassificationAppService classificationApp, IAddressAppService addressApp, IPhoneAppService phoneApp)
        {
            _contactApp = contactApp;
            _classificationApp = classificationApp;
            _addressApp = addressApp;
            _phoneApp = phoneApp;

        }

        // GET: Contact
        public ActionResult Index()
        {

            var contactViewModel = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(_contactApp.GetAll());
            return View(contactViewModel);

        }

        // GET: Contact/Details/5
        public ActionResult Details(Guid id)
        {
            ViewBag.Classification = new SelectList(_classificationApp.GetAll(), "Id", "Description");

            var contact = _contactApp.GetById(id);

            var phones = _phoneApp.GetPhoneByIdContact(id);

            foreach (var ph in phones)
                ph.Classification = _classificationApp.GetById(ph.ClassificationId);



            if (phones.Any())
                contact.Phone = phones;

            var address = _addressApp.GetById(id);
            if (address != null)
                contact.Address = address;


            var contactViewModel = Mapper.Map<Contact, ContactViewModel>(contact);


            return View(contactViewModel);

        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.Classification = new SelectList(_classificationApp.GetAll(), "Id", "Description");

            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public JsonResult Create(ContactViewModel objContact)
        {
            try
            {

                var contact = Mapper.Map<ContactViewModel, Contact>(objContact);
                _contactApp.Add(contact);

                return Json(new { success = true, responseText = "Salvo com sucesso." }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Classification = new SelectList(_classificationApp.GetAll(), "Id", "Description");

            var contact = _contactApp.GetById(id);

            var phones = _phoneApp.GetPhoneByIdContact(id);

            foreach (var ph in phones)
                ph.Classification = _classificationApp.GetById(ph.ClassificationId);



            if (phones.Any())
                contact.Phone = phones;

            var address = _addressApp.GetById(id);
            if (address != null)
                contact.Address = address;


            var contactViewModel = Mapper.Map<Contact, ContactViewModel>(contact);


            return View(contactViewModel);
        }

        //POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactViewModel objContact)
        {
            try
            {
                #region Address
                var address = _addressApp.GetAddressByIdContact(objContact.Id);

                if (address == null && objContact.Address != null)
                {
                    var objAddress = new AddressViewModel()
                    {
                        Id = objContact.Id,
                        StreetAddress = objContact.Address.StreetAddress,
                        City = objContact.Address.City,
                        State = objContact.Address.State,
                        PostalCode = objContact.Address.PostalCode
                    };

                    var addressDomain = Mapper.Map<AddressViewModel, Address>(objAddress);
                    _addressApp.Add(addressDomain);
                };
                #endregion


                var phones = _phoneApp.GetPhoneByIdContact(objContact.Id);

                foreach (var ph in phones)
                    _phoneApp.Remove(ph);

                

                foreach (var item in objContact.Phone)
                {
                    var PhoneViewModel = new PhoneViewModel()
                    {
                        ContactId = objContact.Id,
                        ClassificationId = item.ClassificationId,
                        Number = item.Number
                    };

                    var phoneDomain = Mapper.Map<PhoneViewModel, Phone>(PhoneViewModel);
                    _phoneApp.Add(phoneDomain);
                                       
                }                

                var contactDomain = Mapper.Map<ContactViewModel, Contact>(objContact);
                _contactApp.Update(contactDomain);

                return Json(new { success = true, responseText = "Alterado com sucesso." }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        public ActionResult Delete(Guid id)
        {
            try
            {
                var contact = _contactApp.GetById(id);

                var address = _addressApp.GetById(contact.Id);
                if (address != null)
                    _addressApp.Remove(address);

                var phones = _phoneApp.GetPhoneByIdContact(contact.Id);

                foreach (var ph in phones)
                    _phoneApp.Remove(ph);

                _contactApp.Remove(contact);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // GET: Contact/List
        public ActionResult List()
        {
            try
            {
                var lstAuxContact = new List<Contact>();

                var lstContact = _contactApp.GetAll();

                foreach (var contact in lstContact)
                {
                    var phones = _phoneApp.GetPhoneByIdContact(contact.Id);

                    foreach (var ph in phones)
                        ph.Classification = _classificationApp.GetById(ph.ClassificationId);

                    if (phones != null)
                        contact.Phone = phones;


                    var address = _addressApp.GetById(contact.Id);
                    if (address != null)
                        contact.Address = address;


                    lstAuxContact.Add(contact);
                }

                var contactViewModel = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(lstAuxContact);

                return View(contactViewModel);
            }
            catch
            {

                return View();
            }

        }
    }
}
