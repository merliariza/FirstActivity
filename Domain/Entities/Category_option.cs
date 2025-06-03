using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category_option
    {
        public int Id { get; set; }
        public int Catalogoptions_id { get; set; }
        public int Categoriesoptions_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public Options_response? Options_responses { get; set; }
        public Categories_catalog? Categories_catalogs { get; set; }
    }
}