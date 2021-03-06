﻿using System.Collections.Generic;
using System.Linq;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.RepoInterFace;
using Microsoft.EntityFrameworkCore;

namespace CloudApp.RepositoriesClasses
{
    public class SampleOneRepostry : MainRepostry<Treatment>,ISampleOneRepostry
    {
        private readonly ApplicationDbContext _db;
    
        public SampleOneRepostry(ApplicationDbContext db ) : base(db)
        {
            _db = db;
        
        }

        public IEnumerable<AttachmentForTreament> GetTrementAttchment(long tremntid)
        {
          return  _db.AttachmentForTreaments.Where(treament => treament.TreatmentId == tremntid);
        }

        public IEnumerable<Treatment> GetTrementWithCustmerAndSample(long tremntid)
        {
            return _db.Treatment.Include(treatment => treatment.Custmer)
                .ThenInclude(custmer => custmer.Sample)
                .Where(treatment => treatment.Id == tremntid);
        }

        public Treatment GetTrementWithAttachmentFiles(long treamnetid)
        {
            return _db.Treatment.Include(treatment => treatment.AttachmentForTreaments).Include(treatment => treatment.Custmer)
                .SingleOrDefault(treatment => treatment.Id == treamnetid);
        }

        public IEnumerable<Treatment> GetTreamentWithSampleAndAppUserCms()
        {
            return _db.Treatment.Include(treatment => treatment.Custmer)
                .ThenInclude(custmer => custmer.Sample)
                .Include(treatment => treatment.ApplicationUser)
                .ToList();
        }
    }
}
