using CareerCloud.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace CareerCloudCore.UnitTests.Assignment1
{
    [TestCategory("Assignment 1 Poco Tests")]
    [TestClass]
    public class Assignment1Marking
    {
        private const string _assemblyUnderTest = "CareerCloud.Pocos.dll";

        private Type[] _types;

        [TestInitialize]
        public void Init()
        {
            // create an instance of a POCO to load the Pocos assembly
            ApplicantEducationPoco poco = new ApplicantEducationPoco();
            _types = Assembly.LoadFrom(_assemblyUnderTest).GetTypes();
        }

        [TestMethod]
        public void Assingment_1_Poco_Creation()
        {

            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantEducationPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantJobApplicationPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantProfilePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantResumePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantSkillPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantWorkHistoryPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyDescriptionPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobEducationPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobDescriptionPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobSkillPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyLocationPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyProfilePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginsLogPoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginsRolePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityRolePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SystemCountryCodePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "SystemLanguageCodePoco"));
            Assert.IsTrue(_types.Any(t => t.Name == "IPoco"));
        }

        [TestMethod]
        public void Assignment_1_Poco_ApplicationEducationPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantEducationPoco");
            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));
            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Educations"));


            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CertificateDiploma"), "Certificate_Diploma"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CertificateDiploma"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "StartDate"), "Start_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime?), "StartDate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompletionDate"), "Completion_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime?), "CompletionDate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompletionPercent"), "Completion_Percent"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte?), "CompletionPercent"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Applicant"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Applicant"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Major"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Major"));

        }
        [TestMethod]
        public void Assignment_1_Poco_ApplicantJobApplicationPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantJobApplicationPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Job_Applications"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "ApplicationDate"), "Application_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime), "ApplicationDate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Applicant"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Applicant"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Job"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Job"));

        }

        [TestMethod]
        public void Assignment_1_Poco_ApplicantProfilePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantProfilePoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Profiles"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CurrentSalary"), "Current_Salary"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(decimal?), "CurrentSalary"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CurrentRate"), "Current_Rate"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(decimal?), "CurrentRate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Country"), "Country_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Country"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Province"), "State_Province_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Province"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Street"), "Street_Address"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Street"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "City"), "City_Town"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "City"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "PostalCode"), "Zip_Postal_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "PostalCode"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Login"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Login"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Currency"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Currency"));
        }

        [TestMethod]
        public void Assignment_1_Poco_ApplicantResumePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantResumePoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Resumes"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Applicant"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Applicant"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Resume"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Resume"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "LastUpdated"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "LastUpdated"), "Last_Updated"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime?), "LastUpdated"));


        }

        [TestMethod]
        public void Assignment_1_Poco_ApplicantSkillPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantSkillPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Skills"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "SkillLevel"), "Skill_Level"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "SkillLevel"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "StartMonth"), "Start_Month"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte), "StartMonth"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "StartYear"), "Start_Year"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(int), "StartYear"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "EndMonth"), "End_Month"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte), "EndMonth"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "EndYear"), "End_Year"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(int), "EndYear"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Applicant"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Applicant"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Skill"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Skill"));
        }


        [TestMethod]
        public void Assignment_1_Poco_ApplicantWorkHistoryPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "ApplicantWorkHistoryPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Applicant_Work_History"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyName"), "Company_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CompanyName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CountryCode"), "Country_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CountryCode"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyName"), "Company_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CompanyName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "JobTitle"), "Job_Title"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "JobTitle"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "JobDescription"), "Job_Description"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "JobDescription"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "StartMonth"), "Start_Month"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(short), "StartMonth"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "StartYear"), "Start_Year"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(int), "StartYear"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "EndMonth"), "End_Month"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(short), "EndMonth"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "EndYear"), "End_Year"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(int), "EndYear"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Applicant"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Location"));

        }


        [TestMethod]
        public void Assignment_1_Poco_CompanyDescriptionPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyDescriptionPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Descriptions"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));

            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyName"), "Company_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CompanyName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyDescription"), "Company_Description"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CompanyDescription"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Company"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Company"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "LanguageId"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "LanguageId"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyJobEducationPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyJobEducationPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Job_Educations"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Job"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Job"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Major"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Major"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Importance"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Int16), "Importance"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyJobPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyJobPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Jobs"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "ProfileCreated"), "Profile_Created"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime), "ProfileCreated"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsInactive"), "Is_Inactive"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsInactive"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsCompanyHidden"), "Is_Company_Hidden"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsCompanyHidden"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Company"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Company"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyJobDescriptionPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyJobDescriptionPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Jobs_Descriptions"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "JobName"), "Job_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "JobName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "JobDescriptions"), "Job_Descriptions"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "JobDescriptions"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Job"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Job"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyJobSkillPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyJobSkillPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Job_Skills"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "SkillLevel"), "Skill_Level"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "SkillLevel"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Skill"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Skill"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Importance"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(int), "Importance"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Job"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Job"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyLocationPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyLocationPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Locations"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CountryCode"), "Country_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CountryCode"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Province"), "State_Province_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Province"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Street"), "Street_Address"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Street"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "City"), "City_Town"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "City"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "PostalCode"), "Zip_Postal_Code"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "PostalCode"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Company"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Company"));
        }

        [TestMethod]
        public void Assignment_1_Poco_CompanyProfilePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "CompanyProfilePoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Company_Profiles"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "RegistrationDate"), "Registration_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime), "RegistrationDate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyWebsite"), "Company_Website"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "CompanyWebsite"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "ContactPhone"), "Contact_Phone"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "ContactPhone"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "ContactName"), "Contact_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "ContactName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "CompanyLogo"), "Company_Logo"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "CompanyLogo"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SecurityLoginPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SecurityLoginPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Security_Logins"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "Created"), "Created_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime), "Created"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "PasswordUpdate"), "Password_Update_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime?), "PasswordUpdate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "AgreementAccepted"), "Agreement_Accepted_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime?), "AgreementAccepted"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsLocked"), "Is_Locked"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsLocked"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsInactive"), "Is_Inactive"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsInactive"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "EmailAddress"), "Email_Address"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "EmailAddress"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "PhoneNumber"), "Phone_Number"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "PhoneNumber"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "FullName"), "Full_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "FullName"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "ForceChangePassword"), "Force_Change_Password"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "ForceChangePassword"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "PrefferredLanguage"), "Prefferred_Language"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "PrefferredLanguage"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Login"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Login"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Password"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Password"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SecurityLoginsLogPoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SecurityLoginsLogPoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Security_Logins_Log"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "SourceIP"), "Source_IP"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "SourceIP"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "LogonDate"), "Logon_Date"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(DateTime), "LogonDate"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsSuccesful"), "Is_Succesful"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsSuccesful"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Login"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Login"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SecurityLoginsRolePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SecurityLoginsRolePoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Security_Logins_Roles"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "TimeStamp"), "Time_Stamp"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(byte[]), "TimeStamp"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Login"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Login"));
            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Role"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Role"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SecurityRolePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SecurityRolePoco");

            Assert.IsTrue(GetCharacteristics.ImplementsInterface(poco, "IPoco"));

            Assert.IsTrue(GetCharacteristics.HasTable(poco, "Security_Roles"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Id")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(Guid), "Id"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "IsInactive"), "Is_Inactive"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(bool), "IsInactive"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Role"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Role"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SystemCountryCodePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SystemCountryCodePoco");
            Assert.IsTrue(GetCharacteristics.HasTable(poco, "System_Country_Codes"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "Code")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Code"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Name"));
        }

        [TestMethod]
        public void Assignment_1_Poco_SystemLanguageCodePoco()
        {
            Type poco = GetCharacteristics.GetType(_types, "SystemLanguageCodePoco");
            Assert.IsTrue(GetCharacteristics.HasTable(poco, "System_Language_Codes"));
            Assert.IsTrue(GetCharacteristics.HasKey(GetCharacteristics.GetProperty(poco, "LanguageID")));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "LanguageID"));
            Assert.IsTrue(GetCharacteristics.HasColumn(GetCharacteristics.GetProperty(poco, "NativeName"), "Native_Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "NativeName"));

            Assert.IsNotNull(GetCharacteristics.GetProperty(poco, "Name"));
            Assert.IsTrue(GetCharacteristics.GetPropertyType(poco, typeof(string), "Name"));
        }
    }
}
