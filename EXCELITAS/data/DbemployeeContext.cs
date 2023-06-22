using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EXCELITAS.data;

public partial class DbemployeeContext : DbContext
{
    public DbemployeeContext()
    {
    }

    public DbemployeeContext(DbContextOptions<DbemployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }
    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUsulanEmployee> TblUsulanEmployees { get; set; }

    public virtual DbSet<Tbllog> Tbllog { get; set; }

    public virtual DbSet<TblGradeLevel> TblGradeLevels { get; set; }

    public virtual DbSet<TblJobTitle> TblJobTitles { get; set; }

    public virtual DbSet<TblLaborType> TblLaborTypes { get; set; }

    public virtual DbSet<TblLaborClass> TblLaborClasses { get; set; }

    public virtual DbSet<TblDivision> TblDivisions { get; set; }

    public virtual DbSet<TblCostCenter> TblCostCenters { get; set; }

    public virtual DbSet<TblJobPost> TblJobPosts { get; set; }

    public virtual DbSet<TblMethodOfRecruitment> TblMethodOfRecruitments { get; set; }

    public virtual DbSet<TblSource> TblSources { get; set; }

    public virtual DbSet<TblProductivityType> TblProductivityTypes { get; set; }

    public virtual DbSet<TblJobFunction> TblJobFunctions { get; set; }

    public virtual DbSet<TblWorkLotOrPlant> TblWorkOrPlants { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
        // protected override void OnConfiguring (DBContextOptionsBuilder optionBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=LAB-16;Database=DBEmployee;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Tbl_Employee");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.AccessPropertiesandMembershipAccessDoorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_AccessDoorID");
            entity.Property(e => e.AccessPropertiesandMembershipCompanyPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CompanyPhone");
            entity.Property(e => e.AccessPropertiesandMembershipCompanySimcardId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CompanySIMCardID");
            entity.Property(e => e.AccessPropertiesandMembershipCooperativeMembership)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CooperativeMembership");
            entity.Property(e => e.AccessPropertiesandMembershipLockerId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_LockerID");
            entity.Property(e => e.AccessPropertiesandMembershipParkingAccess)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_ParkingAccess");
            entity.Property(e => e.AccessPropertiesandMembershipProximityCardId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_ProximityCardID");
            entity.Property(e => e.AccessPropertiesandMembershipUnionexitdate)
                .HasColumnType("date")
                .HasColumnName("Access_PropertiesandMembership_UNIONEXITDATE");
            entity.Property(e => e.AccessPropertiesandMembershipUnionmembership)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_UNIONMEMBERSHIP");
            entity.Property(e => e.AccessPropertiesandMembershipUnionmembershipstatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS");
            entity.Property(e => e.AccessPropertiesandMembershipUnionstartdate)
                .HasColumnType("date")
                .HasColumnName("Access_PropertiesandMembership_UNIONSTARTDATE");
            entity.Property(e => e.AccessPropertiesandMembershipWorkEmailAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_WorkEmailAccount");
            entity.Property(e => e.BasicinfoDateofBirth)
                .HasColumnType("datetime")
                .HasColumnName("Basicinfo_DateofBirth");
            entity.Property(e => e.BasicinfoFullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_FULLNAME");
            entity.Property(e => e.BasicinfoGender)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Gender");
            entity.Property(e => e.BasicinfoGlobalid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_GLOBALID");
            entity.Property(e => e.BasicinfoLocalid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_LOCALID");
            entity.Property(e => e.BasicinfoNationality)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Nationality");
            entity.Property(e => e.BasicinfoPhoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_PHOTO");
            entity.Property(e => e.BasicinfoPlaceofBirth)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_PlaceofBirth");
            entity.Property(e => e.BasicinfoReligion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Religion");
            entity.Property(e => e.ContactandAddressCurrentAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentAddress");
            entity.Property(e => e.ContactandAddressCurrentCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentCity");
            entity.Property(e => e.ContactandAddressCurrentRegionKecamatan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentRegionKecamatan");
            entity.Property(e => e.ContactandAddressCurrentRegionKelurahan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentRegionKelurahan");
            entity.Property(e => e.ContactandAddressDormitoryNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_DormitoryNo");
            entity.Property(e => e.ContactandAddressDormitoryStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_DormitoryStatus");
            entity.Property(e => e.ContactandAddressHometownAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_HometownAddress");
            entity.Property(e => e.ContactandAddressHowetownCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_HowetownCity");
            entity.Property(e => e.ContactandAddressKtpaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPAddress");
            entity.Property(e => e.ContactandAddressKtpcity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPCity");
            entity.Property(e => e.ContactandAddressKtpdistrict1Kelurahan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPDistrict1Kelurahan");
            entity.Property(e => e.ContactandAddressKtpdistrict2Kecamatan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPDistrict2Kecamatan");
            entity.Property(e => e.ContactandAddressMobilePhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_MobilePhoneNo");
            entity.Property(e => e.ContactandAddressPersonalEmailAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_PersonalEmailAccount");
            entity.Property(e => e.EducationEducation1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_Education1");
            entity.Property(e => e.EducationEducation2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_Education2");
            entity.Property(e => e.EducationFieldofStudy1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_FieldofStudy1");
            entity.Property(e => e.EducationFieldofStudy2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_FieldofStudy2");
            entity.Property(e => e.EducationInstitutionName1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_InstitutionName1");
            entity.Property(e => e.EducationInstitutionName2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_InstitutionName2");
            entity.Property(e => e.EducationYearofGraduate1).HasColumnName("Education_YearofGraduate1");
            entity.Property(e => e.EducationYearofGraduate2).HasColumnName("Education_YearofGraduate2");
            entity.Property(e => e.EmergencyContactCurrentAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_CurrentAddress");
            entity.Property(e => e.EmergencyContactCurrentCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_CurrentCity");
            entity.Property(e => e.EmergencyContactMobilePhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_MobilePhoneNo");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_Name");
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_Relationship");
            entity.Property(e => e.EmploymentstatusC1end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C1END");
            entity.Property(e => e.EmploymentstatusC1start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C1START");
            entity.Property(e => e.EmploymentstatusC2end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C2END");
            entity.Property(e => e.EmploymentstatusC2start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C2START");
            entity.Property(e => e.EmploymentstatusC3end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C3END");
            entity.Property(e => e.EmploymentstatusC3start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C3START");
            entity.Property(e => e.EmploymentstatusEmployeestatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employmentstatus_EMPLOYEESTATUS");
            entity.Property(e => e.EmploymentstatusEmploymentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employmentstatus_EmploymentType");
            entity.Property(e => e.EmploymentstatusJoinDate)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_JoinDate");
            entity.Property(e => e.EmploymentstatusPermanentstartdate)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_PERMANENTSTARTDATE");
            entity.Property(e => e.EmploymentstatusTotalserviceyearsbyjoin).HasColumnName("Employmentstatus_TOTALSERVICEYEARSBYJOIN");
            entity.Property(e => e.EmploymentstatusTotalserviceyearsbypermanent).HasColumnName("Employmentstatus_TOTALSERVICEYEARSBYPERMANENT");
            entity.Property(e => e.ExitInformationEffectiveDate)
                .HasColumnType("date")
                .HasColumnName("ExitInformation_EffectiveDate");
            entity.Property(e => e.ExitInformationEligibletorehire)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_Eligibletorehire");
            entity.Property(e => e.ExitInformationLastPhysicalDate)
                .HasColumnType("date")
                .HasColumnName("ExitInformation_LastPhysicalDate");
            entity.Property(e => e.ExitInformationReasonofLeaving)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_ReasonofLeaving");
            entity.Property(e => e.ExitInformationTypeofExit)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_TypeofExit");
            entity.Property(e => e.FamilyDetailsChildrenName1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_1");
            entity.Property(e => e.FamilyDetails_DateOfBirth_1)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_1");
            entity.Property(e => e.FamilyDetailsChildrenName2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_2");
            entity.Property(e => e.FamilyDetails_DateOfBirth_2)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_2");
            entity.Property(e => e.FamilyDetailsChildrenName3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_3");
            entity.Property(e => e.FamilyDetails_DateOfBirth_3)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_3");
            entity.Property(e => e.FamilyDetailsChildrenName4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_4");
            entity.Property(e => e.FamilyDetails_DateOfBirth_4)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_4");
            entity.Property(e => e.FamilyDetailsChildrenName5)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_5");
            entity.Property(e => e.FamilyDetails_DateOfBirth_5)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_5");
            entity.Property(e => e.FamilyDetailsChildrenName6)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_6");
            entity.Property(e => e.FamilyDetails_DateOfBirth_6)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_6");
            entity.Property(e => e.FamilyDetailsChildrenName7)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_7");
            entity.Property(e => e.FamilyDetails_DateOfBirth_7)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_7");
            entity.Property(e => e.FamilyDetailsChildrenName8)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_8");
            entity.Property(e => e.FamilyDetails_DateOfBirth_8)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_8");
            entity.Property(e => e.FamilyDetailsChildrenName9)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_9");
            entity.Property(e => e.FamilyDetails_DateOfBirth_9)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_9");
            entity.Property(e => e.FamilyDetailsChildrenName10)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_10");
            entity.Property(e => e.FamilyDetails_DateOfBirth_10)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_10");
            entity.Property(e => e.FamilyDetailsKkno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_KKNo");
            entity.Property(e => e.FamilyDetailsMarritalStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_MarritalStatus");
            entity.Property(e => e.FamilyDetailsNoOfChildren).HasColumnName("FamilyDetails_NoOfChildren");
            entity.Property(e => e.FamilyDetailsSpouseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_SpouseName");
            entity.Property(e => e.IdentityandAccountBankAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_BankAccount");
            entity.Property(e => e.IdentityandAccountNik)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NIK");
            entity.Property(e => e.IdentityandAccountNoBpjskes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoBPJSKes");
            entity.Property(e => e.IdentityandAccountNoBpjstk)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoBPJSTK");
            entity.Property(e => e.IdentityandAccountNoNpwp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoNPWP");
            entity.Property(e => e.IdentityandAccountNoPassport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoPassport");
            entity.Property(e => e.IdentityandAccountTaxStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_TaxStatus");
            entity.Property(e => e.JobprofileCostCenter)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_CostCenter");
            entity.Property(e => e.JobprofileDepartment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_Department");
            entity.Property(e => e.JobprofileDivision)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_Division");
            entity.Property(e => e.JobprofileGradeOrlevel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_GradeORLevel");
            entity.Property(e => e.JobprofileJobFunction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_JobFunction");
            entity.Property(e => e.JobprofileJobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_JobTitle");
            entity.Property(e => e.JobprofileLaborClass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_LaborClass");
            entity.Property(e => e.JobprofileLaborType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_LaborType");
            entity.Property(e => e.JobprofileProductivityType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_ProductivityType");
            entity.Property(e => e.JobprofileShiftPattern)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_ShiftPattern");
            entity.Property(e => e.JobprofileSupervisorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_SupervisorID");
            entity.Property(e => e.JobprofileSupervisorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_SupervisorName");
            entity.Property(e => e.JobprofileWorkCitizenship)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_WorkCitizenship");
            entity.Property(e => e.JobprofileWorkLotOrplant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_WorkLotORPlant");
            entity.Property(e => e.RecruitmentMethodofRecruitment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_MethodofRecruitment");
            entity.Property(e => e.RecruitmentRecruitmentPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_RecruitmentPlace");
            entity.Property(e => e.RecruitmentRequisitionNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_RequisitionNumber");
            entity.Property(e => e.RecruitmentSource)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_Source");
            entity.Property(e => e.AdminApproval).HasColumnName("AdminApproval");
        });

        //TblUsulanEmployee
        modelBuilder.Entity<TblUsulanEmployee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Tbl_UsulanEmployee");

            entity.Property(e => e.AccessPropertiesandMembershipAccessDoorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_AccessDoorID");
            entity.Property(e => e.AccessPropertiesandMembershipCompanyPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CompanyPhone");
            entity.Property(e => e.AccessPropertiesandMembershipCompanySimcardId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CompanySIMCardID");
            entity.Property(e => e.AccessPropertiesandMembershipCooperativeMembership)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_CooperativeMembership");
            entity.Property(e => e.AccessPropertiesandMembershipLockerId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_LockerID");
            entity.Property(e => e.AccessPropertiesandMembershipParkingAccess)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_ParkingAccess");
            entity.Property(e => e.AccessPropertiesandMembershipProximityCardId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_ProximityCardID");
            entity.Property(e => e.AccessPropertiesandMembershipUnionexitdate)
                .HasColumnType("date")
                .HasColumnName("Access_PropertiesandMembership_UNIONEXITDATE");
            entity.Property(e => e.AccessPropertiesandMembershipUnionmembership)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_UNIONMEMBERSHIP");
            entity.Property(e => e.AccessPropertiesandMembershipUnionmembershipstatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS");
            entity.Property(e => e.AccessPropertiesandMembershipUnionstartdate)
                .HasColumnType("date")
                .HasColumnName("Access_PropertiesandMembership_UNIONSTARTDATE");
            entity.Property(e => e.AccessPropertiesandMembershipWorkEmailAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Access_PropertiesandMembership_WorkEmailAccount");
            entity.Property(e => e.BasicinfoDateofBirth)
                .HasColumnType("datetime")
                .HasColumnName("Basicinfo_DateofBirth");
            entity.Property(e => e.BasicinfoFullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_FULLNAME");
            entity.Property(e => e.BasicinfoGender)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Gender");
            entity.Property(e => e.BasicinfoGlobalid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_GLOBALID");
            entity.Property(e => e.BasicinfoLocalid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_LOCALID");
            entity.Property(e => e.BasicinfoNationality)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Nationality");
            entity.Property(e => e.BasicinfoPhoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_PHOTO");
            entity.Property(e => e.BasicinfoPlaceofBirth)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_PlaceofBirth");
            entity.Property(e => e.BasicinfoReligion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Basicinfo_Religion");
            entity.Property(e => e.ContactandAddressCurrentAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentAddress");
            entity.Property(e => e.ContactandAddressCurrentCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentCity");
            entity.Property(e => e.ContactandAddressCurrentRegionKecamatan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentRegionKecamatan");
            entity.Property(e => e.ContactandAddressCurrentRegionKelurahan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_CurrentRegionKelurahan");
            entity.Property(e => e.ContactandAddressDormitoryNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_DormitoryNo");
            entity.Property(e => e.ContactandAddressDormitoryStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_DormitoryStatus");
            entity.Property(e => e.ContactandAddressHometownAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_HometownAddress");
            entity.Property(e => e.ContactandAddressHowetownCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_HowetownCity");
            entity.Property(e => e.ContactandAddressKtpaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPAddress");
            entity.Property(e => e.ContactandAddressKtpcity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPCity");
            entity.Property(e => e.ContactandAddressKtpdistrict1Kelurahan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPDistrict1Kelurahan");
            entity.Property(e => e.ContactandAddressKtpdistrict2Kecamatan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_KTPDistrict2Kecamatan");
            entity.Property(e => e.ContactandAddressMobilePhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_MobilePhoneNo");
            entity.Property(e => e.ContactandAddressPersonalEmailAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContactandAddress_PersonalEmailAccount");
            entity.Property(e => e.EducationEducation1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_Education1");
            entity.Property(e => e.EducationEducation2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_Education2");
            entity.Property(e => e.EducationFieldofStudy1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_FieldofStudy1");
            entity.Property(e => e.EducationFieldofStudy2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_FieldofStudy2");
            entity.Property(e => e.EducationInstitutionName1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_InstitutionName1");
            entity.Property(e => e.EducationInstitutionName2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Education_InstitutionName2");
            entity.Property(e => e.EducationYearofGraduate1).HasColumnName("Education_YearofGraduate1");
            entity.Property(e => e.EducationYearofGraduate2).HasColumnName("Education_YearofGraduate2");
            entity.Property(e => e.EmergencyContactCurrentAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_CurrentAddress");
            entity.Property(e => e.EmergencyContactCurrentCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_CurrentCity");
            entity.Property(e => e.EmergencyContactMobilePhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_MobilePhoneNo");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_Name");
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact_Relationship");
            entity.Property(e => e.EmploymentstatusC1end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C1END");
            entity.Property(e => e.EmploymentstatusC1start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C1START");
            entity.Property(e => e.EmploymentstatusC2end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C2END");
            entity.Property(e => e.EmploymentstatusC2start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C2START");
            entity.Property(e => e.EmploymentstatusC3end)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C3END");
            entity.Property(e => e.EmploymentstatusC3start)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_C3START");
            entity.Property(e => e.EmploymentstatusEmployeestatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employmentstatus_EMPLOYEESTATUS");
            entity.Property(e => e.EmploymentstatusEmploymentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Employmentstatus_EmploymentType");
            entity.Property(e => e.EmploymentstatusJoinDate)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_JoinDate");
            entity.Property(e => e.EmploymentstatusPermanentstartdate)
                .HasColumnType("date")
                .HasColumnName("Employmentstatus_PERMANENTSTARTDATE");
            entity.Property(e => e.EmploymentstatusTotalserviceyearsbyjoin).HasColumnName("Employmentstatus_TOTALSERVICEYEARSBYJOIN");
            entity.Property(e => e.EmploymentstatusTotalserviceyearsbypermanent).HasColumnName("Employmentstatus_TOTALSERVICEYEARSBYPERMANENT");
            entity.Property(e => e.ExitInformationEffectiveDate)
                .HasColumnType("date")
                .HasColumnName("ExitInformation_EffectiveDate");
            entity.Property(e => e.ExitInformationEligibletorehire)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_Eligibletorehire");
            entity.Property(e => e.ExitInformationLastPhysicalDate)
                .HasColumnType("date")
                .HasColumnName("ExitInformation_LastPhysicalDate");
            entity.Property(e => e.ExitInformationReasonofLeaving)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_ReasonofLeaving");
            entity.Property(e => e.ExitInformationTypeofExit)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ExitInformation_TypeofExit");
            entity.Property(e => e.FamilyDetailsChildrenName1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_1");
            entity.Property(e => e.FamilyDetails_DateOfBirth_1)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_1");
            entity.Property(e => e.FamilyDetailsChildrenName2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_2");
            entity.Property(e => e.FamilyDetails_DateOfBirth_2)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_2");
            entity.Property(e => e.FamilyDetailsChildrenName3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_3");
            entity.Property(e => e.FamilyDetails_DateOfBirth_3)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_3");
            entity.Property(e => e.FamilyDetailsChildrenName4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_4");
            entity.Property(e => e.FamilyDetails_DateOfBirth_4)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_4");
            entity.Property(e => e.FamilyDetailsChildrenName5)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_5");
            entity.Property(e => e.FamilyDetails_DateOfBirth_5)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_5");
            entity.Property(e => e.FamilyDetailsChildrenName6)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_6");
            entity.Property(e => e.FamilyDetails_DateOfBirth_6)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_6");
            entity.Property(e => e.FamilyDetailsChildrenName7)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_7");
            entity.Property(e => e.FamilyDetails_DateOfBirth_7)
                .HasColumnType("datetime")
                .HasColumnName("FamilyDetails_DateOfBirth_7");
            entity.Property(e => e.FamilyDetailsChildrenName8)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_8");
            entity.Property(e => e.FamilyDetails_DateOfBirth_8)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_8");
            entity.Property(e => e.FamilyDetailsChildrenName9)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_9");
            entity.Property(e => e.FamilyDetails_DateOfBirth_9)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_9");
            entity.Property(e => e.FamilyDetailsChildrenName10)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_ChildrenName_10");
            entity.Property(e => e.FamilyDetails_DateOfBirth_10)
               .HasColumnType("datetime")
               .HasColumnName("FamilyDetails_DateOfBirth_10");
            entity.Property(e => e.FamilyDetailsKkno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_KKNo");
            entity.Property(e => e.FamilyDetailsMarritalStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_MarritalStatus");
            entity.Property(e => e.FamilyDetailsNoOfChildren).HasColumnName("FamilyDetails_NoOfChildren");
            entity.Property(e => e.FamilyDetailsSpouseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FamilyDetails_SpouseName");
            entity.Property(e => e.IdentityandAccountBankAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_BankAccount");
            entity.Property(e => e.IdentityandAccountNik)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NIK");
            entity.Property(e => e.IdentityandAccountNoBpjskes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoBPJSKes");
            entity.Property(e => e.IdentityandAccountNoBpjstk)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoBPJSTK");
            entity.Property(e => e.IdentityandAccountNoNpwp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoNPWP");
            entity.Property(e => e.IdentityandAccountNoPassport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_NoPassport");
            entity.Property(e => e.IdentityandAccountTaxStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IdentityandAccount_TaxStatus");
            entity.Property(e => e.JobprofileCostCenter)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_CostCenter");
            entity.Property(e => e.JobprofileDepartment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_Department");
            entity.Property(e => e.JobprofileDivision)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_Division");
            entity.Property(e => e.JobprofileGradeOrlevel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_GradeORLevel");
            entity.Property(e => e.JobprofileJobFunction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_JobFunction");
            entity.Property(e => e.JobprofileJobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_JobTitle");
            entity.Property(e => e.JobprofileLaborClass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_LaborClass");
            entity.Property(e => e.JobprofileLaborType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_LaborType");
            entity.Property(e => e.JobprofileProductivityType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_ProductivityType");
            entity.Property(e => e.JobprofileShiftPattern)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_ShiftPattern");
            entity.Property(e => e.JobprofileSupervisorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_SupervisorID");
            entity.Property(e => e.JobprofileSupervisorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_SupervisorName");
            entity.Property(e => e.JobprofileWorkCitizenship)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_WorkCitizenship");
            entity.Property(e => e.JobprofileWorkLotOrplant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Jobprofile_WorkLotORPlant");
            entity.Property(e => e.RecruitmentMethodofRecruitment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_MethodofRecruitment");
            entity.Property(e => e.RecruitmentRecruitmentPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_RecruitmentPlace");
            entity.Property(e => e.RecruitmentRequisitionNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_RequisitionNumber");
            entity.Property(e => e.RecruitmentSource)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recruitment_Source");
            entity.Property(e => e.AdminApproval).HasColumnName("AdminApproval");

        });

        //Tbl_User
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id_user);

            entity.ToTable("Tbl_User");

            entity.Property(e => e.Id_user).HasColumnName("Id_user");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Username");
            entity.Property(e => e.Role)
               .HasMaxLength(255)
               .IsUnicode(false)
               .HasColumnName("Role");

        });


        //Tbl_Log
        modelBuilder.Entity<Tbllog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Tbl_Log");

            entity.Property(e => e.Username).HasColumnName("Username");
            entity.Property(e => e.JenisOperasi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("JenisOperasi");
            entity.Property(e => e.Tanggal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tanggal");
            entity.Property(e => e.Isi)
               .HasMaxLength(255)
               .IsUnicode(false)
               .HasColumnName("Isi");

        });


        //Tbl GradeLevel
        modelBuilder.Entity<TblGradeLevel>(entity =>
        {
            entity.HasKey(e => e.Id_GradeLevel);

            entity.ToTable("Tbl_GradeLevel");

            entity.Property(e => e.Nama_GradeLevel).HasColumnName("Nama_GradeLevel");

        });

        //Tbl JobTitle
        modelBuilder.Entity<TblJobTitle>(entity =>
        {
            entity.HasKey(e => e.Id_JobTitle);

            entity.ToTable("Tbl_JobTitle");

            //entity.Property(e => e.Id_JobTitle).HasColumnName("Id_JobTitle");
            entity.Property(e => e.Nama_JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nama_JobTitle");
            entity.Property(e => e.Id_GradeLevel).HasColumnName("Id_GradeLevel");
        });


        //Tbl LaborType
        modelBuilder.Entity<TblLaborType>(entity =>
        {
            entity.HasKey(e => e.Id_LaborType);

            entity.ToTable("Tbl_LaborType");

            entity.Property(e => e.Nama_LaborType).HasColumnName("Nama_LaborType");

            entity.Property(e => e.Id_JobTitle).HasColumnName("Id_JobTitle");

            //entity.HasforeignKey(e => e.Id_GradeLevel).HasColumnName("Id_GradeLevel");

        });

        //Tbl LaborClass
        modelBuilder.Entity<TblLaborClass>(entity =>
        {
            entity.HasKey(e => e.Id_LaborClass);

            entity.ToTable("Tbl_LaborClass");

            entity.Property(e => e.Nama_LaborClass).HasColumnName("Nama_LaborClass");

            entity.Property(e => e.Id_LaborType).HasColumnName("Id_LaborType");

        });

        //Tbl Division
        modelBuilder.Entity<TblDivision>(entity =>
        {
            entity.HasKey(e => e.Id_Division);

            entity.ToTable("Tbl_Division");

            entity.Property(e => e.Nama_Division).HasColumnName("Nama_Division");

        });

        //Tbl Cost Center
        modelBuilder.Entity<TblCostCenter>(entity =>
        {
            entity.HasKey(e => e.Id_CostCenter);

            entity.ToTable("Tbl_CostCenter");

            //entity.Property(e => e.Id_CostCenter).HasColumnName("Id_CostCenter");
            entity.Property(e => e.Nama_CostCenter)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nama_CostCenter");
            entity.Property(e => e.Deskripsi_CostCenter)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Deskripsi_CostCenter");
            entity.Property(e => e.Id_Division).HasColumnName("Id_Division");
        });

        //Tbl Job Post/ sebelumnya nama tabel nya Tbl Department
        modelBuilder.Entity<TblJobPost>(entity =>
        {
            entity.HasKey(e => e.Id_JobPost);

            entity.ToTable("Tbl_JobPost");

            entity.Property(e => e.Nama_JobPost)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nama_JobPost");
            entity.Property(e => e.Id_CostCenter).HasColumnName("Id_CostCenter");
        });

        //Tbl MethodOfRecruitment
        modelBuilder.Entity<TblMethodOfRecruitment>(entity =>
        {
            entity.HasKey(e => e.Id_MethodOfRecruitment);

            entity.ToTable("Tbl_MethodOfRecruitment");

            entity.Property(e => e.Nama_MethodOfRecruitment).HasColumnName("Nama_MethodOfRecruitment");

        });

        //Tbl Source
        modelBuilder.Entity<TblSource>(entity =>
        {
            entity.HasKey(e => e.Id_Source);

            entity.ToTable("Tbl_Source");

            //entity.Property(e => e.Id_JobTitle).HasColumnName("Id_JobTitle");
            entity.Property(e => e.Nama_Source)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nama_Source");
            entity.Property(e => e.Id_MethodOfRecruitment).HasColumnName("Id_MethodOfRecruitment");
        });

        //Tbl ProductivityType
        modelBuilder.Entity<TblProductivityType>(entity =>
        {
            entity.HasKey(e => e.Id_ProductivityType);

            entity.ToTable("Tbl_ProductivityType");

            entity.Property(e => e.Nama_ProductivityType).HasColumnName("Nama_ProductivityType");

        });

        //Tbl JobFunction
        modelBuilder.Entity<TblJobFunction>(entity =>
        {
            entity.HasKey(e => e.Id_JobFunction);

            entity.ToTable("Tbl_JobFunction");

            entity.Property(e => e.Nama_JobFunction).HasColumnName("Nama_JobFunction");

        });

        //Tbl WorkLotOrPlant
        modelBuilder.Entity<TblWorkLotOrPlant>(entity =>
        {
            entity.HasKey(e => e.Id_WorkLotOrPlant);

            entity.ToTable("Tbl_WorkLotOrPlant");

            entity.Property(e => e.Nama_WorkLotOrPlant).HasColumnName("Nama_WorkLotOrPlant");

        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
