using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EXCELITAS.data
{
    public partial class TblUser
    {
        
        public int Id_user { get; set; }
        [Required]

        public string? Username { get; set; }

        public string? Password { get; set; }

        public int Role { get; set; }
    }
}

