using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Student_Register.Models
{
    public class StudentListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
    }
}