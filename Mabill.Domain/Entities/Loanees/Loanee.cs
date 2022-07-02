using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Users;
using Newtonsoft.Json;
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
        [NotMapped]
        public decimal SumOfLoans { get; set; }
        [NotMapped]
        public decimal SumOfRepaidLoans { get; set; }

        [JsonIgnore]
        public Guid AddedById { get; set; }
        [NotMapped]
        [ForeignKey(nameof(AddedById))]
        public virtual User AddedBy { get; set; }

        [JsonIgnore]
        public Guid JournalId { get; set; }

        [NotMapped]
        [ForeignKey(nameof(JournalId))]
        public virtual Journal Journal { get; set; }
    }
}
