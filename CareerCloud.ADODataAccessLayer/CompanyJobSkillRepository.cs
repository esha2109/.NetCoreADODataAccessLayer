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
    public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
                                   ([Id]
                                   ,[Job]
                                   ,[Skill]
                                   ,[Skill_Level]
                                   ,[Importance])
                             VALUES
                                   (@Id
                                   ,@Job
                                   ,@Skill
                                   ,@Skill_Level
                                   ,@Importance)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Company_Job_Skills";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[10000];

            while (rdr.Read())
            {
                CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Job = rdr.GetGuid(1);
                poco.Skill = rdr.GetString(2);
                poco.SkillLevel = rdr.GetString(3);
                poco.Importance = rdr.GetInt32(4);
                poco.TimeStamp = (byte[])rdr.GetSqlBinary(5);


                pocos[x] = poco;
                x++;
            }

            conn.Close();

            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Skills]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Job_Skills]
                                   SET [Id] = @Id
                                   ,[Job] = @Job
                                   ,[Skill] = @Skill
                                   ,[Skill_Level] = @Skill_Level
                                   ,[Importance] = @Importance
                                   WHERE [Id] = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
