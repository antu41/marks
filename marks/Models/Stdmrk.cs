using System;
using System.Collections.Generic;

namespace marks.Models
{
    public partial class Stdmrk
    {
        public int Id { get; set; }
        public string Studentname { get; set; } = null!;
        public string Midterm { get; set; } = null!;
        public string Finalterm { get; set; } = null!;
        public string Attendance { get; set; } = null!;
        public string Classtest { get; set; } = null!;
        public string Totalmarks { get; set; } = null!;
    }
}
