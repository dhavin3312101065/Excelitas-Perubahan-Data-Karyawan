using EXCELITAS.data;
using EXCELITAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EXCELITAS.Controllers
{
    public class AdminApprovalController : Controller
    {
        private IHostEnvironment Environment;


        private readonly ILogger<HomeController> _logger;
        private DbemployeeContext _dbemployeeContext;

        public AdminApprovalController(ILogger<HomeController> logger, DbemployeeContext dbemployeeContext, IHostEnvironment _environment)
        {
            _logger = logger;
            _dbemployeeContext = dbemployeeContext;

            //for data csv
            Environment = _environment;

        }
        public IActionResult MenuAdminApproval()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeList = new List<Employee>();
            var data = _dbemployeeContext.TblEmployees.Where(m => m.AdminApproval == 0 || m.AdminApproval == 2).ToList();
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

                //1. Handling null values in datetime BasicinfoDateofBirth
                if (item.BasicinfoDateofBirth != null)
                {
                    item.BasicinfoDateofBirth = item.BasicinfoDateofBirth;
                }
                else
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
                    FamilyDetails_DateOfBirth_1 = (DateTime)item.FamilyDetails_DateOfBirth_1,
                    FamilyDetails_ChildrenName_2 = item.FamilyDetailsChildrenName2,
                    FamilyDetails_DateOfBirth_2 = (DateTime)item.FamilyDetails_DateOfBirth_2,
                    FamilyDetails_ChildrenName_3 = item.FamilyDetailsChildrenName3,
                    FamilyDetails_DateOfBirth_3 = (DateTime)item.FamilyDetails_DateOfBirth_3,
                    FamilyDetails_ChildrenName_4 = item.FamilyDetailsChildrenName4,
                    FamilyDetails_DateOfBirth_4 = (DateTime)item.FamilyDetails_DateOfBirth_4,
                    FamilyDetails_ChildrenName_5 = item.FamilyDetailsChildrenName5,
                    FamilyDetails_DateOfBirth_5 = (DateTime)item.FamilyDetails_DateOfBirth_5,
                    FamilyDetails_ChildrenName_6 = item.FamilyDetailsChildrenName6,
                    FamilyDetails_DateOfBirth_6 = (DateTime)item.FamilyDetails_DateOfBirth_6,
                    FamilyDetails_ChildrenName_7 = item.FamilyDetailsChildrenName7,
                    FamilyDetails_DateOfBirth_7 = (DateTime)item.FamilyDetails_DateOfBirth_7,
                    FamilyDetails_ChildrenName_8 = item.FamilyDetailsChildrenName8,
                    FamilyDetails_DateOfBirth_8 = (DateTime)item.FamilyDetails_DateOfBirth_8,
                    FamilyDetails_ChildrenName_9 = item.FamilyDetailsChildrenName9,
                    FamilyDetails_DateOfBirth_9 = (DateTime)item.FamilyDetails_DateOfBirth_9,
                    FamilyDetails_ChildrenName_10 = item.FamilyDetailsChildrenName10,
                    FamilyDetails_DateOfBirth_10 = (DateTime)item.FamilyDetails_DateOfBirth_10,
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

        //Get Detail data di halaman admin approval dari tabel employee atau data input baru
        [HttpGet]
        public IActionResult DetailApprovalInputBaru(int IdEm = 0)
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
                //employee.AdminApproval = 0;
            }
            return View(employee);
        }

        //Detail Data dihalaman adminapproval, juga tombol approval dan reject dari tbl employee
        [HttpPost]
        public IActionResult DetailApprovalInputBaru(Employee employee, string submit)
        {
            switch (submit)
            {
                case "1":
                    // Do something
                    try
                    {
                        //approval data employee yang berasal dari data input baru
                        var dataemployee = _dbemployeeContext.TblEmployees.Where(m => m.Id == employee.Id).FirstOrDefault();
                        //return Content(employee.Basicinfo_LOCALID);
                        dataemployee.AdminApproval = 1;

                        //simpan data karyawan baru ke log

                        var str_log = "BasicinfoLocalid = " + dataemployee.BasicinfoLocalid + "," +
                        "BasicinfoGlobalid = " + dataemployee.BasicinfoGlobalid + "," +
                        " BasicinfoFullname = " + dataemployee.BasicinfoFullname + "," +
                        " BasicinfoGender = " + dataemployee.BasicinfoGender + "," +
                        " BasicinfoPhoto = " + dataemployee.BasicinfoPhoto + "," +
                        " BasicinfoPlaceofBirth = " + dataemployee.BasicinfoPlaceofBirth + "," +
                        " BasicinfoDateofBirth = " + dataemployee.BasicinfoDateofBirth.ToString() + "," +
                        " BasicinfoReligion = " + dataemployee.BasicinfoReligion + "," +
                        " BasicinfoNationality = " + dataemployee.BasicinfoNationality + "," +
                        " EmploymentstatusEmploymentType = " + dataemployee.EmploymentstatusEmploymentType + "," +
                        " EmploymentstatusJoinDate = " + dataemployee.EmploymentstatusJoinDate.ToString() + "," +
                        " EmploymentstatusC1start = " + dataemployee.EmploymentstatusC1start.ToString() + "," +
                        " EmploymentstatusC1end = " + dataemployee.EmploymentstatusC1end.ToString() + "," +
                        " EmploymentstatusC2start = " + dataemployee.EmploymentstatusC2start.ToString() + "," +
                        " EmploymentstatusC2end = " + dataemployee.EmploymentstatusC2end.ToString() + "," +
                        " EmploymentstatusC3start = " + dataemployee.EmploymentstatusC3start.ToString() + "," +
                        " EmploymentstatusC3end = " + dataemployee.EmploymentstatusC3end.ToString() + "," +
                        " EmploymentstatusPermanentstartdate = " + dataemployee.EmploymentstatusPermanentstartdate.ToString() + "," +
                        " Employmentstatusdataemployeestatus = " + dataemployee.EmploymentstatusEmployeestatus + "," +
                        " EmploymentstatusTotalserviceyearsbyjoin = " + dataemployee.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                        " EmploymentstatusTotalserviceyearsbypermanent = " + dataemployee.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                        " JobprofileJobTitle = " + dataemployee.JobprofileJobTitle + "," +
                        " JobprofileGradeOrlevel = " + dataemployee.JobprofileGradeOrlevel + "," +
                        " JobprofileProductivityType = " + dataemployee.JobprofileProductivityType + "," +
                        " JobprofileJobFunction = " + dataemployee.JobprofileJobFunction + "," +
                        " JobprofileWorkCitizenship = " + dataemployee.JobprofileWorkCitizenship + "," +
                        " JobprofileLaborType = " + dataemployee.JobprofileLaborType + "," +
                        " JobprofileLaborClass = " + dataemployee.JobprofileLaborClass + "," +
                        " JobprofileDepartment = " + dataemployee.JobprofileDepartment + "," +
                        " JobprofileCostCenter = " + dataemployee.JobprofileCostCenter + "," +
                        " JobprofileDivision = " + dataemployee.JobprofileDivision + "," +
                        " JobprofileWorkLotOrplant = " + dataemployee.JobprofileWorkLotOrplant + "," +
                        " JobprofileSupervisorId = " + dataemployee.JobprofileSupervisorId + "," +
                        " JobprofileSupervisorName = " + dataemployee.JobprofileSupervisorName + "," +
                        " JobprofileShiftPattern = " + dataemployee.JobprofileShiftPattern + "," +
                        " RecruitmentMethodofRecruitment = " + dataemployee.RecruitmentMethodofRecruitment + "," +
                        " RecruitmentSource = " + dataemployee.RecruitmentSource + "," +
                        " RecruitmentRecruitmentPlace = " + dataemployee.RecruitmentRecruitmentPlace + "," +
                        " RecruitmentRequisitionNumber = " + dataemployee.RecruitmentRequisitionNumber + "," +
                        " EducationEducation1 = " + dataemployee.EducationEducation1 + "," +
                        " EducationFieldofStudy1 = " + dataemployee.EducationFieldofStudy1 + "," +
                        " EducationInstitutionName1 = " + dataemployee.EducationInstitutionName1 + "," +
                        " EducationYearofGraduate1 = " + dataemployee.EducationYearofGraduate1.ToString() + "," +
                        " EducationEducation2 = " + dataemployee.EducationEducation2 + "," +
                        " EducationFieldofStudy2 = " + dataemployee.EducationFieldofStudy2 + "," +
                        " EducationInstitutionName2 = " + dataemployee.EducationInstitutionName2 + "," +
                        " EducationYearofGraduate2 = " + dataemployee.EducationYearofGraduate2.ToString() + "," +
                        " IdentityandAccountNik = " + dataemployee.IdentityandAccountNik + "," +
                        " IdentityandAccountNoBpjskes = " + dataemployee.IdentityandAccountNoBpjskes + "," +
                        " IdentityandAccountNoBpjstk = " + dataemployee.IdentityandAccountNoBpjstk + "," +
                        " IdentityandAccountNoPassport = " + dataemployee.IdentityandAccountNoPassport + "," +
                        " IdentityandAccountBankAccount = " + dataemployee.IdentityandAccountBankAccount + "," +
                        " IdentityandAccountNoNpwp = " + dataemployee.IdentityandAccountNoNpwp + "," +
                        " IdentityandAccountTaxStatus = " + dataemployee.IdentityandAccountTaxStatus + "," +
                        " ContactandAddressMobilePhoneNo = " + dataemployee.ContactandAddressMobilePhoneNo + "," +
                        " ContactandAddressPersonalEmailAccount = " + dataemployee.ContactandAddressPersonalEmailAccount + "," +
                        " ContactandAddressCurrentAddress = " + dataemployee.ContactandAddressCurrentAddress + "," +
                        " ContactandAddressCurrentRegionKelurahan = " + dataemployee.ContactandAddressCurrentRegionKelurahan + "," +
                        " ContactandAddressCurrentRegionKecamatan = " + dataemployee.ContactandAddressCurrentRegionKecamatan + "," +
                        " ContactandAddressCurrentCity = " + dataemployee.ContactandAddressCurrentCity + "," +
                        " ContactandAddressKtpaddress = " + dataemployee.ContactandAddressKtpaddress + "," +
                        " ContactandAddressKtpdistrict1Kelurahan = " + dataemployee.ContactandAddressKtpdistrict1Kelurahan + "," +
                        " ContactandAddressKtpdistrict2Kecamatan = " + dataemployee.ContactandAddressKtpdistrict2Kecamatan + "," +
                        " ContactandAddressKtpcity = " + dataemployee.ContactandAddressKtpcity + "," +
                        " ContactandAddressHometownAddress = " + dataemployee.ContactandAddressHometownAddress + "," +
                        " ContactandAddressHowetownCity = " + dataemployee.ContactandAddressHowetownCity + "," +
                        " ContactandAddressDormitoryStatus = " + dataemployee.ContactandAddressDormitoryStatus + "," +
                        " ContactandAddressDormitoryNo = " + dataemployee.ContactandAddressDormitoryNo + "," +
                        " FamilyDetailsKkno = " + dataemployee.FamilyDetailsKkno + "," +
                        " FamilyDetailsMarritalStatus = " + dataemployee.FamilyDetailsMarritalStatus + "," +
                        " FamilyDetailsSpouseName = " + dataemployee.FamilyDetailsSpouseName + "," +
                        " FamilyDetailsNoOfChildren = " + dataemployee.FamilyDetailsNoOfChildren.ToString() + "," +
                        " FamilyDetailsChildrenName1 = " + dataemployee.FamilyDetailsChildrenName1 + "," +
                        " FamilyDetailsChildrenName2 = " + dataemployee.FamilyDetailsChildrenName2 + "," +
                        " FamilyDetailsChildrenName3 = " + dataemployee.FamilyDetailsChildrenName3 + "," +
                        " EmergencyContactName = " + dataemployee.EmergencyContactName + "," +
                        " EmergencyContactRelationship = " + dataemployee.EmergencyContactRelationship + "," +
                        " EmergencyContactMobilePhoneNo = " + dataemployee.EmergencyContactMobilePhoneNo + "," +
                        " EmergencyContactCurrentAddress = " + dataemployee.EmergencyContactCurrentAddress + "," +
                        " EmergencyContactCurrentCity = " + dataemployee.EmergencyContactCurrentCity + "," +
                        " AccessPropertiesandMembershipWorkEmailAccount = " + dataemployee.AccessPropertiesandMembershipWorkEmailAccount + "," +
                        " AccessPropertiesandMembershipProximityCardId = " + dataemployee.AccessPropertiesandMembershipProximityCardId + "," +
                        " AccessPropertiesandMembershipAccessDoorId = " + dataemployee.AccessPropertiesandMembershipAccessDoorId + "," +
                        " AccessPropertiesandMembershipParkingAccess = " + dataemployee.AccessPropertiesandMembershipParkingAccess + "," +
                        " AccessPropertiesandMembershipLockerId = " + dataemployee.AccessPropertiesandMembershipLockerId + "," +
                        " AccessPropertiesandMembershipCompanySimcardId = " + dataemployee.AccessPropertiesandMembershipCompanySimcardId + "," +
                        " AccessPropertiesandMembershipCompanyPhone = " + dataemployee.AccessPropertiesandMembershipCompanyPhone + "," +
                        " AccessPropertiesandMembershipCooperativeMembership = " + dataemployee.AccessPropertiesandMembershipCooperativeMembership + "," +
                        " AccessPropertiesandMembershipUnionmembership = " + dataemployee.AccessPropertiesandMembershipUnionmembership + "," +
                        " AccessPropertiesandMembershipUnionstartdate = " + dataemployee.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                        " AccessPropertiesandMembershipUnionexitdate = " + dataemployee.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                        " AccessPropertiesandMembershipUnionmembershipstatus = " + dataemployee.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                        " ExitInformationTypeofExit = " + dataemployee.ExitInformationTypeofExit + "," +
                        " ExitInformationLastPhysicalDate = " + dataemployee.ExitInformationLastPhysicalDate.ToString() + "," +
                        " ExitInformationEffectiveDate = " + dataemployee.ExitInformationEffectiveDate.ToString() + "," +
                        " ExitInformationReasonofLeaving = " + dataemployee.ExitInformationReasonofLeaving + "," +
                        " ExitInformationEligibletorehire = " + dataemployee.ExitInformationEligibletorehire;


                        var dataemployeelog = new Tbllog()
                        {
                            Username = "AdminApproval",
                            JenisOperasi = "Persetujuan usulan update data Karyawan baru",
                            Tanggal = DateTime.Now,
                            Isi = str_log,
                        };

                        _dbemployeeContext.Tbllog.Add(dataemployeelog);

                        _dbemployeeContext.SaveChanges();
                        TempData["ApprovalStatus"] = 1;
                    }
                    catch
                    {
                        TempData["ApprovalStatus"] = 0;
                    }
                    break;
                case "0":
                    // Do something
                    try
                    {
                        var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == employee.Id).FirstOrDefault();

                        //ubah status admin approval nya menjadi -1
                        if (data.AdminApproval == 0)
                        {
                            data.AdminApproval = -1;
                        }
                        //simpan ke log, 
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
                         " Employmentstatusdatastatus = " + data.EmploymentstatusEmployeestatus + "," +
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
                            Username = "AdminApproval",
                            JenisOperasi = "Penolakan usulan update data Karyawan baru",
                            Tanggal = DateTime.Now,
                            Isi = str_log,
                        };

                        _dbemployeeContext.Tbllog.Add(datalog);

                        _dbemployeeContext.SaveChanges();
                        TempData["ApprovalStatus"] = 1;
                    }
                    catch
                    {
                        TempData["ApprovalStatus"] = 0;
                    }
                    break;

            }


            return RedirectToAction("MenuAdminApproval", "AdminApproval");

        }

        //Get Detail data di halaman admin approval dari tabel tbl usulanemployee
        //coba
        [HttpGet]
        public IActionResult DetailApproval(string localId = "")
        {
            Employee employee = new Employee();
            var data = _dbemployeeContext.TblUsulanEmployees.Where(m => m.BasicinfoLocalid == localId).FirstOrDefault();

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
                //employee.AdminApproval = 0;
            }
            return View(employee);
        }

        //Detail Data dihalaman adminapproval, juga tombol approval dan reject data karyawan lama
        [HttpPost]
        public IActionResult DetailApproval(Employee employee, string submit)
        {
            switch (submit)
            {
                case "1":
                    // Do something
                    try
                    {
                        //copy data dari tbl usulan employee ke tbl employee
                        var datausulan = _dbemployeeContext.TblUsulanEmployees.Where(m => m.BasicinfoLocalid == employee.Basicinfo_LOCALID).FirstOrDefault();
                        //datausulan.AdminApproval = 1;

                        //approval data employee yang berasal dari data temporer atau usulan
                        var dataemployee = _dbemployeeContext.TblEmployees.Where(m => m.BasicinfoLocalid == employee.Basicinfo_LOCALID).FirstOrDefault();

                        //dataemployee.BasicinfoLocalid = datausulan.Basicinfo_LOCALID;
                        dataemployee.BasicinfoGlobalid = datausulan.BasicinfoGlobalid;
                        dataemployee.BasicinfoFullname = datausulan.BasicinfoFullname;
                        dataemployee.BasicinfoGender = datausulan.BasicinfoGender;
                        dataemployee.BasicinfoPhoto = datausulan.BasicinfoPhoto;
                        dataemployee.BasicinfoPlaceofBirth = datausulan.BasicinfoPlaceofBirth;
                        dataemployee.BasicinfoDateofBirth = datausulan.BasicinfoDateofBirth;
                        dataemployee.BasicinfoReligion = datausulan.BasicinfoReligion;
                        dataemployee.BasicinfoNationality = datausulan.BasicinfoNationality;
                        dataemployee.EmploymentstatusEmploymentType = datausulan.EmploymentstatusEmploymentType;
                        dataemployee.EmploymentstatusJoinDate = datausulan.EmploymentstatusJoinDate;
                        dataemployee.EmploymentstatusC1start = datausulan.EmploymentstatusC1start;
                        dataemployee.EmploymentstatusC1end = datausulan.EmploymentstatusC1end;
                        dataemployee.EmploymentstatusC2start = datausulan.EmploymentstatusC2start;
                        dataemployee.EmploymentstatusC2end = datausulan.EmploymentstatusC2end;
                        dataemployee.EmploymentstatusC3start = datausulan.EmploymentstatusC3start;
                        dataemployee.EmploymentstatusC3end = datausulan.EmploymentstatusC3end;
                        dataemployee.EmploymentstatusPermanentstartdate = datausulan.EmploymentstatusPermanentstartdate;
                        dataemployee.EmploymentstatusEmployeestatus = datausulan.EmploymentstatusEmployeestatus;
                        dataemployee.EmploymentstatusTotalserviceyearsbyjoin = datausulan.EmploymentstatusTotalserviceyearsbyjoin;
                        dataemployee.EmploymentstatusTotalserviceyearsbypermanent = datausulan.EmploymentstatusTotalserviceyearsbypermanent;
                        dataemployee.JobprofileJobTitle = datausulan.JobprofileJobTitle;
                        dataemployee.JobprofileGradeOrlevel = datausulan.JobprofileGradeOrlevel;
                        dataemployee.JobprofileProductivityType = datausulan.JobprofileProductivityType;
                        dataemployee.JobprofileJobFunction = datausulan.JobprofileJobFunction;
                        dataemployee.JobprofileWorkCitizenship = datausulan.JobprofileWorkCitizenship;
                        dataemployee.JobprofileLaborType = datausulan.JobprofileLaborType;
                        dataemployee.JobprofileLaborClass = datausulan.JobprofileLaborClass;
                        dataemployee.JobprofileDepartment = datausulan.JobprofileDepartment;
                        dataemployee.JobprofileCostCenter = datausulan.JobprofileCostCenter;
                        dataemployee.JobprofileDivision = datausulan.JobprofileDivision;
                        dataemployee.JobprofileWorkLotOrplant = datausulan.JobprofileWorkLotOrplant;
                        dataemployee.JobprofileSupervisorId = datausulan.JobprofileSupervisorId;
                        dataemployee.JobprofileSupervisorName = datausulan.JobprofileSupervisorName;
                        dataemployee.JobprofileShiftPattern = datausulan.JobprofileShiftPattern;
                        dataemployee.RecruitmentMethodofRecruitment = datausulan.RecruitmentMethodofRecruitment;
                        dataemployee.RecruitmentSource = datausulan.RecruitmentSource;
                        dataemployee.RecruitmentRecruitmentPlace = datausulan.RecruitmentRecruitmentPlace;
                        dataemployee.RecruitmentRequisitionNumber = datausulan.RecruitmentRequisitionNumber;
                        dataemployee.EducationEducation1 = datausulan.EducationEducation1;
                        dataemployee.EducationFieldofStudy1 = datausulan.EducationFieldofStudy1;
                        dataemployee.EducationInstitutionName1 = datausulan.EducationInstitutionName1;
                        dataemployee.EducationYearofGraduate1 = datausulan.EducationYearofGraduate1;
                        dataemployee.EducationEducation2 = datausulan.EducationEducation2;
                        dataemployee.EducationFieldofStudy2 = datausulan.EducationFieldofStudy2;
                        dataemployee.EducationInstitutionName2 = datausulan.EducationInstitutionName2;
                        dataemployee.EducationYearofGraduate2 = datausulan.EducationYearofGraduate2;
                        dataemployee.IdentityandAccountNik = datausulan.IdentityandAccountNik;
                        dataemployee.IdentityandAccountNoBpjskes = datausulan.IdentityandAccountNoBpjskes;
                        dataemployee.IdentityandAccountNoBpjstk = datausulan.IdentityandAccountNoBpjstk;
                        dataemployee.IdentityandAccountNoPassport = datausulan.IdentityandAccountNoPassport;
                        dataemployee.IdentityandAccountBankAccount = datausulan.IdentityandAccountBankAccount;
                        dataemployee.IdentityandAccountNoNpwp = datausulan.IdentityandAccountNoNpwp;
                        dataemployee.IdentityandAccountTaxStatus = datausulan.IdentityandAccountTaxStatus;
                        dataemployee.ContactandAddressMobilePhoneNo = datausulan.ContactandAddressMobilePhoneNo;
                        dataemployee.ContactandAddressPersonalEmailAccount = datausulan.ContactandAddressPersonalEmailAccount;
                        dataemployee.ContactandAddressCurrentAddress = datausulan.ContactandAddressCurrentAddress;
                        dataemployee.ContactandAddressCurrentRegionKelurahan = datausulan.ContactandAddressCurrentRegionKelurahan;
                        dataemployee.ContactandAddressCurrentRegionKecamatan = datausulan.ContactandAddressCurrentRegionKecamatan;
                        dataemployee.ContactandAddressCurrentCity = datausulan.ContactandAddressCurrentCity;
                        dataemployee.ContactandAddressKtpaddress = datausulan.ContactandAddressKtpaddress;
                        dataemployee.ContactandAddressKtpdistrict1Kelurahan = datausulan.ContactandAddressKtpdistrict1Kelurahan;
                        dataemployee.ContactandAddressKtpdistrict2Kecamatan = datausulan.ContactandAddressKtpdistrict2Kecamatan;
                        dataemployee.ContactandAddressKtpcity = datausulan.ContactandAddressKtpcity;
                        dataemployee.ContactandAddressHometownAddress = datausulan.ContactandAddressHometownAddress;
                        dataemployee.ContactandAddressHowetownCity = datausulan.ContactandAddressHowetownCity;
                        dataemployee.ContactandAddressDormitoryStatus = datausulan.ContactandAddressDormitoryStatus;
                        dataemployee.ContactandAddressDormitoryNo = datausulan.ContactandAddressDormitoryNo;
                        dataemployee.FamilyDetailsKkno = datausulan.FamilyDetailsKkno;
                        dataemployee.FamilyDetailsMarritalStatus = datausulan.FamilyDetailsMarritalStatus;
                        dataemployee.FamilyDetailsSpouseName = datausulan.FamilyDetailsSpouseName;
                        dataemployee.FamilyDetailsNoOfChildren = datausulan.FamilyDetailsNoOfChildren;
                        /*dataemployee.FamilyDetails_DateOfBirth_1 = (DateTime)datausulan.FamilyDetails_DateOfBirth_1;
                        dataemployee.FamilyDetails_ChildrenName_2 = datausulan.FamilyDetailsChildrenName2;
                        dataemployee.FamilyDetails_DateOfBirth_2 = (DateTime)datausulan.FamilyDetails_DateOfBirth_2;
                        dataemployee.FamilyDetails_ChildrenName_3 = datausulan.FamilyDetailsChildrenName3;
                        dataemployee.FamilyDetails_DateOfBirth_3 = (DateTime)datausulan.FamilyDetails_DateOfBirth_3;
                        dataemployee.FamilyDetails_ChildrenName_4 = datausulan.FamilyDetailsChildrenName4;
                        dataemployee.FamilyDetails_DateOfBirth_4 = (DateTime)datausulan.FamilyDetails_DateOfBirth_4;
                        dataemployee.FamilyDetails_ChildrenName_5 = datausulan.FamilyDetailsChildrenName5;
                        dataemployee.FamilyDetails_DateOfBirth_5 = (DateTime)datausulan.FamilyDetails_DateOfBirth_5;
                        dataemployee.FamilyDetails_ChildrenName_6 = datausulan.FamilyDetailsChildrenName6;
                        dataemployee.FamilyDetails_DateOfBirth_6 = (DateTime)datausulan.FamilyDetails_DateOfBirth_6;
                        dataemployee.FamilyDetails_ChildrenName_7 = datausulan.FamilyDetailsChildrenName7;
                        dataemployee.FamilyDetails_DateOfBirth_7 = (DateTime)datausulan.FamilyDetails_DateOfBirth_7;
                        dataemployee.FamilyDetails_ChildrenName_8 = datausulan.FamilyDetailsChildrenName8;
                        dataemployee.FamilyDetails_DateOfBirth_8 = (DateTime)datausulan.FamilyDetails_DateOfBirth_8;
                        dataemployee.FamilyDetails_ChildrenName_9 = datausulan.FamilyDetailsChildrenName9;
                        dataemployee.FamilyDetails_DateOfBirth_9 = (DateTime)datausulan.FamilyDetails_DateOfBirth_9;
                        dataemployee.FamilyDetails_ChildrenName_10 = datausulan.FamilyDetailsChildrenName10;
                        dataemployee.FamilyDetails_DateOfBirth_10 = (DateTime)datausulan.FamilyDetails_DateOfBirth_10;*/
                        dataemployee.EmergencyContactName = datausulan.EmergencyContactName;
                        dataemployee.EmergencyContactRelationship = datausulan.EmergencyContactRelationship;
                        dataemployee.EmergencyContactMobilePhoneNo = datausulan.EmergencyContactMobilePhoneNo;
                        dataemployee.EmergencyContactCurrentCity = datausulan.EmergencyContactCurrentAddress;
                        dataemployee.EmergencyContactCurrentCity = datausulan.EmergencyContactCurrentCity;
                        dataemployee.AccessPropertiesandMembershipWorkEmailAccount = datausulan.AccessPropertiesandMembershipWorkEmailAccount;
                        dataemployee.AccessPropertiesandMembershipProximityCardId = datausulan.AccessPropertiesandMembershipProximityCardId;
                        dataemployee.AccessPropertiesandMembershipAccessDoorId = datausulan.AccessPropertiesandMembershipAccessDoorId;
                        dataemployee.AccessPropertiesandMembershipParkingAccess = datausulan.AccessPropertiesandMembershipParkingAccess;
                        dataemployee.AccessPropertiesandMembershipLockerId = datausulan.AccessPropertiesandMembershipLockerId;
                        dataemployee.AccessPropertiesandMembershipCompanySimcardId = datausulan.AccessPropertiesandMembershipCompanySimcardId;
                        dataemployee.AccessPropertiesandMembershipCompanyPhone = datausulan.AccessPropertiesandMembershipCompanyPhone;
                        dataemployee.AccessPropertiesandMembershipCooperativeMembership = datausulan.AccessPropertiesandMembershipCooperativeMembership;
                        dataemployee.AccessPropertiesandMembershipUnionmembership = datausulan.AccessPropertiesandMembershipUnionmembership;
                        dataemployee.AccessPropertiesandMembershipUnionstartdate = datausulan.AccessPropertiesandMembershipUnionstartdate;
                        dataemployee.AccessPropertiesandMembershipUnionexitdate = datausulan.AccessPropertiesandMembershipUnionexitdate;
                        dataemployee.AccessPropertiesandMembershipUnionmembershipstatus = datausulan.AccessPropertiesandMembershipUnionmembershipstatus;
                        dataemployee.ExitInformationTypeofExit = datausulan.ExitInformationTypeofExit;
                        dataemployee.ExitInformationLastPhysicalDate = datausulan.ExitInformationLastPhysicalDate;
                        dataemployee.ExitInformationEffectiveDate = datausulan.ExitInformationEffectiveDate;
                        dataemployee.ExitInformationReasonofLeaving = datausulan.ExitInformationReasonofLeaving;
                        dataemployee.ExitInformationEligibletorehire = datausulan.ExitInformationEligibletorehire;
                        dataemployee.AdminApproval = 1;

                        _dbemployeeContext.TblUsulanEmployees.Remove(datausulan);
                        //end var

                        //simpan ke log, data yang sudah di approve
                        var str_log = "BasicinfoLocalid = " + dataemployee.BasicinfoLocalid + "," +
                        "BasicinfoGlobalid = " + dataemployee.BasicinfoGlobalid + "," +
                        " BasicinfoFullname = " + dataemployee.BasicinfoFullname + "," +
                        " BasicinfoGender = " + dataemployee.BasicinfoGender + "," +
                        " BasicinfoPhoto = " + dataemployee.BasicinfoPhoto + "," +
                        " BasicinfoPlaceofBirth = " + dataemployee.BasicinfoPlaceofBirth + "," +
                        " BasicinfoDateofBirth = " + dataemployee.BasicinfoDateofBirth.ToString() + "," +
                        " BasicinfoReligion = " + dataemployee.BasicinfoReligion + "," +
                        " BasicinfoNationality = " + dataemployee.BasicinfoNationality + "," +
                        " EmploymentstatusEmploymentType = " + dataemployee.EmploymentstatusEmploymentType + "," +
                        " EmploymentstatusJoinDate = " + dataemployee.EmploymentstatusJoinDate.ToString() + "," +
                        " EmploymentstatusC1start = " + dataemployee.EmploymentstatusC1start.ToString() + "," +
                        " EmploymentstatusC1end = " + dataemployee.EmploymentstatusC1end.ToString() + "," +
                        " EmploymentstatusC2start = " + dataemployee.EmploymentstatusC2start.ToString() + "," +
                        " EmploymentstatusC2end = " + dataemployee.EmploymentstatusC2end.ToString() + "," +
                        " EmploymentstatusC3start = " + dataemployee.EmploymentstatusC3start.ToString() + "," +
                        " EmploymentstatusC3end = " + dataemployee.EmploymentstatusC3end.ToString() + "," +
                        " EmploymentstatusPermanentstartdate = " + dataemployee.EmploymentstatusPermanentstartdate.ToString() + "," +
                        " EmploymentstatusEmployeestatus = " + dataemployee.EmploymentstatusEmployeestatus + "," +
                        " EmploymentstatusTotalserviceyearsbyjoin = " + dataemployee.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                        " EmploymentstatusTotalserviceyearsbypermanent = " + dataemployee.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                        " JobprofileJobTitle = " + dataemployee.JobprofileJobTitle + "," +
                        " JobprofileGradeOrlevel = " + dataemployee.JobprofileGradeOrlevel + "," +
                        " JobprofileProductivityType = " + dataemployee.JobprofileProductivityType + "," +
                        " JobprofileJobFunction = " + dataemployee.JobprofileJobFunction + "," +
                        " JobprofileWorkCitizenship = " + dataemployee.JobprofileWorkCitizenship + "," +
                        " JobprofileLaborType = " + dataemployee.JobprofileLaborType + "," +
                        " JobprofileLaborClass = " + dataemployee.JobprofileLaborClass + "," +
                        " JobprofileDepartment = " + dataemployee.JobprofileDepartment + "," +
                        " JobprofileCostCenter = " + dataemployee.JobprofileCostCenter + "," +
                        " JobprofileDivision = " + dataemployee.JobprofileDivision + "," +
                        " JobprofileWorkLotOrplant = " + dataemployee.JobprofileWorkLotOrplant + "," +
                        " JobprofileSupervisorId = " + dataemployee.JobprofileSupervisorId + "," +
                        " JobprofileSupervisorName = " + dataemployee.JobprofileSupervisorName + "," +
                        " JobprofileShiftPattern = " + dataemployee.JobprofileShiftPattern + "," +
                        " RecruitmentMethodofRecruitment = " + dataemployee.RecruitmentMethodofRecruitment + "," +
                        " RecruitmentSource = " + dataemployee.RecruitmentSource + "," +
                        " RecruitmentRecruitmentPlace = " + dataemployee.RecruitmentRecruitmentPlace + "," +
                        " RecruitmentRequisitionNumber = " + dataemployee.RecruitmentRequisitionNumber + "," +
                        " EducationEducation1 = " + dataemployee.EducationEducation1 + "," +
                        " EducationFieldofStudy1 = " + dataemployee.EducationFieldofStudy1 + "," +
                        " EducationInstitutionName1 = " + dataemployee.EducationInstitutionName1 + "," +
                        " EducationYearofGraduate1 = " + dataemployee.EducationYearofGraduate1.ToString() + "," +
                        " EducationEducation2 = " + dataemployee.EducationEducation2 + "," +
                        " EducationFieldofStudy2 = " + dataemployee.EducationFieldofStudy2 + "," +
                        " EducationInstitutionName2 = " + dataemployee.EducationInstitutionName2 + "," +
                        " EducationYearofGraduate2 = " + dataemployee.EducationYearofGraduate2.ToString() + "," +
                        " IdentityandAccountNik = " + dataemployee.IdentityandAccountNik + "," +
                        " IdentityandAccountNoBpjskes = " + dataemployee.IdentityandAccountNoBpjskes + "," +
                        " IdentityandAccountNoBpjstk = " + dataemployee.IdentityandAccountNoBpjstk + "," +
                        " IdentityandAccountNoPassport = " + dataemployee.IdentityandAccountNoPassport + "," +
                        " IdentityandAccountBankAccount = " + dataemployee.IdentityandAccountBankAccount + "," +
                        " IdentityandAccountNoNpwp = " + dataemployee.IdentityandAccountNoNpwp + "," +
                        " IdentityandAccountTaxStatus = " + dataemployee.IdentityandAccountTaxStatus + "," +
                        " ContactandAddressMobilePhoneNo = " + dataemployee.ContactandAddressMobilePhoneNo + "," +
                        " ContactandAddressPersonalEmailAccount = " + dataemployee.ContactandAddressPersonalEmailAccount + "," +
                        " ContactandAddressCurrentAddress = " + dataemployee.ContactandAddressCurrentAddress + "," +
                        " ContactandAddressCurrentRegionKelurahan = " + dataemployee.ContactandAddressCurrentRegionKelurahan + "," +
                        " ContactandAddressCurrentRegionKecamatan = " + dataemployee.ContactandAddressCurrentRegionKecamatan + "," +
                        " ContactandAddressCurrentCity = " + dataemployee.ContactandAddressCurrentCity + "," +
                        " ContactandAddressKtpaddress = " + dataemployee.ContactandAddressKtpaddress + "," +
                        " ContactandAddressKtpdistrict1Kelurahan = " + dataemployee.ContactandAddressKtpdistrict1Kelurahan + "," +
                        " ContactandAddressKtpdistrict2Kecamatan = " + dataemployee.ContactandAddressKtpdistrict2Kecamatan + "," +
                        " ContactandAddressKtpcity = " + dataemployee.ContactandAddressKtpcity + "," +
                        " ContactandAddressHometownAddress = " + dataemployee.ContactandAddressHometownAddress + "," +
                        " ContactandAddressHowetownCity = " + dataemployee.ContactandAddressHowetownCity + "," +
                        " ContactandAddressDormitoryStatus = " + dataemployee.ContactandAddressDormitoryStatus + "," +
                        " ContactandAddressDormitoryNo = " + dataemployee.ContactandAddressDormitoryNo + "," +
                        " FamilyDetailsKkno = " + dataemployee.FamilyDetailsKkno + "," +
                        " FamilyDetailsMarritalStatus = " + dataemployee.FamilyDetailsMarritalStatus + "," +
                        " FamilyDetailsSpouseName = " + dataemployee.FamilyDetailsSpouseName + "," +
                        " FamilyDetailsNoOfChildren = " + dataemployee.FamilyDetailsNoOfChildren.ToString() + "," +
                        " FamilyDetailsChildrenName1 = " + dataemployee.FamilyDetailsChildrenName1 + "," +
                        " FamilyDetailsChildrenName2 = " + dataemployee.FamilyDetailsChildrenName2 + "," +
                        " FamilyDetailsChildrenName3 = " + dataemployee.FamilyDetailsChildrenName3 + "," +
                        " EmergencyContactName = " + dataemployee.EmergencyContactName + "," +
                        " EmergencyContactRelationship = " + dataemployee.EmergencyContactRelationship + "," +
                        " EmergencyContactMobilePhoneNo = " + dataemployee.EmergencyContactMobilePhoneNo + "," +
                        " EmergencyContactCurrentAddress = " + dataemployee.EmergencyContactCurrentAddress + "," +
                        " EmergencyContactCurrentCity = " + dataemployee.EmergencyContactCurrentCity + "," +
                        " AccessPropertiesandMembershipWorkEmailAccount = " + dataemployee.AccessPropertiesandMembershipWorkEmailAccount + "," +
                        " AccessPropertiesandMembershipProximityCardId = " + dataemployee.AccessPropertiesandMembershipProximityCardId + "," +
                        " AccessPropertiesandMembershipAccessDoorId = " + dataemployee.AccessPropertiesandMembershipAccessDoorId + "," +
                        " AccessPropertiesandMembershipParkingAccess = " + dataemployee.AccessPropertiesandMembershipParkingAccess + "," +
                        " AccessPropertiesandMembershipLockerId = " + dataemployee.AccessPropertiesandMembershipLockerId + "," +
                        " AccessPropertiesandMembershipCompanySimcardId = " + dataemployee.AccessPropertiesandMembershipCompanySimcardId + "," +
                        " AccessPropertiesandMembershipCompanyPhone = " + dataemployee.AccessPropertiesandMembershipCompanyPhone + "," +
                        " AccessPropertiesandMembershipCooperativeMembership = " + dataemployee.AccessPropertiesandMembershipCooperativeMembership + "," +
                        " AccessPropertiesandMembershipUnionmembership = " + dataemployee.AccessPropertiesandMembershipUnionmembership + "," +
                        " AccessPropertiesandMembershipUnionstartdate = " + dataemployee.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                        " AccessPropertiesandMembershipUnionexitdate = " + dataemployee.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                        " AccessPropertiesandMembershipUnionmembershipstatus = " + dataemployee.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                        " ExitInformationTypeofExit = " + dataemployee.ExitInformationTypeofExit + "," +
                        " ExitInformationLastPhysicalDate = " + dataemployee.ExitInformationLastPhysicalDate.ToString() + "," +
                        " ExitInformationEffectiveDate = " + dataemployee.ExitInformationEffectiveDate.ToString() + "," +
                        " ExitInformationReasonofLeaving = " + dataemployee.ExitInformationReasonofLeaving + "," +
                        " ExitInformationEligibletorehire = " + dataemployee.ExitInformationEligibletorehire;


                        var dataemployeelog = new Tbllog()
                        {
                            Username = "AdminApproval",
                            JenisOperasi = "Persetujuan usulan update data Karyawan Lama",
                            Tanggal = DateTime.Now,
                            Isi = str_log,
                        };

                        _dbemployeeContext.Tbllog.Add(dataemployeelog);

                        _dbemployeeContext.SaveChanges();
                        TempData["ApprovalStatus"] = 1;
                    }
                    catch
                    {
                        TempData["ApprovalStatus"] = 0;
                    }
                    break;
                case "0":
                    // Do something
                    try
                    {
                        var data = _dbemployeeContext.TblEmployees.Where(m => m.BasicinfoLocalid == employee.Basicinfo_LOCALID).FirstOrDefault();
                        if (data.AdminApproval == 2)
                        {
                            data.AdminApproval = 3;
                            var datausulan = _dbemployeeContext.TblUsulanEmployees.Where(m => m.BasicinfoLocalid == employee.Basicinfo_LOCALID).FirstOrDefault();
                            //_dbemployeeContext.TblUsulanEmployees.Remove(datausulan);

                            //Simpan data usulan yang direject ke log
                            //Simpan data ke Log, Jenis nya adalah pengajuan ulang update data karyawan lama

                            var str_log = "BasicinfoLocalid = " + datausulan.BasicinfoLocalid + "," +
                            "BasicinfoGlobalid = " + datausulan.BasicinfoGlobalid + "," +
                            " BasicinfoFullname = " + datausulan.BasicinfoFullname + "," +
                            " BasicinfoGender = " + datausulan.BasicinfoGender + "," +
                            " BasicinfoPhoto = " + datausulan.BasicinfoPhoto + "," +
                            " BasicinfoPlaceofBirth = " + datausulan.BasicinfoPlaceofBirth + "," +
                            " BasicinfoDateofBirth = " + datausulan.BasicinfoDateofBirth.ToString() + "," +
                            " BasicinfoReligion = " + datausulan.BasicinfoReligion + "," +
                            " BasicinfoNationality = " + datausulan.BasicinfoNationality + "," +
                            " EmploymentstatusEmploymentType = " + datausulan.EmploymentstatusEmploymentType + "," +
                            " EmploymentstatusJoinDate = " + datausulan.EmploymentstatusJoinDate.ToString() + "," +
                            " EmploymentstatusC1start = " + datausulan.EmploymentstatusC1start.ToString() + "," +
                            " EmploymentstatusC1end = " + datausulan.EmploymentstatusC1end.ToString() + "," +
                            " EmploymentstatusC2start = " + datausulan.EmploymentstatusC2start.ToString() + "," +
                            " EmploymentstatusC2end = " + datausulan.EmploymentstatusC2end.ToString() + "," +
                            " EmploymentstatusC3start = " + datausulan.EmploymentstatusC3start.ToString() + "," +
                            " EmploymentstatusC3end = " + datausulan.EmploymentstatusC3end.ToString() + "," +
                            " EmploymentstatusPermanentstartdate = " + datausulan.EmploymentstatusPermanentstartdate.ToString() + "," +
                            " EmploymentstatusEmployeestatus = " + datausulan.EmploymentstatusEmployeestatus + "," +
                            " EmploymentstatusTotalserviceyearsbyjoin = " + datausulan.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                            " EmploymentstatusTotalserviceyearsbypermanent = " + datausulan.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                            " JobprofileJobTitle = " + datausulan.JobprofileJobTitle + "," +
                            " JobprofileGradeOrlevel = " + datausulan.JobprofileGradeOrlevel + "," +
                            " JobprofileProductivityType = " + datausulan.JobprofileProductivityType + "," +
                            " JobprofileJobFunction = " + datausulan.JobprofileJobFunction + "," +
                            " JobprofileWorkCitizenship = " + datausulan.JobprofileWorkCitizenship + "," +
                            " JobprofileLaborType = " + datausulan.JobprofileLaborType + "," +
                            " JobprofileLaborClass = " + datausulan.JobprofileLaborClass + "," +
                            " JobprofileDepartment = " + datausulan.JobprofileDepartment + "," +
                            " JobprofileCostCenter = " + datausulan.JobprofileCostCenter + "," +
                            " JobprofileDivision = " + datausulan.JobprofileDivision + "," +
                            " JobprofileWorkLotOrplant = " + datausulan.JobprofileWorkLotOrplant + "," +
                            " JobprofileSupervisorId = " + datausulan.JobprofileSupervisorId + "," +
                            " JobprofileSupervisorName = " + datausulan.JobprofileSupervisorName + "," +
                            " JobprofileShiftPattern = " + datausulan.JobprofileShiftPattern + "," +
                            " RecruitmentMethodofRecruitment = " + datausulan.RecruitmentMethodofRecruitment + "," +
                            " RecruitmentSource = " + datausulan.RecruitmentSource + "," +
                            " RecruitmentRecruitmentPlace = " + datausulan.RecruitmentRecruitmentPlace + "," +
                            " RecruitmentRequisitionNumber = " + datausulan.RecruitmentRequisitionNumber + "," +
                            " EducationEducation1 = " + datausulan.EducationEducation1 + "," +
                            " EducationFieldofStudy1 = " + datausulan.EducationFieldofStudy1 + "," +
                            " EducationInstitutionName1 = " + datausulan.EducationInstitutionName1 + "," +
                            " EducationYearofGraduate1 = " + datausulan.EducationYearofGraduate1.ToString() + "," +
                            " EducationEducation2 = " + datausulan.EducationEducation2 + "," +
                            " EducationFieldofStudy2 = " + datausulan.EducationFieldofStudy2 + "," +
                            " EducationInstitutionName2 = " + datausulan.EducationInstitutionName2 + "," +
                            " EducationYearofGraduate2 = " + datausulan.EducationYearofGraduate2.ToString() + "," +
                            " IdentityandAccountNik = " + datausulan.IdentityandAccountNik + "," +
                            " IdentityandAccountNoBpjskes = " + datausulan.IdentityandAccountNoBpjskes + "," +
                            " IdentityandAccountNoBpjstk = " + datausulan.IdentityandAccountNoBpjstk + "," +
                            " IdentityandAccountNoPassport = " + datausulan.IdentityandAccountNoPassport + "," +
                            " IdentityandAccountBankAccount = " + datausulan.IdentityandAccountBankAccount + "," +
                            " IdentityandAccountNoNpwp = " + datausulan.IdentityandAccountNoNpwp + "," +
                            " IdentityandAccountTaxStatus = " + datausulan.IdentityandAccountTaxStatus + "," +
                            " ContactandAddressMobilePhoneNo = " + datausulan.ContactandAddressMobilePhoneNo + "," +
                            " ContactandAddressPersonalEmailAccount = " + datausulan.ContactandAddressPersonalEmailAccount + "," +
                            " ContactandAddressCurrentAddress = " + datausulan.ContactandAddressCurrentAddress + "," +
                            " ContactandAddressCurrentRegionKelurahan = " + datausulan.ContactandAddressCurrentRegionKelurahan + "," +
                            " ContactandAddressCurrentRegionKecamatan = " + datausulan.ContactandAddressCurrentRegionKecamatan + "," +
                            " ContactandAddressCurrentCity = " + datausulan.ContactandAddressCurrentCity + "," +
                            " ContactandAddressKtpaddress = " + datausulan.ContactandAddressKtpaddress + "," +
                            " ContactandAddressKtpdistrict1Kelurahan = " + datausulan.ContactandAddressKtpdistrict1Kelurahan + "," +
                            " ContactandAddressKtpdistrict2Kecamatan = " + datausulan.ContactandAddressKtpdistrict2Kecamatan + "," +
                            " ContactandAddressKtpcity = " + datausulan.ContactandAddressKtpcity + "," +
                            " ContactandAddressHometownAddress = " + datausulan.ContactandAddressHometownAddress + "," +
                            " ContactandAddressHowetownCity = " + datausulan.ContactandAddressHowetownCity + "," +
                            " ContactandAddressDormitoryStatus = " + datausulan.ContactandAddressDormitoryStatus + "," +
                            " ContactandAddressDormitoryNo = " + datausulan.ContactandAddressDormitoryNo + "," +
                            " FamilyDetailsKkno = " + datausulan.FamilyDetailsKkno + "," +
                            " FamilyDetailsMarritalStatus = " + datausulan.FamilyDetailsMarritalStatus + "," +
                            " FamilyDetailsSpouseName = " + datausulan.FamilyDetailsSpouseName + "," +
                            " FamilyDetailsNoOfChildren = " + datausulan.FamilyDetailsNoOfChildren.ToString() + "," +
                            " FamilyDetailsChildrenName1 = " + datausulan.FamilyDetailsChildrenName1 + "," +
                            " FamilyDetailsChildrenName2 = " + datausulan.FamilyDetailsChildrenName2 + "," +
                            " FamilyDetailsChildrenName3 = " + datausulan.FamilyDetailsChildrenName3 + "," +
                            " EmergencyContactName = " + datausulan.EmergencyContactName + "," +
                            " EmergencyContactRelationship = " + datausulan.EmergencyContactRelationship + "," +
                            " EmergencyContactMobilePhoneNo = " + datausulan.EmergencyContactMobilePhoneNo + "," +
                            " EmergencyContactCurrentAddress = " + datausulan.EmergencyContactCurrentAddress + "," +
                            " EmergencyContactCurrentCity = " + datausulan.EmergencyContactCurrentCity + "," +
                            " AccessPropertiesandMembershipWorkEmailAccount = " + datausulan.AccessPropertiesandMembershipWorkEmailAccount + "," +
                            " AccessPropertiesandMembershipProximityCardId = " + datausulan.AccessPropertiesandMembershipProximityCardId + "," +
                            " AccessPropertiesandMembershipAccessDoorId = " + datausulan.AccessPropertiesandMembershipAccessDoorId + "," +
                            " AccessPropertiesandMembershipParkingAccess = " + datausulan.AccessPropertiesandMembershipParkingAccess + "," +
                            " AccessPropertiesandMembershipLockerId = " + datausulan.AccessPropertiesandMembershipLockerId + "," +
                            " AccessPropertiesandMembershipCompanySimcardId = " + datausulan.AccessPropertiesandMembershipCompanySimcardId + "," +
                            " AccessPropertiesandMembershipCompanyPhone = " + datausulan.AccessPropertiesandMembershipCompanyPhone + "," +
                            " AccessPropertiesandMembershipCooperativeMembership = " + datausulan.AccessPropertiesandMembershipCooperativeMembership + "," +
                            " AccessPropertiesandMembershipUnionmembership = " + datausulan.AccessPropertiesandMembershipUnionmembership + "," +
                            " AccessPropertiesandMembershipUnionstartdate = " + datausulan.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                            " AccessPropertiesandMembershipUnionexitdate = " + datausulan.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                            " AccessPropertiesandMembershipUnionmembershipstatus = " + datausulan.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                            " ExitInformationTypeofExit = " + datausulan.ExitInformationTypeofExit + "," +
                            " ExitInformationLastPhysicalDate = " + datausulan.ExitInformationLastPhysicalDate.ToString() + "," +
                            " ExitInformationEffectiveDate = " + datausulan.ExitInformationEffectiveDate.ToString() + "," +
                            " ExitInformationReasonofLeaving = " + datausulan.ExitInformationReasonofLeaving + "," +
                            " ExitInformationEligibletorehire = " + datausulan.ExitInformationEligibletorehire;


                            var datausulanlog = new Tbllog()
                            {
                                Username = "AdminApproval",
                                JenisOperasi = "Penolakan usulan update data Karyawan Lama",
                                Tanggal = DateTime.Now,
                                Isi = str_log,
                            };

                            _dbemployeeContext.Tbllog.Add(datausulanlog);

                        }


                        _dbemployeeContext.SaveChanges();
                        TempData["ApprovalStatus"] = 1;
                    }
                    catch
                    {
                        TempData["ApprovalStatus"] = 0;
                    }
                    break;
            }

            return RedirectToAction("MenuAdminApproval", "Home");

        }

    }
}
