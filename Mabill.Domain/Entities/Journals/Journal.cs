using Mabill.Domain.Base;

namespace Mabill.Domain.Entities.Journals
{
    public class Journal : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
