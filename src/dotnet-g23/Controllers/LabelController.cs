﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g23.Filters;
using dotnet_g23.Models;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.ViewModels.LabelViewModels;
using dotnet_g23.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class LabelController : Controller
    {
        #region Fields
        private readonly ICompanyRepository _companyRepository;
        #endregion

        #region Constructor
        public LabelController(ICompanyRepository compRepo) {
            _companyRepository = compRepo;
        }
        #endregion

        [Route("Companies")]
        public IActionResult Index(GUser user, String query = null)
        {
            // Show companies
            IndexViewModel vm = new IndexViewModel() {
                Companies = query == null ? _companyRepository.GetAll() : _companyRepository.GetByKeyword(query)
            };
            return View(vm);
        }

        [Route("Companies/{id}")]
        public IActionResult Show(Participant participant, int id)
        {
            // Show company contacts

            ShowViewModel vm = new ShowViewModel();

            vm.Company = _companyRepository.GetBy(id);
            vm.Contacts = vm.Company.Contacts;

            return View(vm);
        }

        [HttpPost]
        [Route("Companies/{id}")]
        public IActionResult Send(Participant participant, int id, int[] contactIds)
        {
            // Grant label to company

            Company company = _companyRepository.GetBy(id);
            company.Label = new Label(participant.Group, company);
            _companyRepository.SaveChanges();

            foreach (var cid in contactIds) {//TODO: loop var was 'var id'. Not sure if id below was parameter or loop var
                Contact contact = company.Contacts.First(co => co.ContactId == id);

                AuthMessageSender sender = new AuthMessageSender();
                sender.SendEmailAsync(contact.FirstName + " " + contact.LastName, contact.Email, contact.Company.Name, contact.Company.Description);

            }
            return RedirectToAction("Index", "Labels");
        }

    }
}
