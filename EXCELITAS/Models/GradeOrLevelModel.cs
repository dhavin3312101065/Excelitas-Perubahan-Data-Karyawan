namespace EXCELITAS.Models
{
    public class GradeOrLevelModel
    {

        public List<GradeOrLevel> GradeOrLevelList { get; set; }
    }

    public class GradeOrLevel
    {
        public int Id_GradeLevel { get; set; }

        public string Nama_GradeLevel { get; set; }
    }
}
