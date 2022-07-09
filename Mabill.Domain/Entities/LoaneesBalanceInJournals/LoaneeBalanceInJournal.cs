using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Users;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.LoaneesBalancesInJournals
{
    public class LoaneeBalanceInJournal : BaseEntity
    {
        #region ForLoaneWithAccount
        [JsonIgnore]
        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        #endregion

        [JsonIgnore]
        public Guid JournalId { get; set; }
        [ForeignKey(nameof(JournalId))]
        public Journal Journal { get; set; }

        public decimal Balance { get; set; }

        #region ForLoaneWithoutAccount
        [JsonIgnore]
        public Guid? LoaneeId { get; set; }
        [ForeignKey(nameof(LoaneeId))]
        public Loanee Loanee { get; set; }

        #endregion
    }
}
