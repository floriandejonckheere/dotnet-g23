﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
	public class GroupManageController : Controller
	{

		#region Fields
		//private User _user;
		private readonly IUserRepository _userRepository;
		private readonly IOrganizationRepository _orgRepository;
		#endregion

		#region Constructors
		public GroupManageController(IUserRepository userRepository, IOrganizationRepository orgRepository) {
			_userRepository = userRepository;
			_orgRepository = orgRepository;

			//_user = _userRepository.GetAll().First();
		}
		#endregion

		#region Methods
		//[Route("groups")]
		public IActionResult Index()
		{

            // show list of open groups
            /*IEnumerable<Organization> orgList = _orgRepository.GetAll().Where(o => o.OrganizationRole.ToString() == "Organization").Cast<Organization>();

			Group[] list = {};

			foreach (Organization org in orgList)
				foreach (Group group in org.Groups)
					if (!group.IsClosed())
						list[list.Length-1] = group;

			return View(list);
            */
            return View();


        }

		//[HttpPost]
		//[Route("groups/register")]
		public IActionResult Register(string name) {
			// find group, check if user isn't registered and register user with group

			//Group group = _groupRepo.GetByName(name);
			//group.Participants.Add(_user);

			//if (_user.Group != null)
			//{
				//ViewData["Message"] = "Error: already registered";
				//return View();
			//}


			// redirect to group detail
			return RedirectToAction("Index", "Manage");
		}

		//[HttpPost]
		//[Route("groups/create")]
		public IActionResult Create(string name = null, bool closed = false)
		{
			// validate name, make new group and register user

			if (name == null)
			{
				ViewData["Message"] = "Error: Wrong name";
				return View();
			}

			// check if groupname unique and not empty
			//Organization org = _user.Group.Organization;
			//Group group = org.CreateGroup(name);
			//group.Participants.Add(_user);

			// notify lector
			//_user.Lector.Notify();
			return View();
		}

		//[HttpPost]
		//[Route("groups/invite")]
		public IActionResult Invite(string[] addresses = null)
		{

			if (addresses != null)
			{
				foreach (string address in addresses)
				{
					if (MailHelper.VerifyMailAddress(address))
					{
						// invite mail address
					}
				}
			}

			// notify lector
			//_user.Lector.Notify();
			return View();
		}
		#endregion

	}
}