using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace CareerCloud.UnitTests.Assignment2
{
    class DatabaseConstraints
    {
        protected readonly string _connStr = string.Empty;

        public DatabaseConstraints()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }

        public void DisableConstraintsForPoco(Type pocoType)
        {
            AlterConstraintsForPoco(pocoType, " NOCHECK CONSTRAINT ALL");
        }

        public void EnableConstraintsForPoco(Type pocoType)
        {
            AlterConstraintsForPoco(pocoType, " WITH CHECK CHECK CONSTRAINT ALL");           
        }

        private void AlterConstraintsForPoco(Type pocoType, string alterOption)
        {
            string tableName;
            bool success = TryGetTableName(pocoType, out tableName);
            if (success)
            {
                ExecuteCommand(String.Concat("ALTER TABLE ", tableName, alterOption));
            }
        }     

        private void ExecuteCommand(string commandText)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {                            
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }    
        }

        private bool TryGetTableName(Type pocoType, out string tableName)
        {
            bool result = false;
            tableName = "";
            if (pocoType != null)
            {
                TableAttribute tableAttribute = (TableAttribute)pocoType.GetCustomAttribute(typeof(TableAttribute));
                if (tableAttribute != null)
                {
                    tableName = tableAttribute.Name;
                    result = true;
                }
            }
          
            return result;
        }
    }
}
