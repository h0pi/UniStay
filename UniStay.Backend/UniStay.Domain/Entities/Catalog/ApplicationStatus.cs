using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using UniStay.Domain.Common;

namespace UniStay.Domain.Entities.Catalog
{
    public class ApplicationStatus : BaseEntity
    {
        public string StatusName { get; set; } = string.Empty;

        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
