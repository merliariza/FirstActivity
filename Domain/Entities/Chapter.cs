using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public int Survey_id { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Componenthtml { get; set; }
        public string? Componentreact { get; set; }
        public string? Chapter_number { get; set; }
        public string? Chapter_title { get; set; }
        public Survey? Survey { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}