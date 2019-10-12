using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class IndexForm
    {
        [Required(ErrorMessage = "Please select a MemberID")]

        [CustomValidation(typeof(IndexForm), "ValidateMember")]
        public int? MemberId { get; set; }

        public static ValidationResult ValidateMember(int? MemberId, ValidationContext context)
        {
            if (MemberId == null)
            {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(FinalProjectContext)) as FinalProjectContext;
            var members = dbContext.Membership.FirstOrDefault(x => x.ID == MemberId.Value);
            
            if (!members.ActiveMember) {
                return new ValidationResult("This member is not currently active");
    }
            return ValidationResult.Success;
        }
    }
}
