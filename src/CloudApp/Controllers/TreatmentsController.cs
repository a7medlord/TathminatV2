using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.HelperClass;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class TreatmentsController : Controller
    {
        #region CtorVar
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;
        private readonly SampleOneServices _service;
        private readonly CustemerRepostry _cmsrepo;
     
        #endregion
        
        public TreatmentsController(ApplicationDbContext context , UserManager<ApplicationUser> user , IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
            _service = new SampleOneServices(context , new CustemerRepostry(context));
            _cmsrepo = new CustemerRepostry(_context);
         
        }
        
        public IActionResult GetSample0Report(long id)
        {

            byte[] rendervalue = _service.GetSample0ReportasStreem(id, HttpContext, _env);

            return File(rendervalue, "application/pdf");
        }
        
        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
                string guid = Guid.NewGuid().ToString();
                string filepath = "sample1attachment/" + guid + ".jpg";
                var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
                await Request.Form.Files[0].CopyToAsync(strem);
                strem.Close();
                strem.Dispose();
            return Json(guid);
        }

        public async Task<IActionResult> Create(int ids)
        {
            Custmer cms = _cmsrepo.GetbyId(ids);
            ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");
            ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen), "Value", "Value");
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = cms;
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");
            return View(new Treatment());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ]Treatment treatment , string ids)
        {
          
            if (ModelState.IsValid)
            {
                treatment.DateOfBegin = DateTime.Now.Date;
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] imgsids = ids.Split(';');
                    treatment.AttachmentForTreaments = new List<AttachmentForTreament>();
                    for (int i = 0; i < imgsids.Length - 1; i++)
                    {
                        treatment.AttachmentForTreaments.Add(new AttachmentForTreament() { AttachmentId = imgsids[i] });
                    }
                }
                if (treatment.IsAduit && User.IsInRole("au"))
                {
                    treatment.Adutit = _userManager.GetUserId(User);
                }
                if (treatment.IsApproved && User.IsInRole("apr"))
                {
                    treatment.Approver = _userManager.GetUserId(User);
                }
                if (treatment.IsIntered && User.IsInRole("en"))
                {
                    treatment.Intered = _userManager.GetUserId(User);
                } if (treatment.IsThmin && User.IsInRole("th"))
                {
                    treatment.Muthmen = _userManager.GetUserId(User);
                }
                _service.CreatNewTreamnt(treatment);
                
                return RedirectToAction("Edit", new {Id=treatment.Id});
            }
            await GetListBind(treatment.CustmerId);
            return View("Create",treatment);
        }

        async Task GetListBind(long cmsSelectId)
        {
            ViewData["CustmerId"] = new SelectList(_cmsrepo.Getall().ToList(), "Id", "Name", cmsSelectId);
            ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");
            ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen), "Value", "Value");
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForTreaments.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
        }
     
        public async Task<IActionResult> Edit(long id)
        {
            var treatment = _service.GetTrementWithAtTreatment(id);

            if (treatment == null)
            {
                return NotFound();
            }

            string files = "";
            foreach (AttachmentForTreament file in treatment.AttachmentForTreaments)
            {
                    files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;
           await GetListBind(treatment.CustmerId);
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = treatment.Custmer;
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");
            return View(treatment);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(long id, [Bind] Treatment treatment , string ids)
        {
            if (id != treatment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ids))
                    {
                        string[] imgsids = ids.Split(';');
                        treatment.AttachmentForTreaments = new List<AttachmentForTreament>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            treatment.AttachmentForTreaments.Add(new AttachmentForTreament() { AttachmentId = imgsids[i] });
                        }
                    }


                    if (treatment.IsAduit && User.IsInRole("au"))
                    {
                        treatment.Adutit = _userManager.GetUserId(User);
                    }
                    if (treatment.IsApproved && User.IsInRole("apr"))
                    {
                        treatment.Approver = _userManager.GetUserId(User);
                    }
                    if (treatment.IsIntered && User.IsInRole("en"))
                    {
                        treatment.Intered = _userManager.GetUserId(User);
                    }
                    if (treatment.IsThmin && User.IsInRole("th"))
                    {
                        treatment.Muthmen = _userManager.GetUserId(User);
                    }

                    _service.UpdateExistTreament(treatment);
                   
                    RedirectToAction("Index" , "MainSamples");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(treatment.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index" , "MainSamples");
            }
          await  GetListBind(treatment.CustmerId);
            return View(treatment);
        }
        
        //What is this ??? Single Respon
        public void EditAprove(long id)
        {
            var row = _service.GetTrementById(id);
            row.IsApproved = true;
            _service.UpdateExistTreament(row);
        }

        public void EditFin(long id,double partprice, long bankid ,DateTime date , bool close)
        {
            var row = _service.GetTrementById(id);
            row.FinPriceClose = partprice;
            row.BankModelId = bankid;
            row.FinDateClose = date;
            row.FinPartClose = close;
            _service.UpdateExistTreament(row);
           
        }


        
        private bool TreatmentExists(long id)
        {
            return _context.Treatment.Any(e => e.Id == id);

        }

       
    }
}
