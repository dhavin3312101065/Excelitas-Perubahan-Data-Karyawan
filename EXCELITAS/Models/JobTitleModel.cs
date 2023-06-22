using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXCELITAS.Models
{
    public class JobTitleModel
    {
        
        public int Id_JobTitle { get; set; }

        public string Nama_JobTitle { get; set; }

        public int Id_GradeLevel { get; set; }

    }
}
