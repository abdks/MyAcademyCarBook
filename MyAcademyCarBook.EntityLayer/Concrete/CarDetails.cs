using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class CarDetails
    {
        public int CarDetailsID { get; set; }
        public string Description { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
