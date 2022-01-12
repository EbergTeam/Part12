using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part12.Models
{
    [Bind("Name")] // в привязке участвует только свойство Name, поэтому даже если в запросе мы передадим значения для всех остальных свойств,
                   // эти значения учитываться не будут, а для соответствующих свойств, не участвующих в привязке, будут применяться значения по умолчанию
    public class Phone
    {
        public int Id { get; set; }
        [BindRequired] // обязательно надо будет указать значение для свойства Name в запросе
                       // Exception не будет, в объект ModelState будет помещена информация об ошибках, а свойство ModelState.IsValid возвратит false
        public string Name { get; set; }
        public Company Manufacturer { get; set; }
        [BindNever] // свойство Price будет исключено из привязки
        public int Price { get; set; }
    }
}
