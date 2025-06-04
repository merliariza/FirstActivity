using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categories_catalog : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Option_question>? Option_questions { get; set; }
        public ICollection<Category_option>? Category_options { get; set; }

    }
}