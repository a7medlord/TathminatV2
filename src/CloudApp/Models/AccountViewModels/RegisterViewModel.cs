﻿using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "الايميل")]
        public string Email { get; set; }

       
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمه المرور")]
        [Compare("Password", ErrorMessage = "كلمات المرور غير متشابهة الرجاء التعديل")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "اسم الموظف")]
        public string EmployName { get; set; }
        [Display(Name = "رقم الهوية")]
        public string IdentityId { get; set; }
        [Display(Name = "رقم العضوية")]
        public string MemberId { get; set; }
        [Display(Name = "نسبة الادخال")]
        public double InterPercentage { get; set; }
        [Display(Name = "نسبة")]
        public bool IsInterPercentage { get; set; }

        [Display(Name = "نسبة التثمين")]
        public double MuthminPercentage { get; set; }
        [Display(Name = "نسبة ")]
        public bool IsMuthminPercentage { get; set; }

        [Display(Name = "نسبة التدقيق")]
        public double AduitPercentage { get; set; }
        [Display(Name = "نسبة ")]
        public bool IsAduitPercentage { get; set; }

        [Display(Name = "نسبة الاعتماد")]
        public double AproverPercentage { get; set; }
        [Display(Name = "نسبة ")]
        public bool IsAproverPercentage { get; set; }

        [Display(Name = "نسبة الاشراف")]
        public double SupervisionPercentage { get; set; }
        [Display(Name = "نسبة ")]
        public bool IsSupervisionPercentage { get; set; }


        public string MemberPhotoId { get; set; }
      
        public string ProfilePic { get; set; }

        public string IdenetityPic { get; set; }

        public string [] UsersRolesIds { get; set; }


        [Display(Name = "اسم الحساب")]
        public string UserName { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        public string Id { get; set; }

        public string SigPic { get; set; }
    }
}
