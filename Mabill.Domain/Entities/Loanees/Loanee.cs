using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loans;
using System.Collections.Generic;

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
        public decimal SumOfLoans { get; set; }
        public decimal Balance { get; set; }
    }
}
