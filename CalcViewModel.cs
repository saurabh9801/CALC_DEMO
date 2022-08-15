using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CALC_DEMO.Models
{
    public class CalcViewModel
    {
        public int CID { get; set; }
        public int Fst_Number { get; set; }
        public int Snd_Number { get; set; }
        public string Operator { get; set; }
        public int Result { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}