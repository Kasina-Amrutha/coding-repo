using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRazorApps.Models
{
    public class Organization
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }

    }
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
    public class OrgLocations
    {
        [Key,Column(Order =1)]
        public int OrgId { get; set; }
        [Key, Column(Order = 2)]
        public int LocationId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("org")]
        public int OrgId  { get; set; }
        public Organization? org {  get; set; }
    }
     public class Employee
     { 
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("dept")]
        public int DeptId { get; set; }
        public Department dept { get; set; }
    
    }
}
