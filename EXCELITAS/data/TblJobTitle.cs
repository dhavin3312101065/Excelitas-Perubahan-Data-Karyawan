using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXCELITAS.data
{
    public class TblJobTitle
    {
        
        public int Id_JobTitle { get; set; }

        public string? Nama_JobTitle { get; set; }

        public int Id_GradeLevel { get; set; }
    }
}
