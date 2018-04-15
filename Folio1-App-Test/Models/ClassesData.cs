using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folio1_App_Test.Models
{
    public class ClassesData
    {
        public IEnumerable<tbl_Classes> Cls { get; set; }
        public IEnumerable<tbl_Students> Stud { get; set; }
    }
}