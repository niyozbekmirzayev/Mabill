using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
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
            this.Loans = new List<Loan>();
        }

        #region Common
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        #endregion

        #region Staff
        public StaffRole? Role { get; set; }

        public decimal? SumOfGivenLoans { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
        [NotMapped]
        public virtual Organization Organization { get; set; }
        #endregion

        #region Loanee
        public decimal? SumOfLoans { get; set; }
        public decimal? SumOfRepaidLoans { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        #endregion
    }
}
