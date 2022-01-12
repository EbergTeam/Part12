using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part12.ModelsViews
{
    // Cпециальную модель для передачи данных в представление или модель представления(иными словами View Model)
    // Эта модель упрощает передачу списка компаний в представление
    public class CompanyModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
