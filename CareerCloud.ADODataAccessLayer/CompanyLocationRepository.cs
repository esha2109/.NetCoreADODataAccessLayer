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
    public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyLocationPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Locations]
                                   ([Id]
                                   ,[Company]
                                   ,[Country_Code]
                                   ,[State_Province_Code]
                                   ,[Street_Address]
                                   ,[City_Town]
                                   ,[Zip_Postal_Code])
                             VALUES
                                   (@Id
                                   ,@Company
                                   ,@Country_Code
                                   ,@State_Province_Code
                                   ,@Street_Address
                                   ,@City_Town
                                   ,@Zip_Postal_Code)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                cmd.Parameters.AddWithValue("@City_Town", poco.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Company_Locations";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[10000];

            while (rdr.Read())
            {
                CompanyLocationPoco poco = new CompanyLocationPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Company = rdr.GetGuid(1);
                poco.CountryCode = rdr.GetString(2);
                poco.Province = rdr.IsDBNull(3) ? null : rdr.GetString(3);
                poco.Street = rdr.IsDBNull(4) ? null : rdr.GetString(4);
                poco.City = rdr.IsDBNull(5) ? null : rdr.GetString(5);
                poco.PostalCode = rdr.IsDBNull(6) ? null : rdr.GetString(6);
                poco.TimeStamp = (byte[])rdr.GetSqlBinary(7);

                pocos[x] = poco;
                x++;
            }

            conn.Close();

            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyLocationPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Locations]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyLocationPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Locations]
                                   SET [Id] = @Id
                                   ,[Company] = @Company
                                   ,[Country_Code] = @Country_Code
                                   ,[State_Province_Code] = @State_Province_Code
                                   ,[Street_Address] = @Street_Address
                                   ,[City_Town] = @City_Town
                                   ,[Zip_Postal_Code] = @Zip_Postal_Code
                                    WHERE [Id] = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                cmd.Parameters.AddWithValue("@City_Town", poco.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
