using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int Chapter_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Question_number { get; set; }
        public string? Response_type { get; set; }
        public string? Comment_question { get; set; }
        public string? Question_text { get; set; }
        public Chapter? Chapter { get; set; }
        public ICollection<Summary_option>? Summary_options { get; set; }
        public ICollection<Sub_question>? Sub_questions { get; set; }
        public ICollection<Option_question>? Option_questions { get; set; }
    }
}