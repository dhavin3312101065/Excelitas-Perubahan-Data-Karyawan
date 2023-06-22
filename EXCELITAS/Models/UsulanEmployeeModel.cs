namespace EXCELITAS.Models
{
    public class UsulanEmployeeModel
    {
        public List<UsulanEmployee> UsulanEmployeeList { get; set; }
    }

    public class UsulanEmployee
    {
        public int? Id { get; set; }
        public string Basicinfo_LOCALID { get; set; }
        public string Basicinfo_GLOBALID { get; set; }
        public string Basicinfo_FULLNAME { get; set; }
        public string Basicinfo_Gender { get; set; }
        public string Basicinfo_PHOTO { get; set; }
        public string Basicinfo_PlaceofBirth { get; set; }
        //public Nullable<System.DateTime> Basicinfo_DateofBirth { get; set; }
        public DateTime? Basicinfo_DateofBirth { get; set; }
        public string Basicinfo_Religion { get; set; }
        public string Basicinfo_Nationality { get; set; }
        public string Employmentstatus_EmploymentType { get; set; }
        public DateTime Employmentstatus_JoinDate { get; set; }
        public DateTime? Employmentstatus_C1START { get; set; }
        public DateTime? Employmentstatus_C1END { get; set; }
        public DateTime? Employmentstatus_C2START { get; set; }
        public DateTime? Employmentstatus_C2END { get; set; }
        public DateTime? Employmentstatus_C3START { get; set; }
        public DateTime? Employmentstatus_C3END { get; set; }
        public DateTime? Employmentstatus_PERMANENTSTARTDATE { get; set; } //Nullable<DateTime> Employmentstatus_PERMANENTENDDATE { get; set; }
        public string Employmentstatus_EMPLOYEESTATUS { get; set; }
        public int? Employmentstatus_TOTALSERVICEYEARSBYJOIN { get; set; }
        public int? Employmentstatus_TOTALSERVICEYEARSBYPERMANENT { get; set; }
        public string Jobprofile_JobTitle { get; set; }
        public string Jobprofile_GradeORLevel { get; set; }
        public string Jobprofile_ProductivityType { get; set; }
        public string Jobprofile_JobFunction { get; set; }
        public string Jobprofile_WorkCitizenship { get; set; }
        public string Jobprofile_LaborType { get; set; }
        public string Jobprofile_LaborClass { get; set; }
        public string Jobprofile_Department { get; set; }
        public string Jobprofile_CostCenter { get; set; }
        public string Jobprofile_Division { get; set; }
        public string Jobprofile_WorkLotORPlant { get; set; }
        public string Jobprofile_SupervisorID { get; set; }
        public string Jobprofile_SupervisorName { get; set; }
        public string Jobprofile_ShiftPattern { get; set; }
        public string Recruitment_MethodofRecruitment { get; set; }
        public string Recruitment_Source { get; set; }
        public string Recruitment_RecruitmentPlace { get; set; }
        public string Recruitment_RequisitionNumber { get; set; }
        public string Education_Education1 { get; set; }
        public string Education_FieldofStudy1 { get; set; }
        public string Education_InstitutionName1 { get; set; }
        public int? Education_YearofGraduate1 { get; set; }
        public string Education_Education2 { get; set; }
        public string Education_FieldofStudy2 { get; set; }
        public string Education_InstitutionName2 { get; set; }
        public int? Education_YearofGraduate2 { get; set; }
        public string IdentityandAccount_NIK { get; set; }
        public string IdentityandAccount_NoBPJSKes { get; set; }
        public string IdentityandAccount_NoBPJSTK { get; set; }
        public string IdentityandAccount_NoPassport { get; set; }
        public string IdentityandAccount_BankAccount { get; set; }
        public string IdentityandAccount_NoNPWP { get; set; }
        public string IdentityandAccount_TaxStatus { get; set; }
        public string ContactandAddress_MobilePhoneNo { get; set; }
        public string ContactandAddress_PersonalEmailAccount { get; set; }
        public string ContactandAddress_CurrentAddress { get; set; }
        public string ContactandAddress_CurrentRegionKelurahan { get; set; }
        public string ContactandAddress_CurrentRegionKecamatan { get; set; }
        public string ContactandAddress_CurrentCity { get; set; }
        public string ContactandAddress_KTPAddress { get; set; }
        public string ContactandAddress_KTPDistrict1Kelurahan { get; set; }
        public string ContactandAddress_KTPDistrict2Kecamatan { get; set; }
        public string ContactandAddress_KTPCity { get; set; }
        public string ContactandAddress_HometownAddress { get; set; }
        public string ContactandAddress_HowetownCity { get; set; }
        public string ContactandAddress_DormitoryStatus { get; set; }
        public string ContactandAddress_DormitoryNo { get; set; }
        public string FamilyDetails_KKNo { get; set; }
        public string FamilyDetails_MarritalStatus { get; set; }
        public string FamilyDetails_SpouseName { get; set; }
        public int? FamilyDetails_NoOfChildren { get; set; }
        public string FamilyDetails_ChildrenName_1 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_1 { get; set; }
        public string FamilyDetails_ChildrenName_2 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_2 { get; set; }
        public string FamilyDetails_ChildrenName_3 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_3 { get; set; }
        public string FamilyDetails_ChildrenName_4 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_4 { get; set; }
        public string FamilyDetails_ChildrenName_5 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_5 { get; set; }
        public string FamilyDetails_ChildrenName_6 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_6 { get; set; }
        public string FamilyDetails_ChildrenName_7 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_7 { get; set; }
        public string FamilyDetails_ChildrenName_8 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_8 { get; set; }
        public string FamilyDetails_ChildrenName_9 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_9 { get; set; }
        public string FamilyDetails_ChildrenName_10 { get; set; }
        public DateTime? FamilyDetails_DateOfBirth_10 { get; set; }
        public string EmergencyContact_Name { get; set; }
        public string EmergencyContact_Relationship { get; set; }
        public string EmergencyContact_MobilePhoneNo { get; set; }
        public string EmergencyContact_CurrentAddress { get; set; }
        public string EmergencyContact_CurrentCity { get; set; }
        public string Access_PropertiesandMembership_WorkEmailAccount { get; set; }
        public string Access_PropertiesandMembership_ProximityCardID { get; set; }
        public string Access_PropertiesandMembership_AccessDoorID { get; set; }
        public string Access_PropertiesandMembership_ParkingAccess { get; set; }
        public string Access_PropertiesandMembership_LockerID { get; set; }
        public string Access_PropertiesandMembership_CompanySIMCardID { get; set; }
        public string Access_PropertiesandMembership_CompanyPhone { get; set; }
        public string Access_PropertiesandMembership_CooperativeMembership { get; set; }
        public string Access_PropertiesandMembership_UNIONMEMBERSHIP { get; set; }
        public DateTime? Access_PropertiesandMembership_UNIONSTARTDATE { get; set; }
        public DateTime? Access_PropertiesandMembership_UNIONEXITDATE { get; set; }
        public string Access_PropertiesandMembership_UNIONMEMBERSHIPSTATUS { get; set; }
        public string ExitInformation_TypeofExit { get; set; }
        public DateTime? ExitInformation_LastPhysicalDate { get; set; }
        public DateTime? ExitInformation_EffectiveDate { get; set; }
        public string ExitInformation_ReasonofLeaving { get; set; }
        public string ExitInformation_Eligibletorehire { get; set; }
        public int? AdminApproval { get; set; }


    }
}
