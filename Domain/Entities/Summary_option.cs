using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Summary_option
    {
        public int Id { get; set; }
        public int Id_survey { get; set; }
        public string? Code_number { get; set; }
        public int Idquestion { get; set; }
        public string? Valuerta { get; set; }
        public Survey? Survey { get; set; }
        public Question? Question { get; set; }
    }
}