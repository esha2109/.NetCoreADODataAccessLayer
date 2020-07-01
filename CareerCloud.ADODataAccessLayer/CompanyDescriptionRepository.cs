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
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                                   ([Id]
                                   ,[Company]
                                   ,[LanguageID]
                                   ,[Company_Name]
                                   ,[Company_Description])
                             VALUES
                                   (@Id
                                   ,@Company
                                   ,@LanguageID
                                   ,@Company_Name
                                   ,@Company_Description)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Company_Descriptions";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];

            while (rdr.Read())
            {
                CompanyDescriptionPoco poco = new CompanyDescriptionPoco();

                poco.Id = rdr.GetGuid(0);
                poco.Company = rdr.GetGuid(1);
                poco.LanguageId = rdr.GetString(2);
                poco.CompanyName = rdr.GetString(3);
                poco.CompanyDescription = rdr.GetString(4);
                poco.TimeStamp = (byte[])rdr.GetSqlBinary(5);

                pocos[x] = poco;
                x++;
            }

            conn.Close();

            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Descriptions]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                                   SET [Id] = @Id
                                   ,[Company] = @Company
                                   ,[LanguageID] = @LanguageID
                                   ,[Company_Name] = @Company_Name
                                   ,[Company_Description] = @Company_Description

                                   WHERE [Id] = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
