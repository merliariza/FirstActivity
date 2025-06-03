using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Option_question
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public int Subquestion_id { get; set; }
        public int Optionquestion_id { get; set; }
        public int Optioncatalog_id { get; set; }
        public int Option_id { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Comment_options { get; set; }
        public string? Numberoption { get; set; }
        public Sub_question? Sub_question { get; set; }
        public Question? Question { get; set; }
        public Categories_catalog? Categories_catalogs { get; set; }
        public Options_response? Options_responses { get; set; }

    }
}