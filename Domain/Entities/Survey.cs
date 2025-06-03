using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Componenthtml { get; set; }
        public string? Componentreact { get; set; }
        public string? Description { get; set; }
        public string? Instruction { get; set; }
        public string? Name { get; set; }
        public ICollection<Chapter>? Chapters { get; set; }
        public ICollection<Summary_option>? Summary_options { get; set; }
    }
}