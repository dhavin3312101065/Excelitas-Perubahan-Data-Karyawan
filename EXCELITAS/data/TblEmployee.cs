using System;
using System.Collections.Generic;

namespace EXCELITAS.data;

public partial class TblEmployee
{
    public int? Id { get; set; }

    public string? BasicinfoLocalid { get; set; }

    public string? BasicinfoGlobalid { get; set; }

    public string? BasicinfoFullname { get; set; }

    public string? BasicinfoGender { get; set; }

    public string? BasicinfoPhoto { get; set; }

    public string? BasicinfoPlaceofBirth { get; set; }

    public DateTime? BasicinfoDateofBirth { get; set; }

    public string? BasicinfoReligion { get; set; }

    public string? BasicinfoNationality { get; set; }

    public string? EmploymentstatusEmploymentType { get; set; }

    public DateTime? EmploymentstatusJoinDate { get; set; }

    public DateTime? EmploymentstatusC1start { get; set; }

    public DateTime? EmploymentstatusC1end { get; set; }

    public DateTime? EmploymentstatusC2start { get; set; }

    public DateTime? EmploymentstatusC2end { get; set; }

    public DateTime? EmploymentstatusC3start { get; set; }

    public DateTime? EmploymentstatusC3end { get; set; }

    public DateTime? EmploymentstatusPermanentstartdate { get; set; }

    public string? EmploymentstatusEmployeestatus { get; set; }

    public int? EmploymentstatusTotalserviceyearsbyjoin { get; set; }

    public int? EmploymentstatusTotalserviceyearsbypermanent { get; set; }

    public string? JobprofileJobTitle { get; set; }

    public string? JobprofileGradeOrlevel { get; set; }

    public string? JobprofileProductivityType { get; set; }

    public string? JobprofileJobFunction { get; set; }

    public string? JobprofileWorkCitizenship { get; set; }

    public string? JobprofileLaborType { get; set; }

    public string? JobprofileLaborClass { get; set; }

    public string? JobprofileDepartment { get; set; }

    public string? JobprofileCostCenter { get; set; }

    public string? JobprofileDivision { get; set; }

    public string? JobprofileWorkLotOrplant { get; set; }

    public string? JobprofileSupervisorId { get; set; }

    public string? JobprofileSupervisorName { get; set; }

    public string? JobprofileShiftPattern { get; set; }

    public string? RecruitmentMethodofRecruitment { get; set; }

    public string? RecruitmentSource { get; set; }

    public string? RecruitmentRecruitmentPlace { get; set; }

    public string? RecruitmentRequisitionNumber { get; set; }

    public string? EducationEducation1 { get; set; }

    public string? EducationFieldofStudy1 { get; set; }

    public string? EducationInstitutionName1 { get; set; }

    public int? EducationYearofGraduate1 { get; set; }

    public string? EducationEducation2 { get; set; }

    public string? EducationFieldofStudy2 { get; set; }

    public string? EducationInstitutionName2 { get; set; }

    public int? EducationYearofGraduate2 { get; set; }

    public string? IdentityandAccountNik { get; set; }

    public string? IdentityandAccountNoBpjskes { get; set; }

    public string? IdentityandAccountNoBpjstk { get; set; }

    public string? IdentityandAccountNoPassport { get; set; }

    public string? IdentityandAccountBankAccount { get; set; }

    public string? IdentityandAccountNoNpwp { get; set; }

    public string? IdentityandAccountTaxStatus { get; set; }

    public string? ContactandAddressMobilePhoneNo { get; set; }

    public string? ContactandAddressPersonalEmailAccount { get; set; }

    public string? ContactandAddressCurrentAddress { get; set; }

    public string? ContactandAddressCurrentRegionKelurahan { get; set; }

    public string? ContactandAddressCurrentRegionKecamatan { get; set; }

    public string? ContactandAddressCurrentCity { get; set; }

    public string? ContactandAddressKtpaddress { get; set; }

    public string? ContactandAddressKtpdistrict1Kelurahan { get; set; }

    public string? ContactandAddressKtpdistrict2Kecamatan { get; set; }

    public string? ContactandAddressKtpcity { get; set; }

    public string? ContactandAddressHometownAddress { get; set; }

    public string? ContactandAddressHowetownCity { get; set; }

    public string? ContactandAddressDormitoryStatus { get; set; }

    public string? ContactandAddressDormitoryNo { get; set; }

    public string? FamilyDetailsKkno { get; set; }

    public string? FamilyDetailsMarritalStatus { get; set; }

    public string? FamilyDetailsSpouseName { get; set; }

    public int? FamilyDetailsNoOfChildren { get; set; }

    public string? FamilyDetailsChildrenName1 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_1 { get; set; }

    public string? FamilyDetailsChildrenName2 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_2 { get; set; }

    public string? FamilyDetailsChildrenName3 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_3 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName4 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_4 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName5 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_5 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName6 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_6 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName7 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_7 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName8 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_8 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName9 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_9 { get; set; }

    //kolom tambahan
    public string? FamilyDetailsChildrenName10 { get; set; }

    //kolom tambahan
    public DateTime? FamilyDetails_DateOfBirth_10 { get; set; }
    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactRelationship { get; set; }

    public string? EmergencyContactMobilePhoneNo { get; set; }

    public string? EmergencyContactCurrentAddress { get; set; }

    public string? EmergencyContactCurrentCity { get; set; }

    public string? AccessPropertiesandMembershipWorkEmailAccount { get; set; }

    public string? AccessPropertiesandMembershipProximityCardId { get; set; }

    public string? AccessPropertiesandMembershipAccessDoorId { get; set; }

    public string? AccessPropertiesandMembershipParkingAccess { get; set; }

    public string? AccessPropertiesandMembershipLockerId { get; set; }

    public string? AccessPropertiesandMembershipCompanySimcardId { get; set; }

    public string? AccessPropertiesandMembershipCompanyPhone { get; set; }

    public string? AccessPropertiesandMembershipCooperativeMembership { get; set; }

    public string? AccessPropertiesandMembershipUnionmembership { get; set; }

    public DateTime? AccessPropertiesandMembershipUnionstartdate { get; set; }

    public DateTime? AccessPropertiesandMembershipUnionexitdate { get; set; }

    public string? AccessPropertiesandMembershipUnionmembershipstatus { get; set; }

    public string? ExitInformationTypeofExit { get; set; }

    public DateTime? ExitInformationLastPhysicalDate { get; set; }

    public DateTime? ExitInformationEffectiveDate { get; set; }

    public string? ExitInformationReasonofLeaving { get; set; }

    public string? ExitInformationEligibletorehire { get; set; }

    public int? AdminApproval { get; set; }
}
