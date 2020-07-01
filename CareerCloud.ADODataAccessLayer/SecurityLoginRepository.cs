using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (SecurityLoginPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                   ([Id]
                                   ,[Login]
                                   ,[Password]
                                   ,[Created_Date]
                                   ,[Password_Update_Date]
                                   ,[Agreement_Accepted_Date]
                                   ,[Is_Locked]
                                   ,[Is_Inactive]
                                   ,[Email_Address]
                                   ,[Phone_Number]
                                   ,[Full_Name]
                                   ,[Force_Change_Password]
                                   ,[Prefferred_Language])
                             VALUES
                                   (@Id
                                   ,@Login
                                   ,@Password
                                   ,@Created_Date
                                   ,@Password_Update_Date
                                   ,@Agreement_Accepted_Date
                                   ,@Is_Locked
                                   ,@Is_Inactive
                                   ,@Email_Address
                                   ,@Phone_Number
                                   ,@Full_Name
                                   ,@Force_Change_Password
                                   ,@Prefferred_Language)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Password", poco.Password);
                cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Security_Logins";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[10000];

            while (rdr.Read())
            {
                SecurityLoginPoco poco = new SecurityLoginPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Login = rdr.GetString(1);
                poco.Password = rdr.GetString(2);
                poco.Created = (DateTime)rdr.GetDateTime(3);
                poco.PasswordUpdate = rdr.IsDBNull(4) ? null : (DateTime?)rdr.GetDateTime(4);
                poco.AgreementAccepted = rdr.IsDBNull(5) ? null : (DateTime?)rdr.GetDateTime(5);
                poco.IsLocked = rdr.GetBoolean(6);
                poco.IsInactive = rdr.GetBoolean(7);
                poco.EmailAddress = rdr.GetString(8);
                poco.PhoneNumber = rdr.IsDBNull(9) ? null : rdr.GetString(9);
                poco.FullName = rdr.IsDBNull(10) ? null : rdr.GetString(10);
                poco.ForceChangePassword = rdr.GetBoolean(11);
                poco.PrefferredLanguage = rdr.IsDBNull(12) ? null : rdr.GetString(12);
                poco.TimeStamp = (byte[])rdr.GetSqlBinary(13);
           
                pocos[x] = poco;
                x++;
            }

            conn.Close();

            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (SecurityLoginPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (SecurityLoginPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                   SET [Id] = @Id
                                   ,[Login] = @Login
                                   ,[Password] = @Password
                                   ,[Created_Date] = @Created_Date
                                   ,[Password_Update_Date] = @Password_Update_Date
                                   ,[Agreement_Accepted_Date] = @Agreement_Accepted_Date
                                   ,[Is_Locked] = @Is_Locked
                                   ,[Is_Inactive] = @Is_Inactive
                                   ,[Email_Address] = @Email_Address
                                   ,[Phone_Number] = @Phone_Number
                                   ,[Full_Name] = @Full_Name
                                   ,[Force_Change_Password] = @Force_Change_Password
                                   ,[Prefferred_Language] = @Prefferred_Language
                                   WHERE [Id] = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Password", poco.Password);
                cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
