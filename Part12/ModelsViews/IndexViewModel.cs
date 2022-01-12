using Part12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part12.ModelsViews
{
    // c помощью этой модели мы сможем передать в представление сразу и список компаний, и список смартфонов
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<CompanyModels> Companies { get; set; }
    }
}
