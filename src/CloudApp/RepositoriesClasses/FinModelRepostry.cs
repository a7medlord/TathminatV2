using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Identity;

namespace CloudApp.RepositoriesClasses
{
    public class FinModelRepostry
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public FinModelRepostry(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _userManager = user;
        }

        public List<FinModel> GetInComeAndOutCome()
        {

            return null;
        }






    }
}
