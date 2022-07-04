using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Users
{
    public class User : Person
    {
        public User()
        {
            Loans = new List<Loan>();
        }

        #region Common
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        #endregion

        #region Staff
        [NotMapped]
        public decimal SumOfGivenLoans { get; set; }
        public StaffRole? Role { get; set; } = null;

        [JsonIgnore]
        public Guid? OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }
        #endregion

        #region Loanee
        [NotMapped]
        public decimal SumOfLoans { get; set; }
        [NotMapped]
        public decimal SumOfRepaidLoans { get; set; }

        [InverseProperty(nameof(Loan.User))]
        public virtual ICollection<Loan> Loans { get; set; }
        #endregion
    }
}
