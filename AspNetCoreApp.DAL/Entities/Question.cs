using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetCoreApp.DAL.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Presentation Presentation { get; set; }
        public string Sentence { get; set; }
        public string Options { get; set; }
        public int Correct { get; set; }
        public int Slide { get; set; }
    }
}
