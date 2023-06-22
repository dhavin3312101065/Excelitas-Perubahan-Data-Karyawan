using EXCELITAS.data;
using EXCELITAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EXCELITAS.Controllers
{
    public class AdminOperasionalController : Controller
    {
        private IHostEnvironment Environment;


        private readonly ILogger<HomeController> _logger;
        private DbemployeeContext _dbemployeeContext;

        public AdminOperasionalController(ILogger<HomeController> logger, DbemployeeContext dbemployeeContext, IHostEnvironment _environment)
        {
            _logger = logger;
            _dbemployeeContext = dbemployeeContext;

            //for data csv
            Environment = _environment;

        }

        //Tampilan Tabel Data di halaman Admin Operasional
        public IActionResult MenuAdminOperasional()
        {
                // disable browser's back button and and if somebody try to login by paste the url of any user account page, he can't.
                // nonaktifkan tombol kembali browser dan dan jika seseorang mencoba masuk dengan menempelkan url halaman akun pengguna mana pun, dia tidak bisa.
                /*if (HttpContext.Session.GetInt32("Role") == null)
                {
                    return RedirectToAction("Index", "Home");
                }*/

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
                string NmDepartment = "";
                if (d == 0)
                {
                    NmDepartment = "-";
                }
                else
                {
                    var NamaDepartment = _dbemployeeContext.TblJobPosts.Where(m => m.Id_JobPost == d).FirstOrDefault();
                    NmDepartment = NamaDepartment.Nama_JobPost;
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
                    Jobprofile_Department = NmDepartment,
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

        //Get Update Data untuk Admin Operasional (Karyawan lama)
        [HttpGet]
        public IActionResult UpdateApprovedData(int IdEm = 0)
        {
            Employee employee = new Employee();
            var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == IdEm).FirstOrDefault();

            var today = DateTime.Now;
            int yeartoday = today.Year;

            //Difference day Service By Join
            DateTime yearJoinDate = (DateTime)data.EmploymentstatusJoinDate;
            int yjd = yearJoinDate.Year;
            int idiffday = yeartoday - yjd;

            //Difference day Service By Permanent
            int PDdiffday;
            try
            {
                DateTime permanentDate = (DateTime)data.EmploymentstatusPermanentstartdate;
                int PD = permanentDate.Year;
                PDdiffday = yeartoday - PD;
            }
            catch
            {
                PDdiffday = -1;
            };

            int totalservicebypermanent;
            totalservicebypermanent = PDdiffday;

            //view bag Grade/Level
            List<TblGradeLevel> listgradelevel = _dbemployeeContext.TblGradeLevels.ToList();
            ViewBag.listgradelevel = new SelectList(listgradelevel, "Id_GradeLevel", "Nama_GradeLevel");

            //View bag Division
            List<TblDivision> listdivision = _dbemployeeContext.TblDivisions.ToList();
            ViewBag.listdivision = new SelectList(listdivision, "Id_Division", "Nama_Division");

            //View bag MethodOfRecruitment
            List<TblMethodOfRecruitment> ListMethodOfRecruitment = _dbemployeeContext.TblMethodOfRecruitments.ToList();
            ViewBag.ListMethodOfRecruitment = new SelectList(ListMethodOfRecruitment, "Id_MethodOfRecruitment", "Nama_MethodOfRecruitment");

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
                employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT = totalservicebypermanent;
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
                employee.FamilyDetails_ChildrenName_2 = data.FamilyDetailsChildrenName2;
                employee.FamilyDetails_ChildrenName_3 = data.FamilyDetailsChildrenName3;
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

        //Post update Data untuk halaman Admin Operasional (Karyawan lama)
        [HttpPost]
        public IActionResult UpdateApprovedData(Employee employee, IFormFile file)
        {
            try
            {
                int uploadfoto = 0;

                //Save The Picture In folder
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(contentPath, "wwwroot", "images_usulan");
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

                using var transaction = _dbemployeeContext.Database.BeginTransaction();

                var data = _dbemployeeContext.TblEmployees.Where(m => m.Id == employee.Id).FirstOrDefault();
               
                data.AdminApproval = 2;



                //cek jika ditabel usulan employee sudah ada datanya maka update, jika belum maka insert
                var cekdatausulan = _dbemployeeContext.TblUsulanEmployees.Where(m => m.BasicinfoLocalid == employee.Basicinfo_LOCALID).FirstOrDefault();
                if (cekdatausulan != null)
                {
                    cekdatausulan.BasicinfoLocalid = employee.Basicinfo_LOCALID;
                    cekdatausulan.BasicinfoGlobalid = employee.Basicinfo_GLOBALID;
                    cekdatausulan.BasicinfoFullname = employee.Basicinfo_FULLNAME;
                    cekdatausulan.BasicinfoGender = employee.Basicinfo_Gender;
                    if (uploadfoto == 1)
                    {
                        cekdatausulan.BasicinfoPhoto = employee.Basicinfo_PHOTO;
                    }
                    else
                    {
                        //form tidak meng upload foto maka data nya dari data awal, tbl_employee
                        cekdatausulan.BasicinfoPhoto = data.BasicinfoPhoto;
                    }
                    cekdatausulan.BasicinfoPlaceofBirth = employee.Basicinfo_PlaceofBirth;
                    cekdatausulan.BasicinfoDateofBirth = employee.Basicinfo_DateofBirth;
                    cekdatausulan.BasicinfoReligion = employee.Basicinfo_Religion;
                    cekdatausulan.BasicinfoNationality = employee.Basicinfo_Nationality;
                    cekdatausulan.EmploymentstatusEmploymentType = employee.Employmentstatus_EmploymentType;
                    cekdatausulan.EmploymentstatusJoinDate = employee.Employmentstatus_JoinDate;
                    cekdatausulan.EmploymentstatusC1start = employee.Employmentstatus_C1START;
                    cekdatausulan.EmploymentstatusC1end = employee.Employmentstatus_C1END;
                    cekdatausulan.EmploymentstatusC2start = employee.Employmentstatus_C2START;
                    cekdatausulan.EmploymentstatusC2end = employee.Employmentstatus_C2END;
                    cekdatausulan.EmploymentstatusC3start = employee.Employmentstatus_C3START;
                    cekdatausulan.EmploymentstatusC3end = employee.Employmentstatus_C3END;
                    cekdatausulan.EmploymentstatusPermanentstartdate = employee.Employmentstatus_PERMANENTSTARTDATE;
                    cekdatausulan.EmploymentstatusEmployeestatus = employee.Employmentstatus_EMPLOYEESTATUS;
                    cekdatausulan.EmploymentstatusTotalserviceyearsbyjoin = employee.Employmentstatus_TOTALSERVICEYEARSBYJOIN;
                    cekdatausulan.EmploymentstatusTotalserviceyearsbypermanent = employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT;
                    cekdatausulan.JobprofileJobTitle = employee.Jobprofile_JobTitle;
                    cekdatausulan.JobprofileGradeOrlevel = employee.Jobprofile_GradeORLevel;
                    cekdatausulan.JobprofileProductivityType = employee.Jobprofile_ProductivityType;
                    cekdatausulan.JobprofileJobFunction = employee.Jobprofile_JobFunction;
                    cekdatausulan.JobprofileWorkCitizenship = employee.Jobprofile_WorkCitizenship;
                    cekdatausulan.JobprofileLaborType = employee.Jobprofile_LaborType;
                    cekdatausulan.JobprofileLaborClass = employee.Jobprofile_LaborClass;
                    cekdatausulan.JobprofileDepartment = employee.Jobprofile_Department;
                    cekdatausulan.JobprofileCostCenter = employee.Jobprofile_CostCenter;
                    cekdatausulan.JobprofileDivision = employee.Jobprofile_Division;
                    cekdatausulan.JobprofileWorkLotOrplant = employee.Jobprofile_WorkLotORPlant;
                    cekdatausulan.JobprofileSupervisorId = employee.Jobprofile_SupervisorID;
                    cekdatausulan.JobprofileSupervisorName = employee.Jobprofile_SupervisorName;
                    cekdatausulan.JobprofileShiftPattern = employee.Jobprofile_ShiftPattern;
                    cekdatausulan.RecruitmentMethodofRecruitment = employee.Recruitment_MethodofRecruitment;
                    cekdatausulan.RecruitmentSource = employee.Recruitment_Source;
                    cekdatausulan.RecruitmentRecruitmentPlace = employee.Recruitment_RecruitmentPlace;
                    cekdatausulan.RecruitmentRequisitionNumber = employee.Recruitment_RequisitionNumber;
                    cekdatausulan.EducationEducation1 = employee.Education_Education1;
                    cekdatausulan.EducationFieldofStudy1 = employee.Education_FieldofStudy1;
                    cekdatausulan.EducationInstitutionName1 = employee.Education_InstitutionName1;
                    cekdatausulan.EducationYearofGraduate1 = employee.Education_YearofGraduate1;
                    cekdatausulan.EducationEducation2 = employee.Education_Education2;
                    cekdatausulan.EducationFieldofStudy2 = employee.Education_FieldofStudy2;
                    cekdatausulan.EducationInstitutionName2 = employee.Education_InstitutionName2;
                    cekdatausulan.EducationYearofGraduate2 = employee.Education_YearofGraduate2;
                    cekdatausulan.IdentityandAccountNik = employee.IdentityandAccount_NIK;
                    cekdatausulan.IdentityandAccountNoBpjskes = employee.IdentityandAccount_NoBPJSKes;
                    cekdatausulan.IdentityandAccountNoBpjstk = employee.IdentityandAccount_NoBPJSTK;
                    cekdatausulan.IdentityandAccountNoPassport = employee.IdentityandAccount_NoPassport;
                    cekdatausulan.IdentityandAccountBankAccount = employee.IdentityandAccount_BankAccount;
                    cekdatausulan.IdentityandAccountNoNpwp = employee.IdentityandAccount_NoNPWP;
                    cekdatausulan.IdentityandAccountTaxStatus = employee.IdentityandAccount_TaxStatus;
                    cekdatausulan.ContactandAddressMobilePhoneNo = employee.ContactandAddress_MobilePhoneNo;
                    cekdatausulan.ContactandAddressPersonalEmailAccount = employee.ContactandAddress_PersonalEmailAccount;
                    cekdatausulan.ContactandAddressCurrentAddress = employee.ContactandAddress_CurrentAddress;
                    cekdatausulan.ContactandAddressCurrentRegionKelurahan = employee.ContactandAddress_CurrentRegionKelurahan;
                    cekdatausulan.ContactandAddressCurrentRegionKecamatan = employee.ContactandAddress_CurrentRegionKecamatan;
                    cekdatausulan.ContactandAddressCurrentCity = employee.ContactandAddress_CurrentCity;
                    cekdatausulan.ContactandAddressKtpaddress = employee.ContactandAddress_KTPAddress;
                    cekdatausulan.ContactandAddressKtpdistrict1Kelurahan = employee.ContactandAddress_KTPDistrict1Kelurahan;
                    cekdatausulan.ContactandAddressKtpdistrict2Kecamatan = employee.ContactandAddress_KTPDistrict2Kecamatan;
                    cekdatausulan.ContactandAddressKtpcity = employee.ContactandAddress_KTPCity;
                    cekdatausulan.ContactandAddressHometownAddress = employee.ContactandAddress_HometownAddress;
                    cekdatausulan.ContactandAddressHowetownCity = employee.ContactandAddress_HowetownCity;
                    cekdatausulan.ContactandAddressDormitoryStatus = employee.ContactandAddress_DormitoryStatus;
                    cekdatausulan.ContactandAddressDormitoryNo = employee.ContactandAddress_DormitoryNo;
                    cekdatausulan.FamilyDetailsKkno = employee.FamilyDetails_KKNo;
                    cekdatausulan.FamilyDetailsMarritalStatus = employee.FamilyDetails_MarritalStatus;
                    cekdatausulan.FamilyDetailsSpouseName = employee.FamilyDetails_SpouseName;
                    cekdatausulan.FamilyDetailsNoOfChildren = employee.FamilyDetails_NoOfChildren;
                    cekdatausulan.FamilyDetailsChildrenName1 = employee.FamilyDetails_ChildrenName_1;
                    cekdatausulan.FamilyDetails_DateOfBirth_1 = employee.FamilyDetails_DateOfBirth_1;
                    cekdatausulan.FamilyDetailsChildrenName2 = employee.FamilyDetails_ChildrenName_2;
                    cekdatausulan.FamilyDetails_DateOfBirth_2 = employee.FamilyDetails_DateOfBirth_2;
                    cekdatausulan.FamilyDetailsChildrenName3 = employee.FamilyDetails_ChildrenName_3;
                    cekdatausulan.FamilyDetails_DateOfBirth_3 = employee.FamilyDetails_DateOfBirth_3;
                    cekdatausulan.FamilyDetailsChildrenName4 = employee.FamilyDetails_ChildrenName_4;
                    cekdatausulan.FamilyDetails_DateOfBirth_4 = employee.FamilyDetails_DateOfBirth_4;
                    cekdatausulan.FamilyDetailsChildrenName5 = employee.FamilyDetails_ChildrenName_5;
                    cekdatausulan.FamilyDetails_DateOfBirth_5 = employee.FamilyDetails_DateOfBirth_5;
                    cekdatausulan.FamilyDetailsChildrenName6 = employee.FamilyDetails_ChildrenName_6;
                    cekdatausulan.FamilyDetails_DateOfBirth_6 = employee.FamilyDetails_DateOfBirth_6;
                    cekdatausulan.FamilyDetailsChildrenName7 = employee.FamilyDetails_ChildrenName_7;
                    cekdatausulan.FamilyDetails_DateOfBirth_7 = employee.FamilyDetails_DateOfBirth_7;
                    cekdatausulan.FamilyDetailsChildrenName8 = employee.FamilyDetails_ChildrenName_8;
                    cekdatausulan.FamilyDetails_DateOfBirth_8 = employee.FamilyDetails_DateOfBirth_8;
                    cekdatausulan.FamilyDetailsChildrenName9 = employee.FamilyDetails_ChildrenName_9;
                    cekdatausulan.FamilyDetails_DateOfBirth_9 = employee.FamilyDetails_DateOfBirth_9;
                    cekdatausulan.FamilyDetailsChildrenName10 = employee.FamilyDetails_ChildrenName_10;
                    cekdatausulan.FamilyDetails_DateOfBirth_10 = employee.FamilyDetails_DateOfBirth_10;
                    cekdatausulan.EmergencyContactName = employee.EmergencyContact_Name;
                    cekdatausulan.EmergencyContactRelationship = employee.EmergencyContact_Relationship;
                    cekdatausulan.EmergencyContactMobilePhoneNo = employee.EmergencyContact_MobilePhoneNo;
                    cekdatausulan.EmergencyContactCurrentCity = employee.EmergencyContact_CurrentAddress;
                    cekdatausulan.EmergencyContactCurrentCity = employee.EmergencyContact_CurrentCity;
                    cekdatausulan.AccessPropertiesandMembershipWorkEmailAccount = employee.Access_PropertiesandMembership_WorkEmailAccount;
                    cekdatausulan.AccessPropertiesandMembershipProximityCardId = employee.Access_PropertiesandMembership_ProximityCardID;
                    cekdatausulan.AccessPropertiesandMembershipAccessDoorId = employee.Access_PropertiesandMembership_AccessDoorID;
                    cekdatausulan.AccessPropertiesandMembershipParkingAccess = employee.Access_PropertiesandMembership_ParkingAccess;
                    cekdatausulan.AccessPropertiesandMembershipLockerId = employee.Access_PropertiesandMembership_LockerID;
                    cekdatausulan.AccessPropertiesandMembershipCompanySimcardId = employee.Access_PropertiesandMembership_CompanySIMCardID;
                    cekdatausulan.AccessPropertiesandMembershipCompanyPhone = employee.Access_PropertiesandMembership_CompanyPhone;
                    cekdatausulan.AccessPropertiesandMembershipCooperativeMembership = employee.Access_PropertiesandMembership_CooperativeMembership;
                    cekdatausulan.AccessPropertiesandMembershipUnionmembership = employee.Access_PropertiesandMembership_UNIONMEMBERSHIP;
                    cekdatausulan.AccessPropertiesandMembershipUnionstartdate = employee.Access_PropertiesandMembership_UNIONSTARTDATE;
                    cekdatausulan.AccessPropertiesandMembershipUnionexitdate = employee.Access_PropertiesandMembership_UNIONEXITDATE;
                    cekdatausulan.AccessPropertiesandMembershipUnionmembershipstatus = employee.Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS;
                    cekdatausulan.ExitInformationTypeofExit = employee.ExitInformation_TypeofExit;
                    cekdatausulan.ExitInformationLastPhysicalDate = employee.ExitInformation_LastPhysicalDate;
                    cekdatausulan.ExitInformationEffectiveDate = employee.ExitInformation_EffectiveDate;
                    cekdatausulan.ExitInformationReasonofLeaving = employee.ExitInformation_ReasonofLeaving;
                    cekdatausulan.ExitInformationEligibletorehire = employee.ExitInformation_Eligibletorehire;
                    cekdatausulan.AdminApproval = uploadfoto;

                    //Simpan data ke Log, Jenis nya adalah pengajuan ulang update data karyawan lama

                    var str_log = "BasicinfoLocalid = " + cekdatausulan.BasicinfoLocalid + "," +
                    "BasicinfoGlobalid = " + cekdatausulan.BasicinfoGlobalid + "," +
                    " BasicinfoFullname = " + cekdatausulan.BasicinfoFullname + "," +
                    " BasicinfoGender = " + cekdatausulan.BasicinfoGender + "," +
                    " BasicinfoPhoto = " + cekdatausulan.BasicinfoPhoto + "," +
                    " BasicinfoPlaceofBirth = " + cekdatausulan.BasicinfoPlaceofBirth + "," +
                    " BasicinfoDateofBirth = " + cekdatausulan.BasicinfoDateofBirth.ToString() + "," +
                    " BasicinfoReligion = " + cekdatausulan.BasicinfoReligion + "," +
                    " BasicinfoNationality = " + cekdatausulan.BasicinfoNationality + "," +
                    " EmploymentstatusEmploymentType = " + cekdatausulan.EmploymentstatusEmploymentType + "," +
                    " EmploymentstatusJoinDate = " + cekdatausulan.EmploymentstatusJoinDate.ToString() + "," +
                    " EmploymentstatusC1start = " + cekdatausulan.EmploymentstatusC1start.ToString() + "," +
                    " EmploymentstatusC1end = " + cekdatausulan.EmploymentstatusC1end.ToString() + "," +
                    " EmploymentstatusC2start = " + cekdatausulan.EmploymentstatusC2start.ToString() + "," +
                    " EmploymentstatusC2end = " + cekdatausulan.EmploymentstatusC2end.ToString() + "," +
                    " EmploymentstatusC3start = " + cekdatausulan.EmploymentstatusC3start.ToString() + "," +
                    " EmploymentstatusC3end = " + cekdatausulan.EmploymentstatusC3end.ToString() + "," +
                    " EmploymentstatusPermanentstartdate = " + cekdatausulan.EmploymentstatusPermanentstartdate.ToString() + "," +
                    " EmploymentstatusEmployeestatus = " + cekdatausulan.EmploymentstatusEmployeestatus + "," +
                    " EmploymentstatusTotalserviceyearsbyjoin = " + cekdatausulan.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                    " EmploymentstatusTotalserviceyearsbypermanent = " + cekdatausulan.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                    " JobprofileJobTitle = " + cekdatausulan.JobprofileJobTitle + "," +
                    " JobprofileGradeOrlevel = " + cekdatausulan.JobprofileGradeOrlevel + "," +
                    " JobprofileProductivityType = " + cekdatausulan.JobprofileProductivityType + "," +
                    " JobprofileJobFunction = " + cekdatausulan.JobprofileJobFunction + "," +
                    " JobprofileWorkCitizenship = " + cekdatausulan.JobprofileWorkCitizenship + "," +
                    " JobprofileLaborType = " + cekdatausulan.JobprofileLaborType + "," +
                    " JobprofileLaborClass = " + cekdatausulan.JobprofileLaborClass + "," +
                    " JobprofileDepartment = " + cekdatausulan.JobprofileDepartment + "," +
                    " JobprofileCostCenter = " + cekdatausulan.JobprofileCostCenter + "," +
                    " JobprofileDivision = " + cekdatausulan.JobprofileDivision + "," +
                    " JobprofileWorkLotOrplant = " + cekdatausulan.JobprofileWorkLotOrplant + "," +
                    " JobprofileSupervisorId = " + cekdatausulan.JobprofileSupervisorId + "," +
                    " JobprofileSupervisorName = " + cekdatausulan.JobprofileSupervisorName + "," +
                    " JobprofileShiftPattern = " + cekdatausulan.JobprofileShiftPattern + "," +
                    " RecruitmentMethodofRecruitment = " + cekdatausulan.RecruitmentMethodofRecruitment + "," +
                    " RecruitmentSource = " + cekdatausulan.RecruitmentSource + "," +
                    " RecruitmentRecruitmentPlace = " + cekdatausulan.RecruitmentRecruitmentPlace + "," +
                    " RecruitmentRequisitionNumber = " + cekdatausulan.RecruitmentRequisitionNumber + "," +
                    " EducationEducation1 = " + cekdatausulan.EducationEducation1 + "," +
                    " EducationFieldofStudy1 = " + cekdatausulan.EducationFieldofStudy1 + "," +
                    " EducationInstitutionName1 = " + cekdatausulan.EducationInstitutionName1 + "," +
                    " EducationYearofGraduate1 = " + cekdatausulan.EducationYearofGraduate1.ToString() + "," +
                    " EducationEducation2 = " + cekdatausulan.EducationEducation2 + "," +
                    " EducationFieldofStudy2 = " + cekdatausulan.EducationFieldofStudy2 + "," +
                    " EducationInstitutionName2 = " + cekdatausulan.EducationInstitutionName2 + "," +
                    " EducationYearofGraduate2 = " + cekdatausulan.EducationYearofGraduate2.ToString() + "," +
                    " IdentityandAccountNik = " + cekdatausulan.IdentityandAccountNik + "," +
                    " IdentityandAccountNoBpjskes = " + cekdatausulan.IdentityandAccountNoBpjskes + "," +
                    " IdentityandAccountNoBpjstk = " + cekdatausulan.IdentityandAccountNoBpjstk + "," +
                    " IdentityandAccountNoPassport = " + cekdatausulan.IdentityandAccountNoPassport + "," +
                    " IdentityandAccountBankAccount = " + cekdatausulan.IdentityandAccountBankAccount + "," +
                    " IdentityandAccountNoNpwp = " + cekdatausulan.IdentityandAccountNoNpwp + "," +
                    " IdentityandAccountTaxStatus = " + cekdatausulan.IdentityandAccountTaxStatus + "," +
                    " ContactandAddressMobilePhoneNo = " + cekdatausulan.ContactandAddressMobilePhoneNo + "," +
                    " ContactandAddressPersonalEmailAccount = " + cekdatausulan.ContactandAddressPersonalEmailAccount + "," +
                    " ContactandAddressCurrentAddress = " + cekdatausulan.ContactandAddressCurrentAddress + "," +
                    " ContactandAddressCurrentRegionKelurahan = " + cekdatausulan.ContactandAddressCurrentRegionKelurahan + "," +
                    " ContactandAddressCurrentRegionKecamatan = " + cekdatausulan.ContactandAddressCurrentRegionKecamatan + "," +
                    " ContactandAddressCurrentCity = " + cekdatausulan.ContactandAddressCurrentCity + "," +
                    " ContactandAddressKtpaddress = " + cekdatausulan.ContactandAddressKtpaddress + "," +
                    " ContactandAddressKtpdistrict1Kelurahan = " + cekdatausulan.ContactandAddressKtpdistrict1Kelurahan + "," +
                    " ContactandAddressKtpdistrict2Kecamatan = " + cekdatausulan.ContactandAddressKtpdistrict2Kecamatan + "," +
                    " ContactandAddressKtpcity = " + cekdatausulan.ContactandAddressKtpcity + "," +
                    " ContactandAddressHometownAddress = " + cekdatausulan.ContactandAddressHometownAddress + "," +
                    " ContactandAddressHowetownCity = " + cekdatausulan.ContactandAddressHowetownCity + "," +
                    " ContactandAddressDormitoryStatus = " + cekdatausulan.ContactandAddressDormitoryStatus + "," +
                    " ContactandAddressDormitoryNo = " + cekdatausulan.ContactandAddressDormitoryNo + "," +
                    " FamilyDetailsKkno = " + cekdatausulan.FamilyDetailsKkno + "," +
                    " FamilyDetailsMarritalStatus = " + cekdatausulan.FamilyDetailsMarritalStatus + "," +
                    " FamilyDetailsSpouseName = " + cekdatausulan.FamilyDetailsSpouseName + "," +
                    " FamilyDetailsNoOfChildren = " + cekdatausulan.FamilyDetailsNoOfChildren.ToString() + "," +
                    " FamilyDetailsChildrenName1 = " + cekdatausulan.FamilyDetailsChildrenName1 + "," +
                    " FamilyDetailsChildrenName2 = " + cekdatausulan.FamilyDetailsChildrenName2 + "," +
                    " FamilyDetailsChildrenName3 = " + cekdatausulan.FamilyDetailsChildrenName3 + "," +
                    " EmergencyContactName = " + cekdatausulan.EmergencyContactName + "," +
                    " EmergencyContactRelationship = " + cekdatausulan.EmergencyContactRelationship + "," +
                    " EmergencyContactMobilePhoneNo = " + cekdatausulan.EmergencyContactMobilePhoneNo + "," +
                    " EmergencyContactCurrentAddress = " + cekdatausulan.EmergencyContactCurrentAddress + "," +
                    " EmergencyContactCurrentCity = " + cekdatausulan.EmergencyContactCurrentCity + "," +
                    " AccessPropertiesandMembershipWorkEmailAccount = " + cekdatausulan.AccessPropertiesandMembershipWorkEmailAccount + "," +
                    " AccessPropertiesandMembershipProximityCardId = " + cekdatausulan.AccessPropertiesandMembershipProximityCardId + "," +
                    " AccessPropertiesandMembershipAccessDoorId = " + cekdatausulan.AccessPropertiesandMembershipAccessDoorId + "," +
                    " AccessPropertiesandMembershipParkingAccess = " + cekdatausulan.AccessPropertiesandMembershipParkingAccess + "," +
                    " AccessPropertiesandMembershipLockerId = " + cekdatausulan.AccessPropertiesandMembershipLockerId + "," +
                    " AccessPropertiesandMembershipCompanySimcardId = " + cekdatausulan.AccessPropertiesandMembershipCompanySimcardId + "," +
                    " AccessPropertiesandMembershipCompanyPhone = " + cekdatausulan.AccessPropertiesandMembershipCompanyPhone + "," +
                    " AccessPropertiesandMembershipCooperativeMembership = " + cekdatausulan.AccessPropertiesandMembershipCooperativeMembership + "," +
                    " AccessPropertiesandMembershipUnionmembership = " + cekdatausulan.AccessPropertiesandMembershipUnionmembership + "," +
                    " AccessPropertiesandMembershipUnionstartdate = " + cekdatausulan.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                    " AccessPropertiesandMembershipUnionexitdate = " + cekdatausulan.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                    " AccessPropertiesandMembershipUnionmembershipstatus = " + cekdatausulan.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                    " ExitInformationTypeofExit = " + cekdatausulan.ExitInformationTypeofExit + "," +
                    " ExitInformationLastPhysicalDate = " + cekdatausulan.ExitInformationLastPhysicalDate.ToString() + "," +
                    " ExitInformationEffectiveDate = " + cekdatausulan.ExitInformationEffectiveDate.ToString() + "," +
                    " ExitInformationReasonofLeaving = " + cekdatausulan.ExitInformationReasonofLeaving + "," +
                    " ExitInformationEligibletorehire = " + cekdatausulan.ExitInformationEligibletorehire;


                    var cekdatausulanlog = new Tbllog()
                    {
                        Username = "AdminOperasional",
                        JenisOperasi = "Pengajuan ulang usulan update data Karyawan Lama",
                        Tanggal = DateTime.Now,
                        Isi = str_log,
                    };

                    _dbemployeeContext.Tbllog.Add(cekdatausulanlog);
                }
                else
                {

                    //insert data form ke tabel Usulan Employee
                    var datausulanemployee = new TblUsulanEmployee()
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
                        EmploymentstatusTotalserviceyearsbyjoin = employee.Employmentstatus_TOTALSERVICEYEARSBYJOIN,
                        EmploymentstatusTotalserviceyearsbypermanent = employee.Employmentstatus_TOTALSERVICEYEARSBYPERMANENT,
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
                        AdminApproval = uploadfoto,
                    };

                    _dbemployeeContext.TblUsulanEmployees.Add(datausulanemployee);

                    //Pengajuan usulan baru update karyawan lama
                    var str_log = "BasicinfoLocalid = " + datausulanemployee.BasicinfoLocalid + "," +
                    "BasicinfoGlobalid = " + datausulanemployee.BasicinfoGlobalid + "," +
                    " BasicinfoFullname = " + datausulanemployee.BasicinfoFullname + "," +
                    " BasicinfoGender = " + datausulanemployee.BasicinfoGender + "," +
                    " BasicinfoPhoto = " + datausulanemployee.BasicinfoPhoto + "," +
                    " BasicinfoPlaceofBirth = " + datausulanemployee.BasicinfoPlaceofBirth + "," +
                    " BasicinfoDateofBirth = " + datausulanemployee.BasicinfoDateofBirth.ToString() + "," +
                    " BasicinfoReligion = " + datausulanemployee.BasicinfoReligion + "," +
                    " BasicinfoNationality = " + datausulanemployee.BasicinfoNationality + "," +
                    " EmploymentstatusEmploymentType = " + datausulanemployee.EmploymentstatusEmploymentType + "," +
                    " EmploymentstatusJoinDate = " + datausulanemployee.EmploymentstatusJoinDate.ToString() + "," +
                    " EmploymentstatusC1start = " + datausulanemployee.EmploymentstatusC1start.ToString() + "," +
                    " EmploymentstatusC1end = " + datausulanemployee.EmploymentstatusC1end.ToString() + "," +
                    " EmploymentstatusC2start = " + datausulanemployee.EmploymentstatusC2start.ToString() + "," +
                    " EmploymentstatusC2end = " + datausulanemployee.EmploymentstatusC2end.ToString() + "," +
                    " EmploymentstatusC3start = " + datausulanemployee.EmploymentstatusC3start.ToString() + "," +
                    " EmploymentstatusC3end = " + datausulanemployee.EmploymentstatusC3end.ToString() + "," +
                    " EmploymentstatusPermanentstartdate = " + datausulanemployee.EmploymentstatusPermanentstartdate.ToString() + "," +
                    " EmploymentstatusEmployeestatus = " + datausulanemployee.EmploymentstatusEmployeestatus + "," +
                    " EmploymentstatusTotalserviceyearsbyjoin = " + datausulanemployee.EmploymentstatusTotalserviceyearsbyjoin.ToString() + "," +
                    " EmploymentstatusTotalserviceyearsbypermanent = " + datausulanemployee.EmploymentstatusTotalserviceyearsbypermanent.ToString() + "," +
                    " JobprofileJobTitle = " + datausulanemployee.JobprofileJobTitle + "," +
                    " JobprofileGradeOrlevel = " + datausulanemployee.JobprofileGradeOrlevel + "," +
                    " JobprofileProductivityType = " + datausulanemployee.JobprofileProductivityType + "," +
                    " JobprofileJobFunction = " + datausulanemployee.JobprofileJobFunction + "," +
                    " JobprofileWorkCitizenship = " + datausulanemployee.JobprofileWorkCitizenship + "," +
                    " JobprofileLaborType = " + datausulanemployee.JobprofileLaborType + "," +
                    " JobprofileLaborClass = " + datausulanemployee.JobprofileLaborClass + "," +
                    " JobprofileDepartment = " + datausulanemployee.JobprofileDepartment + "," +
                    " JobprofileCostCenter = " + datausulanemployee.JobprofileCostCenter + "," +
                    " JobprofileDivision = " + datausulanemployee.JobprofileDivision + "," +
                    " JobprofileWorkLotOrplant = " + datausulanemployee.JobprofileWorkLotOrplant + "," +
                    " JobprofileSupervisorId = " + datausulanemployee.JobprofileSupervisorId + "," +
                    " JobprofileSupervisorName = " + datausulanemployee.JobprofileSupervisorName + "," +
                    " JobprofileShiftPattern = " + datausulanemployee.JobprofileShiftPattern + "," +
                    " RecruitmentMethodofRecruitment = " + datausulanemployee.RecruitmentMethodofRecruitment + "," +
                    " RecruitmentSource = " + datausulanemployee.RecruitmentSource + "," +
                    " RecruitmentRecruitmentPlace = " + datausulanemployee.RecruitmentRecruitmentPlace + "," +
                    " RecruitmentRequisitionNumber = " + datausulanemployee.RecruitmentRequisitionNumber + "," +
                    " EducationEducation1 = " + datausulanemployee.EducationEducation1 + "," +
                    " EducationFieldofStudy1 = " + datausulanemployee.EducationFieldofStudy1 + "," +
                    " EducationInstitutionName1 = " + datausulanemployee.EducationInstitutionName1 + "," +
                    " EducationYearofGraduate1 = " + datausulanemployee.EducationYearofGraduate1.ToString() + "," +
                    " EducationEducation2 = " + datausulanemployee.EducationEducation2 + "," +
                    " EducationFieldofStudy2 = " + datausulanemployee.EducationFieldofStudy2 + "," +
                    " EducationInstitutionName2 = " + datausulanemployee.EducationInstitutionName2 + "," +
                    " EducationYearofGraduate2 = " + datausulanemployee.EducationYearofGraduate2.ToString() + "," +
                    " IdentityandAccountNik = " + datausulanemployee.IdentityandAccountNik + "," +
                    " IdentityandAccountNoBpjskes = " + datausulanemployee.IdentityandAccountNoBpjskes + "," +
                    " IdentityandAccountNoBpjstk = " + datausulanemployee.IdentityandAccountNoBpjstk + "," +
                    " IdentityandAccountNoPassport = " + datausulanemployee.IdentityandAccountNoPassport + "," +
                    " IdentityandAccountBankAccount = " + datausulanemployee.IdentityandAccountBankAccount + "," +
                    " IdentityandAccountNoNpwp = " + datausulanemployee.IdentityandAccountNoNpwp + "," +
                    " IdentityandAccountTaxStatus = " + datausulanemployee.IdentityandAccountTaxStatus + "," +
                    " ContactandAddressMobilePhoneNo = " + datausulanemployee.ContactandAddressMobilePhoneNo + "," +
                    " ContactandAddressPersonalEmailAccount = " + datausulanemployee.ContactandAddressPersonalEmailAccount + "," +
                    " ContactandAddressCurrentAddress = " + datausulanemployee.ContactandAddressCurrentAddress + "," +
                    " ContactandAddressCurrentRegionKelurahan = " + datausulanemployee.ContactandAddressCurrentRegionKelurahan + "," +
                    " ContactandAddressCurrentRegionKecamatan = " + datausulanemployee.ContactandAddressCurrentRegionKecamatan + "," +
                    " ContactandAddressCurrentCity = " + datausulanemployee.ContactandAddressCurrentCity + "," +
                    " ContactandAddressKtpaddress = " + datausulanemployee.ContactandAddressKtpaddress + "," +
                    " ContactandAddressKtpdistrict1Kelurahan = " + datausulanemployee.ContactandAddressKtpdistrict1Kelurahan + "," +
                    " ContactandAddressKtpdistrict2Kecamatan = " + datausulanemployee.ContactandAddressKtpdistrict2Kecamatan + "," +
                    " ContactandAddressKtpcity = " + datausulanemployee.ContactandAddressKtpcity + "," +
                    " ContactandAddressHometownAddress = " + datausulanemployee.ContactandAddressHometownAddress + "," +
                    " ContactandAddressHowetownCity = " + datausulanemployee.ContactandAddressHowetownCity + "," +
                    " ContactandAddressDormitoryStatus = " + datausulanemployee.ContactandAddressDormitoryStatus + "," +
                    " ContactandAddressDormitoryNo = " + datausulanemployee.ContactandAddressDormitoryNo + "," +
                    " FamilyDetailsKkno = " + datausulanemployee.FamilyDetailsKkno + "," +
                    " FamilyDetailsMarritalStatus = " + datausulanemployee.FamilyDetailsMarritalStatus + "," +
                    " FamilyDetailsSpouseName = " + datausulanemployee.FamilyDetailsSpouseName + "," +
                    " FamilyDetailsNoOfChildren = " + datausulanemployee.FamilyDetailsNoOfChildren.ToString() + "," +
                    " FamilyDetailsChildrenName1 = " + datausulanemployee.FamilyDetailsChildrenName1 + "," +
                    " FamilyDetailsChildrenName2 = " + datausulanemployee.FamilyDetailsChildrenName2 + "," +
                    " FamilyDetailsChildrenName3 = " + datausulanemployee.FamilyDetailsChildrenName3 + "," +
                    " EmergencyContactName = " + datausulanemployee.EmergencyContactName + "," +
                    " EmergencyContactRelationship = " + datausulanemployee.EmergencyContactRelationship + "," +
                    " EmergencyContactMobilePhoneNo = " + datausulanemployee.EmergencyContactMobilePhoneNo + "," +
                    " EmergencyContactCurrentAddress = " + datausulanemployee.EmergencyContactCurrentAddress + "," +
                    " EmergencyContactCurrentCity = " + datausulanemployee.EmergencyContactCurrentCity + "," +
                    " AccessPropertiesandMembershipWorkEmailAccount = " + datausulanemployee.AccessPropertiesandMembershipWorkEmailAccount + "," +
                    " AccessPropertiesandMembershipProximityCardId = " + datausulanemployee.AccessPropertiesandMembershipProximityCardId + "," +
                    " AccessPropertiesandMembershipAccessDoorId = " + datausulanemployee.AccessPropertiesandMembershipAccessDoorId + "," +
                    " AccessPropertiesandMembershipParkingAccess = " + datausulanemployee.AccessPropertiesandMembershipParkingAccess + "," +
                    " AccessPropertiesandMembershipLockerId = " + datausulanemployee.AccessPropertiesandMembershipLockerId + "," +
                    " AccessPropertiesandMembershipCompanySimcardId = " + datausulanemployee.AccessPropertiesandMembershipCompanySimcardId + "," +
                    " AccessPropertiesandMembershipCompanyPhone = " + datausulanemployee.AccessPropertiesandMembershipCompanyPhone + "," +
                    " AccessPropertiesandMembershipCooperativeMembership = " + datausulanemployee.AccessPropertiesandMembershipCooperativeMembership + "," +
                    " AccessPropertiesandMembershipUnionmembership = " + datausulanemployee.AccessPropertiesandMembershipUnionmembership + "," +
                    " AccessPropertiesandMembershipUnionstartdate = " + datausulanemployee.AccessPropertiesandMembershipUnionstartdate.ToString() + "," +
                    " AccessPropertiesandMembershipUnionexitdate = " + datausulanemployee.AccessPropertiesandMembershipUnionexitdate.ToString() + "," +
                    " AccessPropertiesandMembershipUnionmembershipstatus = " + datausulanemployee.AccessPropertiesandMembershipUnionmembershipstatus + "," +
                    " ExitInformationTypeofExit = " + datausulanemployee.ExitInformationTypeofExit + "," +
                    " ExitInformationLastPhysicalDate = " + datausulanemployee.ExitInformationLastPhysicalDate.ToString() + "," +
                    " ExitInformationEffectiveDate = " + datausulanemployee.ExitInformationEffectiveDate.ToString() + "," +
                    " ExitInformationReasonofLeaving = " + datausulanemployee.ExitInformationReasonofLeaving + "," +
                    " ExitInformationEligibletorehire = " + datausulanemployee.ExitInformationEligibletorehire;


                    var datausulanemployeelog = new Tbllog()
                    {
                        Username = "AdminOperasional",
                        JenisOperasi = "Pengajuan usulan update data Karyawan Lama",
                        Tanggal = DateTime.Now,
                        Isi = str_log,
                    };

                    _dbemployeeContext.Tbllog.Add(datausulanemployeelog);

                }



                _dbemployeeContext.SaveChanges();
                TempData["UpdateStatusApprovedData"] = 1;
                //end var
                transaction.Commit();
                //return Content(datausulanemployee.BasicinfoGlobalid);
            }
            catch
            {
                TempData["UpdateStatusApprovedData"] = 0;
                //return RedirectToAction("MenuAdminOperasional", "Home");
            }
            return RedirectToAction("MenuAdminOperasional", "AdminOperasional");
        }
    }
}
