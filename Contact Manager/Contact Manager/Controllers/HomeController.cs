using Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.IO;
using Contact_Manager.Repositories;
using Contact_Manager.Service;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileUpload _fileUpload;
        private readonly IContactService _contactService;
        private readonly IInfoTable _infoTable;
        ApplicationContext _context;
       
       

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IFileUpload fileUpload, IContactService contactService,IInfoTable infoTable)
        {
            _context = context;
            _logger = logger;
            _contactService = contactService;
            _fileUpload = fileUpload;
            _infoTable = infoTable;
        }

        public IActionResult Index()
        {
           


            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                ContactManager contact = await _context.FileUpload.FirstOrDefaultAsync(keyid => keyid.Id.ToString() == id);
                    
                if (contact != null)
                {
                    _context.FileUpload.Remove(contact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Present");
                }
            }
            return NotFound();
        }
        public IActionResult Present()
        {
            var infoout = _infoTable.GetInformation();
            return View(infoout);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                ContactManager contact = await _context.FileUpload.FirstOrDefaultAsync(p => p.Id.ToString() == id);
                if (contact != null)
                    
                    return View(contact);
                    
                    
            }
            
            return NotFound();
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactManager contact)
        {
            _context.FileUpload.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Present");
        }
        [HttpPost]
        public IActionResult Create(IFormFile contact)
        {
            var contactManager = _contactService.CsvToModel(contact);
            
            foreach (var item in contactManager)
            {
                ContactManager result= new ContactManager { Name = item.Name, Dateofbirth = item.Dateofbirth, Married = item.Married, Phone = item.Phone, Salary = item.Salary };

                _context.FileUpload.Add(result);
                
            }
            _context.SaveChanges();

            
            return RedirectToAction("Present");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
