using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sub_question
    {
        public int Id { get; set; }
        public int Subquestion_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Subquestion_number { get; set; }
        public string? Comment_subquestion { get; set; }
        public string? Subquestion_text { get; set; }
        public Question? Question { get; set; }
        public ICollection<Option_question>? Option_questions { get; set; }
    }
}