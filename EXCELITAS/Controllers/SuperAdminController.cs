using EXCELITAS.data;
using EXCELITAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EXCELITAS.Controllers
{
    public class SuperAdminController : Controller
    {

        private readonly ILogger<SuperAdminController> _logger;
        private DbemployeeContext _dbemployeeContext;

        public SuperAdminController(ILogger<SuperAdminController> logger, DbemployeeContext dbemployeeContext, IHostEnvironment _environment)
        {
            _logger = logger;
            _dbemployeeContext = dbemployeeContext;


        }

        public IActionResult MenuSuperAdmin()
        {
            return View();
        }

        public IActionResult ListGradeOrLevel()
        {
            GradeOrLevelModel gradelevelmodel = new GradeOrLevelModel();
            gradelevelmodel.GradeOrLevelList = new List<GradeOrLevel>();
            var data = _dbemployeeContext.TblGradeLevels.ToList();


            foreach (var item in data)
            {
                gradelevelmodel.GradeOrLevelList.Add(new GradeOrLevel
                {
                    Id_GradeLevel = item.Id_GradeLevel, //berfungsi untuk update, berdasarkan Id
                    Nama_GradeLevel = item.Nama_GradeLevel,

                });
            }
            return View(gradelevelmodel);
        }

        [HttpGet]
        public IActionResult SaveGradeOrLevel()
        {
            GradeOrLevel gradeOrLevel = new GradeOrLevel();
            return View(gradeOrLevel);
        }

        [HttpPost]
        public IActionResult SaveGradeOrLevel(GradeOrLevel Gradelevel)
        {
            var GradeorLeveldata = new TblGradeLevel()
            {
                Id_GradeLevel = Gradelevel.Id_GradeLevel,
                Nama_GradeLevel = Gradelevel.Nama_GradeLevel

            };

            _dbemployeeContext.TblGradeLevels.Add(GradeorLeveldata);
            _dbemployeeContext.SaveChanges();
            return RedirectToAction("ListGradeOrLevel", "SuperAdmin");
        }

        [HttpGet]
        public IActionResult Update(int IdGrl = 0)
        {
            GradeOrLevel gradeOrLevel = new GradeOrLevel();
            var data = _dbemployeeContext.TblGradeLevels.Where(m => m.Id_GradeLevel == IdGrl).FirstOrDefault();


            if (data != null)
            {
                gradeOrLevel.Id_GradeLevel = data.Id_GradeLevel;
                gradeOrLevel.Nama_GradeLevel = data.Nama_GradeLevel;
            }
            return View(gradeOrLevel);
        }

        //Post update Data untuk halaman admin input
        [HttpPost]
        public IActionResult Update(GradeOrLevel gradeOrLevel)
        {
            //try
            //{
            //Finding the member by its Id which we would update
            var data = _dbemployeeContext.TblGradeLevels.Where(m => m.Id_GradeLevel == gradeOrLevel.Id_GradeLevel).FirstOrDefault();
            data.Id_GradeLevel = gradeOrLevel.Id_GradeLevel;
            data.Nama_GradeLevel = gradeOrLevel.Nama_GradeLevel;

            _dbemployeeContext.SaveChanges();
            TempData["UpdateStatus"] = 1;
            //}
            //catch
            //{
            //    TempData["UpdateStatus"] = 0;
            //}
            return RedirectToAction("ListGradeOrLevel", "SuperAdmin");
        }

        [HttpGet]
        public IActionResult Delete(int IdGrl = 0)
        {

            try
            {
                var data = _dbemployeeContext.TblGradeLevels.Where(m => m.Id_GradeLevel == IdGrl).FirstOrDefault();
                if (data != null)
                {
                    _dbemployeeContext.TblGradeLevels.Remove(data);
                    _dbemployeeContext.SaveChanges();
                }

                TempData["DeleteStatus"] = 1;
            }
            catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("ListGradeOrLevel", "SuperAdmin");
        }
    }
}
