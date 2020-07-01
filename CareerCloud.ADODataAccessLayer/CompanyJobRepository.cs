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
    public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                   ([Id]
                                   ,[Company]
                                   ,[Profile_Created]
                                   ,[Is_Inactive]
                                   ,[Is_Company_Hidden])
                             VALUES
                                   (@Id
                                   ,@Company
                                   ,@Profile_Created
                                   ,@Is_Inactive
                                   ,@Is_Company_Hidden)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Company_Jobs";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyJobPoco[] pocos = new CompanyJobPoco[10000];

            while (rdr.Read())
            {
                CompanyJobPoco poco = new CompanyJobPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Company = rdr.GetGuid(1);
                poco.ProfileCreated = (DateTime)rdr.GetDateTime(2);
                poco.IsInactive = rdr.GetBoolean(3);
                poco.IsCompanyHidden = rdr.GetBoolean(4);
                poco.TimeStamp = (byte[])rdr.GetSqlBinary(5);

                pocos[x] = poco;
                x++;
            }

            conn.Close();

            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Jobs]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                                   SET [Id] = @Id
                                   ,[Company] = @Company
                                   ,[Profile_Created] = @Profile_Created
                                   ,[Is_Inactive] = @Is_Inactive
                                   ,[Is_Company_Hidden] = @Is_Company_Hidden
                                   WHERE [Id] = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
