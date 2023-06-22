using EXCELITAS.data;
using EXCELITAS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Session; //for session
using Microsoft.AspNetCore.Http; //for session
using Microsoft.AspNetCore.Http.Extensions; //for session
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Configuration;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System;

namespace EXCELITAS.Controllers
{
    public class HomeController : Controller
    {

        private IHostEnvironment Environment;


        private readonly ILogger<HomeController> _logger;
        private DbemployeeContext _dbemployeeContext;

        public HomeController(ILogger<HomeController> logger, DbemployeeContext dbemployeeContext, IHostEnvironment _environment)
        {
            _logger = logger;
            _dbemployeeContext = dbemployeeContext;

            //for data csv
            Environment = _environment;

        }

        /*private string ShowNomor(int a )
        {
            if (a == 1)
            {
                return "satu";
            }
            else
            {
                return "nilai lain";
            }
        }*/

        //Import CSV
        //1. Mengambil Id_Grade Level Dari Nama_Grade Level
        private string GetIdGradeLevelFromName(string Nama_GradeLevel, List<TblGradeLevel> GL)
        {
            int Id_GradeLevelHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (GL[i].Nama_GradeLevel == Nama_GradeLevel)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < GL.Count);
            if (ketemu == true)
            {
                Id_GradeLevelHasil = GL[IndexFound].Id_GradeLevel;
            }
            else
            {
                Id_GradeLevelHasil = 0;
            }
            
            return (Convert.ToString(Id_GradeLevelHasil));
        }

        //2. Mengambil Id_JobTitle Dari Nama_JobTitle
        private string GetIdJobTitleFromName(string Nama_JobTitle, List<TblJobTitle> JT)
        {
            int Id_JobTitleHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (JT[i].Nama_JobTitle == Nama_JobTitle)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < JT.Count);
            if (ketemu == true)
            {
                Id_JobTitleHasil = JT[IndexFound].Id_JobTitle;
            }
            else
            {
                Id_JobTitleHasil = 0;
            }

            
            return (Convert.ToString(Id_JobTitleHasil));
        }

        //3. Mengambil Id_LaborType Dari Nama_Labor Type
        private string GetIdLaborTypeFromName(string Nama_LaborType, List<TblLaborType> LT)
        {
            int Id_LaborTypeHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (LT[i].Nama_LaborType == Nama_LaborType)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < LT.Count);
            if (ketemu == true)
            {
                Id_LaborTypeHasil = LT[IndexFound].Id_LaborType;
            }
            else
            {
                Id_LaborTypeHasil = 0;
            }
            
            return (Convert.ToString(Id_LaborTypeHasil));
        }

        //4. Mengambil Id_LaborClass Dari Nama_Labor Class   
        private string GetIdLaborClassFromName(string Nama_LaborClass, List<TblLaborClass> LB)
        {
            int Id_LaborClassHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (LB[i].Nama_LaborClass == Nama_LaborClass)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < LB.Count);
            if (ketemu == true)
            {
                Id_LaborClassHasil = LB[IndexFound].Id_LaborClass;
            }
            else
            {
                Id_LaborClassHasil = 0;
            }
            
            return (Convert.ToString(Id_LaborClassHasil));
        }

        //5. Mengambil Id Department Dari Nama_Department
        private string GetIdDivisionFromName(string Nama_Division, List<TblDivision> DV)
        {
            int Id_DivisionHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (DV[i].Nama_Division == Nama_Division)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < DV.Count);
            if (ketemu == true)
            {
                Id_DivisionHasil = DV[IndexFound].Id_Division;
            }
            else
            {
                Id_DivisionHasil = 0;
            }
            
            return (Convert.ToString(Id_DivisionHasil));
        }

        //6. Mengambil Id_CostCenter Dari Nama_CostCenter dan deskripsi
        private string GetIdCostCenterFromName(string Nama_CostCenter, List<TblCostCenter> CC)
        {
            int Id_CostCenterHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (CC[i].Nama_CostCenter == Nama_CostCenter)
                {
                    ketemu = true;
                    IndexFound = i;
                }
                i++;
            } while (ketemu == false && i < CC.Count);
            if (ketemu == true)
            {
                Id_CostCenterHasil = CC[IndexFound].Id_CostCenter;
            }
            else
            {
                Id_CostCenterHasil = 0;
            }
            
            return (Convert.ToString(Id_CostCenterHasil));
        }

        //7. Mengambil Id_JobPost Dari Nama_JobPost
        private string GetIdJobPostFromName(string Nm_JobPost, List<TblJobPost> DP)
        {
            int Id_JobPostHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (DP[i].Nama_JobPost == Nm_JobPost)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < DP.Count);
            if(ketemu == true)
            {
                Id_JobPostHasil = DP[IndexFound].Id_JobPost;
            }
            else
            {
                Id_JobPostHasil = 0;
            }
            
            return (Convert.ToString(Id_JobPostHasil));
        }

        //8. Mengambil Id_JobFunction Dari Nama_JobFunction 
        private string GetIdJobFunctionFromName(string Nm_JobFunction, List<TblJobFunction> JF)
        {
            int Id_JobFunctionHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (JF[i].Nama_JobFunction == Nm_JobFunction)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < JF.Count);
            if (ketemu == true)
            {
                Id_JobFunctionHasil = JF[IndexFound].Id_JobFunction;
            }
            else
            {
                Id_JobFunctionHasil = 0;
            }

            return (Convert.ToString(Id_JobFunctionHasil));
        }

        //9. Mengambil Id_ProductivityType dari Nama_ProductivityType
        private string GetIdProductivityTypeFromName(string Nm_ProductivityType, List<TblProductivityType> PT)
        {
            int Id_ProductivityTypeHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (PT[i].Nama_ProductivityType == Nm_ProductivityType)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < PT.Count);
            if (ketemu == true)
            {
                Id_ProductivityTypeHasil = PT[IndexFound].Id_ProductivityType;
            }
            else
            {
                Id_ProductivityTypeHasil = 0;
            }

            return (Convert.ToString(Id_ProductivityTypeHasil));
        }

        //10. Mengambil Id_WorkLotOrPlant dari Nama_WorkLotOrPlant
        private string GetIdWorkLotOrPlantFromName(string Nm_WorkLotOrPlant, List<TblWorkLotOrPlant> WLP)
        {
            int Id_WorkLotOrPlantHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (WLP[i].Nama_WorkLotOrPlant == Nm_WorkLotOrPlant)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < WLP.Count);
            if (ketemu == true)
            {
                Id_WorkLotOrPlantHasil = WLP[IndexFound].Id_WorkLotOrPlant;
            }
            else
            {
                Id_WorkLotOrPlantHasil = 0;
            }

            return (Convert.ToString(Id_WorkLotOrPlantHasil));
        }

        //11. Mengambil Id_MethodOfRecruitment Dari Nama_MethodOfRecruitment 
        private string GetIdMethodOfRecruitmentFromName(string Nama_MethodOfRecruitment, List<TblMethodOfRecruitment> MoR)
        {
            int Id_MethodOfRecruitmentHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (MoR[i].Nama_MethodOfRecruitment == Nama_MethodOfRecruitment)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < MoR.Count);
            if (ketemu == true)
            {
                Id_MethodOfRecruitmentHasil = MoR[IndexFound].Id_MethodOfRecruitment;
            }
            else
            {
                Id_MethodOfRecruitmentHasil = 0;
            }
            
            return (Convert.ToString(Id_MethodOfRecruitmentHasil));
        }

        //12. Mengambil Id_Source Dari Nama_Source
        private string GetIdSourceFromName(string Nama_Source, List<TblSource> SC)
        {
            int Id_SourceHasil = 0;
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (SC[i].Nama_Source == Nama_Source)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < SC.Count);
            if (ketemu == true)
            {
                Id_SourceHasil = SC[IndexFound].Id_Source;
            }
            else
            {
                Id_SourceHasil = 0;
            }
            
            return (Convert.ToString(Id_SourceHasil));
        }


        //Export CSV
        //Mengambil Nama_GradeLevel dari Id_GradeLevel
        private string GetNamaGradeLevelFromId(string Id_GradeLevel, List<TblGradeLevel> GL)
        {
            string NamaGradeLevelHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(GL[i].Id_GradeLevel) == Id_GradeLevel)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < GL.Count);
            string hasil = GL[IndexFound].Nama_GradeLevel;
            NamaGradeLevelHasil = hasil;
            return(NamaGradeLevelHasil);
        }

        //Mengambil Nama_JobTitle dari Id_JobTitle 
        private string GetNamaJobTitleFromId(string Id_JobTitle, List<TblJobTitle> JT)
        {
            string NamaJobTitleHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(JT[i].Id_JobTitle) == Id_JobTitle)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < JT.Count);
            string hasil = JT[IndexFound].Nama_JobTitle;
            NamaJobTitleHasil = hasil;
            return (NamaJobTitleHasil);
        }

        //Mengambil Nama_LaborType dari Id_LaborType
        private string GetNamaLaborTypeFromId(string Id_LaborType, List<TblLaborType> LT)
        {
            string NamaLaborTypeHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(LT[i].Id_LaborType) == Id_LaborType)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < LT.Count);
            string hasil = LT[IndexFound].Nama_LaborType;
            NamaLaborTypeHasil = hasil;
            return (NamaLaborTypeHasil);
        }

        //Mengambil Nama_LaborClass dari Id_LaborClass
        private string GetNamaLaborClassFromId(string Id_LaborClass, List<TblLaborClass> LC)
        {
            string NamaLaborClassHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(LC[i].Id_LaborClass) == Id_LaborClass)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < LC.Count);
            string hasil = LC[IndexFound].Nama_LaborClass;
            NamaLaborClassHasil = hasil;
            return (NamaLaborClassHasil);
        }

        //Mengambil Nama_Department dari Id_Department
        private string GetNamaDivisionFromId(string Id_Division, List<TblDivision> DV)
        {
            string NamaDivisionHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(DV[i].Id_Division) == Id_Division)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < DV.Count);
            string hasil = DV[IndexFound].Nama_Division;
            NamaDivisionHasil = hasil;
            return (NamaDivisionHasil);
        }

        //Mengambil Nama_CostCenter dari Id_CostCenter 
        private string GetNamaCostCenterFromId(string Id_CostCenter, List<TblCostCenter> CC)
        {
            string NamaCostCenterHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(CC[i].Id_CostCenter) == Id_CostCenter)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < CC.Count);
            string hasil = CC[IndexFound].Nama_CostCenter;
            NamaCostCenterHasil = hasil;
            return (NamaCostCenterHasil);
        }

        //Mengambil Nama_JobPost dari Id_JobPost
        private string GetNamaJobPostFromId(string ID_Department, List<TblJobPost> DP)
        {
            string NamaJobPostHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(DP[i].Id_JobPost) == ID_Department)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false  && i < DP.Count);
            string hasil = DP[IndexFound].Nama_JobPost;
            NamaJobPostHasil = hasil;
            return (NamaJobPostHasil);
        }

        //Mengambil Nama_MethodOfRecruitment dari Id_MethodOfRecruitment
        private string GetNamaMoRFromId(string Id_MethodOfRecruitment, List<TblMethodOfRecruitment> MoR)
        {
            string NamaMoRHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(MoR[i].Id_MethodOfRecruitment) == Id_MethodOfRecruitment)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < MoR.Count);
            string hasil = MoR[IndexFound].Nama_MethodOfRecruitment;
            NamaMoRHasil = hasil;
            return (NamaMoRHasil);
        }

        //Mengambil Nama_Source dari Id_Source
        private string GetNamaSourceFromId(string Id_Source, List<TblSource> SC)
        {
            string NamaSourceHasil = "";
            int IndexFound = 0;
            bool ketemu = false;
            int i = 0;
            do
            {
                if (Convert.ToString(SC[i].Id_Source) == Id_Source)
                {
                    ketemu = true;
                    IndexFound = i;
                    //Id_GradeLevelHasil = GL[i].Id_GradeLevel;
                }
                i++;
            } while (ketemu == false && i < SC.Count);
            string hasil = SC[IndexFound].Nama_Source;
            NamaSourceHasil = hasil;
            return (NamaSourceHasil);
        }


        //Fungsi untuk mengecek isi data pada GradeLevel, jobtitle dll.
        private bool CekAllKondisi (bool GradeLevelKondisi, bool JobTitleKondisi, 
                                    bool LaborTypeKondisi, bool LaborClassKondisi, 
                                    bool ProdTypeKondisiOke, bool JobFucnKondisiOke,
                                    bool DivisionKondisi, bool CostCenterKondisi, bool DepartmentKondisi, 
                                    bool WorkLOPKondisiOke, bool MethodOfRec, bool SourceKondisi)
        {
            if (GradeLevelKondisi == true && JobTitleKondisi == true && LaborTypeKondisi == true 
                && LaborClassKondisi == true && ProdTypeKondisiOke == true 
                && JobFucnKondisiOke == true && DivisionKondisi == true && CostCenterKondisi == true 
                && DepartmentKondisi == true && WorkLOPKondisiOke == true && MethodOfRec == true && SourceKondisi == true)
            {
                return true;
            }else
            {
                return false;
            }
        }


        //Tampilan Index/Halaman utama
        [HttpGet]
        public IActionResult Index()
       {


            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                return RedirectToAction("MenuSuperAdmin", "SuperAdmin");
            }
            else if (HttpContext.Session.GetInt32("Role") == 2)
            {
                return RedirectToAction("MenuAdminInput", "Home");
            }
            else if (HttpContext.Session.GetInt32("Role") == 3)
            {

                return RedirectToAction("MenuAdminApproval", "AdminApproval");
            }
            else if (HttpContext.Session.GetInt32("Role") == 4)
            {

                return RedirectToAction("MenuAdminOperasional", "AdminOperasional");
            }
            else if (HttpContext.Session.GetInt32("Role") == 5)
            {

                return RedirectToAction("MenuAdminView", "AdminView");
            }
            else

            {
                return View();
            }


        }

        //DROPDOWN CASCADING KE 1
        //Fungsi untuk mengambil data JobTitle
        public string GetJobTitle (int Id_GradeLevel, int IDJobTitle = 0)
        {
            var data = _dbemployeeContext.TblJobTitles.Where(x => x.Id_GradeLevel == Id_GradeLevel).ToList();
            int indexSelected = 0;
            int j = 1;
            List<string> JobTitleList = new List<string>();
            foreach (var item in data) 
            {
                
                if (item.Id_JobTitle == IDJobTitle)
                {
                    indexSelected = j;
                }
             

                JobTitleList.Add(Convert.ToString(item.Id_JobTitle));
                JobTitleList.Add(item.Nama_JobTitle);
                j++;
            }

            int i = 1;
            string str = " ";
            foreach (var item in JobTitleList) 
           {
                if (i % 2 == 1)
                {
                    
                    if (i == indexSelected)
                    {
                        str += "<option value='" + item + "' selected>";
                    }
                    else
                    {
                        str += "<option value='" + item + "'>";
                    }
                }
                else
                {
                    str += item + "</option>";
                }
                i++;
            }
           return (str);
            
        }

        //Fungsi untuk mengambil data jobtitle ketika loadpage untuk update dan detail
        public string GetJobTitleLoad(int Id_GradeLevel, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            //int g = Convert.ToInt32(dataEmployee.JobprofileGradeOrlevel);
            //var datajobtitle = _dbemployeeContext.TblJobTitles.Where(x => x.Id_GradeLevel == g).ToList();
            int h = Convert.ToInt32(dataEmployee.JobprofileGradeOrlevel);
            //Console.WriteLine(h);
            //Console.ReadLine();
            var data = _dbemployeeContext.TblJobTitles.Where(x => x.Id_GradeLevel == h).ToList();
            int m = Convert.ToInt32(dataEmployee.JobprofileJobTitle);


            int indexSelected = 0;
            int j = 1;
            List<string> JobTitleList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_JobTitle == m)
                {
                    str += "<option value='" + item.Id_JobTitle + "' selected>";
                    str += item.Nama_JobTitle + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_JobTitle + "'>";
                    str += item.Nama_JobTitle + "</option>";
                }

                JobTitleList.Add(Convert.ToString(item.Id_JobTitle));
                JobTitleList.Add(item.Nama_JobTitle);
                j++;
            }
            return (str);

        }

        //Fungsi untuk mengambil data jobtitle ketika loadpage untuk detail data usulan dihalaman admin approval
        public string GetJobTitleLoadUsulan(int Id_GradeLevel, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployeeUsulan.JobprofileGradeOrlevel);
            var data = _dbemployeeContext.TblJobTitles.Where(x => x.Id_GradeLevel == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.JobprofileJobTitle);


            int indexSelected = 0;
            int j = 1;
            List<string> JobTitleList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_JobTitle == m)
                {
                    str += "<option value='" + item.Id_JobTitle + "' selected>";
                    str += item.Nama_JobTitle + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_JobTitle + "'>";
                    str += item.Nama_JobTitle + "</option>";
                }

                JobTitleList.Add(Convert.ToString(item.Id_JobTitle));
                JobTitleList.Add(item.Nama_JobTitle);
                j++;
            }

            return (str);

        }

        //Fungsi untuk mengambil Labor Type
        public string GetLaborType(int Id_JobTitle, int IDLaborType = 0)
        {
            var data = _dbemployeeContext.TblLaborTypes.Where(x => x.Id_JobTitle == Id_JobTitle).ToList();

            int indexSelected = 0;
            int j = 1;
            List<string> LaborTypeList = new List<string>();
            foreach (var item in data)
            {
                if (item.Id_LaborType == IDLaborType)
                {
                    indexSelected = j;
                }

                LaborTypeList.Add(Convert.ToString(item.Id_LaborType));
                LaborTypeList.Add(item.Nama_LaborType);
                j++;
            }

            int i = 1;
            string str = " ";
            foreach (var item in LaborTypeList)
            {
                if (i % 2 == 1)
                {
                    if (i == indexSelected)
                    {
                        str += "<option value='" + item + "' selected>";
                    }
                    else
                    {
                        str += "<option value='" + item + "'>";
                    }
                   
                }
                else
                {
                    str += item + "</option>";
                }
                i++;
            }
            return (str);

        }

        //Fungsi mengambil labor type ketika load page untuk update dan detail
        public string GetLaborTypeLoad(int Id_GradeLevel, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            //int g = Convert.ToInt32(dataEmployee.JobprofileGradeOrlevel);
            //var datajobtitle = _dbemployeeContext.TblJobTitles.Where(x => x.Id_GradeLevel == g).ToList();
            int h = Convert.ToInt32(dataEmployee.JobprofileJobTitle);
            //Console.WriteLine(h);
            //Console.ReadLine();
            var data = _dbemployeeContext.TblLaborTypes.Where(x => x.Id_JobTitle == h).ToList();
            int m = Convert.ToInt32(dataEmployee.JobprofileLaborType);


            int indexSelected = 0;
            int j = 1;
            List<string> LaborTypeList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_LaborType == m)
                {
                    str += "<option value='" + item.Id_LaborType + "' selected>";
                    str += item.Nama_LaborType + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_LaborType + "'>";
                    str += item.Nama_LaborType + "</option>";
                }

                LaborTypeList.Add(Convert.ToString(item.Id_JobTitle));
                LaborTypeList.Add(item.Nama_LaborType);
                j++;
            }
            return (str);

        }

        //Fungsi mengambil labor type ketika load page untuk detail data usulan dihalaman admin approval
        public string GetLaborTypeLoadUsulan (int Id_GradeLevel, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployeeUsulan.JobprofileJobTitle);
            var data = _dbemployeeContext.TblLaborTypes.Where(x => x.Id_JobTitle == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.JobprofileLaborType);

            int indexSelected = 0;
            int j = 1;
            List<string> LaborTypeList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_LaborType == m)
                {
                    str += "<option value='" + item.Id_LaborType + "' selected>";
                    str += item.Nama_LaborType + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_LaborType + "'>";
                    str += item.Nama_LaborType + "</option>";
                }

                LaborTypeList.Add(Convert.ToString(item.Id_LaborType));
                LaborTypeList.Add(item.Nama_LaborType);
                j++;
            }

            return (str);

        }

        //Fungsi untuk mengambil Labor Class
        public string GetLaborClass(int Id_LaborType, int IDLaborClass = 0)
        {
            var data = _dbemployeeContext.TblLaborClasses.Where(x => x.Id_LaborType == Id_LaborType).ToList();
            int indexSelected = 0;
            int j = 1;
            List<string> LaborClassList = new List<string>();
            foreach (var item in data)
            {
                if (item.Id_LaborClass == IDLaborClass)
                {
                    indexSelected = j;
                }
                LaborClassList.Add(Convert.ToString(item.Id_LaborClass));
                LaborClassList.Add(item.Nama_LaborClass);
                j++;
            }

            int i = 1;
            string str = " ";
            foreach (var item in LaborClassList)
            {
                if (i % 2 == 1)
                {
                    if (i == indexSelected)
                    {
                        str += "<option value=' " + item + "' selected>";
                    }
                    else
                    {
                        str += "<option value=' " + item + "'>";
                    }
                }
                else
                {
                    str += item + "</option>";
                }
                i++;
            }
            return (str);

        }

        //Fungsi untuk mengambil Labor Class ketika load page untuk update
        public string GetLaborClassLoad (int Id_GradeLevel, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployee.JobprofileLaborType);
            var data = _dbemployeeContext.TblLaborClasses.Where(x => x.Id_LaborType == h).ToList();
            int m = Convert.ToInt32(dataEmployee.JobprofileLaborClass);

            int indexSelected = 0;
            int j = 1;
            List<string> LaborClassList = new List<string>();
            
            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_LaborClass == m)
                {
                    str += "<option value='" + item.Id_LaborClass + "' selected>";
                    str += item.Nama_LaborClass + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_LaborClass + "'>";
                    str += item.Nama_LaborClass + "</option>";
                }

                LaborClassList.Add(Convert.ToString(item.Id_LaborClass));
                LaborClassList.Add(item.Nama_LaborClass);
                j++;
            }
            return (str);

        }

        //Fungsi mengambil labor Class ketika load page untuk detail data usulan dihalaman admin approval
        public string GetLaborClassLoadUsulan(int Id_GradeLevel, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployeeUsulan.JobprofileLaborType);
            var data = _dbemployeeContext.TblLaborClasses.Where(x => x.Id_LaborType == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.JobprofileLaborClass);

            int indexSelected = 0;
            int j = 1;
            List<string> LaborClassList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_LaborClass == m)
                {
                    str += "<option value='" + item.Id_LaborClass + "' selected>";
                    str += item.Nama_LaborClass + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_LaborClass + "'>";
                    str += item.Nama_LaborClass + "</option>";
                }

                LaborClassList.Add(Convert.ToString(item.Id_LaborClass));
                LaborClassList.Add(item.Nama_LaborClass);
                j++;
            }
            return (str);

        }


        //DROPDOWN CASCADING KE 2
        //Fungsi untuk mengambil data Cost Center 
        public string GetCostCenter(int Id_Division, int IDCostCenter = 0)
        {
            var data = _dbemployeeContext.TblCostCenters.Where(x => x.Id_Division == Id_Division).ToList();

            int indexSelected = 0;
            int j = 1;
            List<string> CostCenterList = new List<string>();

            //percobaan
            string str = " ";
            foreach (var item in data)
            {

                if (item.Id_CostCenter == IDCostCenter)
                {
                    str += "<option value = '" + item.Id_CostCenter + "' selected>";
                    str += item.Nama_CostCenter + "+" + item.Deskripsi_CostCenter + "</option>";

                    indexSelected = j;
                }else
                {
                    str += "<option value = '" + item.Id_CostCenter + "'>";
                    str += item.Nama_CostCenter + "+" + item.Deskripsi_CostCenter + "</option>";
                }


                CostCenterList.Add(Convert.ToString(item.Id_CostCenter));
                CostCenterList.Add(item.Nama_CostCenter);
                CostCenterList.Add(item.Deskripsi_CostCenter);
                j++;
            }

            return (str);

        }

        //Fungsi untuk mengambil data cost center ketika load page untuk update dan detail
        public string GetCostCenterLoad(int Id_Division, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();

            int h = Convert.ToInt32(dataEmployee.JobprofileDivision);

            var data = _dbemployeeContext.TblCostCenters.Where(x => x.Id_Division == h).ToList();
            int m = Convert.ToInt32(dataEmployee.JobprofileCostCenter);

            int indexSelected = 0;
            int j = 1;
            List<string> CostCenterList = new List<string>();
      
            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_CostCenter == m)
                {
                    str += "<option value='" + item.Id_CostCenter + "' selected>";
                    str += item.Nama_CostCenter + "+" + item.Deskripsi_CostCenter + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_CostCenter + "'>";
                    str += item.Nama_CostCenter + "+" + item.Deskripsi_CostCenter + "</option>";
                }

                CostCenterList.Add(Convert.ToString(item.Id_CostCenter));
                CostCenterList.Add(item.Nama_CostCenter);
                CostCenterList.Add(item.Deskripsi_CostCenter);
                j++;
            }
            return (str);
        }

        //Fungsi untuk mengambil cost center ketika load page untuk detail data usulan dihalaman admin approval
        public string GetCostCenterLoadUsulan(int Id_Division, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();

            int h = Convert.ToInt32(dataEmployeeUsulan.JobprofileDivision);

            var data = _dbemployeeContext.TblCostCenters.Where(x => x.Id_Division == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.JobprofileCostCenter);

            int indexSelected = 0;
            int j = 1;
            List<string> CostCenterList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_CostCenter == m)
                {
                    str += "<option value='" + item.Id_CostCenter + "' selected>";
                    str += item.Nama_CostCenter + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_CostCenter + "'>";
                    str += item.Nama_CostCenter + "</option>";
                }

                CostCenterList.Add(Convert.ToString(item.Id_CostCenter));
                CostCenterList.Add(item.Nama_CostCenter);
                j++;
            }
            return (str);
        }


        //Fungsi untuk mengambil data JobPost
        public string GetJobPost(int Id_CostCenter, int IDJobPost=0) 
        {
            var data = _dbemployeeContext.TblJobPosts.Where(x => x.Id_CostCenter == Id_CostCenter).ToList();

            int indexSelected = 0;
            int j = 1;
            List<string> JobPostList = new List<string>();
            foreach (var item in data)
            {

                if (item.Id_JobPost == IDJobPost)
                {
                    indexSelected = j;
                }

                JobPostList.Add(Convert.ToString(item.Id_JobPost));
                JobPostList.Add(item.Nama_JobPost);
                j++;

            }
          

            int i = 1;
            string str = " ";
            foreach (var item in JobPostList)
            {
                if (i % 2 == 1)
                {
                    if (i == indexSelected)
                    {
                        str += "<option value='" + item + "' selected>";
                    }
                    else
                    {
                        str += "<option value='" + item + "'>";
                    }
                }
                else
                {
                    str += item + "</option>";
                }
                i++;
            }
            return (str);

        }

        //Fungsi untuk mengambil data JobPost ketika load page untuk update dan detail
        public string GetJobPostLoad(int Id_Division, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployee.JobprofileCostCenter);
            var data = _dbemployeeContext.TblJobPosts.Where(x => x.Id_CostCenter == h).ToList();
            int m = Convert.ToInt32(dataEmployee.JobprofileDepartment);

            int indexSelected = 0;
            int j = 1;
            List<string> DepartmentList = new List<string>();


            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_JobPost == m)
                {
                    str += "<option value='" + item.Id_JobPost + "' selected>";
                    str += item.Nama_JobPost + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_JobPost + "'>";
                    str += item.Nama_JobPost + "</option>";
                }

                DepartmentList.Add(Convert.ToString(item.Id_JobPost));
                DepartmentList.Add(item.Nama_JobPost);
                j++;
            }

            return (str);
        }

        //Fungsi untuk mengambil Department ketika load page untuk detail data usulan dihalaman admin approval
        public string GetDepartmentLoadUsulan (int Id_Division, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployeeUsulan.JobprofileCostCenter);
            var data = _dbemployeeContext.TblJobPosts.Where(x => x.Id_CostCenter == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.JobprofileDepartment);

            int indexSelected = 0;
            int j = 1;
            List<string> DepartmentList = new List<string>();


            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_JobPost == m)
                {
                    str += "<option value='" + item.Id_JobPost + "' selected>";
                    str += item.Nama_JobPost + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_JobPost + "'>";
                    str += item.Id_JobPost + "</option>";
                }

                DepartmentList.Add(Convert.ToString(item.Id_JobPost));
                DepartmentList.Add(item.Nama_JobPost);
                j++;
            }

            return (str);
        }


        //DROPDOWN CASCADING KE 3
        //Fungsi untuk mengambil data Source
        public string GetSource(int Id_MethodOfRecruitment, int IDSource = 0)
        {
            var data = _dbemployeeContext.TblSources.Where(x => x.Id_MethodOfRecruitment == Id_MethodOfRecruitment).ToList();

            int indexSelected = 0;
            int j = 1;

            List<string> SourceList = new List<string>();
            foreach (var item in data)
            {
                if (item.Id_Source == IDSource)
                {
                    indexSelected = j;
                }

                SourceList.Add(Convert.ToString(item.Id_Source));
                SourceList.Add(item.Nama_Source);
                j++;
            }

            int i = 1;
            string str = " ";
            foreach (var item in SourceList)
            {
                if (i % 2 == 1)
                {
                    if (i == indexSelected)
                    {
                        str += "<option value=' " + item + "' selected>";
                    }
                    else
                    {
                        str += "<option value=' " + item + "'>";
                    }
                }
                else
                {
                    str += item + "</option>";
                }
                i++;
            }
            return (str);

        }

        //Fungsi untuk mengambil data source ketika load page untuk update dan detail\
        public string GetSourceLoad(int Id_MethodOfRecruitment, string LocalID)
        {
            var dataEmployee = _dbemployeeContext.TblEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployee.RecruitmentMethodofRecruitment);
            var data = _dbemployeeContext.TblSources.Where(x => x.Id_MethodOfRecruitment == h).ToList();
            int m = Convert.ToInt32(dataEmployee.RecruitmentSource);

            int indexSelected = 0;
            int j = 1;

            List<string> SourceList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_Source == m)
                {
                    str += "<option value='" + item.Id_Source + "' selected>";
                    str += item.Nama_Source + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_Source + "'>";
                    str += item.Nama_Source + "</option>";
                }

                SourceList.Add(Convert.ToString(item.Id_Source));
                SourceList.Add(item.Nama_Source);
                j++;
            }

            return (str);

        }

        //Fungsi untuk mengambil cost center ketika load page untuk detail data usulan dihalaman admin approval
        public string GetSourceLoadUsulan(int Id_MethodOfRecruitment, string LocalID)
        {
            var dataEmployeeUsulan = _dbemployeeContext.TblUsulanEmployees.Where(x => x.BasicinfoLocalid == LocalID).FirstOrDefault();
            int h = Convert.ToInt32(dataEmployeeUsulan.RecruitmentMethodofRecruitment);
            var data = _dbemployeeContext.TblSources.Where(x => x.Id_MethodOfRecruitment == h).ToList();
            int m = Convert.ToInt32(dataEmployeeUsulan.RecruitmentSource);

            int indexSelected = 0;
            int j = 1;

            List<string> SourceList = new List<string>();

            string str = " ";
            foreach (var item in data)
            {
                if (item.Id_Source == m)
                {
                    str += "<option value='" + item.Id_Source + "' selected>";
                    str += item.Nama_Source + "</option>";
                    indexSelected = j;
                }
                else
                {
                    str += "<option value='" + item.Id_Source + "'>";
                    str += item.Nama_Source + "</option>";
                }

                SourceList.Add(Convert.ToString(item.Id_Source));
                SourceList.Add(item.Nama_Source);
                j++;
            }

            return (str);

        }



        //Tampilan Tabel Data pada Admin Input
        public IActionResult MenuAdminInput()
        {
            // disable browser's back button and and if somebody try to login by paste the url of any user account page, he can't.
            //nonaktifkan tombol kembali browser dan dan jika seseorang mencoba masuk dengan menempelkan url halaman akun pengguna mana pun, dia tidak bisa.
            //if (HttpContext.Session.GetInt32("Role") == null)
            //{
            //   return RedirectToAction("Index", "Home");
            //}

            //if (User.Identity == true)
            //{
            //    Response.Redirect("The Page you want");
            //}

            //else
            //    Response.Redirect("Login.aspx"); // redirect it to your login page

            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeList = new List<Employee>();
            var data = _dbemployeeContext.TblEmployees.Where (m => m.AdminApproval == 0 || m.AdminApproval == -1).ToList();
            
            //var data = _dbemployeeContext.TblEmployees.ToList();
            foreach (var item in data)
            {
                //Track untuk GradeLevel
                int a = Convert.ToInt32(item.JobprofileGradeOrlevel);
                string NmGradeLevel = "";
                if (a == 0)
                {
                    NmGradeLevel = "-";
                }
                else
                {
                    var NamaGradeLevel = _dbemployeeContext.TblGradeLevels.Where(m => m.Id_GradeLevel == a).FirstOrDefault();
                    NmGradeLevel = NamaGradeLevel.Nama_GradeLevel;
                }
                   


                //track untuk JobTitle
                int b = Convert.ToInt32(item.JobprofileJobTitle);
                string NmJobTitle = "";
                if (b == 0)
                {
                    NmJobTitle = "-";
                }else
                {
                    var NamaJobTitle = _dbemployeeContext.TblJobTitles.Where(m => m.Id_JobTitle == b).FirstOrDefault();
                    NmJobTitle = NamaJobTitle.Nama_JobTitle;
                }

                //track untuk LaborType
                int c = Convert.ToInt32(item.JobprofileLaborType);
                string NmLaborType = "";
                if (c == 0)
                {
                    NmLaborType = "-";
                }
                else
                {
                    var NamaLaborType = _dbemployeeContext.TblLaborTypes.Where(m => m.Id_LaborType == c).FirstOrDefault();
                    NmLaborType = NamaLaborType.Nama_LaborType;
                }

                //track untuk JobPost
                int d = Convert.ToInt32(item.JobprofileDivision);
                string NmDepartment = "";
                if (d == 0)
                {
                    NmDepartment = "-";
                }
                else
                {
                    var NamaDepart = _dbemployeeContext.TblDivisions.Where(m => m.Id_Division == d).FirstOrDefault();
                    NmDepartment = NamaDepart.Nama_Division;
                }

                //track untuk  total service by permanent
                int n = Convert.ToInt32 (item.EmploymentstatusTotalserviceyearsbypermanent);
                string totaltahunbypermanent = "";
                if (n == -1)
                {
                    totaltahunbypermanent = "-";
                }
                else
                {
                    totaltahunbypermanent = n.ToString();
                }


                //1. Handling null values in datetime BasicinfoDateofBirth
                if (item.BasicinfoDateofBirth != null)
                {
                    item.BasicinfoDateofBirth = item.BasicinfoDateofBirth;
                }else
                {
                    item.BasicinfoDateofBirth = DateTime.MaxValue;
                }

                //2. Handling null values in datetime EmploymentstatusJoinDate
                if (item.EmploymentstatusJoinDate != null)
                {
                    item.EmploymentstatusJoinDate = item.EmploymentstatusJoinDate;
                }
                else
                {
                    item.EmploymentstatusJoinDate = DateTime.MaxValue;
                }

                //3. Handling null values in datetime (DateTime)item.EmploymentstatusC1start
                if (item.EmploymentstatusC1start != null)
                {
                    item.EmploymentstatusC1start = item.EmploymentstatusC1start;
                }
                else
                {
                    item.EmploymentstatusC1start = DateTime.MaxValue;
                }

                //4. Handling null values in datetime (DateTime)item.EmploymentstatusC1start
                if (item.EmploymentstatusC1end != null)
                {
                    item.EmploymentstatusC1end = item.EmploymentstatusC1end;
                }
                else
                {
                    item.EmploymentstatusC1end = DateTime.MaxValue;
                }

                //5. Handling null values in datetime (DateTime)item.EmploymentstatusC2start
                if (item.EmploymentstatusC2start != null)
                {
                    item.EmploymentstatusC2start = item.EmploymentstatusC2start;
                }
                else
                {
                    item.EmploymentstatusC2start = DateTime.MaxValue;
                }

                //6. Handling null values in datetime (DateTime)item.EmploymentstatusC2end
                if (item.EmploymentstatusC2end != null)
                {
                    item.EmploymentstatusC2end = item.EmploymentstatusC2end;
                }
                else
                {
                    item.EmploymentstatusC2end = DateTime.MaxValue;
                }


                //7. Handling null values in datetime (DateTime)item.EmploymentstatusC3start
                if (item.EmploymentstatusC3start != null)
                {
                    item.EmploymentstatusC3start = item.EmploymentstatusC3start;
                }
                else
                {
                    item.EmploymentstatusC3start = DateTime.MaxValue;
                }


                //8. Handling null values in datetime (DateTime)item.EmploymentstatusC3end
                if (item.EmploymentstatusC3end != null)
                {
                    item.EmploymentstatusC3end = item.EmploymentstatusC3end;
                }
                else
                {
                    item.EmploymentstatusC3end = DateTime.MaxValue;
                }

                //9. Handling null values in datetime (DateTime)item.EmploymentstatusPermanentstartdate
                if (item.EmploymentstatusPermanentstartdate != null)
                {
                    item.EmploymentstatusPermanentstartdate = item.EmploymentstatusPermanentstartdate;
                }
                else
                {
                    item.EmploymentstatusPermanentstartdate = DateTime.MaxValue;
                }

                //10. Handling null values in datetime (DateTime)item.FamilyDetails_DateOfBirth_1
                if (item.FamilyDetails_DateOfBirth_1 != null)
                {
                    item.FamilyDetails_DateOfBirth_1 = item.FamilyDetails_DateOfBirth_1;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_1 = DateTime.MaxValue;
                }

                //11. Handling null values in datetime(DateTime)item.FamilyDetailsChildrenName2
                if (item.FamilyDetails_DateOfBirth_2 != null)
                {
                    item.FamilyDetails_DateOfBirth_2 = item.FamilyDetails_DateOfBirth_2;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_2 = DateTime.MaxValue;
                }

                //12. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_2
                if (item.FamilyDetails_DateOfBirth_2 != null)
                {
                    item.FamilyDetails_DateOfBirth_2 = item.FamilyDetails_DateOfBirth_2;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_2 = DateTime.MaxValue;
                }

                //13. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_3
                if (item.FamilyDetails_DateOfBirth_3 != null)
                {
                    item.FamilyDetails_DateOfBirth_3 = item.FamilyDetails_DateOfBirth_3;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_3 = DateTime.MaxValue;
                }

                //14. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_4
                if (item.FamilyDetails_DateOfBirth_4 != null)
                {
                    item.FamilyDetails_DateOfBirth_4 = item.FamilyDetails_DateOfBirth_4;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_4 = DateTime.MaxValue;
                }

                //15. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_5
                if (item.FamilyDetails_DateOfBirth_5 != null)
                {
                    item.FamilyDetails_DateOfBirth_5 = item.FamilyDetails_DateOfBirth_5;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_5 = DateTime.MaxValue;
                }

                //16. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_6
                if (item.FamilyDetails_DateOfBirth_6 != null)
                {
                    item.FamilyDetails_DateOfBirth_6 = item.FamilyDetails_DateOfBirth_6;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_6 = DateTime.MaxValue;
                }

                //17. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_7
                if (item.FamilyDetails_DateOfBirth_7 != null)
                {
                    item.FamilyDetails_DateOfBirth_7 = item.FamilyDetails_DateOfBirth_7;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_7 = DateTime.MaxValue;
                }

                //18. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_4
                if (item.FamilyDetails_DateOfBirth_8 != null)
                {
                    item.FamilyDetails_DateOfBirth_8 = item.FamilyDetails_DateOfBirth_8;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_8 = DateTime.MaxValue;
                }

                //19. Handling null values in datetime(DateTime)item.FamilyDetails_DateOfBirth_9
                if (item.FamilyDetails_DateOfBirth_9 != null)
                {
                    item.FamilyDetails_DateOfBirth_9 = item.FamilyDetails_DateOfBirth_9;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_9 = DateTime.MaxValue;
                }

                //20. Handling null values in datetime(DateTime)item. FamilyDetails_DateOfBirth_10
                if (item.FamilyDetails_DateOfBirth_10 != null)
                {
                    item.FamilyDetails_DateOfBirth_10 = item.FamilyDetails_DateOfBirth_10;
                }
                else
                {
                    item.FamilyDetails_DateOfBirth_10 = DateTime.MaxValue;
                }

                //21. Handling null values in datetime(DateTime)item.AccessPropertiesandMembershipUnionstartdate
                if (item.AccessPropertiesandMembershipUnionstartdate != null)
                {
                    item.AccessPropertiesandMembershipUnionstartdate = item.AccessPropertiesandMembershipUnionstartdate;
                }
                else
                {
                    item.AccessPropertiesandMembershipUnionstartdate = DateTime.MaxValue;
                }

                //22. Handling null values in datetime(DateTime)item.AccessPropertiesandMembershipUnionexitdate
                if (item.AccessPropertiesandMembershipUnionexitdate != null)
                {
                    item.AccessPropertiesandMembershipUnionexitdate = item.AccessPropertiesandMembershipUnionexitdate;
                }
                else
                {
                    item.AccessPropertiesandMembershipUnionexitdate = DateTime.MaxValue;
                }

                //23. Handling null values in datetime(DateTime)item.ExitInformationLastPhysicalDate
                if (item.ExitInformationLastPhysicalDate != null)
                {
                    item.ExitInformationLastPhysicalDate = item.ExitInformationLastPhysicalDate;
                }
                else
                {
                    item.ExitInformationLastPhysicalDate = DateTime.MaxValue;
                }

                //24. Handling null values in datetime(DateTime)item.ExitInformationEffectiveDate
                if (item.ExitInformationEffectiveDate != null)
                {
                    item.ExitInformationEffectiveDate = item.ExitInformationEffectiveDate;
                }
                else
                {
                    item.ExitInformationEffectiveDate = DateTime.MaxValue;
                }

            

                employeeModel.EmployeeList.Add(new Employee
                {
                    Id = item.Id, //berfungsi untuk update, berdasarkan Id
                    Basicinfo_LOCALID = item.BasicinfoLocalid,
                    Basicinfo_GLOBALID = item.BasicinfoGlobalid,
                    Basicinfo_FULLNAME = item.BasicinfoFullname,
                    Basicinfo_Gender = item.BasicinfoGender,
                    Basicinfo_PHOTO = item.BasicinfoPhoto,
                    Basicinfo_PlaceofBirth = item.BasicinfoPlaceofBirth,
                    Basicinfo_DateofBirth = (DateTime)item.BasicinfoDateofBirth,
                    Basicinfo_Religion = item.BasicinfoReligion,
                    Basicinfo_Nationality = item.BasicinfoNationality,
                    Employmentstatus_EmploymentType = item.EmploymentstatusEmploymentType,
                    Employmentstatus_JoinDate = (DateTime)item.EmploymentstatusJoinDate,
                    Employmentstatus_C1START = (DateTime)item.EmploymentstatusC1start,
                    Employmentstatus_C1END = (DateTime)item.EmploymentstatusC1end,
                    Employmentstatus_C2START = (DateTime)item.EmploymentstatusC2start,
                    Employmentstatus_C2END = (DateTime)item.EmploymentstatusC2end,
                    Employmentstatus_C3START = (DateTime)item.EmploymentstatusC3start,
                    Employmentstatus_C3END = (DateTime)item.EmploymentstatusC3end,
                    Employmentstatus_PERMANENTSTARTDATE = (DateTime)item.EmploymentstatusPermanentstartdate,
                    Employmentstatus_EMPLOYEESTATUS = item.EmploymentstatusEmployeestatus,
                    Employmentstatus_TOTALSERVICEYEARSBYJOIN = item.EmploymentstatusTotalserviceyearsbyjoin,
                    Employmentstatus_TOTALSERVICEYEARSBYPERMANENT = item.EmploymentstatusTotalserviceyearsbypermanent,
                    //Jobprofile_JobTitle = item.JobprofileJobTitle,
                    Jobprofile_JobTitle = NmJobTitle,
                    //Jobprofile_GradeORLevel = item.JobprofileGradeOrlevel,
                    Jobprofile_GradeORLevel = NmGradeLevel,
                    Jobprofile_ProductivityType = item.JobprofileProductivityType,
                    Jobprofile_JobFunction = item.JobprofileJobFunction,
                    Jobprofile_WorkCitizenship = item.JobprofileWorkCitizenship,
                    Jobprofile_LaborType = NmLaborType,
                    Jobprofile_LaborClass = item.JobprofileLaborClass,
                    Jobprofile_Department = item.JobprofileDepartment,
                    Jobprofile_CostCenter = item.JobprofileCostCenter,
                    Jobprofile_Division = NmDepartment,
                    Jobprofile_WorkLotORPlant = item.JobprofileWorkLotOrplant,
                    Jobprofile_SupervisorID = item.JobprofileSupervisorId,
                    Jobprofile_SupervisorName = item.JobprofileSupervisorName,
                    Jobprofile_ShiftPattern = item.JobprofileShiftPattern,
                    Recruitment_MethodofRecruitment = item.RecruitmentMethodofRecruitment,
                    Recruitment_Source = item.RecruitmentSource,
                    Recruitment_RecruitmentPlace = item.RecruitmentRecruitmentPlace,
                    Recruitment_RequisitionNumber = item.RecruitmentRequisitionNumber,
                    Education_Education1 = item.EducationEducation1,
                    Education_FieldofStudy1 = item.EducationFieldofStudy1,
                    Education_InstitutionName1 = item.EducationInstitutionName1,
                    Education_YearofGraduate1 = item.EducationYearofGraduate1,
                    Education_Education2 = item.EducationEducation2,
                    Education_FieldofStudy2 = item.EducationFieldofStudy2,
                    Education_InstitutionName2 = item.EducationInstitutionName2,
                    Education_YearofGraduate2 = item.EducationYearofGraduate2,
                    IdentityandAccount_NIK = item.IdentityandAccountNik,
                    IdentityandAccount_NoBPJSKes = item.IdentityandAccountNoBpjskes,
                    IdentityandAccount_NoBPJSTK = item.IdentityandAccountNoBpjstk,
                    IdentityandAccount_NoPassport = item.IdentityandAccountNoPassport,
                    IdentityandAccount_BankAccount = item.IdentityandAccountBankAccount,
                    IdentityandAccount_NoNPWP = item.IdentityandAccountNoNpwp,
                    IdentityandAccount_TaxStatus = item.IdentityandAccountTaxStatus,
                    ContactandAddress_MobilePhoneNo = item.ContactandAddressMobilePhoneNo,
                    ContactandAddress_PersonalEmailAccount = item.ContactandAddressPersonalEmailAccount,
                    ContactandAddress_CurrentAddress = item.ContactandAddressCurrentAddress,
                    ContactandAddress_CurrentRegionKelurahan = item.ContactandAddressCurrentRegionKelurahan,
                    ContactandAddress_CurrentRegionKecamatan = item.ContactandAddressCurrentRegionKecamatan,
                    ContactandAddress_CurrentCity = item.ContactandAddressCurrentCity,
                    ContactandAddress_KTPAddress = item.ContactandAddressKtpaddress,
                    ContactandAddress_KTPDistrict1Kelurahan = item.ContactandAddressKtpdistrict1Kelurahan,
                    ContactandAddress_KTPDistrict2Kecamatan = item.ContactandAddressKtpdistrict2Kecamatan,
                    ContactandAddress_KTPCity = item.ContactandAddressKtpcity,
                    ContactandAddress_HometownAddress = item.ContactandAddressHometownAddress,
                    ContactandAddress_HowetownCity = item.ContactandAddressHowetownCity,
                    ContactandAddress_DormitoryStatus = item.ContactandAddressDormitoryStatus,
                    ContactandAddress_DormitoryNo = item.ContactandAddressDormitoryNo,
                    FamilyDetails_KKNo = item.FamilyDetailsKkno,
                    FamilyDetails_MarritalStatus = item.FamilyDetailsMarritalStatus,
                    FamilyDetails_SpouseName = item.FamilyDetailsSpouseName,
                    FamilyDetails_NoOfChildren = item.FamilyDetailsNoOfChildren,
                    FamilyDetails_ChildrenName_1 = item.FamilyDetailsChildrenName1,
                    FamilyDetails_DateOfBirth_1 = (DateTime) item.FamilyDetails_DateOfBirth_1,                
                    FamilyDetails_ChildrenName_2 = item.FamilyDetailsChildrenName2,
                    FamilyDetails_DateOfBirth_2 = (DateTime)item.FamilyDetails_DateOfBirth_2,
                    FamilyDetails_ChildrenName_3 = item.FamilyDetailsChildrenName3,
                    FamilyDetails_DateOfBirth_3 = (DateTime)item.FamilyDetails_DateOfBirth_3,
                    FamilyDetails_ChildrenName_4 = item.FamilyDetailsChildrenName4,
                    FamilyDetails_DateOfBirth_4 = (DateTime) item.FamilyDetails_DateOfBirth_4,                  
                    FamilyDetails_ChildrenName_5 = item.FamilyDetailsChildrenName5,
                    FamilyDetails_DateOfBirth_5 = (DateTime) item.FamilyDetails_DateOfBirth_5,
                    FamilyDetails_ChildrenName_6 = item.FamilyDetailsChildrenName6,
                    FamilyDetails_DateOfBirth_6 = (DateTime) item.FamilyDetails_DateOfBirth_6,
                    FamilyDetails_ChildrenName_7 = item.FamilyDetailsChildrenName7,
                    FamilyDetails_DateOfBirth_7 = (DateTime) item.FamilyDetails_DateOfBirth_7,                 
                    FamilyDetails_ChildrenName_8 = item.FamilyDetailsChildrenName8,
                    FamilyDetails_DateOfBirth_8 = (DateTime) item.FamilyDetails_DateOfBirth_8,
                    FamilyDetails_ChildrenName_9 = item.FamilyDetailsChildrenName9,
                    FamilyDetails_DateOfBirth_9 = (DateTime) item.FamilyDetails_DateOfBirth_9,
                    FamilyDetails_ChildrenName_10 = item.FamilyDetailsChildrenName10,
                    FamilyDetails_DateOfBirth_10 = (DateTime) item.FamilyDetails_DateOfBirth_10,
                    EmergencyContact_Name = item.EmergencyContactName,
                    EmergencyContact_Relationship = item.EmergencyContactRelationship,
                    EmergencyContact_MobilePhoneNo = item.EmergencyContactMobilePhoneNo,
                    EmergencyContact_CurrentAddress = item.EmergencyContactCurrentAddress,
                    EmergencyContact_CurrentCity = item.EmergencyContactCurrentCity,
                    Access_PropertiesandMembership_WorkEmailAccount = item.AccessPropertiesandMembershipWorkEmailAccount,
                    Access_PropertiesandMembership_ProximityCardID = item.AccessPropertiesandMembershipProximityCardId,
                    Access_PropertiesandMembership_AccessDoorID = item.AccessPropertiesandMembershipAccessDoorId,
                    Access_PropertiesandMembership_ParkingAccess = item.AccessPropertiesandMembershipParkingAccess,
                    Access_PropertiesandMembership_LockerID = item.AccessPropertiesandMembershipLockerId,
                    Access_PropertiesandMembership_CompanySIMCardID = item.AccessPropertiesandMembershipCompanySimcardId,
                    Access_PropertiesandMembership_CompanyPhone = item.AccessPropertiesandMembershipCompanyPhone,
                    Access_PropertiesandMembership_CooperativeMembership = item.AccessPropertiesandMembershipCooperativeMembership,
                    Access_PropertiesandMembership_UNIONMEMBERSHIP = item.AccessPropertiesandMembershipUnionmembership,
                    Access_PropertiesandMembership_UNIONSTARTDATE = (DateTime)item.AccessPropertiesandMembershipUnionstartdate,
                    Access_PropertiesandMembership_UNIONEXITDATE = (DateTime)item.AccessPropertiesandMembershipUnionexitdate,
                    Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS = item.AccessPropertiesandMembershipUnionmembershipstatus,
                    ExitInformation_TypeofExit = item.ExitInformationTypeofExit,
                    ExitInformation_LastPhysicalDate = (DateTime)item.ExitInformationLastPhysicalDate,
                    ExitInformation_EffectiveDate = (DateTime)item.ExitInformationEffectiveDate,
                    ExitInformation_ReasonofLeaving = item.ExitInformationReasonofLeaving,
                    ExitInformation_Eligibletorehire = item.ExitInformationEligibletorehire,
                    AdminApproval = item.AdminApproval

                });
            }
            //ViewBag.Message = employeeModel;
            
            //string ss = ShowNomor(1);
            //ViewBag.ss = ss;
            //ViewData["Jumlah"] = employeeModel.EmployeeList.Count;
            return View(employeeModel);

        }

        //Tampilan /view Tabel Data dihalaman Admin View
        public IActionResult MenuAdminView()
        {
            // disable browser's back button and and if somebody try to login by paste the url of any user account page, he can't.
            //nonaktifkan tombol kembali browser dan dan jika seseorang mencoba masuk dengan menempelkan url halaman akun pengguna mana pun, dia tidak bisa.
            if (HttpContext.Session.GetInt32("Role") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeList = new List<Employee>();
            var data = _dbemployeeContext.TblEmployees.Where(m => m.AdminApproval == 1 || m.AdminApproval == 2 || m.AdminApproval == 3).ToList();
            //var data = _dbemployeeContext.TblEmployees.ToList();
            foreach (var item in data)
            {
                //Track untuk GradeLevel
                int a = Convert.ToInt32(item.JobprofileGradeOrlevel);
                string NmGradeLevel = "";
                if (a == 0)
                {
                    NmGradeLevel = "-";
                }
                else
                {
                    var NamaGradeLevel = _dbemployeeContext.TblGradeLevels.Where(m => m.Id_GradeLevel == a).FirstOrDefault();
                    NmGradeLevel = NamaGradeLevel.Nama_GradeLevel;
                }



                //track untuk JobTitle
                int b = Convert.ToInt32(item.JobprofileJobTitle);
                string NmJobTitle = "";
                if (b == 0)
                {
                    NmJobTitle = "-";
                }
                else
                {
                    var NamaJobTitle = _dbemployeeContext.TblJobTitles.Where(m => m.Id_JobTitle == b).FirstOrDefault();
                    NmJobTitle = NamaJobTitle.Nama_JobTitle;
                }

                //track untuk LaborType
                int c = Convert.ToInt32(item.JobprofileLaborType);
                string NmLaborType = "";
                if (c == 0)
                {
                    NmLaborType = "-";
                }
                else
                {
                    var NamaLaborType = _dbemployeeContext.TblLaborTypes.Where(m => m.Id_LaborType == c).FirstOrDefault();
                    NmLaborType = NamaLaborType.Nama_LaborType;
                }

                //track untuk JobPost
                int d = Convert.ToInt32(item.JobprofileDepartment);
                string NmJobPost = "";
                if (d == 0)
                {
                    NmJobPost = "-";
                }
                else
                {
                    var NamaJobPost = _dbemployeeContext.TblJobPosts.Where(m => m.Id_JobPost == d).FirstOrDefault();
                    NmJobPost = NamaJobPost.Nama_JobPost;
                }

                employeeModel.EmployeeList.Add(new Employee
                {
                    Id = item.Id,
                    Basicinfo_LOCALID = item.BasicinfoLocalid,
                    Basicinfo_GLOBALID = item.BasicinfoGlobalid,
                    Basicinfo_FULLNAME = item.BasicinfoFullname,
                    Basicinfo_Gender = item.BasicinfoGender,
                    Basicinfo_PHOTO = item.BasicinfoPhoto,
                    Basicinfo_PlaceofBirth = item.BasicinfoPlaceofBirth,
                    Basicinfo_DateofBirth = (DateTime)item.BasicinfoDateofBirth,
                    Basicinfo_Religion = item.BasicinfoReligion,
                    Basicinfo_Nationality = item.BasicinfoNationality,
                    Employmentstatus_EmploymentType = item.EmploymentstatusEmploymentType,
                    Employmentstatus_JoinDate = (DateTime)item.EmploymentstatusJoinDate,
                    Employmentstatus_C1START = (DateTime)item.EmploymentstatusC1start,
                    Employmentstatus_C1END = (DateTime)item.EmploymentstatusC1end,
                    Employmentstatus_C2START = (DateTime)item.EmploymentstatusC2start,
                    Employmentstatus_C2END = (DateTime)item.EmploymentstatusC2end,
                    Employmentstatus_C3START = (DateTime)item.EmploymentstatusC3start,
                    Employmentstatus_C3END = (DateTime)item.EmploymentstatusC3end,
                    Employmentstatus_PERMANENTSTARTDATE = (DateTime)item.EmploymentstatusPermanentstartdate,
                    Employmentstatus_EMPLOYEESTATUS = item.EmploymentstatusEmployeestatus,
                    Employmentstatus_TOTALSERVICEYEARSBYJOIN = item.EmploymentstatusTotalserviceyearsbyjoin,
                    Employmentstatus_TOTALSERVICEYEARSBYPERMANENT = item.EmploymentstatusTotalserviceyearsbypermanent,
                    Jobprofile_JobTitle = NmJobTitle,
                    Jobprofile_GradeORLevel = NmGradeLevel,
                    Jobprofile_ProductivityType = item.JobprofileProductivityType,
                    Jobprofile_JobFunction = item.JobprofileJobFunction,
                    Jobprofile_WorkCitizenship = item.JobprofileWorkCitizenship,
                    Jobprofile_LaborType = NmLaborType,
                    Jobprofile_LaborClass = item.JobprofileLaborClass,
                    Jobprofile_Department = NmJobPost,
                    Jobprofile_CostCenter = item.JobprofileCostCenter,
                    Jobprofile_Division = item.JobprofileDivision,
                    Jobprofile_WorkLotORPlant = item.JobprofileWorkLotOrplant,
                    Jobprofile_SupervisorID = item.JobprofileSupervisorId,
                    Jobprofile_SupervisorName = item.JobprofileSupervisorName,
                    Jobprofile_ShiftPattern = item.JobprofileShiftPattern,
                    Recruitment_MethodofRecruitment = item.RecruitmentMethodofRecruitment,
                    Recruitment_Source = item.RecruitmentSource,
                    Recruitment_RecruitmentPlace = item.RecruitmentRecruitmentPlace,
                    Recruitment_RequisitionNumber = item.RecruitmentRequisitionNumber,
                    Education_Education1 = item.EducationEducation1,
                    Education_FieldofStudy1 = item.EducationFieldofStudy1,
                    Education_InstitutionName1 = item.EducationInstitutionName1,
                    Education_YearofGraduate1 = item.EducationYearofGraduate1,
                    Education_Education2 = item.EducationEducation2,
                    Education_FieldofStudy2 = item.EducationFieldofStudy2,
                    Education_InstitutionName2 = item.EducationInstitutionName2,
                    Education_YearofGraduate2 = item.EducationYearofGraduate2,
                    IdentityandAccount_NIK = item.IdentityandAccountNik,
                    IdentityandAccount_NoBPJSKes = item.IdentityandAccountNoBpjskes,
                    IdentityandAccount_NoBPJSTK = item.IdentityandAccountNoBpjstk,
                    IdentityandAccount_NoPassport = item.IdentityandAccountNoPassport,
                    IdentityandAccount_BankAccount = item.IdentityandAccountBankAccount,
                    IdentityandAccount_NoNPWP = item.IdentityandAccountNoNpwp,
                    IdentityandAccount_TaxStatus = item.IdentityandAccountTaxStatus,
                    ContactandAddress_MobilePhoneNo = item.ContactandAddressMobilePhoneNo,
                    ContactandAddress_PersonalEmailAccount = item.ContactandAddressPersonalEmailAccount,
                    ContactandAddress_CurrentAddress = item.ContactandAddressCurrentAddress,
                    ContactandAddress_CurrentRegionKelurahan = item.ContactandAddressCurrentRegionKelurahan,
                    ContactandAddress_CurrentRegionKecamatan = item.ContactandAddressCurrentRegionKecamatan,
                    ContactandAddress_CurrentCity = item.ContactandAddressCurrentCity,
                    ContactandAddress_KTPAddress = item.ContactandAddressKtpaddress,
                    ContactandAddress_KTPDistrict1Kelurahan = item.ContactandAddressKtpdistrict1Kelurahan,
                    ContactandAddress_KTPDistrict2Kecamatan = item.ContactandAddressKtpdistrict2Kecamatan,
                    ContactandAddress_KTPCity = item.ContactandAddressKtpcity,
                    ContactandAddress_HometownAddress = item.ContactandAddressHometownAddress,
                    ContactandAddress_HowetownCity = item.ContactandAddressHowetownCity,
                    ContactandAddress_DormitoryStatus = item.ContactandAddressDormitoryStatus,
                    ContactandAddress_DormitoryNo = item.ContactandAddressDormitoryNo,
                    FamilyDetails_KKNo = item.FamilyDetailsKkno,
                    FamilyDetails_MarritalStatus = item.FamilyDetailsMarritalStatus,
                    FamilyDetails_SpouseName = item.FamilyDetailsSpouseName,
                    FamilyDetails_NoOfChildren = item.FamilyDetailsNoOfChildren,
                    FamilyDetails_ChildrenName_1 = item.FamilyDetailsChildrenName1,
                    FamilyDetails_ChildrenName_2 = item.FamilyDetailsChildrenName2,
                    FamilyDetails_ChildrenName_3 = item.FamilyDetailsChildrenName3,
                    EmergencyContact_Name = item.EmergencyContactName,
                    EmergencyContact_Relationship = item.EmergencyContactRelationship,
                    EmergencyContact_MobilePhoneNo = item.EmergencyContactMobilePhoneNo,
                    EmergencyContact_CurrentAddress = item.EmergencyContactCurrentAddress,
                    EmergencyContact_CurrentCity = item.EmergencyContactCurrentCity,
                    Access_PropertiesandMembership_WorkEmailAccount = item.AccessPropertiesandMembershipWorkEmailAccount,
                    Access_PropertiesandMembership_ProximityCardID = item.AccessPropertiesandMembershipProximityCardId,
                    Access_PropertiesandMembership_AccessDoorID = item.AccessPropertiesandMembershipAccessDoorId,
                    Access_PropertiesandMembership_ParkingAccess = item.AccessPropertiesandMembershipParkingAccess,
                    Access_PropertiesandMembership_LockerID = item.AccessPropertiesandMembershipLockerId,
                    Access_PropertiesandMembership_CompanySIMCardID = item.AccessPropertiesandMembershipCompanySimcardId,
                    Access_PropertiesandMembership_CompanyPhone = item.AccessPropertiesandMembershipCompanyPhone,
                    Access_PropertiesandMembership_CooperativeMembership = item.AccessPropertiesandMembershipCooperativeMembership,
                    Access_PropertiesandMembership_UNIONMEMBERSHIP = item.AccessPropertiesandMembershipUnionmembership,
                    Access_PropertiesandMembership_UNIONSTARTDATE = (DateTime)item.AccessPropertiesandMembershipUnionstartdate,
                    Access_PropertiesandMembership_UNIONEXITDATE = (DateTime)item.AccessPropertiesandMembershipUnionexitdate,
                    Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS = item.AccessPropertiesandMembershipUnionmembershipstatus,
                    ExitInformation_TypeofExit = item.ExitInformationTypeofExit,
                    ExitInformation_LastPhysicalDate = (DateTime)item.ExitInformationLastPhysicalDate,
                    ExitInformation_EffectiveDate = (DateTime)item.ExitInformationEffectiveDate,
                    ExitInformation_ReasonofLeaving = item.ExitInformationReasonofLeaving,
                    ExitInformation_Eligibletorehire = item.ExitInformationEligibletorehire,
                    AdminApproval = item.AdminApproval

                });
            }
            //ViewBag.Message = employeeModel;
            //ViewData["Jumlah"] = employeeModel.EmployeeList.Count;
            return View(employeeModel);

        }

        //Get Save Data Input
        [HttpGet]
        public IActionResult SaveDataInput(/*int defaultGradeLevelId = 1*/)
        {
            Employee employee = new Employee();

            //view bag Grade/Level
             List<TblGradeLevel> listgradelevel = _dbemployeeContext.TblGradeLevels.ToList();
             ViewBag.listgradelevel = new SelectList(listgradelevel, "Id_GradeLevel", "Nama_GradeLevel");

            //View bag Division
            List<TblDivision> listdivision = _dbemployeeContext.TblDivisions.ToList();
            ViewBag.listdivision = new SelectList(listdivision, "Id_Division", "Nama_Division");

            //View bag MethodOfRecruitment
            List<TblMethodOfRecruitment> ListMethodOfRecruitment = _dbemployeeContext.TblMethodOfRecruitments.ToList();
            ViewBag.ListMethodOfRecruitment = new SelectList(ListMethodOfRecruitment, "Id_MethodOfRecruitment", "Nama_MethodOfRecruitment");

            //View bag ProductivityType
            List<TblProductivityType> listProductivityType = _dbemployeeContext.TblProductivityTypes.ToList();
            ViewBag.listProductivityType = new SelectList(listProductivityType, "Id_ProductivityType", "Nama_ProductivityType");

            //View bag JobFunction
            List<TblJobFunction> listJobFunction = _dbemployeeContext.TblJobFunctions.ToList();
            ViewBag.listJobFunction = new SelectList(listJobFunction, "Id_JobFunction", "Nama_JobFunction");

            //View bag WorkOrPlant
            List<TblWorkLotOrPlant> listWorkLotOrPlant = _dbemployeeContext.TblWorkOrPlants.ToList();
            ViewBag.listWorkLotOrPlant = new SelectList(listWorkLotOrPlant, "Id_WorkLotOrPlant", "Nama_WorkLotOrPlant");

            //modelview.employee = employee; 
            //modelview.gradeLevel_JobProfileModels = model;
            return View(employee);
        }

        //Post Save Data input
        [HttpPost] 
        public IActionResult SaveDataInput(Employee employee, IFormFile file)
        {
            //try
            //{
                int uploadfoto = 0;

                //Save The Picture In folder
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(contentPath, "wwwroot", "images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                    if (file != null)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        uploadfoto = 1;

                    //Bind Picture info to model
                    employee.Basicinfo_PHOTO = file.FileName;

                    // If upload photo?
                    if (uploadfoto == 1)
                        {
                            employee.Basicinfo_PHOTO = file.FileName;
                        }        
                    }

                var employeedata = new TblEmployee()
                {

                    BasicinfoLocalid = employee.Basicinfo_LOCALID,
                    BasicinfoGlobalid = employee.Basicinfo_GLOBALID,
                    BasicinfoFullname = employee.Basicinfo_FULLNAME,
                    BasicinfoGender = employee.Basicinfo_Gender,
                    BasicinfoPhoto = employee.Basicinfo_PHOTO,
                    BasicinfoPlaceofBirth = employee.Basicinfo_PlaceofBirth,
                    BasicinfoDateofBirth = employee.Basicinfo_DateofBirth,
                    BasicinfoReligion = employee.Basicinfo_Religion,
                    BasicinfoNationality = employee.Basicinfo_Nationality,
                    EmploymentstatusEmploymentType = employee.Employmentstatus_EmploymentType,
                    EmploymentstatusJoinDate = employee.Employmentstatus_JoinDate,
                    EmploymentstatusC1start = employee.Employmentstatus_C1START,
                    EmploymentstatusC1end = employee.Employmentstatus_C1END,
                    EmploymentstatusC2start = employee.Employmentstatus_C2START,
                    EmploymentstatusC2end = employee.Employmentstatus_C2END,
                    EmploymentstatusC3start = employee.Employmentstatus_C3START,
                    EmploymentstatusC3end = employee.Employmentstatus_C3END,
                    EmploymentstatusPermanentstartdate = employee.Employmentstatus_PERMANENTSTARTDATE,
                    EmploymentstatusEmployeestatus = employee.Employmentstatus_EMPLOYEESTATUS,
                    //EmploymentstatusTotalserviceyearsbyjoin = idiffday,
                    //EmploymentstatusTotalserviceyearsbypermanent = pDdiffday,
                    JobprofileJobTitle = employee.Jobprofile_JobTitle,
                    JobprofileGradeOrlevel = employee.Jobprofile_GradeORLevel,
                    JobprofileProductivityType = employee.Jobprofile_ProductivityType,
                    JobprofileJobFunction = employee.Jobprofile_JobFunction,
                    JobprofileWorkCitizenship = employee.Jobprofile_WorkCitizenship,
                    JobprofileLaborType = employee.Jobprofile_LaborType,
                    JobprofileLaborClass = employee.Jobprofile_LaborClass,
                    JobprofileDepartment = employee.Jobprofile_Department,
                    JobprofileCostCenter = employee.Jobprofile_CostCenter,
                    JobprofileDivision = employee.Jobprofile_Division,
                    JobprofileWorkLotOrplant = employee.Jobprofile_WorkLotORPlant,
                    JobprofileSupervisorId = employee.Jobprofile_SupervisorID,
                    JobprofileSupervisorName = employee.Jobprofile_SupervisorName,
                    JobprofileShiftPattern = employee.Jobprofile_ShiftPattern,
                    RecruitmentMethodofRecruitment = employee.Recruitment_MethodofRecruitment,
                    RecruitmentSource = employee.Recruitment_Source,
                    RecruitmentRecruitmentPlace = employee.Recruitment_RecruitmentPlace,
                    RecruitmentRequisitionNumber = employee.Recruitment_RequisitionNumber,
                    EducationEducation1 = employee.Education_Education1,
                    EducationFieldofStudy1 = employee.Education_FieldofStudy1,
                    EducationInstitutionName1 = employee.Education_InstitutionName1,
                    EducationYearofGraduate1 = employee.Education_YearofGraduate1,
                    EducationEducation2 = employee.Education_Education2,
                    EducationFieldofStudy2 = employee.Education_FieldofStudy2,
                    EducationInstitutionName2 = employee.Education_InstitutionName2,
                    EducationYearofGraduate2 = employee.Education_YearofGraduate2,
                    IdentityandAccountNik = employee.IdentityandAccount_NIK,
                    IdentityandAccountNoBpjskes = employee.IdentityandAccount_NoBPJSKes,
                    IdentityandAccountNoBpjstk = employee.IdentityandAccount_NoBPJSTK,
                    IdentityandAccountNoPassport = employee.IdentityandAccount_NoPassport,
                    IdentityandAccountBankAccount = employee.IdentityandAccount_BankAccount,
                    IdentityandAccountNoNpwp = employee.IdentityandAccount_NoNPWP,
                    IdentityandAccountTaxStatus = employee.IdentityandAccount_TaxStatus,
                    ContactandAddressMobilePhoneNo = employee.ContactandAddress_MobilePhoneNo,
                    ContactandAddressPersonalEmailAccount = employee.ContactandAddress_PersonalEmailAccount,
                    ContactandAddressCurrentAddress = employee.ContactandAddress_CurrentAddress,
                    ContactandAddressCurrentRegionKelurahan = employee.ContactandAddress_CurrentRegionKelurahan,
                    ContactandAddressCurrentRegionKecamatan = employee.ContactandAddress_CurrentRegionKecamatan,
                    ContactandAddressCurrentCity = employee.ContactandAddress_CurrentCity,
                    ContactandAddressKtpaddress = employee.ContactandAddress_KTPAddress,
                    ContactandAddressKtpdistrict1Kelurahan = employee.ContactandAddress_KTPDistrict1Kelurahan,
                    ContactandAddressKtpdistrict2Kecamatan = employee.ContactandAddress_KTPDistrict2Kecamatan,
                    ContactandAddressKtpcity = employee.ContactandAddress_KTPCity,
                    ContactandAddressHometownAddress = employee.ContactandAddress_HometownAddress,
                    ContactandAddressHowetownCity = employee.ContactandAddress_HowetownCity,
                    ContactandAddressDormitoryStatus = employee.ContactandAddress_DormitoryStatus,
                    ContactandAddressDormitoryNo = employee.ContactandAddress_DormitoryNo,
                    FamilyDetailsKkno = employee.FamilyDetails_KKNo,
                    FamilyDetailsMarritalStatus = employee.FamilyDetails_MarritalStatus,
                    FamilyDetailsSpouseName = employee.FamilyDetails_SpouseName,
                    FamilyDetailsNoOfChildren = employee.FamilyDetails_NoOfChildren,
                    FamilyDetailsChildrenName1 = employee.FamilyDetails_ChildrenName_1,
                    FamilyDetails_DateOfBirth_1 = employee.FamilyDetails_DateOfBirth_1,
                    FamilyDetailsChildrenName2 = employee.FamilyDetails_ChildrenName_2,
                    FamilyDetails_DateOfBirth_2 = employee.FamilyDetails_DateOfBirth_2,
                    FamilyDetailsChildrenName3 = employee.FamilyDetails_ChildrenName_3,
                    FamilyDetails_DateOfBirth_3 = employee.FamilyDetails_DateOfBirth_3,
                    FamilyDetailsChildrenName4 = employee.FamilyDetails_ChildrenName_4,
                    FamilyDetails_DateOfBirth_4 = employee.FamilyDetails_DateOfBirth_4,
                    FamilyDetailsChildrenName5 = employee.FamilyDetails_ChildrenName_5,
                    FamilyDetails_DateOfBirth_5 = employee.FamilyDetails_DateOfBirth_5,
                    FamilyDetailsChildrenName6 = employee.FamilyDetails_ChildrenName_6,
                    FamilyDetails_DateOfBirth_6 = employee.FamilyDetails_DateOfBirth_6,
                    FamilyDetailsChildrenName7 = employee.FamilyDetails_ChildrenName_7,
                    FamilyDetails_DateOfBirth_7 = employee.FamilyDetails_DateOfBirth_7,
                    FamilyDetailsChildrenName8 = employee.FamilyDetails_ChildrenName_8,
                    FamilyDetails_DateOfBirth_8 = employee.FamilyDetails_DateOfBirth_8,
                    FamilyDetailsChildrenName9 = employee.FamilyDetails_ChildrenName_9,
                    FamilyDetails_DateOfBirth_9 = employee.FamilyDetails_DateOfBirth_9,
                    FamilyDetailsChildrenName10 = employee.FamilyDetails_ChildrenName_10,
                    FamilyDetails_DateOfBirth_10 = employee.FamilyDetails_DateOfBirth_10,
                    EmergencyContactName = employee.EmergencyContact_Name,
                    EmergencyContactRelationship = employee.EmergencyContact_Relationship,
                    EmergencyContactMobilePhoneNo = employee.EmergencyContact_MobilePhoneNo,
                    EmergencyContactCurrentAddress = employee.EmergencyContact_CurrentAddress,
                    EmergencyContactCurrentCity = employee.EmergencyContact_CurrentCity,
                    AccessPropertiesandMembershipWorkEmailAccount = employee.Access_PropertiesandMembership_WorkEmailAccount,
                    AccessPropertiesandMembershipProximityCardId = employee.Access_PropertiesandMembership_ProximityCardID,
                    AccessPropertiesandMembershipAccessDoorId = employee.Access_PropertiesandMembership_AccessDoorID,
                    AccessPropertiesandMembershipParkingAccess = employee.Access_PropertiesandMembership_ParkingAccess,
                    AccessPropertiesandMembershipLockerId = employee.Access_PropertiesandMembership_LockerID,
                    AccessPropertiesandMembershipCompanySimcardId = employee.Access_PropertiesandMembership_CompanySIMCardID,
                    AccessPropertiesandMembershipCompanyPhone = employee.Access_PropertiesandMembership_CompanyPhone,
                    AccessPropertiesandMembershipCooperativeMembership = employee.Access_PropertiesandMembership_CooperativeMembership,
                    AccessPropertiesandMembershipUnionmembership = employee.Access_PropertiesandMembership_UNIONMEMBERSHIP,
                    AccessPropertiesandMembershipUnionstartdate = employee.Access_PropertiesandMembership_UNIONSTARTDATE,
                    AccessPropertiesandMembershipUnionexitdate = employee.Access_PropertiesandMembership_UNIONEXITDATE,
                    AccessPropertiesandMembershipUnionmembershipstatus = employee.Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS,
                    ExitInformationTypeofExit = employee.ExitInformation_TypeofExit,
                    ExitInformationLastPhysicalDate = employee.ExitInformation_LastPhysicalDate,
                    ExitInformationEffectiveDate = employee.ExitInformation_EffectiveDate,
                    ExitInformationReasonofLeaving = employee.ExitInformation_ReasonofLeaving,
                    ExitInformationEligibletorehire = employee.ExitInformation_Eligibletorehire,
                    AdminApproval = 0


                };

                _dbemployeeContext.TblEmployees.Add(employeedata);

                //Simpan data ke Log, Jenis nya adalah add data karyawan baru
                var str_log = "BasicinfoLocalid = " + employeedata.BasicinfoLocalid + "," +
                 "BasicinfoGlobalid = " + employeedata.BasicinfoGlobalid + "," +
                 " BasicinfoFullname = " + employeedata.BasicinfoFullname + "," +
                 " BasicinfoGender = " + employeedata.BasicinfoGender + "," +
                 " BasicinfoPhoto = " + employeedata.BasicinfoPhoto + "," +
                 " BasicinfoPlaceofBirth = " + employeedata.BasicinfoPlaceofBirth + "," +
                 " BasicinfoDateofBirth = " + employeedata.BasicinfoDateofBirth.ToString() + "," +
                 " BasicinfoReligion = " + employeedata.BasicinfoReligion + "," +
                 " BasicinfoNationality = " + employeedata.BasicinfoNationality + "," +
                 " EmploymentstatusEmploymentType = " + employeedata.EmploymentstatusEmploymentType + "," +
                 " EmploymentstatusJoinDate = " + employeedata.EmploymentstatusJoinDate.ToString() + "," +
                 " EmploymentstatusC1start = " + employeedata.EmploymentstatusC1start.ToString() + "," +
                 " EmploymentstatusC1end = " + employeedata.EmploymentstatusC1end.ToString() + "," +
                 " EmploymentstatusC2start = " + employeedata.EmploymentstatusC2start.ToString() + "," +
                 " EmploymentstatusC2end = " + employeedata.EmploymentstatusC2end.ToString() + "," +
                 " EmploymentstatusC3start = " + employeedata.EmploymentstatusC3start.ToString() + "," +
                 " EmploymentstatusC3end = " + employeedata.EmploymentstatusC3end.ToString() + "," +
                 " EmploymentstatusPermanentstartdate = " + employeedata.EmploymentstatusPermanentstartdate.ToString() + "," +
                 " EmploymentstatusEmployeestatus = " + employeedata.EmploymentstatusEmployeestatus + "," +
                 " EmploymentstatusTotalserviceyearsbyjoin = " + employeedata.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                 " EmploymentstatusTotalserviceyearsbypermanent = " + employeedata.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                 " JobprofileJobTitle = " + employeedata.JobprofileJobTitle + "," +
                 " JobprofileGradeOrlevel = " + employeedata.JobprofileGradeOrlevel + "," +
                 " JobprofileProductivityType = " + employeedata.JobprofileProductivityType + "," +
                 " JobprofileJobFunction = " + employeedata.JobprofileJobFunction + "," +
                 " JobprofileWorkCitizenship = " + employeedata.JobprofileWorkCitizenship + "," +
                 " JobprofileLaborType = " + employeedata.JobprofileLaborType + "," +
                 " JobprofileLaborClass = " + employeedata.JobprofileLaborClass + "," +
                 " JobprofileDepartment = " + employeedata.JobprofileDepartment + "," +
                 " JobprofileCostCenter = " + employeedata.JobprofileCostCenter + "," +
                 " JobprofileDivision = " + employeedata.JobprofileDivision + "," +
                 " JobprofileWorkLotOrplant = " + employeedata.JobprofileWorkLotOrplant + "," +
                 " JobprofileSupervisorId = " + employeedata.JobprofileSupervisorId + "," +
                 " JobprofileSupervisorName = " + employeedata.JobprofileSupervisorName + "," +
                 " JobprofileShiftPattern = " + employeedata.JobprofileShiftPattern + "," +
                 " RecruitmentMethodofRecruitment = " + employeedata.RecruitmentMethodofRecruitment + "," +
                 " RecruitmentSource = " + employeedata.RecruitmentSource + "," +
                 " RecruitmentRecruitmentPlace = " + employeedata.RecruitmentRecruitmentPlace + "," +
                 " RecruitmentRequisitionNumber = " + employeedata.RecruitmentRequisitionNumber + "," +
                 " EducationEducation1 = " + employeedata.EducationEducation1 + "," +
                 " EducationFieldofStudy1 = " + employeedata.EducationFieldofStudy1 + "," +
                 " EducationInstitutionName1 = " + employeedata.EducationInstitutionName1 + "," +
                 " EducationYearofGraduate1 = " + employeedata.EducationYearofGraduate1.ToString() + "," +
                 " EducationEducation2 = " + employeedata.EducationEducation2 + "," +
                 " EducationFieldofStudy2 = " + employeedata.EducationFieldofStudy2 + "," +
                 " EducationInstitutionName2 = " + employeedata.EducationInstitutionName2 + "," +
                 " EducationYearofGraduate2 = " + employeedata.EducationYearofGraduate2.ToString() + "," +
                 " IdentityandAccountNik = " + employeedata.IdentityandAccountNik + "," +
                 " IdentityandAccountNoBpjskes = " + employeedata.IdentityandAccountNoBpjskes + "," +
                 " IdentityandAccountNoBpjstk = " + employeedata.IdentityandAccountNoBpjstk + "," +
                 " IdentityandAccountNoPassport = " + employeedata.IdentityandAccountNoPassport + "," +
                 " IdentityandAccountBankAccount = " + employeedata.IdentityandAccountBankAccount + "," +
                 " IdentityandAccountNoNpwp = " + employeedata.IdentityandAccountNoNpwp + "," +
                 " IdentityandAccountTaxStatus = " + employeedata.IdentityandAccountTaxStatus + "," +
                 " ContactandAddressMobilePhoneNo = " + employeedata.ContactandAddressMobilePhoneNo + "," +
                 " ContactandAddressPersonalEmailAccount = " + employeedata.ContactandAddressPersonalEmailAccount + "," +
                 " ContactandAddressCurrentAddress = " + employeedata.ContactandAddressCurrentAddress + "," +
                 " ContactandAddressCurrentRegionKelurahan = " + employeedata.ContactandAddressCurrentRegionKelurahan + "," +
                 " ContactandAddressCurrentRegionKecamatan = " + employeedata.ContactandAddressCurrentRegionKecamatan + "," +
                 " ContactandAddressCurrentCity = " + employeedata.ContactandAddressCurrentCity + "," +
                 " ContactandAddressKtpaddress = " + employeedata.ContactandAddressKtpaddress + "," +
                 " ContactandAddressKtpdistrict1Kelurahan = " + employeedata.ContactandAddressKtpdistrict1Kelurahan + "," +
                 " ContactandAddressKtpdistrict2Kecamatan = " + employeedata.ContactandAddressKtpdistrict2Kecamatan + "," +
                 " ContactandAddressKtpcity = " + employeedata.ContactandAddressKtpcity + "," +
                 " ContactandAddressHometownAddress = " + employeedata.ContactandAddressHometownAddress + "," +
                 " ContactandAddressHowetownCity = " + employeedata.ContactandAddressHowetownCity + "," +
                 " ContactandAddressDormitoryStatus = " + employeedata.ContactandAddressDormitoryStatus + "," +
                 " ContactandAddressDormitoryNo = " + employeedata.ContactandAddressDormitoryNo + "," +
                 " FamilyDetailsKkno = " + employeedata.FamilyDetailsKkno + "," +
                 " FamilyDetailsMarritalStatus = " + employeedata.FamilyDetailsMarritalStatus + "," +
                 " FamilyDetailsSpouseName = " + employeedata.FamilyDetailsSpouseName + "," +
                 " FamilyDetailsNoOfChildren = " + employeedata.FamilyDetailsNoOfChildren.ToString() + "," +
                 " FamilyDetailsChildrenName1 = " + employeedata.FamilyDetailsChildrenName1 + "," +
                 " FamilyDetailsChildrenName2 = " + employeedata.FamilyDetailsChildrenName2 + "," +
                 " FamilyDetailsChildrenName3 = " + employeedata.FamilyDetailsChildrenName3 + "," +
                 " EmergencyContactName = " + employeedata.EmergencyContactName + "," +
                 " EmergencyContactRelationship = " + employeedata.EmergencyContactRelationship + "," +
                 " EmergencyContactMobilePhoneNo = " + employeedata.EmergencyContactMobilePhoneNo + "," +
                 " EmergencyContactCurrentAddress = " + employeedata.EmergencyContactCurrentAddress + "," +
                 " EmergencyContactCurrentCity = " + employeedata.EmergencyContactCurrentCity + "," +
                 " AccessPropertiesandMembershipWorkEmailAccount = " + employeedata.AccessPropertiesandMembershipWorkEmailAccount + "," +
                 " AccessPropertiesandMembershipProximityCardId = " + employeedata.AccessPropertiesandMembershipProximityCardId + "," +
                 " AccessPropertiesandMembershipAccessDoorId = " + employeedata.AccessPropertiesandMembershipAccessDoorId + "," +
                 " AccessPropertiesandMembershipParkingAccess = " + employeedata.AccessPropertiesandMembershipParkingAccess + "," +
                 " AccessPropertiesandMembershipLockerId = " + employeedata.AccessPropertiesandMembershipLockerId + "," +
                 " AccessPropertiesandMembershipCompanySimcardId = " + employeedata.AccessPropertiesandMembershipCompanySimcardId + "," +
                 " AccessPropertiesandMembershipCompanyPhone = " + employeedata.AccessPropertiesandMembershipCompanyPhone + "," +
                 " AccessPropertiesandMembershipCooperativeMembership = " + employeedata.AccessPropertiesandMembershipCooperativeMembership + "," +
                 " AccessPropertiesandMembershipUnionmembership = " + employeedata.AccessPropertiesandMembershipUnionmembership + "," +
                 " AccessPropertiesandMembershipUnionstartdate = " + employeedata.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                 " AccessPropertiesandMembershipUnionexitdate = " + employeedata.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                 " AccessPropertiesandMembershipUnionmembershipstatus = " + employeedata.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                 " ExitInformationTypeofExit = " + employeedata.ExitInformationTypeofExit + "," +
                 " ExitInformationLastPhysicalDate = " + employeedata.ExitInformationLastPhysicalDate.ToString() + "," +
                 " ExitInformationEffectiveDate = " + employeedata.ExitInformationEffectiveDate.ToString() + "," +
                 " ExitInformationReasonofLeaving = " + employeedata.ExitInformationReasonofLeaving + "," +
                 " ExitInformationEligibletorehire = " + employeedata.ExitInformationEligibletorehire;


                var datalog = new Tbllog()
                {
                    Username = "AdminInput",
                    JenisOperasi = "Input Data Karyawan Baru",
                    Tanggal = DateTime.Now,
                    Isi = str_log,
                };

                _dbemployeeContext.Tbllog.Add(datalog);
                _dbemployeeContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            //}
            //catch
            //{
                //TempData["UpdateStatus"] = 0;
            //}

        
            return RedirectToAction("MenuAdminInput", "Home");
    
        }

        //Get Update Data untuk Admin Input
        //Update.Input
        [HttpGet]
        public IActionResult Update( int IdEm = 0)
        {
            Employee employee = new Employee();
            var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == IdEm).FirstOrDefault();

            //Difference day Service By Join
            var today = DateTime.Now;
            int yeartoday = today.Year;
            DateTime yearJoinDate = (DateTime)data.EmploymentstatusJoinDate;
            int yjd = yearJoinDate.Year;
            int idiffday = yeartoday - yjd;


            //Difference day Service By Permanent
            int pDdiffday;
            try
            {
                DateTime permanentDate = (DateTime)data.EmploymentstatusPermanentstartdate;
                int pD = permanentDate.Year;
                pDdiffday = yeartoday - pD;
            }
            catch
            {
                pDdiffday = -1;
            };

            int totaltahunbypermanent;
            totaltahunbypermanent = pDdiffday;

            //view bag Grade/Level
            List<TblGradeLevel> listgradelevel = _dbemployeeContext.TblGradeLevels.ToList();
            ViewBag.listgradelevel = new SelectList(listgradelevel, "Id_GradeLevel", "Nama_GradeLevel");

            //View bag Division
            List<TblDivision> listdivision = _dbemployeeContext.TblDivisions.ToList();
            ViewBag.listdivision = new SelectList(listdivision, "Id_Division", "Nama_Division");
           
            //View bag MethodOfRecruitment
            List<TblMethodOfRecruitment> ListMethodOfRecruitment = _dbemployeeContext.TblMethodOfRecruitments.ToList();
            ViewBag.ListMethodOfRecruitment = new SelectList(ListMethodOfRecruitment, "Id_MethodOfRecruitment", "Nama_MethodOfRecruitment");

            //View bag ProductivityType
            List<TblProductivityType> listProductivityType = _dbemployeeContext.TblProductivityTypes.ToList();
            ViewBag.listProductivityType = new SelectList(listProductivityType, "Id_ProductivityType", "Nama_ProductivityType");

            //View bag JobFunction
            List<TblJobFunction> listJobFunction = _dbemployeeContext.TblJobFunctions.ToList();
            ViewBag.listJobFunction = new SelectList(listJobFunction, "Id_JobFunction", "Nama_JobFunction");

            //View bag WorkOrPlant
            List<TblWorkLotOrPlant> listWorkLotOrPlant = _dbemployeeContext.TblWorkOrPlants.ToList();
            ViewBag.listWorkLotOrPlant = new SelectList(listWorkLotOrPlant, "Id_WorkLotOrPlant", "Nama_WorkLotOrPlant");

            //1. Handling null values in datetime BasicinfoDateofBirth
            if (data.BasicinfoDateofBirth != null)
            {
                data.BasicinfoDateofBirth = data.BasicinfoDateofBirth;
            }
            else
            {
                data.BasicinfoDateofBirth = DateTime.MaxValue;
            }

            //2. Handling null values in datetime EmploymentstatusJoinDate
            if (data.EmploymentstatusJoinDate != null)
            {
                data.EmploymentstatusJoinDate = data.EmploymentstatusJoinDate;
            }
            else
            {
                data.EmploymentstatusJoinDate = DateTime.MaxValue;
            }

            //3. Handling null values in datetime (DateTime)data.EmploymentstatusC1start
            if (data.EmploymentstatusC1start != null)
            {
                data.EmploymentstatusC1start = data.EmploymentstatusC1start;
            }
            else
            {
                data.EmploymentstatusC1start = DateTime.MaxValue;
            }

            //4. Handling null values in datetime (DateTime)data.EmploymentstatusC1start
            if (data.EmploymentstatusC1end != null)
            {
                data.EmploymentstatusC1end = data.EmploymentstatusC1end;
            }
            else
            {
                data.EmploymentstatusC1end = DateTime.MaxValue;
            }

            //5. Handling null values in datetime (DateTime)data.EmploymentstatusC2start
            if (data.EmploymentstatusC2start != null)
            {
                data.EmploymentstatusC2start = data.EmploymentstatusC2start;
            }
            else
            {
                data.EmploymentstatusC2start = DateTime.MaxValue;
            }

            //6. Handling null values in datetime (DateTime)data.EmploymentstatusC2end
            if (data.EmploymentstatusC2end != null)
            {
                data.EmploymentstatusC2end = data.EmploymentstatusC2end;
            }
            else
            {
                data.EmploymentstatusC2end = DateTime.MaxValue;
            }


            //7. Handling null values in datetime (DateTime)data.EmploymentstatusC3start
            if (data.EmploymentstatusC3start != null)
            {
                data.EmploymentstatusC3start = data.EmploymentstatusC3start;
            }
            else
            {
                data.EmploymentstatusC3start = DateTime.MaxValue;
            }


            //8. Handling null values in datetime (DateTime)data.EmploymentstatusC3end
            if (data.EmploymentstatusC3end != null)
            {
                data.EmploymentstatusC3end = data.EmploymentstatusC3end;
            }
            else
            {
                data.EmploymentstatusC3end = DateTime.MaxValue;
            }

            //9. Handling null values in datetime (DateTime)data.EmploymentstatusPermanentstartdate
            if (data.EmploymentstatusPermanentstartdate != null)
            {
                data.EmploymentstatusPermanentstartdate = data.EmploymentstatusPermanentstartdate;
            }
            else
            {
                data.EmploymentstatusPermanentstartdate = DateTime.MaxValue;
            }

            //10. Handling null values in datetime (DateTime)data.FamilyDetails_DateOfBirth_1
            if (data.FamilyDetails_DateOfBirth_1 != null)
            {
                data.FamilyDetails_DateOfBirth_1 = data.FamilyDetails_DateOfBirth_1;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_1 = DateTime.MaxValue;
            }

            //11. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_2
            if (data.FamilyDetails_DateOfBirth_2 != null)
            {
                data.FamilyDetails_DateOfBirth_2 = data.FamilyDetails_DateOfBirth_2;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_2 = DateTime.MaxValue;
            }

            //12. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_3
            if (data.FamilyDetails_DateOfBirth_3 != null)
            {
                data.FamilyDetails_DateOfBirth_3 = data.FamilyDetails_DateOfBirth_3;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_3 = DateTime.MaxValue;
            }

            //13. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_4
            if (data.FamilyDetails_DateOfBirth_4 != null)
            {
                data.FamilyDetails_DateOfBirth_4 = data.FamilyDetails_DateOfBirth_4;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_4 = DateTime.MaxValue;
            }

            //14. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_5
            if (data.FamilyDetails_DateOfBirth_5 != null)
            {
                data.FamilyDetails_DateOfBirth_5 = data.FamilyDetails_DateOfBirth_5;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_5 = DateTime.MaxValue;
            }

            //15. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_6
            if (data.FamilyDetails_DateOfBirth_6 != null)
            {
                data.FamilyDetails_DateOfBirth_6 = data.FamilyDetails_DateOfBirth_6;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_6 = DateTime.MaxValue;
            }

            //16. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_7
            if (data.FamilyDetails_DateOfBirth_7 != null)
            {
                data.FamilyDetails_DateOfBirth_7 = data.FamilyDetails_DateOfBirth_7;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_7 = DateTime.MaxValue;
            }

            //17. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_4
            if (data.FamilyDetails_DateOfBirth_8 != null)
            {
                data.FamilyDetails_DateOfBirth_8 = data.FamilyDetails_DateOfBirth_8;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_8 = DateTime.MaxValue;
            }

            //18. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_9
            if (data.FamilyDetails_DateOfBirth_9 != null)
            {
                data.FamilyDetails_DateOfBirth_9 = data.FamilyDetails_DateOfBirth_9;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_9 = DateTime.MaxValue;
            }

            //19. Handling null values in datetime(DateTime)data. FamilyDetails_DateOfBirth_10
            if (data.FamilyDetails_DateOfBirth_10 != null)
            {
                data.FamilyDetails_DateOfBirth_10 = data.FamilyDetails_DateOfBirth_10;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_10 = DateTime.MaxValue;
            }

            //20. Handling null values in datetime(DateTime)data.AccessPropertiesandMembershipUnionstartdate
            if (data.AccessPropertiesandMembershipUnionstartdate != null)
            {
                data.AccessPropertiesandMembershipUnionstartdate = data.AccessPropertiesandMembershipUnionstartdate;
            }
            else
            {
                data.AccessPropertiesandMembershipUnionstartdate = DateTime.MaxValue;
            }

            //21. Handling null values in datetime(DateTime)data.AccessPropertiesandMembershipUnionexitdate
            if (data.AccessPropertiesandMembershipUnionexitdate != null)
            {
                data.AccessPropertiesandMembershipUnionexitdate = data.AccessPropertiesandMembershipUnionexitdate;
            }
            else
            {
                data.AccessPropertiesandMembershipUnionexitdate = DateTime.MaxValue;
            }

            //22. Handling null values in datetime(DateTime)data.ExitInformationLastPhysicalDate
            if (data.ExitInformationLastPhysicalDate != null)
            {
                data.ExitInformationLastPhysicalDate = data.ExitInformationLastPhysicalDate;
            }
            else
            {
                data.ExitInformationLastPhysicalDate = DateTime.MaxValue;
            }

            //23. Handling null values in datetime(DateTime)data.ExitInformationEffectiveDate
            if (data.ExitInformationEffectiveDate != null)
            {
                data.ExitInformationEffectiveDate = data.ExitInformationEffectiveDate;
            }
            else
            {
                data.ExitInformationEffectiveDate = DateTime.MaxValue;
            }


            if (data != null)
            {
                employee.Id = data.Id;
                employee.Basicinfo_LOCALID = data.BasicinfoLocalid;
                employee.Basicinfo_GLOBALID = data.BasicinfoGlobalid;
                employee.Basicinfo_FULLNAME = data.BasicinfoFullname;
                employee.Basicinfo_Gender = data.BasicinfoGender;
                employee.Basicinfo_PHOTO = data.BasicinfoPhoto;
                employee.Basicinfo_PlaceofBirth = data.BasicinfoPlaceofBirth;
                employee.Basicinfo_DateofBirth = (DateTime) data.BasicinfoDateofBirth;
                employee.Basicinfo_Religion = data.BasicinfoReligion;
                employee.Basicinfo_Nationality = data.BasicinfoNationality;
                employee.Employmentstatus_EmploymentType = data.EmploymentstatusEmploymentType;
                employee.Employmentstatus_JoinDate = (DateTime) data.EmploymentstatusJoinDate;
                employee.Employmentstatus_C1START = (DateTime) data.EmploymentstatusC1start;
                employee.Employmentstatus_C1END = (DateTime) data.EmploymentstatusC1end;
                employee.Employmentstatus_C2START = (DateTime) data.EmploymentstatusC2start;
                employee.Employmentstatus_C2END = (DateTime) data.EmploymentstatusC2end;
                employee.Employmentstatus_C3START = (DateTime) data.EmploymentstatusC3start;
                employee.Employmentstatus_C3END = (DateTime) data.EmploymentstatusC3end;
                employee.Employmentstatus_PERMANENTSTARTDATE = (DateTime) data.EmploymentstatusPermanentstartdate;
                employee.Employmentstatus_EMPLOYEESTATUS = data.EmploymentstatusEmployeestatus;
                employee.Employmentstatus_TOTALSERVICEYEARSBYJOIN = idiffday;
                employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT = totaltahunbypermanent;
                employee.Jobprofile_JobTitle = data.JobprofileJobTitle;
                employee.Jobprofile_GradeORLevel = data.JobprofileGradeOrlevel;
                employee.Jobprofile_ProductivityType = data.JobprofileProductivityType;
                employee.Jobprofile_JobFunction = data.JobprofileJobFunction;
                employee.Jobprofile_WorkCitizenship = data.JobprofileWorkCitizenship;
                employee.Jobprofile_LaborType = data.JobprofileLaborType;
                employee.Jobprofile_LaborClass = data.JobprofileLaborClass;
                employee.Jobprofile_Department = data.JobprofileDepartment;
                employee.Jobprofile_CostCenter = data.JobprofileCostCenter;
                employee.Jobprofile_Division = data.JobprofileDivision;
                employee.Jobprofile_WorkLotORPlant = data.JobprofileWorkLotOrplant;
                employee.Jobprofile_SupervisorID = data.JobprofileSupervisorId;
                employee.Jobprofile_SupervisorName = data.JobprofileSupervisorName;
                employee.Jobprofile_ShiftPattern = data.JobprofileShiftPattern;
                employee.Recruitment_MethodofRecruitment = data.RecruitmentMethodofRecruitment;
                employee.Recruitment_Source = data.RecruitmentSource;
                employee.Recruitment_RecruitmentPlace = data.RecruitmentRecruitmentPlace;
                employee.Recruitment_RequisitionNumber = data.RecruitmentRequisitionNumber;
                employee.Education_Education1 = data.EducationEducation1;
                employee.Education_FieldofStudy1 = data.EducationFieldofStudy1;
                employee.Education_InstitutionName1 = data.EducationInstitutionName1;
                employee.Education_YearofGraduate1 = data.EducationYearofGraduate1;
                employee.Education_Education2 = data.EducationEducation2;
                employee.Education_FieldofStudy2 = data.EducationFieldofStudy2;
                employee.Education_InstitutionName2 = data.EducationInstitutionName2;
                employee.Education_YearofGraduate2 = data.EducationYearofGraduate2;
                employee.IdentityandAccount_NIK = data.IdentityandAccountNik;
                employee.IdentityandAccount_NoBPJSKes = data.IdentityandAccountNoBpjskes;
                employee.IdentityandAccount_NoBPJSTK = data.IdentityandAccountNoBpjstk;
                employee.IdentityandAccount_NoPassport = data.IdentityandAccountNoPassport;
                employee.IdentityandAccount_BankAccount = data.IdentityandAccountBankAccount;
                employee.IdentityandAccount_NoNPWP = data.IdentityandAccountNoNpwp;
                employee.IdentityandAccount_TaxStatus = data.IdentityandAccountTaxStatus;
                employee.ContactandAddress_MobilePhoneNo = data.ContactandAddressMobilePhoneNo;
                employee.ContactandAddress_PersonalEmailAccount = data.ContactandAddressPersonalEmailAccount;
                employee.ContactandAddress_CurrentAddress = data.ContactandAddressCurrentAddress;
                employee.ContactandAddress_CurrentRegionKelurahan = data.ContactandAddressCurrentRegionKelurahan;
                employee.ContactandAddress_CurrentRegionKecamatan = data.ContactandAddressCurrentRegionKecamatan;
                employee.ContactandAddress_CurrentCity = data.ContactandAddressCurrentCity;
                employee.ContactandAddress_KTPAddress = data.ContactandAddressKtpaddress;
                employee.ContactandAddress_KTPDistrict1Kelurahan = data.ContactandAddressKtpdistrict1Kelurahan;
                employee.ContactandAddress_KTPDistrict2Kecamatan = data.ContactandAddressKtpdistrict2Kecamatan;
                employee.ContactandAddress_KTPCity = data.ContactandAddressKtpcity;
                employee.ContactandAddress_HometownAddress = data.ContactandAddressHometownAddress;
                employee.ContactandAddress_HowetownCity = data.ContactandAddressHowetownCity;
                employee.ContactandAddress_DormitoryStatus = data.ContactandAddressDormitoryStatus;
                employee.ContactandAddress_DormitoryNo = data.ContactandAddressDormitoryNo;
                employee.FamilyDetails_KKNo = data.FamilyDetailsKkno;
                employee.FamilyDetails_MarritalStatus = data.FamilyDetailsMarritalStatus;
                employee.FamilyDetails_SpouseName = data.FamilyDetailsSpouseName;
                employee.FamilyDetails_NoOfChildren = data.FamilyDetailsNoOfChildren;
                employee.FamilyDetails_ChildrenName_1 = data.FamilyDetailsChildrenName1;
                employee.FamilyDetails_DateOfBirth_1 = (DateTime) data.FamilyDetails_DateOfBirth_1;
                employee.FamilyDetails_ChildrenName_2 = data.FamilyDetailsChildrenName2;
                employee.FamilyDetails_DateOfBirth_2 = (DateTime)data.FamilyDetails_DateOfBirth_2;
                employee.FamilyDetails_ChildrenName_3 = data.FamilyDetailsChildrenName3;
                employee.FamilyDetails_DateOfBirth_3 = (DateTime)data.FamilyDetails_DateOfBirth_3;
                employee.FamilyDetails_ChildrenName_4 = data.FamilyDetailsChildrenName4;
                employee.FamilyDetails_DateOfBirth_4 = (DateTime)data.FamilyDetails_DateOfBirth_4;
                employee.FamilyDetails_ChildrenName_5 = data.FamilyDetailsChildrenName5;
                employee.FamilyDetails_DateOfBirth_5 = (DateTime)data.FamilyDetails_DateOfBirth_5;
                employee.FamilyDetails_ChildrenName_6 = data.FamilyDetailsChildrenName6;
                employee.FamilyDetails_DateOfBirth_6 = (DateTime)data.FamilyDetails_DateOfBirth_6;
                employee.FamilyDetails_ChildrenName_7 = data.FamilyDetailsChildrenName7;
                employee.FamilyDetails_DateOfBirth_7 = (DateTime)data.FamilyDetails_DateOfBirth_7;
                employee.FamilyDetails_ChildrenName_8 = data.FamilyDetailsChildrenName8;
                employee.FamilyDetails_DateOfBirth_8 = (DateTime)data.FamilyDetails_DateOfBirth_8;
                employee.FamilyDetails_ChildrenName_9 = data.FamilyDetailsChildrenName9;
                employee.FamilyDetails_DateOfBirth_9 = (DateTime)data.FamilyDetails_DateOfBirth_9;
                employee.FamilyDetails_ChildrenName_10 = data.FamilyDetailsChildrenName10;
                employee.FamilyDetails_DateOfBirth_10 = (DateTime)data.FamilyDetails_DateOfBirth_10;
                employee.EmergencyContact_Name = data.EmergencyContactName;
                employee.EmergencyContact_Relationship = data.EmergencyContactRelationship;
                employee.EmergencyContact_MobilePhoneNo = data.EmergencyContactMobilePhoneNo;
                employee.EmergencyContact_CurrentAddress = data.EmergencyContactCurrentAddress;
                employee.EmergencyContact_CurrentCity = data.EmergencyContactCurrentCity;
                employee.Access_PropertiesandMembership_WorkEmailAccount = data.AccessPropertiesandMembershipWorkEmailAccount;
                employee.Access_PropertiesandMembership_ProximityCardID = data.AccessPropertiesandMembershipProximityCardId;
                employee.Access_PropertiesandMembership_AccessDoorID = data.AccessPropertiesandMembershipAccessDoorId;
                employee.Access_PropertiesandMembership_ParkingAccess = data.AccessPropertiesandMembershipParkingAccess;
                employee.Access_PropertiesandMembership_LockerID = data.AccessPropertiesandMembershipLockerId;
                employee.Access_PropertiesandMembership_CompanySIMCardID = data.AccessPropertiesandMembershipCompanySimcardId;
                employee.Access_PropertiesandMembership_CompanyPhone = data.AccessPropertiesandMembershipCompanyPhone;
                employee.Access_PropertiesandMembership_CooperativeMembership = data.AccessPropertiesandMembershipCooperativeMembership;
                employee.Access_PropertiesandMembership_UNIONMEMBERSHIP = data.AccessPropertiesandMembershipUnionmembership;
                employee.Access_PropertiesandMembership_UNIONSTARTDATE = (DateTime)data.AccessPropertiesandMembershipUnionstartdate;
                employee.Access_PropertiesandMembership_UNIONEXITDATE = (DateTime) data.AccessPropertiesandMembershipUnionexitdate;
                employee.Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS = data.AccessPropertiesandMembershipUnionmembershipstatus;
                employee.ExitInformation_TypeofExit = data.ExitInformationTypeofExit;
                employee.ExitInformation_LastPhysicalDate = (DateTime) data.ExitInformationLastPhysicalDate;
                employee.ExitInformation_EffectiveDate = (DateTime) data.ExitInformationEffectiveDate;
                employee.ExitInformation_ReasonofLeaving = data.ExitInformationReasonofLeaving;
                employee.ExitInformation_Eligibletorehire = data.ExitInformationEligibletorehire;
            }
            return View(employee);
        }

        //Post update Data untuk halaman admin input
        [HttpPost]
        public IActionResult Update(Employee employee, IFormFile file)
        {
            //try
            //{
                int uploadfoto = 0;
                //Save The Picture In folder
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(contentPath, "wwwroot", "images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Close();
                    }

                    //Bind Picture info to model
                    employee.Basicinfo_PHOTO = file.FileName;
                    uploadfoto = 1;
                }

                //1.Handling null values in datetime Basicinfo_DateofBirth
                if (employee.Basicinfo_DateofBirth != null)
                {
                    employee.Basicinfo_DateofBirth = employee.Basicinfo_DateofBirth; 
                }
                else
                {
                    employee.Basicinfo_DateofBirth = DateTime.MaxValue;
                }

                //2.Handling null values in datetime C1 START
                if (employee.Employmentstatus_C1START != null)
                {
                    employee.Employmentstatus_C1START = employee.Employmentstatus_C1START; 
                }
                else
                {
                    employee.Employmentstatus_C1START = DateTime.MaxValue;
                }

                //3.Handling null values in datetime C1 END
                if (employee.Employmentstatus_C1END != null)
                {
                    employee.Employmentstatus_C1END = employee.Employmentstatus_C1END;
                }
                else
                {
                    employee.Employmentstatus_C1END = DateTime.MaxValue;
                }

                //4. Handling null values in datetime C2 START
                if (employee.Employmentstatus_C2START != null)
                {
                    employee.Employmentstatus_C2START = employee.Employmentstatus_C2START; //C1 START
                }
                else
                {
                    employee.Employmentstatus_C2START = DateTime.MaxValue;
                }

                //5. Handling null values in datetime C2 END
                if (employee.Employmentstatus_C2END != null)
                {
                    employee.Employmentstatus_C2END = employee.Employmentstatus_C2END; //C1 START
                }
                else
                {
                    employee.Employmentstatus_C2END = DateTime.MaxValue;
                }

                //6. Handling null values in datetime C3 START
                if (employee.Employmentstatus_C3START != null)
                {
                    employee.Employmentstatus_C3START = employee.Employmentstatus_C3START; //C1 START
                }
                else
                {
                    employee.Employmentstatus_C3START = DateTime.MaxValue;
                }

                //7. Handling null values in datetime C3 END
                if (employee.Employmentstatus_C3END != null)
                {
                    employee.Employmentstatus_C3END = employee.Employmentstatus_C3END; //C1 START
                }
                else
                {
                    employee.Employmentstatus_C3END = DateTime.MaxValue;
                }


                //8. Handling null values in datetime Employmentstatus_PERMANENTSTARTDATE
                if (employee.Employmentstatus_PERMANENTSTARTDATE != null)
                {
                    employee.Employmentstatus_PERMANENTSTARTDATE = employee.Employmentstatus_PERMANENTSTARTDATE; //C1 START
                }
                else
                {
                    employee.Employmentstatus_PERMANENTSTARTDATE = DateTime.MaxValue;
                }

                
                //9. Handling null values in datetime FamilyDetails_DateOfBirth_1
                if (employee.FamilyDetails_DateOfBirth_1 != null)
                {
                    employee.FamilyDetails_DateOfBirth_1 = employee.FamilyDetails_DateOfBirth_1; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_1 = DateTime.MaxValue;
                }

                
                //10. Handling null values in datetime FamilyDetails_DateOfBirth_2
                if (employee.FamilyDetails_DateOfBirth_2 != null)
                {
                    employee.FamilyDetails_DateOfBirth_2 = employee.FamilyDetails_DateOfBirth_2; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_2 = DateTime.MaxValue;
                }

                
                //11. Handling null values in datetime FamilyDetails_DateOfBirth_3
                if (employee.FamilyDetails_DateOfBirth_3 != null)
                {
                    employee.FamilyDetails_DateOfBirth_3 = employee.FamilyDetails_DateOfBirth_3; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_3 = DateTime.MaxValue;
                }

                
                //12. Handling null values in datetime FamilyDetails_DateOfBirth_4
                if (employee.FamilyDetails_DateOfBirth_4 != null)
                {
                    employee.FamilyDetails_DateOfBirth_4 = employee.FamilyDetails_DateOfBirth_4; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_4 = DateTime.MaxValue;
                }

                
                //13. Handling null values in datetime FamilyDetails_DateOfBirth_5
                if (employee.FamilyDetails_DateOfBirth_5 != null)
                {
                    employee.FamilyDetails_DateOfBirth_5 = employee.FamilyDetails_DateOfBirth_5; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_5 = DateTime.MaxValue;
                }

                
                //14. Handling null values in datetime FamilyDetails_DateOfBirth_6
                if (employee.FamilyDetails_DateOfBirth_6 != null)
                {
                    employee.FamilyDetails_DateOfBirth_6 = employee.FamilyDetails_DateOfBirth_6; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_6 = DateTime.MaxValue;
                }

                
                //15. Handling null values in datetime FamilyDetails_DateOfBirth_7
                if (employee.FamilyDetails_DateOfBirth_7 != null)
                {
                    employee.FamilyDetails_DateOfBirth_7 = employee.FamilyDetails_DateOfBirth_7; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_7 = DateTime.MaxValue;
                }

                
                //16. Handling null values in datetime FamilyDetails_DateOfBirth_8
                if (employee.FamilyDetails_DateOfBirth_8 != null)
                {
                    employee.FamilyDetails_DateOfBirth_8 = employee.FamilyDetails_DateOfBirth_8; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_8 = DateTime.MaxValue;
                }

                
                //17. Handling null values in datetime FamilyDetails_DateOfBirth_9
                if (employee.FamilyDetails_DateOfBirth_9 != null)
                {
                    employee.FamilyDetails_DateOfBirth_9 = employee.FamilyDetails_DateOfBirth_9; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_9 = DateTime.MaxValue;
                }

                //18. Handling null values in datetime FamilyDetails_DateOfBirth_10
                if (employee.FamilyDetails_DateOfBirth_10 != null)
                {
                    employee.FamilyDetails_DateOfBirth_10 = employee.FamilyDetails_DateOfBirth_10; //C1 START
                }
                else
                {
                    employee.FamilyDetails_DateOfBirth_10 = DateTime.MaxValue;
                }

                //19. Handling null values in datetime Access_PropertiesandMembership_UNIONSTARTDATE
                if (employee.Access_PropertiesandMembership_UNIONSTARTDATE != null)
                {
                    employee.Access_PropertiesandMembership_UNIONSTARTDATE = employee.Access_PropertiesandMembership_UNIONSTARTDATE; //C1 START
                }
                else
                {
                    employee.Access_PropertiesandMembership_UNIONSTARTDATE = DateTime.MaxValue;
                }

                //20. Handling null values in datetime Access_PropertiesandMembership_UNIONEXITDATE
                if (employee.Access_PropertiesandMembership_UNIONEXITDATE != null)
                {
                    employee.Access_PropertiesandMembership_UNIONEXITDATE = employee.Access_PropertiesandMembership_UNIONEXITDATE; //C1 START
                }
                else
                {
                    employee.Access_PropertiesandMembership_UNIONEXITDATE = DateTime.MaxValue;
                }

                //21. Handling null values in datetime ExitInformation_LastPhysicalDate
                if (employee.ExitInformation_LastPhysicalDate != null)
                {
                    employee.ExitInformation_LastPhysicalDate = employee.ExitInformation_LastPhysicalDate; //C1 START
                }
                else
                {
                    employee.ExitInformation_LastPhysicalDate = DateTime.MaxValue;
                }

                //22. Handling null values in datetime ExitInformation_EffectiveDate
                if (employee.ExitInformation_EffectiveDate != null)
                {
                    employee.ExitInformation_EffectiveDate = employee.ExitInformation_EffectiveDate; //C1 START
                }
                else
                {
                    employee.ExitInformation_EffectiveDate = DateTime.MaxValue;
                }


                //Finding the member by its Id which we would update
                var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == employee.Id).FirstOrDefault();
                data.Id = employee.Id;
                data.BasicinfoLocalid = employee.Basicinfo_LOCALID;
                data.BasicinfoGlobalid = employee.Basicinfo_GLOBALID;
                data.BasicinfoFullname = employee.Basicinfo_FULLNAME;
                data.BasicinfoGender = employee.Basicinfo_Gender;
                if (uploadfoto == 1)
                {
                    data.BasicinfoPhoto = employee.Basicinfo_PHOTO;
                }   
                data.BasicinfoPlaceofBirth = employee.Basicinfo_PlaceofBirth;
                data.BasicinfoDateofBirth = employee.Basicinfo_DateofBirth;
                data.BasicinfoReligion = employee.Basicinfo_Religion;
                data.BasicinfoNationality = employee.Basicinfo_Nationality;
                data.EmploymentstatusEmploymentType = employee.Employmentstatus_EmploymentType;
                data.EmploymentstatusJoinDate = employee.Employmentstatus_JoinDate;
                data.EmploymentstatusC1start = employee.Employmentstatus_C1START;
                data.EmploymentstatusC1end = employee.Employmentstatus_C1END;
                data.EmploymentstatusC2start = employee.Employmentstatus_C2START;
                data.EmploymentstatusC2end = employee.Employmentstatus_C2END;
                data.EmploymentstatusC3start = employee.Employmentstatus_C3START;
                data.EmploymentstatusC3end = employee.Employmentstatus_C3END;
                data.EmploymentstatusPermanentstartdate = employee.Employmentstatus_PERMANENTSTARTDATE;
                data.EmploymentstatusEmployeestatus = employee.Employmentstatus_EMPLOYEESTATUS;
                data.EmploymentstatusTotalserviceyearsbyjoin = employee.Employmentstatus_TOTALSERVICEYEARSBYJOIN;
                data.EmploymentstatusTotalserviceyearsbypermanent = employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT;
                data.JobprofileJobTitle = employee.Jobprofile_JobTitle;
                data.JobprofileGradeOrlevel = employee.Jobprofile_GradeORLevel;
                data.JobprofileProductivityType = employee.Jobprofile_ProductivityType;
                data.JobprofileJobFunction = employee.Jobprofile_JobFunction;
                data.JobprofileWorkCitizenship = employee.Jobprofile_WorkCitizenship;
                data.JobprofileLaborType = employee.Jobprofile_LaborType;
                data.JobprofileLaborClass = employee.Jobprofile_LaborClass;
                data.JobprofileDepartment = employee.Jobprofile_Department;
                data.JobprofileCostCenter = employee.Jobprofile_CostCenter;
                data.JobprofileDivision = employee.Jobprofile_Division;
                data.JobprofileWorkLotOrplant = employee.Jobprofile_WorkLotORPlant;
                data.JobprofileSupervisorId = employee.Jobprofile_SupervisorID;
                data.JobprofileSupervisorName = employee.Jobprofile_SupervisorName;
                data.JobprofileShiftPattern = employee.Jobprofile_ShiftPattern;
                data.RecruitmentMethodofRecruitment = employee.Recruitment_MethodofRecruitment;
                data.RecruitmentSource = employee.Recruitment_Source;
                data.RecruitmentRecruitmentPlace = employee.Recruitment_RecruitmentPlace;
                data.RecruitmentRequisitionNumber = employee.Recruitment_RequisitionNumber;
                data.EducationEducation1 = employee.Education_Education1;
                data.EducationFieldofStudy1 = employee.Education_FieldofStudy1;
                data.EducationInstitutionName1 = employee.Education_InstitutionName1;
                data.EducationYearofGraduate1 = employee.Education_YearofGraduate1;
                data.EducationEducation2 = employee.Education_Education2;
                data.EducationFieldofStudy2 = employee.Education_FieldofStudy2;
                data.EducationInstitutionName2 = employee.Education_InstitutionName2;
                data.EducationYearofGraduate2 = employee.Education_YearofGraduate2;
                data.IdentityandAccountNik = employee.IdentityandAccount_NIK;
                data.IdentityandAccountNoBpjskes = employee.IdentityandAccount_NoBPJSKes;
                data.IdentityandAccountNoBpjstk = employee.IdentityandAccount_NoBPJSTK;
                data.IdentityandAccountNoPassport = employee.IdentityandAccount_NoPassport;
                data.IdentityandAccountBankAccount = employee.IdentityandAccount_BankAccount;
                data.IdentityandAccountNoNpwp = employee.IdentityandAccount_NoNPWP;
                data.IdentityandAccountTaxStatus = employee.IdentityandAccount_TaxStatus;
                data.ContactandAddressMobilePhoneNo = employee.ContactandAddress_MobilePhoneNo;
                data.ContactandAddressPersonalEmailAccount = employee.ContactandAddress_PersonalEmailAccount;
                data.ContactandAddressCurrentAddress = employee.ContactandAddress_CurrentAddress;
                data.ContactandAddressCurrentRegionKelurahan = employee.ContactandAddress_CurrentRegionKelurahan;
                data.ContactandAddressCurrentRegionKecamatan = employee.ContactandAddress_CurrentRegionKecamatan;
                data.ContactandAddressCurrentCity = employee.ContactandAddress_CurrentCity;
                data.ContactandAddressKtpaddress = employee.ContactandAddress_KTPAddress;
                data.ContactandAddressKtpdistrict1Kelurahan = employee.ContactandAddress_KTPDistrict1Kelurahan;
                data.ContactandAddressKtpdistrict2Kecamatan = employee.ContactandAddress_KTPDistrict2Kecamatan;
                data.ContactandAddressKtpcity = employee.ContactandAddress_KTPCity;
                data.ContactandAddressHometownAddress = employee.ContactandAddress_HometownAddress;
                data.ContactandAddressHowetownCity = employee.ContactandAddress_HowetownCity;
                data.ContactandAddressDormitoryStatus = employee.ContactandAddress_DormitoryStatus;
                data.ContactandAddressDormitoryNo = employee.ContactandAddress_DormitoryNo;
                data.FamilyDetailsKkno = employee.FamilyDetails_KKNo;
                data.FamilyDetailsMarritalStatus = employee.FamilyDetails_MarritalStatus;
                data.FamilyDetailsSpouseName = employee.FamilyDetails_SpouseName;
                data.FamilyDetailsNoOfChildren = employee.FamilyDetails_NoOfChildren;
                data.FamilyDetailsChildrenName1 = employee.FamilyDetails_ChildrenName_1;
                data.FamilyDetails_DateOfBirth_1 = employee.FamilyDetails_DateOfBirth_1;
                data.FamilyDetailsChildrenName2 = employee.FamilyDetails_ChildrenName_2;
                data.FamilyDetails_DateOfBirth_2 = employee.FamilyDetails_DateOfBirth_2;
                data.FamilyDetailsChildrenName3 = employee.FamilyDetails_ChildrenName_3;
                data.FamilyDetails_DateOfBirth_3 = employee.FamilyDetails_DateOfBirth_3;
                data.FamilyDetailsChildrenName4 = employee.FamilyDetails_ChildrenName_4;
                data.FamilyDetails_DateOfBirth_4 = employee.FamilyDetails_DateOfBirth_4;
                data.FamilyDetailsChildrenName5 = employee.FamilyDetails_ChildrenName_5;
                data.FamilyDetails_DateOfBirth_5 = employee.FamilyDetails_DateOfBirth_5;
                data.FamilyDetailsChildrenName6 = employee.FamilyDetails_ChildrenName_6;
                data.FamilyDetails_DateOfBirth_6 = employee.FamilyDetails_DateOfBirth_6;
                data.FamilyDetailsChildrenName7 = employee.FamilyDetails_ChildrenName_7;
                data.FamilyDetails_DateOfBirth_7 = employee.FamilyDetails_DateOfBirth_7;
                data.FamilyDetailsChildrenName8 = employee.FamilyDetails_ChildrenName_8;
                data.FamilyDetails_DateOfBirth_8 = employee.FamilyDetails_DateOfBirth_8;
                data.FamilyDetailsChildrenName9 = employee.FamilyDetails_ChildrenName_9;
                data.FamilyDetails_DateOfBirth_9 = employee.FamilyDetails_DateOfBirth_9;
                data.FamilyDetailsChildrenName10 = employee.FamilyDetails_ChildrenName_10;
                data.FamilyDetails_DateOfBirth_10 = employee.FamilyDetails_DateOfBirth_10;
                data.EmergencyContactName = employee.EmergencyContact_Name;
                data.EmergencyContactRelationship = employee.EmergencyContact_Relationship;
                data.EmergencyContactMobilePhoneNo = employee.EmergencyContact_MobilePhoneNo;
                data.EmergencyContactCurrentCity = employee.EmergencyContact_CurrentAddress;
                data.EmergencyContactCurrentCity = employee.EmergencyContact_CurrentCity;
                data.AccessPropertiesandMembershipWorkEmailAccount = employee.Access_PropertiesandMembership_WorkEmailAccount;
                data.AccessPropertiesandMembershipProximityCardId = employee.Access_PropertiesandMembership_ProximityCardID;
                data.AccessPropertiesandMembershipAccessDoorId = employee.Access_PropertiesandMembership_AccessDoorID;
                data.AccessPropertiesandMembershipParkingAccess = employee.Access_PropertiesandMembership_ParkingAccess;
                data.AccessPropertiesandMembershipLockerId = employee.Access_PropertiesandMembership_LockerID;
                data.AccessPropertiesandMembershipCompanySimcardId = employee.Access_PropertiesandMembership_CompanySIMCardID;
                data.AccessPropertiesandMembershipCompanyPhone = employee.Access_PropertiesandMembership_CompanyPhone;
                data.AccessPropertiesandMembershipCooperativeMembership = employee.Access_PropertiesandMembership_CooperativeMembership;
                data.AccessPropertiesandMembershipUnionmembership = employee.Access_PropertiesandMembership_UNIONMEMBERSHIP;
                data.AccessPropertiesandMembershipUnionstartdate = employee.Access_PropertiesandMembership_UNIONSTARTDATE;
                data.AccessPropertiesandMembershipUnionexitdate = employee.Access_PropertiesandMembership_UNIONEXITDATE;
                data.AccessPropertiesandMembershipUnionmembershipstatus = employee.Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS;
                data.ExitInformationTypeofExit = employee.ExitInformation_TypeofExit;
                data.ExitInformationLastPhysicalDate = employee.ExitInformation_LastPhysicalDate;
                data.ExitInformationEffectiveDate = employee.ExitInformation_EffectiveDate;
                data.ExitInformationReasonofLeaving = employee.ExitInformation_ReasonofLeaving;
                data.ExitInformationEligibletorehire = employee.ExitInformation_Eligibletorehire;
                data.AdminApproval = 0;

                //Simpan data ke Log, Jenis nya adalah add data karyawan baru

                var str_log = "BasicinfoLocalid = " + data.BasicinfoLocalid + "," +
                "BasicinfoGlobalid = " + data.BasicinfoGlobalid + "," +
                " BasicinfoFullname = " + data.BasicinfoFullname + "," +
                " BasicinfoGender = " + data.BasicinfoGender + "," +
                " BasicinfoPhoto = " + data.BasicinfoPhoto + "," +
                " BasicinfoPlaceofBirth = " + data.BasicinfoPlaceofBirth + "," +
                " BasicinfoDateofBirth = " + data.BasicinfoDateofBirth.ToString() + "," +
                " BasicinfoReligion = " + data.BasicinfoReligion + "," +
                " BasicinfoNationality = " + data.BasicinfoNationality + "," +
                " EmploymentstatusEmploymentType = " + data.EmploymentstatusEmploymentType + "," +
                " EmploymentstatusJoinDate = " + data.EmploymentstatusJoinDate.ToString() + "," +
                " EmploymentstatusC1start = " + data.EmploymentstatusC1start.ToString() + "," +
                " EmploymentstatusC1end = " + data.EmploymentstatusC1end.ToString() + "," +
                " EmploymentstatusC2start = " + data.EmploymentstatusC2start.ToString() + "," +
                " EmploymentstatusC2end = " + data.EmploymentstatusC2end.ToString() + "," +
                " EmploymentstatusC3start = " + data.EmploymentstatusC3start.ToString() + "," +
                " EmploymentstatusC3end = " + data.EmploymentstatusC3end.ToString() + "," +
                " EmploymentstatusPermanentstartdate = " + data.EmploymentstatusPermanentstartdate.ToString() + "," +
                " EmploymentstatusEmployeestatus = " + data.EmploymentstatusEmployeestatus + "," +
                " EmploymentstatusTotalserviceyearsbyjoin = " + data.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                " EmploymentstatusTotalserviceyearsbypermanent = " + data.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                " JobprofileJobTitle = " + data.JobprofileJobTitle + "," +
                " JobprofileGradeOrlevel = " + data.JobprofileGradeOrlevel + "," +
                " JobprofileProductivityType = " + data.JobprofileProductivityType + "," +
                " JobprofileJobFunction = " + data.JobprofileJobFunction + "," +
                " JobprofileWorkCitizenship = " + data.JobprofileWorkCitizenship + "," +
                " JobprofileLaborType = " + data.JobprofileLaborType + "," +
                " JobprofileLaborClass = " + data.JobprofileLaborClass + "," +
                " JobprofileDepartment = " + data.JobprofileDepartment + "," +
                " JobprofileCostCenter = " + data.JobprofileCostCenter + "," +
                " JobprofileDivision = " + data.JobprofileDivision + "," +
                " JobprofileWorkLotOrplant = " + data.JobprofileWorkLotOrplant + "," +
                " JobprofileSupervisorId = " + data.JobprofileSupervisorId + "," +
                " JobprofileSupervisorName = " + data.JobprofileSupervisorName + "," +
                " JobprofileShiftPattern = " + data.JobprofileShiftPattern + "," +
                " RecruitmentMethodofRecruitment = " + data.RecruitmentMethodofRecruitment + "," +
                " RecruitmentSource = " + data.RecruitmentSource + "," +
                " RecruitmentRecruitmentPlace = " + data.RecruitmentRecruitmentPlace + "," +
                " RecruitmentRequisitionNumber = " + data.RecruitmentRequisitionNumber + "," +
                " EducationEducation1 = " + data.EducationEducation1 + "," +
                " EducationFieldofStudy1 = " + data.EducationFieldofStudy1 + "," +
                " EducationInstitutionName1 = " + data.EducationInstitutionName1 + "," +
                " EducationYearofGraduate1 = " + data.EducationYearofGraduate1.ToString() + "," +
                " EducationEducation2 = " + data.EducationEducation2 + "," +
                " EducationFieldofStudy2 = " + data.EducationFieldofStudy2 + "," +
                " EducationInstitutionName2 = " + data.EducationInstitutionName2 + "," +
                " EducationYearofGraduate2 = " + data.EducationYearofGraduate2.ToString() + "," +
                " IdentityandAccountNik = " + data.IdentityandAccountNik + "," +
                " IdentityandAccountNoBpjskes = " + data.IdentityandAccountNoBpjskes + "," +
                " IdentityandAccountNoBpjstk = " + data.IdentityandAccountNoBpjstk + "," +
                " IdentityandAccountNoPassport = " + data.IdentityandAccountNoPassport + "," +
                " IdentityandAccountBankAccount = " + data.IdentityandAccountBankAccount + "," +
                " IdentityandAccountNoNpwp = " + data.IdentityandAccountNoNpwp + "," +
                " IdentityandAccountTaxStatus = " + data.IdentityandAccountTaxStatus + "," +
                " ContactandAddressMobilePhoneNo = " + data.ContactandAddressMobilePhoneNo + "," +
                " ContactandAddressPersonalEmailAccount = " + data.ContactandAddressPersonalEmailAccount + "," +
                " ContactandAddressCurrentAddress = " + data.ContactandAddressCurrentAddress + "," +
                " ContactandAddressCurrentRegionKelurahan = " + data.ContactandAddressCurrentRegionKelurahan + "," +
                " ContactandAddressCurrentRegionKecamatan = " + data.ContactandAddressCurrentRegionKecamatan + "," +
                " ContactandAddressCurrentCity = " + data.ContactandAddressCurrentCity + "," +
                " ContactandAddressKtpaddress = " + data.ContactandAddressKtpaddress + "," +
                " ContactandAddressKtpdistrict1Kelurahan = " + data.ContactandAddressKtpdistrict1Kelurahan + "," +
                " ContactandAddressKtpdistrict2Kecamatan = " + data.ContactandAddressKtpdistrict2Kecamatan + "," +
                " ContactandAddressKtpcity = " + data.ContactandAddressKtpcity + "," +
                " ContactandAddressHometownAddress = " + data.ContactandAddressHometownAddress + "," +
                " ContactandAddressHowetownCity = " + data.ContactandAddressHowetownCity + "," +
                " ContactandAddressDormitoryStatus = " + data.ContactandAddressDormitoryStatus + "," +
                " ContactandAddressDormitoryNo = " + data.ContactandAddressDormitoryNo + "," +
                " FamilyDetailsKkno = " + data.FamilyDetailsKkno + "," +
                " FamilyDetailsMarritalStatus = " + data.FamilyDetailsMarritalStatus + "," +
                " FamilyDetailsSpouseName = " + data.FamilyDetailsSpouseName + "," +
                " FamilyDetailsNoOfChildren = " + data.FamilyDetailsNoOfChildren.ToString() + "," +
                " FamilyDetailsChildrenName1 = " + data.FamilyDetailsChildrenName1 + "," +
                " FamilyDetailsChildrenName2 = " + data.FamilyDetailsChildrenName2 + "," +
                " FamilyDetailsChildrenName3 = " + data.FamilyDetailsChildrenName3 + "," +
                " EmergencyContactName = " + data.EmergencyContactName + "," +
                " EmergencyContactRelationship = " + data.EmergencyContactRelationship + "," +
                " EmergencyContactMobilePhoneNo = " + data.EmergencyContactMobilePhoneNo + "," +
                " EmergencyContactCurrentAddress = " + data.EmergencyContactCurrentAddress + "," +
                " EmergencyContactCurrentCity = " + data.EmergencyContactCurrentCity + "," +
                " AccessPropertiesandMembershipWorkEmailAccount = " + data.AccessPropertiesandMembershipWorkEmailAccount + "," +
                " AccessPropertiesandMembershipProximityCardId = " + data.AccessPropertiesandMembershipProximityCardId + "," +
                " AccessPropertiesandMembershipAccessDoorId = " + data.AccessPropertiesandMembershipAccessDoorId + "," +
                " AccessPropertiesandMembershipParkingAccess = " + data.AccessPropertiesandMembershipParkingAccess + "," +
                " AccessPropertiesandMembershipLockerId = " + data.AccessPropertiesandMembershipLockerId + "," +
                " AccessPropertiesandMembershipCompanySimcardId = " + data.AccessPropertiesandMembershipCompanySimcardId + "," +
                " AccessPropertiesandMembershipCompanyPhone = " + data.AccessPropertiesandMembershipCompanyPhone + "," +
                " AccessPropertiesandMembershipCooperativeMembership = " + data.AccessPropertiesandMembershipCooperativeMembership + "," +
                " AccessPropertiesandMembershipUnionmembership = " + data.AccessPropertiesandMembershipUnionmembership + "," +
                " AccessPropertiesandMembershipUnionstartdate = " + data.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                " AccessPropertiesandMembershipUnionexitdate = " + data.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                " AccessPropertiesandMembershipUnionmembershipstatus = " + data.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                " ExitInformationTypeofExit = " + data.ExitInformationTypeofExit + "," +
                " ExitInformationLastPhysicalDate = " + data.ExitInformationLastPhysicalDate.ToString() + "," +
                " ExitInformationEffectiveDate = " + data.ExitInformationEffectiveDate.ToString() + "," +
                " ExitInformationReasonofLeaving = " + data.ExitInformationReasonofLeaving + "," +
                " ExitInformationEligibletorehire = " + data.ExitInformationEligibletorehire;


                var datalog = new Tbllog()
                {
                    Username = "AdminInput",
                    JenisOperasi = "Update Data Karyawan Baru",
                    Tanggal = DateTime.Now,
                    Isi = str_log,
                };

                _dbemployeeContext.Tbllog.Add(datalog);
                _dbemployeeContext.SaveChanges();
                TempData["UpdateStatus"] = 1;
            //}
            //catch
            //{
            //    TempData["UpdateStatus"] = 0;
            //}
            return RedirectToAction("MenuAdminInput", "Home");
        }

        //Delete Data dari halaman admin input
        [HttpGet]
        //public IActionResult Delete(string Basicinfo_LOCALID = "")
        public IActionResult Delete(int IdEm = 0)
        {

            try
            {
                //var data = _dbemployeeContext.TblEmployees.Where(m => m.BasicinfoLocalid == Basicinfo_LOCALID).FirstOrDefault();
                var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == IdEm).FirstOrDefault();
                if (data != null)
                {
                    _dbemployeeContext.TblEmployees.Remove(data);
                    _dbemployeeContext.SaveChanges();
                }

                TempData["DeleteStatus"] = 1;
            }catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "Home");
        }

        //Get Detail data di halaman admin input, admin view, dan admin operasional
        //Detail.cshtml
        [HttpGet]
        public IActionResult Detail(int IdEm = 0)
        {

            Employee employee = new Employee();
            var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == IdEm).FirstOrDefault();

            //Difference day Service By Join
            var today = DateTime.Now;
            int yeartoday = today.Year;
            DateTime yearJoinDate = (DateTime)data.EmploymentstatusJoinDate;
            int yjd = yearJoinDate.Year;
            int idiffday = yeartoday - yjd;

            //Difference day Service By Permanent
            int pDdiffday;
            try
            {
                DateTime permanentDate = (DateTime)data.EmploymentstatusPermanentstartdate;
                int pD = permanentDate.Year;
                pDdiffday = yeartoday - pD;
            }
            catch
            {
                pDdiffday = -1;
            };

            int totaltahunbypermanent;
            totaltahunbypermanent = pDdiffday;


            //view bag Grade/Level
            List<TblGradeLevel> listgradelevel = _dbemployeeContext.TblGradeLevels.ToList();
            ViewBag.listgradelevel = new SelectList(listgradelevel, "Id_GradeLevel", "Nama_GradeLevel");

            //View bag Division
            List<TblDivision> listdivision = _dbemployeeContext.TblDivisions.ToList();
            ViewBag.listdivision = new SelectList(listdivision, "Id_Division", "Nama_Division");

            //View bag MethodOfRecruitment
            List<TblMethodOfRecruitment> ListMethodOfRecruitment = _dbemployeeContext.TblMethodOfRecruitments.ToList();
            ViewBag.ListMethodOfRecruitment = new SelectList(ListMethodOfRecruitment, "Id_MethodOfRecruitment", "Nama_MethodOfRecruitment");

            //View bag ProductivityType
            List<TblProductivityType> listProductivityType = _dbemployeeContext.TblProductivityTypes.ToList();
            ViewBag.listProductivityType = new SelectList(listProductivityType, "Id_ProductivityType", "Nama_ProductivityType");

            //View bag JobFunction
            List<TblJobFunction> listJobFunction = _dbemployeeContext.TblJobFunctions.ToList();
            ViewBag.listJobFunction = new SelectList(listJobFunction, "Id_JobFunction", "Nama_JobFunction");

            //View bag WorkOrPlant
            List<TblWorkLotOrPlant> listWorkLotOrPlant = _dbemployeeContext.TblWorkOrPlants.ToList();
            ViewBag.listWorkLotOrPlant = new SelectList(listWorkLotOrPlant, "Id_WorkLotOrPlant", "Nama_WorkLotOrPlant");

            //1. Handling null values in datetime BasicinfoDateofBirth
            if (data.BasicinfoDateofBirth != null)
            {
                data.BasicinfoDateofBirth = data.BasicinfoDateofBirth;
            }
            else
            {
                data.BasicinfoDateofBirth = DateTime.MaxValue;
            }

            //2. Handling null values in datetime EmploymentstatusJoinDate
            if (data.EmploymentstatusJoinDate != null)
            {
                data.EmploymentstatusJoinDate = data.EmploymentstatusJoinDate;
            }
            else
            {
                data.EmploymentstatusJoinDate = DateTime.MaxValue;
            }

            //3. Handling null values in datetime (DateTime)data.EmploymentstatusC1start
            if (data.EmploymentstatusC1start != null)
            {
                data.EmploymentstatusC1start = data.EmploymentstatusC1start;
            }
            else
            {
                data.EmploymentstatusC1start = DateTime.MaxValue;
            }

            //4. Handling null values in datetime (DateTime)data.EmploymentstatusC1start
            if (data.EmploymentstatusC1end != null)
            {
                data.EmploymentstatusC1end = data.EmploymentstatusC1end;
            }
            else
            {
                data.EmploymentstatusC1end = DateTime.MaxValue;
            }

            //5. Handling null values in datetime (DateTime)data.EmploymentstatusC2start
            if (data.EmploymentstatusC2start != null)
            {
                data.EmploymentstatusC2start = data.EmploymentstatusC2start;
            }
            else
            {
                data.EmploymentstatusC2start = DateTime.MaxValue;
            }

            //6. Handling null values in datetime (DateTime)data.EmploymentstatusC2end
            if (data.EmploymentstatusC2end != null)
            {
                data.EmploymentstatusC2end = data.EmploymentstatusC2end;
            }
            else
            {
                data.EmploymentstatusC2end = DateTime.MaxValue;
            }


            //7. Handling null values in datetime (DateTime)data.EmploymentstatusC3start
            if (data.EmploymentstatusC3start != null)
            {
                data.EmploymentstatusC3start = data.EmploymentstatusC3start;
            }
            else
            {
                data.EmploymentstatusC3start = DateTime.MaxValue;
            }


            //8. Handling null values in datetime (DateTime)data.EmploymentstatusC3end
            if (data.EmploymentstatusC3end != null)
            {
                data.EmploymentstatusC3end = data.EmploymentstatusC3end;
            }
            else
            {
                data.EmploymentstatusC3end = DateTime.MaxValue;
            }

            //9. Handling null values in datetime (DateTime)data.EmploymentstatusPermanentstartdate
            if (data.EmploymentstatusPermanentstartdate != null)
            {
                data.EmploymentstatusPermanentstartdate = data.EmploymentstatusPermanentstartdate;
            }
            else
            {
                data.EmploymentstatusPermanentstartdate = DateTime.MaxValue;
            }

            //10. Handling null values in datetime (DateTime)data.FamilyDetails_DateOfBirth_1
            if (data.FamilyDetails_DateOfBirth_1 != null)
            {
                data.FamilyDetails_DateOfBirth_1 = data.FamilyDetails_DateOfBirth_1;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_1 = DateTime.MaxValue;
            }

            //11. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_2
            if (data.FamilyDetails_DateOfBirth_2 != null)
            {
                data.FamilyDetails_DateOfBirth_2 = data.FamilyDetails_DateOfBirth_2;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_2 = DateTime.MaxValue;
            }

            //12. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_3
            if (data.FamilyDetails_DateOfBirth_3 != null)
            {
                data.FamilyDetails_DateOfBirth_3 = data.FamilyDetails_DateOfBirth_3;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_3 = DateTime.MaxValue;
            }

            //13. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_4
            if (data.FamilyDetails_DateOfBirth_4 != null)
            {
                data.FamilyDetails_DateOfBirth_4 = data.FamilyDetails_DateOfBirth_4;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_4 = DateTime.MaxValue;
            }

            //14. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_5
            if (data.FamilyDetails_DateOfBirth_5 != null)
            {
                data.FamilyDetails_DateOfBirth_5 = data.FamilyDetails_DateOfBirth_5;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_5 = DateTime.MaxValue;
            }

            //15. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_6
            if (data.FamilyDetails_DateOfBirth_6 != null)
            {
                data.FamilyDetails_DateOfBirth_6 = data.FamilyDetails_DateOfBirth_6;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_6 = DateTime.MaxValue;
            }

            //16. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_7
            if (data.FamilyDetails_DateOfBirth_7 != null)
            {
                data.FamilyDetails_DateOfBirth_7 = data.FamilyDetails_DateOfBirth_7;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_7 = DateTime.MaxValue;
            }

            //17. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_4
            if (data.FamilyDetails_DateOfBirth_8 != null)
            {
                data.FamilyDetails_DateOfBirth_8 = data.FamilyDetails_DateOfBirth_8;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_8 = DateTime.MaxValue;
            }

            //18. Handling null values in datetime(DateTime)data.FamilyDetails_DateOfBirth_9
            if (data.FamilyDetails_DateOfBirth_9 != null)
            {
                data.FamilyDetails_DateOfBirth_9 = data.FamilyDetails_DateOfBirth_9;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_9 = DateTime.MaxValue;
            }

            //19. Handling null values in datetime(DateTime)data. FamilyDetails_DateOfBirth_10
            if (data.FamilyDetails_DateOfBirth_10 != null)
            {
                data.FamilyDetails_DateOfBirth_10 = data.FamilyDetails_DateOfBirth_10;
            }
            else
            {
                data.FamilyDetails_DateOfBirth_10 = DateTime.MaxValue;
            }

            //20. Handling null values in datetime(DateTime)data.AccessPropertiesandMembershipUnionstartdate
            if (data.AccessPropertiesandMembershipUnionstartdate != null)
            {
                data.AccessPropertiesandMembershipUnionstartdate = data.AccessPropertiesandMembershipUnionstartdate;
            }
            else
            {
                data.AccessPropertiesandMembershipUnionstartdate = DateTime.MaxValue;
            }

            //21. Handling null values in datetime(DateTime)data.AccessPropertiesandMembershipUnionexitdate
            if (data.AccessPropertiesandMembershipUnionexitdate != null)
            {
                data.AccessPropertiesandMembershipUnionexitdate = data.AccessPropertiesandMembershipUnionexitdate;
            }
            else
            {
                data.AccessPropertiesandMembershipUnionexitdate = DateTime.MaxValue;
            }

            //22. Handling null values in datetime(DateTime)data.ExitInformationLastPhysicalDate
            if (data.ExitInformationLastPhysicalDate != null)
            {
                data.ExitInformationLastPhysicalDate = data.ExitInformationLastPhysicalDate;
            }
            else
            {
                data.ExitInformationLastPhysicalDate = DateTime.MaxValue;
            }

            //23. Handling null values in datetime(DateTime)data.ExitInformationEffectiveDate
            if (data.ExitInformationEffectiveDate != null)
            {
                data.ExitInformationEffectiveDate = data.ExitInformationEffectiveDate;
            }
            else
            {
                data.ExitInformationEffectiveDate = DateTime.MaxValue;
            }

            if (data != null)
            {
                //employee.Id = data.Id;
                employee.Basicinfo_LOCALID = data.BasicinfoLocalid;
                employee.Basicinfo_GLOBALID = data.BasicinfoGlobalid;
                employee.Basicinfo_FULLNAME = data.BasicinfoFullname;
                employee.Basicinfo_Gender = data.BasicinfoGender;
                employee.Basicinfo_PHOTO = data.BasicinfoPhoto;
                employee.Basicinfo_PlaceofBirth = data.BasicinfoPlaceofBirth;
                employee.Basicinfo_DateofBirth = (DateTime)data.BasicinfoDateofBirth;
                employee.Basicinfo_Religion = data.BasicinfoReligion;
                employee.Basicinfo_Nationality = data.BasicinfoNationality;
                employee.Employmentstatus_EmploymentType = data.EmploymentstatusEmploymentType;
                employee.Employmentstatus_JoinDate = (DateTime)data.EmploymentstatusJoinDate;
                employee.Employmentstatus_C1START = (DateTime)data.EmploymentstatusC1start;
                employee.Employmentstatus_C1END = (DateTime)data.EmploymentstatusC1end;
                employee.Employmentstatus_C2START = (DateTime)data.EmploymentstatusC2start;
                employee.Employmentstatus_C2END = (DateTime)data.EmploymentstatusC2end;
                employee.Employmentstatus_C3START = (DateTime)data.EmploymentstatusC3start;
                employee.Employmentstatus_C3END = (DateTime)data.EmploymentstatusC3end;
                employee.Employmentstatus_PERMANENTSTARTDATE = (DateTime)data.EmploymentstatusPermanentstartdate;
                employee.Employmentstatus_EMPLOYEESTATUS = data.EmploymentstatusEmployeestatus;
                employee.Employmentstatus_TOTALSERVICEYEARSBYJOIN = idiffday;
                employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT = totaltahunbypermanent;
                employee.Jobprofile_JobTitle = data.JobprofileJobTitle;
                employee.Jobprofile_GradeORLevel = data.JobprofileGradeOrlevel;
                employee.Jobprofile_ProductivityType = data.JobprofileProductivityType;
                employee.Jobprofile_JobFunction = data.JobprofileJobFunction;
                employee.Jobprofile_WorkCitizenship = data.JobprofileWorkCitizenship;
                employee.Jobprofile_LaborType = data.JobprofileLaborType;
                employee.Jobprofile_LaborClass = data.JobprofileLaborClass;
                employee.Jobprofile_Department = data.JobprofileLaborType;
                employee.Jobprofile_CostCenter = data.JobprofileCostCenter;
                employee.Jobprofile_Division = data.JobprofileDivision;
                employee.Jobprofile_WorkLotORPlant = data.JobprofileWorkLotOrplant;
                employee.Jobprofile_SupervisorID = data.JobprofileSupervisorId;
                employee.Jobprofile_SupervisorName = data.JobprofileSupervisorName;
                employee.Jobprofile_ShiftPattern = data.JobprofileShiftPattern;
                employee.Recruitment_MethodofRecruitment = data.RecruitmentMethodofRecruitment;
                employee.Recruitment_Source = data.RecruitmentSource;
                employee.Recruitment_RecruitmentPlace = data.RecruitmentRecruitmentPlace;
                employee.Recruitment_RequisitionNumber = data.RecruitmentRequisitionNumber;
                employee.Education_Education1 = data.EducationEducation1;
                employee.Education_FieldofStudy1 = data.EducationFieldofStudy1;
                employee.Education_InstitutionName1 = data.EducationInstitutionName1;
                employee.Education_YearofGraduate1 = data.EducationYearofGraduate1;
                employee.Education_Education2 = data.EducationEducation2;
                employee.Education_FieldofStudy2 = data.EducationFieldofStudy2;
                employee.Education_InstitutionName2 = data.EducationInstitutionName2;
                employee.Education_YearofGraduate2 = data.EducationYearofGraduate2;
                employee.IdentityandAccount_NIK = data.IdentityandAccountNik;
                employee.IdentityandAccount_NoBPJSKes = data.IdentityandAccountNoBpjskes;
                employee.IdentityandAccount_NoBPJSTK = data.IdentityandAccountNoBpjstk;
                employee.IdentityandAccount_NoPassport = data.IdentityandAccountNoPassport;
                employee.IdentityandAccount_BankAccount = data.IdentityandAccountBankAccount;
                employee.IdentityandAccount_NoNPWP = data.IdentityandAccountNoNpwp;
                employee.IdentityandAccount_TaxStatus = data.IdentityandAccountTaxStatus;
                employee.ContactandAddress_MobilePhoneNo = data.ContactandAddressMobilePhoneNo;
                employee.ContactandAddress_PersonalEmailAccount = data.ContactandAddressPersonalEmailAccount;
                employee.ContactandAddress_CurrentAddress = data.ContactandAddressCurrentAddress;
                employee.ContactandAddress_CurrentRegionKelurahan = data.ContactandAddressCurrentRegionKelurahan;
                employee.ContactandAddress_CurrentRegionKecamatan = data.ContactandAddressCurrentRegionKecamatan;
                employee.ContactandAddress_CurrentCity = data.ContactandAddressCurrentCity;
                employee.ContactandAddress_KTPAddress = data.ContactandAddressKtpaddress;
                employee.ContactandAddress_KTPDistrict1Kelurahan = data.ContactandAddressKtpaddress;
                employee.ContactandAddress_KTPDistrict2Kecamatan = data.ContactandAddressKtpdistrict2Kecamatan;
                employee.ContactandAddress_KTPCity = data.ContactandAddressKtpcity;
                employee.ContactandAddress_HometownAddress = data.ContactandAddressHometownAddress;
                employee.ContactandAddress_HowetownCity = data.ContactandAddressHowetownCity;
                employee.ContactandAddress_DormitoryStatus = data.ContactandAddressDormitoryStatus;
                employee.ContactandAddress_DormitoryNo = data.ContactandAddressDormitoryNo;
                employee.FamilyDetails_KKNo = data.FamilyDetailsKkno;
                employee.FamilyDetails_MarritalStatus = data.FamilyDetailsMarritalStatus;
                employee.FamilyDetails_SpouseName = data.FamilyDetailsSpouseName;
                employee.FamilyDetails_NoOfChildren = data.FamilyDetailsNoOfChildren;
                employee.FamilyDetails_ChildrenName_1 = data.FamilyDetailsChildrenName1;
                employee.FamilyDetails_DateOfBirth_1 = (DateTime)data.FamilyDetails_DateOfBirth_1;
                employee.FamilyDetails_ChildrenName_2 = data.FamilyDetailsChildrenName2;
                employee.FamilyDetails_DateOfBirth_2 = (DateTime)data.FamilyDetails_DateOfBirth_2;
                employee.FamilyDetails_ChildrenName_3 = data.FamilyDetailsChildrenName3;
                employee.FamilyDetails_DateOfBirth_3 = (DateTime)data.FamilyDetails_DateOfBirth_3;
                employee.FamilyDetails_ChildrenName_4 = data.FamilyDetailsChildrenName4;
                employee.FamilyDetails_DateOfBirth_4 = (DateTime)data.FamilyDetails_DateOfBirth_4;
                employee.FamilyDetails_ChildrenName_5 = data.FamilyDetailsChildrenName5;
                employee.FamilyDetails_DateOfBirth_5 = (DateTime)data.FamilyDetails_DateOfBirth_5;
                employee.FamilyDetails_ChildrenName_6 = data.FamilyDetailsChildrenName6;
                employee.FamilyDetails_DateOfBirth_6 = (DateTime)data.FamilyDetails_DateOfBirth_6;
                employee.FamilyDetails_ChildrenName_7 = data.FamilyDetailsChildrenName7;
                employee.FamilyDetails_DateOfBirth_7 = (DateTime)data.FamilyDetails_DateOfBirth_7;
                employee.FamilyDetails_ChildrenName_8 = data.FamilyDetailsChildrenName8;
                employee.FamilyDetails_DateOfBirth_8 = (DateTime)data.FamilyDetails_DateOfBirth_8;
                employee.FamilyDetails_ChildrenName_9 = data.FamilyDetailsChildrenName9;
                employee.FamilyDetails_DateOfBirth_9 = (DateTime)data.FamilyDetails_DateOfBirth_9;
                employee.FamilyDetails_ChildrenName_10 = data.FamilyDetailsChildrenName10;
                employee.FamilyDetails_DateOfBirth_10 = (DateTime)data.FamilyDetails_DateOfBirth_10;
                employee.EmergencyContact_Name = data.EmergencyContactName;
                employee.EmergencyContact_Relationship = data.EmergencyContactRelationship;
                employee.EmergencyContact_MobilePhoneNo = data.EmergencyContactMobilePhoneNo;
                employee.EmergencyContact_CurrentAddress = data.EmergencyContactCurrentCity;
                employee.EmergencyContact_CurrentCity = data.EmergencyContactCurrentCity;
                employee.Access_PropertiesandMembership_WorkEmailAccount = data.AccessPropertiesandMembershipWorkEmailAccount;
                employee.Access_PropertiesandMembership_ProximityCardID = data.AccessPropertiesandMembershipProximityCardId;
                employee.Access_PropertiesandMembership_AccessDoorID = data.AccessPropertiesandMembershipAccessDoorId;
                employee.Access_PropertiesandMembership_ParkingAccess = data.AccessPropertiesandMembershipParkingAccess;
                employee.Access_PropertiesandMembership_LockerID = data.AccessPropertiesandMembershipLockerId;
                employee.Access_PropertiesandMembership_CompanySIMCardID = data.AccessPropertiesandMembershipCompanySimcardId;
                employee.Access_PropertiesandMembership_CompanyPhone = data.AccessPropertiesandMembershipCompanyPhone;
                employee.Access_PropertiesandMembership_CooperativeMembership = data.AccessPropertiesandMembershipCooperativeMembership;
                employee.Access_PropertiesandMembership_UNIONMEMBERSHIP = data.AccessPropertiesandMembershipUnionmembership;
                employee.Access_PropertiesandMembership_UNIONSTARTDATE = (DateTime)data.AccessPropertiesandMembershipUnionstartdate;
                employee.Access_PropertiesandMembership_UNIONEXITDATE = (DateTime)data.AccessPropertiesandMembershipUnionexitdate;
                employee.Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS = data.AccessPropertiesandMembershipUnionmembershipstatus;
                employee.ExitInformation_TypeofExit = data.ExitInformationTypeofExit;
                employee.ExitInformation_LastPhysicalDate = (DateTime)data.ExitInformationLastPhysicalDate;
                employee.ExitInformation_EffectiveDate = (DateTime)data.ExitInformationEffectiveDate;
                employee.ExitInformation_ReasonofLeaving = data.ExitInformationReasonofLeaving;
                employee.ExitInformation_Eligibletorehire = data.ExitInformationEligibletorehire;
            }
            return View(employee);
        }



        //Controller upload data csv
        [HttpGet]
        public IActionResult SaveDataCSV()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveDataCSV(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                string path = Path.Combine(this.Environment.ContentRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();

                string[] dataheader = new string[115] {
                    "Basicinfo_Local ID",
                    "BasicInfo_Global ID",
                    "BasicInfo_Full Name",
                    "BasicInfo_Gender",
                    "BasicInfo_Photo",
                    "BasicInfo_Place of Birth",
                    "BasicInfo_Date of Birth",
                    "BasicInfo_Religion",
                    "BasicInfo_Nationality",
                    "Employmentstatus_Employment Type",
                    "Employmentstatus_Join Date",
                    "Employmentstatus_C1 Start",
                    "Employmentstatus_C1 End",
                    "Employmentstatus_C2 Start",
                    "Employmentstatus_C2 End",
                    "Employmentstatus_C3 Start",
                    "Employmentstatus_C3 End",
                    "Employmentstatus_Permanent Start Date",
                    "Employmentstatus_Employee status",
                    "Employmentstatus_Total service years by join",
                    "Employmentstatus_Total service years by permanent",
                    "Jobprofile_Grade Or level",
                    "Jobprofile_Job Title",
                    "Jobprofile_Labor Type",
                    "Jobprofile_Labor Class",
                    "Jobprofile_Productivity Type",
                    "Jobprofile_Job Function",
                    "Jobprofile_Work Citizen ship",
                    "Jobprofile_Department",
                    "Jobprofile_Cost Center",
                    "Jobprofile_Job Post",                 
                    "Jobprofile_Work Lot Or Plant",
                    "Jobprofile_Supervisor Id",
                    "Jobprofile_Supervisor Name",
                    "Jobprofile_Shift Pattern",
                    "Recruitment_Method of Recruitment ",
                    "Recruitment_Source ",
                    "Recruitment_Recruitment Place ",
                    "Recruitment_Requisition Number ",
                    "Education_Education 1 ",
                    "Education_FieldofStudy 1 ",
                    "Education_InstitutionName 1 ",
                    "Education_YearofGraduate 1 ",
                    "Education_Education 2 ",
                    "Education_FieldofStudy 2 ",
                    "Education_InstitutionName 2 ",
                    "Education_YearofGraduate 2 ",
                    "IdentityandAccount_Nik ",
                    "IdentityandAccount_No Bpjs Kes ",
                    "IdentityandAccount_No Bpjs TK ",
                    "IdentityandAccount_No Passport ",
                    "IdentityandAccount_Bank Account ",
                    "IdentityandAccount_No Npwp ",
                    "IdentityandAccount_Tax Status ",
                    "ContactandAddress_Mobile Phone No. ",
                    "ContactandAddress_Personal Email Account ",
                    "ContactandAddress_Current Address ",
                    "ContactandAddress_Current Region (Kelurahan) ",
                    "ContactandAddress_Current Region (Kecamatan) ",
                    "ContactandAddress_Current City ",
                    "ContactandAddress_Ktp address ",
                    "ContactandAddress_Ktp district1 (Kelurahan) ",
                    "ContactandAddress_Ktp district2 (Kecamatan) ",
                    "ContactandAddress_Ktp city ",
                    "ContactandAddress_Hometown Address ",
                    "ContactandAddress_Howetown City ",
                    "ContactandAddress_Dormitory Status ",
                    "ContactandAddress_Dormitory No. ",
                    "FamilyDetails_Kk No ",
                    "FamilyDetails_Marrital Status ",
                    "FamilyDetails_Spouse Name ",
                    "FamilyDetails_No Of Children ",
                    "FamilyDetails Children Name_1",
                    "FamilyDetails_DateOfBirth_1",
                    "FamilyDetails Children Name_2",
                    "FamilyDetails_DateOfBirth_2",
                    "FamilyDetails Children Name_3",
                    "FamilyDetails_DateOfBirth_3",
                    "FamilyDetails Children Name_4",
                    "FamilyDetails_DateOfBirth_4",
                    "FamilyDetails Children Name_5",
                    "FamilyDetails_DateOfBirth_5",
                    "FamilyDetails Children Name_6",
                    "FamilyDetails_DateOfBirth_6",
                    "FamilyDetails Children Name_7",
                    "FamilyDetails_DateOfBirth_7",
                    "FamilyDetails Children Name_8",
                    "FamilyDetails_DateOfBirth_8",
                    "FamilyDetails Children Name_9",
                    "FamilyDetails_DateOfBirth_9",
                    "FamilyDetails Children Name_10",
                    "FamilyDetails_DateOfBirth_10",
                    "EmergencyContact_Name",
                    "EmergencyContact_Relationship ",
                    "EmergencyContact_MobilePhoneNo ",
                    "EmergencyContact_CurrentAddress ",
                    "EmergencyContact_CurrentCity ",
                    "AccessPropertiesandMembership_Work Email Account ",
                    "AccessPropertiesandMembership_Proximity Card Id ",
                    "AccessPropertiesandMembership_Access Door Id ",
                    "AccessPropertiesandMembership_Parking Access ",
                    "AccessPropertiesandMembership_Locker Id ",
                    "AccessPropertiesandMembership_Company Sim card Id ",
                    "AccessPropertiesandMembership_Company Phone ",
                    "AccessPropertiesandMembership_Cooperative Membership ",
                    "AccessPropertiesandMembership_Union membership ",
                    "AccessPropertiesandMembership_Union start date ",
                    "AccessPropertiesandMembership_Union exit date ",
                    "AccessPropertiesandMembership_Union membership status ",
                    "ExitInformation_Type of Exit ",
                    "ExitInformation_Last Physical Date ",
                    "ExitInformation_Effective Date ",
                    "ExitInformation_Reasono f Leaving ",
                    "ExitInformation_Eligible to rehire",
                    "Info Process"
                    };
                DataTable dtReport = new DataTable();
                for (int k=0; k<115; k++)
                {
                    dtReport.Columns.Add(dataheader[k]);

                }

                bool firstRow = true;


                //Siapkan ListArrayValueTeksGradeLevel 
                //Ambil data ListArrayValueTeks dari tabel Tbl_GradeLevel
                List<TblGradeLevel>  ListArrayValueTeksGradeLevel = _dbemployeeContext.TblGradeLevels.ToList();

                //Siapkan ListArrayValueTeksJobTitle
                List<TblJobTitle> ListArrayValueTeksJobTitle = _dbemployeeContext.TblJobTitles.ToList();

                //Siapakan ListArrayValueTeksLaborType
                List<TblLaborType> ListArrayValueTeksLaborType = _dbemployeeContext.TblLaborTypes.ToList();

                //Siapkan ListArrayValueTeksLaborClass
                List<TblLaborClass> ListArrayValueTeksLaborClass = _dbemployeeContext.TblLaborClasses.ToList();

                //Siapkan ListArrayValueTeksProdType
                List<TblProductivityType> ListArrayValueTeksProdType = _dbemployeeContext.TblProductivityTypes.ToList();

                //Siapkan ListArrayValueTeksJobFunction
                List<TblJobFunction> ListArrayValueTeksJobFunction = _dbemployeeContext.TblJobFunctions.ToList();

                //Siapkan ListArrayValueTeksWorklotOrPlant
                List<TblWorkLotOrPlant> ListArrayValueTeksWorklotOrPlant = _dbemployeeContext.TblWorkOrPlants.ToList();

                //Siapkan ListArrayValueTeksDivision
                List<TblDivision> ListArrayValueTeksDivision = _dbemployeeContext.TblDivisions.ToList();

                //Siapkan listArrayValueTeksCostCenter
                List<TblCostCenter> ListArrayValueTeksCostCenter = _dbemployeeContext.TblCostCenters.ToList();

                //Siapkan ListArrayValueTeksJobPost
                List<TblJobPost> ListArrayValueTeksJobPost = _dbemployeeContext.TblJobPosts.ToList();

                //Siapkan ListArrayValueTeksMoR
                List<TblMethodOfRecruitment> ListArrayValueTeksMoR= _dbemployeeContext.TblMethodOfRecruitments.ToList();

                //Siapkan ListArrayValueTeksSource
                List<TblSource> ListArrayValueTeksSource = _dbemployeeContext.TblSources.ToList();

                foreach (string row in csvData.Split('\n'))
                {         
                        if (!string.IsNullOrEmpty(row))
                        {
                            //jumlahrow++;
                            if (firstRow)
                            {
                                foreach (string cell in row.Split(';'))
                                {
                                    dt.Columns.Add(cell.Trim());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                
                                int i = 0;
                                foreach (string cell in row.Split(';'))
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                    i++;
                                }

                                //1. tracking ketika datetime str_BasicinfoDateofBirth kosong
                                if (dt.Rows[dt.Rows.Count - 1][6] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][6] = dt.Rows[dt.Rows.Count - 1][6];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][6] = DateTime.MaxValue;
                                }

                                //2. tracking ketika datetime join date kosong
                                if (dt.Rows[dt.Rows.Count - 1][10] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][10] = dt.Rows[dt.Rows.Count - 1][10];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][10] = DateTime.MaxValue;
                                }

                                //3. tracking ketika date time EmploymentstatusC1start kosong
                                if (dt.Rows[dt.Rows.Count - 1][11] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][11] = dt.Rows[dt.Rows.Count - 1][11];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][11] = DateTime.MaxValue;
                                }

                                //4. tracking ketika date time EmploymentstatusC1end kosong
                                if (dt.Rows[dt.Rows.Count - 1][12] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][12] = dt.Rows[dt.Rows.Count - 1][12];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][12] = DateTime.MaxValue;
                                }

                                //5. tracking ketika date time EmploymentstatusC2start kosong
                                if (dt.Rows[dt.Rows.Count - 1][13] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][13] = dt.Rows[dt.Rows.Count - 1][13];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][13] = DateTime.MaxValue;
                                }

                                //6. tracking ketika date time EmploymentstatusC2end kosong
                                if (dt.Rows[dt.Rows.Count - 1][14] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][14] = dt.Rows[dt.Rows.Count - 1][14];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][14] = DateTime.MaxValue;
                                }

                                //7. tracking ketika date time EmploymentstatusC3start kosong
                                if (dt.Rows[dt.Rows.Count - 1][15] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][15] = dt.Rows[dt.Rows.Count - 1][15];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][15] = DateTime.MaxValue;
                                }

                                //8. tracking ketika date time EmploymentstatusC3end kosong
                                if (dt.Rows[dt.Rows.Count - 1][16] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][16] = dt.Rows[dt.Rows.Count - 1][16];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][16] = DateTime.MaxValue;
                                }

                                //9. tracking ketika date time EmploymentstatusPermanentstartdate
                                if (dt.Rows[dt.Rows.Count - 1][17] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][17]= dt.Rows[dt.Rows.Count - 1][17];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][17] = DateTime.MaxValue;
                                }

                                //10. tracking ketika date time FamilyDetails_DateOfBirth_1 kosong
                                if (dt.Rows[dt.Rows.Count - 1][73] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][73]= dt.Rows[dt.Rows.Count - 1][73];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][73] = DateTime.MaxValue;
                                }

                                //11. tracking ketika date time FamilyDetails_DateOfBirth_2 kosong
                                if (dt.Rows[dt.Rows.Count - 1][75] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][75]= dt.Rows[dt.Rows.Count - 1][75];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][75] = DateTime.MaxValue;
                                }
                                //12. tracking ketika date time FamilyDetails_DateOfBirth_3 kosong
                                if (dt.Rows[dt.Rows.Count - 1][77] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][77]= dt.Rows[dt.Rows.Count - 1][77];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][77] = DateTime.MaxValue;
                                }
                                //13. tracking ketika date time FamilyDetails_DateOfBirth_4 kosong
                                if (dt.Rows[dt.Rows.Count - 1][79] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][79]= dt.Rows[dt.Rows.Count - 1][79];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][79] = DateTime.MaxValue;
                                }

                                //14. tracking ketika date time FamilyDetails_DateOfBirth_5 kosong
                                if (dt.Rows[dt.Rows.Count - 1][81] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][81]= dt.Rows[dt.Rows.Count - 1][81];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][81] = DateTime.MaxValue;
                                }

                                //15. tracking ketika date time FamilyDetails_DateOfBirth_6 kosong
                                if (dt.Rows[dt.Rows.Count - 1][83] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][83]= dt.Rows[dt.Rows.Count - 1][83];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][83] = DateTime.MaxValue;
                                }

                                //16. tracking ketika date time FamilyDetails_DateOfBirth_7 kosong
                                if (dt.Rows[dt.Rows.Count - 1][85] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][85]= dt.Rows[dt.Rows.Count - 1][85];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][85] = DateTime.MaxValue;
                                }

                                //17. tracking ketika date time FamilyDetails_DateOfBirth_8 kosong
                                if (dt.Rows[dt.Rows.Count - 1][87] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][87]= dt.Rows[dt.Rows.Count - 1][87];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][87] = DateTime.MaxValue;
                                }
                                //18. tracking ketika date time FamilyDetails_DateOfBirth_9 kosong
                                if (dt.Rows[dt.Rows.Count - 1][89] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][89]= dt.Rows[dt.Rows.Count - 1][89];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][89] = DateTime.MaxValue;
                                }

                                //19. tracking ketika date time FamilyDetails_DateOfBirth_10 kosong
                                if (dt.Rows[dt.Rows.Count - 1][91] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][91]= dt.Rows[dt.Rows.Count - 1][91];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][91] = DateTime.MaxValue;
                                }

                                //20. tracking ketika date time AccessPropertiesandMembershipUnionstartdate kosong
                                if (dt.Rows[dt.Rows.Count - 1][106] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][106] = dt.Rows[dt.Rows.Count - 1][106];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][106] = DateTime.MaxValue;
                                }

                                //21. tracking ketika date time AccessPropertiesandMembershipUnionexitdate kosong
                                if (dt.Rows[dt.Rows.Count - 1][107] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][107] = dt.Rows[dt.Rows.Count - 1][107];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][107] = DateTime.MaxValue;
                                }

                                //22. tracking ketika date time ExitInformationLastPhysicalDate kosong
                                if (dt.Rows[dt.Rows.Count - 1][110] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][110] = dt.Rows[dt.Rows.Count - 1][110];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][110] = DateTime.MaxValue;
                                }

                                //23. tracking ketika date time ExitInformationEffectiveDate kosong
                                if (dt.Rows[dt.Rows.Count - 1][111] != "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][111] = dt.Rows[dt.Rows.Count - 1][111];
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][111] = DateTime.MaxValue;
                                }

                                //INTEGER////
                                 //tracking ketika date time EmploymentstatusTotalserviceyearsbyjoin kosong
                                String str_EmploymentstatusTotalserviceyearsbyjoin = "";
                                if (dt.Rows[dt.Rows.Count - 1][19] != "")
                                {
                                    str_EmploymentstatusTotalserviceyearsbyjoin = Convert.ToString(dt.Rows[dt.Rows.Count - 1][19]);
                                }
                                else
                                {
                                    str_EmploymentstatusTotalserviceyearsbyjoin = "0";
                                }

                                //tracking ketika date time EmploymentstatusTotalserviceyearsbypermanent kosong
                                String str_EmploymentstatusTotalserviceyearsbypermanent = "";
                                if (dt.Rows[dt.Rows.Count - 1][20] != "")
                                {
                                    str_EmploymentstatusTotalserviceyearsbypermanent = Convert.ToString(dt.Rows[dt.Rows.Count - 1][20]);
                                }
                                else
                                {
                                    str_EmploymentstatusTotalserviceyearsbypermanent = "0";
                                }

                                //tracking ketika EducationYearofGraduate1 kosong
                                String str_EducationYearofGraduate1 = "";
                                if (dt.Rows[dt.Rows.Count - 1][42] != "")
                                {
                                    str_EducationYearofGraduate1 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][42]);
                                }
                                else
                                {
                                    str_EducationYearofGraduate1 = "0000";
                                }

                                //tracking ketika EEducationYearofGraduate2 kosong
                                String str_EducationYearofGraduate2 = "";
                                if (dt.Rows[dt.Rows.Count - 1][46] != "")
                                {
                                    str_EducationYearofGraduate2 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][46]);
                                }
                                else
                                {
                                    str_EducationYearofGraduate2 = "0000";
                                }

                                //tracking ketika FamilyDetailsNoOfChildren kosong
                                String str_FamilyDetailsNoOfChildren = "";
                                if (dt.Rows[dt.Rows.Count - 1][71] != "")
                                {
                                    str_FamilyDetailsNoOfChildren = Convert.ToString(dt.Rows[dt.Rows.Count - 1][71]);
                                }
                                else
                                {
                                    str_FamilyDetailsNoOfChildren = "0";
                                }

                            //Try insert 1 row
                            string Id_GradeLevel = GetIdGradeLevelFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][21]), ListArrayValueTeksGradeLevel);
                            string Id_JobTitle = GetIdJobTitleFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][22]), ListArrayValueTeksJobTitle);
                            string Id_LaborType = GetIdLaborTypeFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][23]), ListArrayValueTeksLaborType);
                            string Id_LaborClass = GetIdLaborClassFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][24]), ListArrayValueTeksLaborClass);

                            string ID_ProductivityType = GetIdProductivityTypeFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][25]), ListArrayValueTeksProdType);
                            string ID_JobFunction = GetIdJobFunctionFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][26]), ListArrayValueTeksJobFunction);
                           

                            string Id_Division = GetIdDivisionFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][28]), ListArrayValueTeksDivision);
                            string Id_CostCenter = GetIdCostCenterFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][29]), ListArrayValueTeksCostCenter);
                            string Id_JobPost = GetIdJobPostFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][30]), ListArrayValueTeksJobPost);
                            string ID_WorklotOrPlant = GetIdWorkLotOrPlantFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][31]), ListArrayValueTeksWorklotOrPlant);


                            string Id_MethodOfRecruitment = GetIdMethodOfRecruitmentFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][35]), ListArrayValueTeksMoR);
                            string Id_Source = GetIdSourceFromName(Convert.ToString(dt.Rows[dt.Rows.Count - 1][36]), ListArrayValueTeksSource);

                            bool[] listKondisi = new bool[12];

                            //Cek GradeLevel
                            bool GradeLevelKondisiOke = false;
                            if (Id_GradeLevel != "0")
                            {
                                GradeLevelKondisiOke = true;
                            }

                            listKondisi[0] = GradeLevelKondisiOke;

                            //Cek JobTitle
                            bool JobTitleKondisiOke = false;
                            if (Id_JobTitle != "0")
                            {
                                JobTitleKondisiOke = true;
                            }

                            listKondisi[1] = JobTitleKondisiOke;

                            //Cek LaborType
                            bool LaborTypeKondisiOke = false;
                            if (Id_LaborType != "0")
                            {
                                LaborTypeKondisiOke = true;
                            }

                            listKondisi[2] = LaborTypeKondisiOke;

                            //Cek Labor Class
                            bool LaborClassKondisiOke = false;
                            if (Id_LaborClass != "0")
                            {
                                LaborClassKondisiOke = true;
                            }

                            listKondisi[3] = LaborClassKondisiOke;

                            //Cek Productivity Type
                            bool ProdTypeKondisiOke = false;
                            if (ID_ProductivityType != "0")
                            {
                                ProdTypeKondisiOke = true;
                            }

                            listKondisi[4] = LaborClassKondisiOke;

                            //Cek JobFunction
                            bool JobFucnKondisiOke = false;
                            if (ID_JobFunction != "0")
                            {
                                JobFucnKondisiOke = true;
                            }

                            listKondisi[5] = LaborClassKondisiOke;

                            

                            //Cek Division
                            bool DivisionKondisiOke = false;
                            if (Id_Division != "0")
                            {
                                DivisionKondisiOke = true;
                            }

                            listKondisi[6] = DivisionKondisiOke;

                            //Cek CostCenter
                            bool CostCenterKondisiOke = false;
                            if (Id_CostCenter != "0")
                            {
                                CostCenterKondisiOke = true;
                            }

                            listKondisi[7] = CostCenterKondisiOke;

                            //Cek JobPost
                            bool JobPostKondisiOke = false;
                            if (Id_JobPost != "0")
                            {
                                JobPostKondisiOke = true;
                            }

                            listKondisi[8] = JobPostKondisiOke;

                            //Cek WorkLotOrPlant
                            bool WorkLOPKondisiOke = false;
                            if (ID_WorklotOrPlant != "0")
                            {
                                WorkLOPKondisiOke = true;
                            }

                            listKondisi[9] = LaborClassKondisiOke;

                            //Cek MethodOfRecruitment
                            bool MethodOfRecKondisiOke = false;
                            if (Id_MethodOfRecruitment != "0")
                            {
                                MethodOfRecKondisiOke = true;
                            }

                            listKondisi[10] = MethodOfRecKondisiOke;

                            //Cek Source
                            bool SourceKondisiOke = false;
                            if (Id_Source != "0")
                            {
                                SourceKondisiOke = true;
                            }

                            listKondisi[11] = SourceKondisiOke;


                            bool CekAll = CekAllKondisi(GradeLevelKondisiOke, JobTitleKondisiOke, 
                                                        LaborTypeKondisiOke, LaborClassKondisiOke, 
                                                        ProdTypeKondisiOke, JobFucnKondisiOke,    
                                                        DivisionKondisiOke, CostCenterKondisiOke, 
                                                        JobPostKondisiOke, WorkLOPKondisiOke, MethodOfRecKondisiOke, 
                                                        SourceKondisiOke);

                            if (CekAll==true) 
                            {
                                try
                                {
                                    var employeedata = new TblEmployee()
                                    {
                                        BasicinfoLocalid = Convert.ToString(dt.Rows[dt.Rows.Count - 1][0]),
                                        BasicinfoGlobalid = Convert.ToString(dt.Rows[dt.Rows.Count - 1][1]),
                                        BasicinfoFullname = Convert.ToString(dt.Rows[dt.Rows.Count - 1][2]),
                                        BasicinfoGender = Convert.ToString(dt.Rows[dt.Rows.Count - 1][3]),
                                        BasicinfoPhoto = Convert.ToString(dt.Rows[dt.Rows.Count - 1][4]),
                                        BasicinfoPlaceofBirth = Convert.ToString(dt.Rows[dt.Rows.Count - 1][5]),
                                        BasicinfoDateofBirth = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][6]),
                                        BasicinfoReligion = Convert.ToString(dt.Rows[dt.Rows.Count - 1][7]),
                                        BasicinfoNationality = Convert.ToString(dt.Rows[dt.Rows.Count - 1][8]),
                                        EmploymentstatusEmploymentType = Convert.ToString(dt.Rows[dt.Rows.Count - 1][9]),
                                        EmploymentstatusJoinDate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][10]),
                                        EmploymentstatusC1start = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][11]),
                                        EmploymentstatusC1end = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][12]),
                                        EmploymentstatusC2start = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][13]),
                                        EmploymentstatusC2end = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][14]),
                                        EmploymentstatusC3start = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][15]),
                                        EmploymentstatusC3end = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][15]),
                                        EmploymentstatusPermanentstartdate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][17]),
                                        EmploymentstatusEmployeestatus = Convert.ToString(dt.Rows[dt.Rows.Count - 1][18]),
                                        EmploymentstatusTotalserviceyearsbyjoin = Convert.ToInt32(str_EmploymentstatusTotalserviceyearsbyjoin),
                                        EmploymentstatusTotalserviceyearsbypermanent = Convert.ToInt32(str_EmploymentstatusTotalserviceyearsbypermanent),
                                        JobprofileGradeOrlevel = Id_GradeLevel,
                                        JobprofileJobTitle = Id_JobTitle,
                                        JobprofileLaborType = Id_LaborType,
                                        JobprofileLaborClass = Id_LaborClass,
                                        JobprofileProductivityType = ID_ProductivityType,
                                        JobprofileJobFunction = ID_JobFunction,
                                        JobprofileWorkCitizenship = Convert.ToString(dt.Rows[dt.Rows.Count - 1][27]),
                                        JobprofileDivision = Id_Division,
                                        JobprofileCostCenter = Id_CostCenter,
                                        JobprofileDepartment = Id_JobPost,
                                        JobprofileWorkLotOrplant = ID_WorklotOrPlant,
                                        JobprofileSupervisorId = Convert.ToString(dt.Rows[dt.Rows.Count - 1][32]),
                                        JobprofileSupervisorName = Convert.ToString(dt.Rows[dt.Rows.Count - 1][33]),
                                        JobprofileShiftPattern = Convert.ToString(dt.Rows[dt.Rows.Count - 1][34]),
                                        RecruitmentMethodofRecruitment = Id_MethodOfRecruitment,
                                        RecruitmentSource = Id_Source,
                                        RecruitmentRecruitmentPlace = Convert.ToString(dt.Rows[dt.Rows.Count - 1][37]),
                                        RecruitmentRequisitionNumber = Convert.ToString(dt.Rows[dt.Rows.Count - 1][38]),
                                        EducationEducation1 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][39]),
                                        EducationFieldofStudy1 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][40]),
                                        EducationInstitutionName1 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][41]),
                                        EducationYearofGraduate1 = Convert.ToInt32(str_EducationYearofGraduate1),
                                        EducationEducation2 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][43]),
                                        EducationFieldofStudy2 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][44]),
                                        EducationInstitutionName2 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][45]),
                                        EducationYearofGraduate2 = Convert.ToInt32(str_EducationYearofGraduate2),
                                        IdentityandAccountNik = Convert.ToString(dt.Rows[dt.Rows.Count - 1][47]),
                                        IdentityandAccountNoBpjskes = Convert.ToString(dt.Rows[dt.Rows.Count - 1][48]),
                                        IdentityandAccountNoBpjstk = Convert.ToString(dt.Rows[dt.Rows.Count - 1][49]),
                                        IdentityandAccountNoPassport = Convert.ToString(dt.Rows[dt.Rows.Count - 1][50]),
                                        IdentityandAccountBankAccount = Convert.ToString(dt.Rows[dt.Rows.Count - 1][51]),
                                        IdentityandAccountNoNpwp = Convert.ToString(dt.Rows[dt.Rows.Count - 1][52]),
                                        IdentityandAccountTaxStatus = Convert.ToString(dt.Rows[dt.Rows.Count - 1][53]),
                                        ContactandAddressMobilePhoneNo = Convert.ToString(dt.Rows[dt.Rows.Count - 1][54]),
                                        ContactandAddressPersonalEmailAccount = Convert.ToString(dt.Rows[dt.Rows.Count - 1][55]),
                                        ContactandAddressCurrentAddress = Convert.ToString(dt.Rows[dt.Rows.Count - 1][56]),
                                        ContactandAddressCurrentRegionKelurahan = Convert.ToString(dt.Rows[dt.Rows.Count - 1][57]),
                                        ContactandAddressCurrentRegionKecamatan = Convert.ToString(dt.Rows[dt.Rows.Count - 1][58]),
                                        ContactandAddressCurrentCity = Convert.ToString(dt.Rows[dt.Rows.Count - 1][59]),
                                        ContactandAddressKtpaddress = Convert.ToString(dt.Rows[dt.Rows.Count - 1][60]),
                                        ContactandAddressKtpdistrict1Kelurahan = Convert.ToString(dt.Rows[dt.Rows.Count - 1][61]),
                                        ContactandAddressKtpdistrict2Kecamatan = Convert.ToString(dt.Rows[dt.Rows.Count - 1][62]),
                                        ContactandAddressKtpcity = Convert.ToString(dt.Rows[dt.Rows.Count - 1][63]),
                                        ContactandAddressHometownAddress = Convert.ToString(dt.Rows[dt.Rows.Count - 1][64]),
                                        ContactandAddressHowetownCity = Convert.ToString(dt.Rows[dt.Rows.Count - 1][65]),
                                        ContactandAddressDormitoryStatus = Convert.ToString(dt.Rows[dt.Rows.Count - 1][66]),
                                        ContactandAddressDormitoryNo = Convert.ToString(dt.Rows[dt.Rows.Count - 1][67]),
                                        FamilyDetailsKkno = Convert.ToString(dt.Rows[dt.Rows.Count - 1][68]),
                                        FamilyDetailsMarritalStatus = Convert.ToString(dt.Rows[dt.Rows.Count - 1][69]),
                                        FamilyDetailsSpouseName = Convert.ToString(dt.Rows[dt.Rows.Count - 1][70]),
                                        FamilyDetailsNoOfChildren = Convert.ToInt32(str_FamilyDetailsNoOfChildren),
                                        FamilyDetailsChildrenName1 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][72]),
                                        FamilyDetails_DateOfBirth_1 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][73]),
                                        FamilyDetailsChildrenName2 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][74]),
                                        FamilyDetails_DateOfBirth_2 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][75]),
                                        FamilyDetailsChildrenName3 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][76]),
                                        FamilyDetails_DateOfBirth_3 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][77]),
                                        FamilyDetailsChildrenName4 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][78]),
                                        FamilyDetails_DateOfBirth_4 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][79]),
                                        FamilyDetailsChildrenName5 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][80]),
                                        FamilyDetails_DateOfBirth_5 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][81]),
                                        FamilyDetailsChildrenName6 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][82]),
                                        FamilyDetails_DateOfBirth_6 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][83]),
                                        FamilyDetailsChildrenName7 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][84]),
                                        FamilyDetails_DateOfBirth_7 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][85]),
                                        FamilyDetailsChildrenName8 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][86]),
                                        FamilyDetails_DateOfBirth_8 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][87]),
                                        FamilyDetailsChildrenName9 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][88]),
                                        FamilyDetails_DateOfBirth_9 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][89]),
                                        FamilyDetailsChildrenName10 = Convert.ToString(dt.Rows[dt.Rows.Count - 1][90]),
                                        FamilyDetails_DateOfBirth_10 = /*Convert.ToDateTime(tanggal),*/ Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][91]),
                                        EmergencyContactName = Convert.ToString(dt.Rows[dt.Rows.Count - 1][92]),
                                        EmergencyContactRelationship = Convert.ToString(dt.Rows[dt.Rows.Count - 1][93]),
                                        EmergencyContactMobilePhoneNo = Convert.ToString(dt.Rows[dt.Rows.Count - 1][94]),
                                        EmergencyContactCurrentAddress = Convert.ToString(dt.Rows[dt.Rows.Count - 1][95]),
                                        EmergencyContactCurrentCity = Convert.ToString(dt.Rows[dt.Rows.Count - 1][96]),
                                        AccessPropertiesandMembershipWorkEmailAccount = Convert.ToString(dt.Rows[dt.Rows.Count - 1][97]),
                                        AccessPropertiesandMembershipProximityCardId = Convert.ToString(dt.Rows[dt.Rows.Count - 1][98]),
                                        AccessPropertiesandMembershipAccessDoorId = Convert.ToString(dt.Rows[dt.Rows.Count - 1][99]),
                                        AccessPropertiesandMembershipParkingAccess = Convert.ToString(dt.Rows[dt.Rows.Count - 1][100]),
                                        AccessPropertiesandMembershipLockerId = Convert.ToString(dt.Rows[dt.Rows.Count - 1][101]),
                                        AccessPropertiesandMembershipCompanySimcardId = Convert.ToString(dt.Rows[dt.Rows.Count - 1][102]),
                                        AccessPropertiesandMembershipCompanyPhone = Convert.ToString(dt.Rows[dt.Rows.Count - 1][103]),
                                        AccessPropertiesandMembershipCooperativeMembership = Convert.ToString(dt.Rows[dt.Rows.Count - 1][104]),
                                        AccessPropertiesandMembershipUnionmembership = Convert.ToString(dt.Rows[dt.Rows.Count - 1][105]),
                                        AccessPropertiesandMembershipUnionstartdate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][106]), //106
                                        AccessPropertiesandMembershipUnionexitdate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][107]), //107
                                        AccessPropertiesandMembershipUnionmembershipstatus = Convert.ToString(dt.Rows[dt.Rows.Count - 1][108]),
                                        ExitInformationTypeofExit = Convert.ToString(dt.Rows[dt.Rows.Count - 1][109]),
                                        ExitInformationLastPhysicalDate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][110]),
                                        ExitInformationEffectiveDate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][111]),
                                        ExitInformationReasonofLeaving = Convert.ToString(dt.Rows[dt.Rows.Count - 1][112]),
                                        ExitInformationEligibletorehire = Convert.ToString(dt.Rows[dt.Rows.Count - 1][113]),
                                        AdminApproval = 0


                                    };
                                    _dbemployeeContext.TblEmployees.Add(employeedata);
                                    ViewBag.sukses = "Berhasil";

                                    //Simpan Data ke log
                                    var str_log = "BasicinfoLocalid = " + employeedata.BasicinfoLocalid + "," +
                                                 "BasicinfoGlobalid = " + employeedata.BasicinfoGlobalid + "," +
                                                 " BasicinfoFullname = " + employeedata.BasicinfoFullname + "," +
                                                 " BasicinfoGender = " + employeedata.BasicinfoGender + "," +
                                                 " BasicinfoPhoto = " + employeedata.BasicinfoPhoto + "," +
                                                 " BasicinfoPlaceofBirth = " + employeedata.BasicinfoPlaceofBirth + "," +
                                                 " BasicinfoDateofBirth = " + employeedata.BasicinfoDateofBirth.ToString() + "," +
                                                 " BasicinfoReligion = " + employeedata.BasicinfoReligion + "," +
                                                 " BasicinfoNationality = " + employeedata.BasicinfoNationality + "," +
                                                 " EmploymentstatusEmploymentType = " + employeedata.EmploymentstatusEmploymentType + "," +
                                                 " EmploymentstatusJoinDate = " + employeedata.EmploymentstatusJoinDate.ToString() + "," +
                                                 " EmploymentstatusC1start = " + employeedata.EmploymentstatusC1start.ToString() + "," +
                                                 " EmploymentstatusC1end = " + employeedata.EmploymentstatusC1end.ToString() + "," +
                                                 " EmploymentstatusC2start = " + employeedata.EmploymentstatusC2start.ToString() + "," +
                                                 " EmploymentstatusC2end = " + employeedata.EmploymentstatusC2end.ToString() + "," +
                                                 " EmploymentstatusC3start = " + employeedata.EmploymentstatusC3start.ToString() + "," +
                                                 " EmploymentstatusC3end = " + employeedata.EmploymentstatusC3end.ToString() + "," +
                                                 " EmploymentstatusPermanentstartdate = " + employeedata.EmploymentstatusPermanentstartdate.ToString() + "," +
                                                 " EmploymentstatusEmployeestatus = " + employeedata.EmploymentstatusEmployeestatus + "," +
                                                 " EmploymentstatusTotalserviceyearsbyjoin = " + employeedata.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                                                 " EmploymentstatusTotalserviceyearsbypermanent = " + employeedata.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                                                 " JobprofileGradeOrlevel = " + employeedata.JobprofileGradeOrlevel + "," +
                                                 " JobprofileJobTitle = " + employeedata.JobprofileJobTitle + "," +
                                                 " JobprofileLaborType = " + employeedata.JobprofileLaborType + "," +
                                                 " JobprofileLaborClass = " + employeedata.JobprofileLaborClass + "," +
                                                 " JobprofileProductivityType = " + employeedata.JobprofileProductivityType + "," +
                                                 " JobprofileJobFunction = " + employeedata.JobprofileJobFunction + "," +
                                                 " JobprofileWorkCitizenship = " + employeedata.JobprofileWorkCitizenship + "," +
                                                 " JobprofileDivision = " + employeedata.JobprofileDivision + "," + //penampung department
                                                 " JobprofileCostCenter = " + employeedata.JobprofileCostCenter + "," +
                                                 " JobprofileDepartment = " + employeedata.JobprofileDepartment + "," + //penampung job post
                                                 " JobprofileWorkLotOrplant = " + employeedata.JobprofileWorkLotOrplant + "," +
                                                 " JobprofileSupervisorId = " + employeedata.JobprofileSupervisorId + "," +
                                                 " JobprofileSupervisorName = " + employeedata.JobprofileSupervisorName + "," +
                                                 " JobprofileShiftPattern = " + employeedata.JobprofileShiftPattern + "," +
                                                 " RecruitmentMethodofRecruitment = " + employeedata.RecruitmentMethodofRecruitment + "," +
                                                 " RecruitmentSource = " + employeedata.RecruitmentSource + "," +
                                                 " RecruitmentRecruitmentPlace = " + employeedata.RecruitmentRecruitmentPlace + "," +
                                                 " RecruitmentRequisitionNumber = " + employeedata.RecruitmentRequisitionNumber + "," +
                                                 " EducationEducation1 = " + employeedata.EducationEducation1 + "," +
                                                 " EducationFieldofStudy1 = " + employeedata.EducationFieldofStudy1 + "," +
                                                 " EducationInstitutionName1 = " + employeedata.EducationInstitutionName1 + "," +
                                                 " EducationYearofGraduate1 = " + employeedata.EducationYearofGraduate1.ToString() + "," +
                                                 " EducationEducation2 = " + employeedata.EducationEducation2 + "," +
                                                 " EducationFieldofStudy2 = " + employeedata.EducationFieldofStudy2 + "," +
                                                 " EducationInstitutionName2 = " + employeedata.EducationInstitutionName2 + "," +
                                                 " EducationYearofGraduate2 = " + employeedata.EducationYearofGraduate2.ToString() + "," +
                                                 " IdentityandAccountNik = " + employeedata.IdentityandAccountNik + "," +
                                                 " IdentityandAccountNoBpjskes = " + employeedata.IdentityandAccountNoBpjskes + "," +
                                                 " IdentityandAccountNoBpjstk = " + employeedata.IdentityandAccountNoBpjstk + "," +
                                                 " IdentityandAccountNoPassport = " + employeedata.IdentityandAccountNoPassport + "," +
                                                 " IdentityandAccountBankAccount = " + employeedata.IdentityandAccountBankAccount + "," +
                                                 " IdentityandAccountNoNpwp = " + employeedata.IdentityandAccountNoNpwp + "," +
                                                 " IdentityandAccountTaxStatus = " + employeedata.IdentityandAccountTaxStatus + "," +
                                                 " ContactandAddressMobilePhoneNo = " + employeedata.ContactandAddressMobilePhoneNo + "," +
                                                 " ContactandAddressPersonalEmailAccount = " + employeedata.ContactandAddressPersonalEmailAccount + "," +
                                                 " ContactandAddressCurrentAddress = " + employeedata.ContactandAddressCurrentAddress + "," +
                                                 " ContactandAddressCurrentRegionKelurahan = " + employeedata.ContactandAddressCurrentRegionKelurahan + "," +
                                                 " ContactandAddressCurrentRegionKecamatan = " + employeedata.ContactandAddressCurrentRegionKecamatan + "," +
                                                 " ContactandAddressCurrentCity = " + employeedata.ContactandAddressCurrentCity + "," +
                                                 " ContactandAddressKtpaddress = " + employeedata.ContactandAddressKtpaddress + "," +
                                                 " ContactandAddressKtpdistrict1Kelurahan = " + employeedata.ContactandAddressKtpdistrict1Kelurahan + "," +
                                                 " ContactandAddressKtpdistrict2Kecamatan = " + employeedata.ContactandAddressKtpdistrict2Kecamatan + "," +
                                                 " ContactandAddressKtpcity = " + employeedata.ContactandAddressKtpcity + "," +
                                                 " ContactandAddressHometownAddress = " + employeedata.ContactandAddressHometownAddress + "," +
                                                 " ContactandAddressHowetownCity = " + employeedata.ContactandAddressHowetownCity + "," +
                                                 " ContactandAddressDormitoryStatus = " + employeedata.ContactandAddressDormitoryStatus + "," +
                                                 " ContactandAddressDormitoryNo = " + employeedata.ContactandAddressDormitoryNo + "," +
                                                 " FamilyDetailsKkno = " + employeedata.FamilyDetailsKkno + "," +
                                                 " FamilyDetailsMarritalStatus = " + employeedata.FamilyDetailsMarritalStatus + "," +
                                                 " FamilyDetailsSpouseName = " + employeedata.FamilyDetailsSpouseName + "," +
                                                 " FamilyDetailsNoOfChildren = " + employeedata.FamilyDetailsNoOfChildren.ToString() + "," +
                                                 " FamilyDetailsChildrenName1 = " + employeedata.FamilyDetailsChildrenName1 + "," +
                                                 " FamilyDetailsChildrenName2 = " + employeedata.FamilyDetailsChildrenName2 + "," +
                                                 " FamilyDetailsChildrenName3 = " + employeedata.FamilyDetailsChildrenName3 + "," +
                                                 " EmergencyContactName = " + employeedata.EmergencyContactName + "," +
                                                 " EmergencyContactRelationship = " + employeedata.EmergencyContactRelationship + "," +
                                                 " EmergencyContactMobilePhoneNo = " + employeedata.EmergencyContactMobilePhoneNo + "," +
                                                 " EmergencyContactCurrentAddress = " + employeedata.EmergencyContactCurrentAddress + "," +
                                                 " EmergencyContactCurrentCity = " + employeedata.EmergencyContactCurrentCity + "," +
                                                 " AccessPropertiesandMembershipWorkEmailAccount = " + employeedata.AccessPropertiesandMembershipWorkEmailAccount + "," +
                                                 " AccessPropertiesandMembershipProximityCardId = " + employeedata.AccessPropertiesandMembershipProximityCardId + "," +
                                                 " AccessPropertiesandMembershipAccessDoorId = " + employeedata.AccessPropertiesandMembershipAccessDoorId + "," +
                                                 " AccessPropertiesandMembershipParkingAccess = " + employeedata.AccessPropertiesandMembershipParkingAccess + "," +
                                                 " AccessPropertiesandMembershipLockerId = " + employeedata.AccessPropertiesandMembershipLockerId + "," +
                                                 " AccessPropertiesandMembershipCompanySimcardId = " + employeedata.AccessPropertiesandMembershipCompanySimcardId + "," +
                                                 " AccessPropertiesandMembershipCompanyPhone = " + employeedata.AccessPropertiesandMembershipCompanyPhone + "," +
                                                 " AccessPropertiesandMembershipCooperativeMembership = " + employeedata.AccessPropertiesandMembershipCooperativeMembership + "," +
                                                 " AccessPropertiesandMembershipUnionmembership = " + employeedata.AccessPropertiesandMembershipUnionmembership + "," +
                                                 " AccessPropertiesandMembershipUnionstartdate = " + employeedata.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                                                 " AccessPropertiesandMembershipUnionexitdate = " + employeedata.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                                                 " AccessPropertiesandMembershipUnionmembershipstatus = " + employeedata.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                                                 " ExitInformationTypeofExit = " + employeedata.ExitInformationTypeofExit + "," +
                                                 " ExitInformationLastPhysicalDate = " + employeedata.ExitInformationLastPhysicalDate.ToString() + "," +
                                                 " ExitInformationEffectiveDate = " + employeedata.ExitInformationEffectiveDate.ToString() + "," +
                                                 " ExitInformationReasonofLeaving = " + employeedata.ExitInformationReasonofLeaving + "," +
                                                 " ExitInformationEligibletorehire = " + employeedata.ExitInformationEligibletorehire;


                                    var datalog = new Tbllog()
                                    {
                                        Username = "AdminInput",
                                        JenisOperasi = "Migrasi CSV Data Karyawan Baru",
                                        Tanggal = DateTime.Now,
                                        Isi = str_log,
                                    };

                                    
                                    _dbemployeeContext.Tbllog.Add(datalog);

                                }
                                catch
                                {
                                    dtReport.Rows.Add();
                                    for (int cr = 0; cr < 114; cr++)
                                    {
                                        dtReport.Rows[dtReport.Rows.Count - 1][cr] = dt.Rows[dt.Rows.Count - 1][cr];
                                    }
                                    dtReport.Rows[dtReport.Rows.Count - 1][114] = "2";


                                    //dipengembangan berikutnya adalah penyimpanan log untuk yang gagal
                                }
                            }//end if CekAll
                            else
                            {
                                dtReport.Rows.Add();
                                for (int ct=0; ct < 114; ct++)
                                {
                                    dtReport.Rows[dtReport.Rows.Count - 1][ct] = dt.Rows[dtReport.Rows.Count - 1][ct];
                                }
                                dtReport.Rows[dtReport.Rows.Count - 1][114] = "1";
                                int p = 0;
                                for (p=0; p < 12; p++)
                                {
                                  switch (p)
                                    {
                                        case 0:

                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][21] = "Not Oke";
                                            }                                           
                                            break;

                                        case 1:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][22] = "Not Oke";
                                            }
                                            break;

                                        case 2:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][23] = "Not Oke";
                                            }
                                            break;

                                        case 3:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][24] = "Not Oke";
                                            }
                                            break;

                                        case 4:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][25] = "Not Oke";
                                            }
                                            break;

                                        case 5:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][26] = "Not Oke";
                                            }
                                            break;

                                        case 6:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][28] = "Not Oke";
                                            }
                                            break;

                                        case 7:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][29] = "Not Oke";
                                            }
                                            break;

                                        case 8:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][30] = "Not Oke";
                                            }
                                            break;

                                        case 9:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][31] = "Not Oke";
                                            }
                                            break;

                                        case 10:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][35] = "Not Oke";
                                            }
                                            break;

                                        case 11:
                                            if (listKondisi[p] == false)
                                            {
                                                dtReport.Rows[dtReport.Rows.Count - 1][36] = "Not Oke";
                                            }
                                            break;


                                    }

                                  
                                }
                                
                            }
                                _dbemployeeContext.SaveChanges();
                            }//Akhir else
                        }                
                }//end foreach row csv file

                //dtReport.Columns[0].ToString

                return View(dtReport);
            }

            return View();
        }



        [HttpGet]
        public FileResult Export (string pilihan)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeList = new List<Employee>();
            var data = _dbemployeeContext.TblEmployees.Where(m => (m.AdminApproval == 1 || m.AdminApproval == 2 || m.AdminApproval == 3) && m.ExitInformationTypeofExit == "-").ToList();
            //StringBuilder sb = new StringBuilder();

            //Jika Pilihan = INACTIVE maka ambil data ExitInformation_TypeofExit != "-", jika ACTIVE = -
            if (pilihan == "ACTIVE")
            {
                 data = _dbemployeeContext.TblEmployees.Where(m => (m.AdminApproval == 1 || m.AdminApproval == 2 || m.AdminApproval == 3) && m.ExitInformationTypeofExit == "-").ToList();
            }else if (pilihan == "INACTIVE")
            {
                data = _dbemployeeContext.TblEmployees.Where(m => (m.AdminApproval == 1 || m.AdminApproval == 2 || m.AdminApproval == 3) && m.ExitInformationTypeofExit != "-").ToList();
            }

            //Siapkan ListArrayValueTeksGradeLevel 
            //Ambil data ListArrayValueTeks dari tabel Tbl_GradeLevel
            List<TblGradeLevel> ListArrayValueTeksGradeLevel = _dbemployeeContext.TblGradeLevels.ToList();

            //Siapkan ListArrayValueTeksJobTitle
            List<TblJobTitle> ListArrayValueTeksJobTitle = _dbemployeeContext.TblJobTitles.ToList();

            //Siapakan ListArrayValueTeksLaborType
            List<TblLaborType> ListArrayValueTeksLaborType = _dbemployeeContext.TblLaborTypes.ToList();

            //Siapkan ListArrayValueTeksLaborClass
            List<TblLaborClass> ListArrayValueTeksLaborClass = _dbemployeeContext.TblLaborClasses.ToList();

            //Siapkan ListArrayValueTeksDivision
            List<TblDivision> ListArrayValueTeksDivision = _dbemployeeContext.TblDivisions.ToList();

            //Siapkan listArrayValueTeksCostCenter
            List<TblCostCenter> ListArrayValueTeksCostCenter = _dbemployeeContext.TblCostCenters.ToList();

            //Siapkan ListArrayValueTeksJobPost
            List<TblJobPost> ListArrayValueTeksDepartment = _dbemployeeContext.TblJobPosts.ToList();

            //Siapkan ListArrayValueTeksMoR
            List<TblMethodOfRecruitment> ListArrayValueTeksMoR = _dbemployeeContext.TblMethodOfRecruitments.ToList();

            //Siapkan ListArrayValueTeksSource
            List<TblSource> ListArrayValueTeksSource = _dbemployeeContext.TblSources.ToList();

            //Pemberian label header
            string[] columnNames = new string[] { "Basicinfo_Local ID ",
                "BasicInfo_Global ID ",
                " BasicInfo_Full Name ",
                " BasicInfo_Gender ",
                " BasicInfo_Photo ",
                " BasicInfo_Place of Birth ",
                " BasicInfo_Date of Birth ",
                " BasicInfo_Religion ",
                " BasicInfo_Nationality ",
                " Employmentstatus_Employment Type ",
                " Employmentstatus_Join Date ",
                " Employmentstatus_C1 Start ",
                " Employmentstatus_C1 End ",
                " Employmentstatus_C2 Start ",
                " Employmentstatus_C2 End ",
                " Employmentstatus_C3 Start ",
                " Employmentstatus_C3 End ",
                " Employmentstatus_Permanent Start Date ",
                " Employmentstatus_Employee status ",
                " Employmentstatus_Total service years byjoin ",
                " Employmentstatus_Total service years bypermanent ",
                " Jobprofile_Job Title ",
                " Jobprofile_Grade Or level ",
                " Jobprofile_Productivity Type ",
                " Jobprofile_Job Function ",
                " Jobprofile_Work Citizen ship ",
                " Jobprofile_Labor Type ",
                " Jobprofile_Labor Class ",
                " Jobprofile_Department ",
                " Jobprofile_Cost Center ",
                " Jobprofile_Division ",
                " Jobprofile_Work Lot Or Plant ",
                " Jobprofile_Supervisor Id ",
                " Jobprofile_Supervisor Name ",
                " Jobprofile_Shift Pattern ",
                " Recruitment_Method of Recruitment ",
                " Recruitment_Source ",
                " Recruitment_Recruitment Place ",
                " Recruitment_Requisition Number ",
                " Education_Education 1 ",
                " Education_FieldofStudy 1 ",
                " Education_InstitutionName 1 ",
                " Education_YearofGraduate 1 ",
                " Education_Education 2 ",
                " Education_FieldofStudy 2 ",
                " Education_InstitutionName 2 ",
                " Education_YearofGraduate 2 ",
                " IdentityandAccount_Nik ",
                " IdentityandAccount_No Bpjs kes ",
                " IdentityandAccount_No Bpjs tk ",
                " IdentityandAccount_No Passport ",
                " IdentityandAccount_Bank Account ",
                " IdentityandAccount_No Npwp ",
                " IdentityandAccount_Tax Status ",
                " ContactandAddress_Mobile Phone No ",
                " ContactandAddress_Personal Email Account ",
                " ContactandAddress_Current Address ",
                " ContactandAddress_Current Region Kelurahan ",
                " ContactandAddress_Current Region Kecamatan ",
                " ContactandAddress_Current City ",
                " ContactandAddress_Ktp address ",
                " ContactandAddress_Ktp district1 Kelurahan ",
                " ContactandAddress_Ktp district2 Kecamatan ",
                " ContactandAddress_Ktp city ",
                " ContactandAddress_Hometown Address ",
                " ContactandAddress_Howetown City ",
                " ContactandAddress_Dormitory Status ",
                " ContactandAddress_Dormitory No ",
                " FamilyDetails_Kk No ",
                " FamilyDetails_Marital Status ",
                " FamilyDetails_Spouse Name ",
                " FamilyDetails_No Of Children ",
                " FamilyDetails_Children Name 1 ",
                " FamilyDetails_Children Name 2 ",
                " FamilyDetails_Children Name 3 ",
                " EmergencyContact_Name",
                " EmergencyContact_Relationship ",
                " EmergencyContact_MobilePhoneNo ",
                " EmergencyContact_CurrentAddress ",
                " EmergencyContact_CurrentCity ",
                " AccessPropertiesandMembership_Work Email Account ",
                " AccessPropertiesandMembership_Proximity Card Id ",
                " AccessPropertiesandMembership_AccessDoorId ",
                " AccessPropertiesandMembership_ParkingAccess ",
                " AccessPropertiesandMembership_LockerId ",
                " AccessPropertiesandMembership_CompanySimcardId ",
                " AccessPropertiesandMembership_CompanyPhone ",
                " AccessPropertiesandMembership_CooperativeMembership ",
                " AccessPropertiesandMembership_Unionmembership ",
                " AccessPropertiesandMembership_Unionstartdate ",
                " AccessPropertiesandMembership_Unionexitdate ",
                " AccessPropertiesandMembership_Unionmembershipstatus ",
                " ExitInformation_TypeofExit ",
                " ExitInformation_LastPhysicalDate ",
                " ExitInformation_EffectiveDate ",
                " ExitInformation_ReasonofLeaving ",
                " ExitInformation_Eligibletorehire ",
        };

            string csv = string.Empty;
             foreach (string columnName in columnNames)
            {
                csv += columnName + ';';
            }

            csv += "\r\n";

   
            foreach (var dataemployee in data)
            {
                string Nama_GradeLevel = GetNamaGradeLevelFromId(dataemployee.JobprofileGradeOrlevel, ListArrayValueTeksGradeLevel);
                string Nama_JobTitle = GetNamaJobTitleFromId(dataemployee.JobprofileJobTitle, ListArrayValueTeksJobTitle);
                string Nama_LaborType = GetNamaLaborTypeFromId(dataemployee.JobprofileLaborType, ListArrayValueTeksLaborType);
                string Nama_LaborClass = GetNamaLaborClassFromId(dataemployee.JobprofileLaborClass, ListArrayValueTeksLaborClass);

                string Nama_Division = GetNamaDivisionFromId(dataemployee.JobprofileDivision, ListArrayValueTeksDivision);
                string Nama_CostCenter = GetNamaCostCenterFromId(dataemployee.JobprofileCostCenter, ListArrayValueTeksCostCenter);
                string Nama_Department = GetNamaJobPostFromId(dataemployee.JobprofileDepartment, ListArrayValueTeksDepartment);

                string Nama_MethodOfRecruitment = GetNamaMoRFromId(dataemployee.RecruitmentMethodofRecruitment, ListArrayValueTeksMoR);
                string Nama_Source = GetNamaSourceFromId(dataemployee.RecruitmentSource, ListArrayValueTeksSource);

                csv += dataemployee.BasicinfoLocalid + ';';
                csv += dataemployee.BasicinfoGlobalid + ';';
                csv += dataemployee.BasicinfoFullname + ';';
                csv += dataemployee.BasicinfoGender + ';';
                csv += dataemployee.BasicinfoPhoto + ';';
                csv += dataemployee.BasicinfoPlaceofBirth + ';';
                csv += dataemployee.BasicinfoDateofBirth.ToString() + ';';
                csv += dataemployee.BasicinfoReligion + ';';
                csv += dataemployee.BasicinfoNationality + ';';
                csv += dataemployee.EmploymentstatusEmploymentType + ';';
                csv += dataemployee.EmploymentstatusJoinDate.ToString() + ';';
                csv += dataemployee.EmploymentstatusC1start.ToString() + ';';
                csv += dataemployee.EmploymentstatusC1end.ToString() + ';';
                csv += dataemployee.EmploymentstatusC2start.ToString() + ';';
                csv += dataemployee.EmploymentstatusC2end.ToString() + ';';
                csv += dataemployee.EmploymentstatusC3start.ToString() + ';';
                csv += dataemployee.EmploymentstatusC3end.ToString() + ';';
                csv += dataemployee.EmploymentstatusPermanentstartdate.ToString() + ';';
                csv += dataemployee.EmploymentstatusEmployeestatus + ';';
                csv += dataemployee.EmploymentstatusTotalserviceyearsbyjoin.ToString() + ';';
                csv += dataemployee.EmploymentstatusTotalserviceyearsbypermanent.ToString() + ';';
                csv += Nama_JobTitle + ';';
                csv += Nama_GradeLevel + ';';
                csv += dataemployee.JobprofileProductivityType + ';';
                csv += dataemployee.JobprofileJobFunction + ';';
                csv += dataemployee.JobprofileWorkCitizenship + ';';
                csv += Nama_LaborType + ';';
                csv += Nama_LaborClass + ';';
                csv += Nama_Department + ';';
                csv += Nama_CostCenter + ';';
                csv += Nama_Division + ';';
                csv += dataemployee.JobprofileWorkLotOrplant + ';';
                csv += dataemployee.JobprofileSupervisorId + ';';
                csv += dataemployee.JobprofileSupervisorName + ';';
                csv += dataemployee.JobprofileShiftPattern + ';';
                csv += Nama_MethodOfRecruitment + ';';
                csv += Nama_Source + ';';
                csv += dataemployee.RecruitmentRecruitmentPlace + ';';
                csv += dataemployee.RecruitmentRequisitionNumber + ';';
                csv += dataemployee.EducationEducation1 + ';';
                csv += dataemployee.EducationFieldofStudy1 + ';';
                csv += dataemployee.EducationInstitutionName1 + ';';
                csv += dataemployee.EducationYearofGraduate1.ToString() + ';';
                csv += dataemployee.EducationEducation2 + ';';
                csv += dataemployee.EducationFieldofStudy2 + ';';
                csv += dataemployee.EducationInstitutionName2 + ';';
                csv += dataemployee.EducationYearofGraduate2.ToString() + ';';
                csv += dataemployee.IdentityandAccountNik + ';';
                csv += dataemployee.IdentityandAccountNoBpjskes + ';';
                csv += dataemployee.IdentityandAccountNoBpjstk + ';';
                csv += dataemployee.IdentityandAccountNoPassport + ';';
                csv += dataemployee.IdentityandAccountBankAccount + ';';
                csv += dataemployee.IdentityandAccountNoNpwp + ';';
                csv += dataemployee.IdentityandAccountTaxStatus + ';';
                csv += dataemployee.ContactandAddressMobilePhoneNo + ';';
                csv += dataemployee.ContactandAddressPersonalEmailAccount + ';';
                csv += dataemployee.ContactandAddressCurrentAddress + ';';
                csv += dataemployee.ContactandAddressCurrentRegionKelurahan + ';';
                csv += dataemployee.ContactandAddressCurrentRegionKecamatan + ';';
                csv += dataemployee.ContactandAddressCurrentCity + ';';
                csv += dataemployee.ContactandAddressKtpaddress + ';';
                csv += dataemployee.ContactandAddressKtpdistrict1Kelurahan + ';';
                csv += dataemployee.ContactandAddressKtpdistrict2Kecamatan + ';';
                csv += dataemployee.ContactandAddressKtpcity + ';';
                csv += dataemployee.ContactandAddressHometownAddress + ';';
                csv += dataemployee.ContactandAddressHowetownCity + ';';
                csv += dataemployee.ContactandAddressDormitoryStatus + ';';
                csv += dataemployee.ContactandAddressDormitoryNo + ';';
                csv += dataemployee.FamilyDetailsKkno + ';';
                csv += dataemployee.FamilyDetailsMarritalStatus + ';';
                csv += dataemployee.FamilyDetailsSpouseName + ';';
                csv += dataemployee.FamilyDetailsNoOfChildren.ToString() + ';';
                csv += dataemployee.FamilyDetailsChildrenName1 + ';';
                csv += dataemployee.FamilyDetailsChildrenName2 + ';';
                csv += dataemployee.FamilyDetailsChildrenName3 + ';';
                csv += dataemployee.EmergencyContactName + ';';
                csv += dataemployee.EmergencyContactRelationship + ';';
                csv += dataemployee.EmergencyContactMobilePhoneNo + ';';
                csv += dataemployee.EmergencyContactCurrentAddress + ';';
                csv += dataemployee.EmergencyContactCurrentCity + ';';
                csv += dataemployee.AccessPropertiesandMembershipWorkEmailAccount + ';';
                csv += dataemployee.AccessPropertiesandMembershipProximityCardId + ';';
                csv += dataemployee.AccessPropertiesandMembershipAccessDoorId + ';';
                csv += dataemployee.AccessPropertiesandMembershipParkingAccess + ';';
                csv += dataemployee.AccessPropertiesandMembershipLockerId + ';';
                csv += dataemployee.AccessPropertiesandMembershipCompanySimcardId + ';';
                csv += dataemployee.AccessPropertiesandMembershipCompanyPhone + ';';
                csv += dataemployee.AccessPropertiesandMembershipCooperativeMembership + ';';
                csv += dataemployee.AccessPropertiesandMembershipUnionmembership + ';';
                csv += dataemployee.AccessPropertiesandMembershipUnionstartdate.ToString() + ';';
                csv += dataemployee.AccessPropertiesandMembershipUnionexitdate.ToString() + ';';
                csv += dataemployee.AccessPropertiesandMembershipUnionmembershipstatus + ';';
                csv += dataemployee.ExitInformationTypeofExit + ';';
                csv += dataemployee.ExitInformationLastPhysicalDate.ToString() + ';';
                csv += dataemployee.ExitInformationEffectiveDate.ToString() + ';';
                csv += dataemployee.ExitInformationReasonofLeaving + ';';
                csv += dataemployee.ExitInformationEligibletorehire;


                csv += "\r\n";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File (bytes, "text/csv", "Emp.csv");
        }



        //Controller Login
        //[HttpPost]
        /*public IActionResult Login(User user)
        {
            //Employee employee = new Employee();
            var data = _dbemployeeContext.TblUsers.Where(m => (m.Username == user.Username) && (m.Password == user.Password)).FirstOrDefault();

            //simpan ke log
            var datalog = new Tbllog()
            {
                Username = user.Username,
                JenisOperasi = "",
                Tanggal = DateTime.Now,
                Isi = "",
            };



            if (data != null)
            {

                //Registrasi variabel session
                HttpContext.Session.SetInt32("Id_user", data.Id_user);
                HttpContext.Session.SetInt32("Role", data.Role);
                HttpContext.Session.SetString("Username", data.Username);

                TempData["LoginStatus"] = 1;
                //TempData["Id_user"] = data.Id_user;
                //TempData["Role"] = data.Role;
                //TempData["Username"] = data.Username;

                datalog.JenisOperasi = "Login Sukses";
                _dbemployeeContext.Tbllog.Add(datalog);


                _dbemployeeContext.SaveChanges();
                return RedirectToAction("Index", "Home");
                //RedirectToAction("Test", new { ID = model.ID, projectName = model.ProjectName })
            }
            else
            {
                datalog.JenisOperasi = "Login Gagal";
                _dbemployeeContext.Tbllog.Add(datalog);


                _dbemployeeContext.SaveChanges();
                TempData["LoginStatus"] = 0;
                return RedirectToAction("Index", "Home");
            }

        }*/

        public IActionResult Login(User user)
        {
            //Employee employee = new Employee();
            //string verified = Hasher.Verify(Hash, user.Password);
            //var data = _dbemployeeContext.TblUsers.Where(m => (m.Username == user.Username) && (m.Password == user.Password)).FirstOrDefault();
            var data = _dbemployeeContext.TblUsers.Where(m => (m.Username == user.Username)).FirstOrDefault();

            string pswd = data.Password;

            //simpan ke log
            var datalog = new Tbllog()
            {
                Username = user.Username,
                JenisOperasi = "",
                Tanggal = DateTime.Now,
                Isi = "",
            };

            if (Hasher.Verify(user.Password, pswd))
            {
                //Registrasi variabel session
                HttpContext.Session.SetInt32("Id_user", data.Id_user);
                HttpContext.Session.SetInt32("Role", data.Role);
                HttpContext.Session.SetString("Username", data.Username);

                TempData["LoginStatus"] = 1;
                //TempData["Id_user"] = data.Id_user;
                //TempData["Role"] = data.Role;
                //TempData["Username"] = data.Username;

                datalog.JenisOperasi = "Login Sukses";
                _dbemployeeContext.Tbllog.Add(datalog);


                _dbemployeeContext.SaveChanges();
                return RedirectToAction("Index", "Home");
                //RedirectToAction("Test", new { ID = model.ID, projectName = model.ProjectName })

            }
            else
            {
                datalog.JenisOperasi = "Login Gagal";
                _dbemployeeContext.Tbllog.Add(datalog);


                _dbemployeeContext.SaveChanges();
                TempData["LoginStatus"] = 0;
                return RedirectToAction("Index", "Home");
            }
        }

        //Controller Logout
        [HttpGet]
        public IActionResult Logout ()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            string hash_password = Hasher.Hash(user.Password);
            var RegisterData = new TblUser()
            {
                Username = user.Username,
                Password = hash_password,
                Role = user.Role
            };

            _dbemployeeContext.TblUsers.Add(RegisterData);
            _dbemployeeContext.SaveChanges();
            return RedirectToAction("Register", "Home");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}