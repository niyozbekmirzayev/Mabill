using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Loanees
{
    public class Loanee : Person
    {
        public Loanee()
        {
            this.Loans = new List<Loan>();
        }

        public virtual ICollection<Loan> Loans { get; set; }

        public string Description { get; set; }
        public decimal? SumOfLoans { get; set; }
        public decimal? SumOfRepaidLoans { get; set; }

        [ForeignKey(nameof(AddedBy))]
        public Guid AddedById { get; set; }
        [NotMapped]
        public virtual User AddedBy { get; set; }
    }
}
