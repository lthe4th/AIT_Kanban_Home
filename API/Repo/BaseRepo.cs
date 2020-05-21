using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Repo
{
    public class BaseRepo
    {
        protected IDbConnection con;
        public BaseRepo()
        {
            string ConnectionString  = "Data Source=localhost; Initial Catalog=Kanban; Integrated Security = true";
            con = new SqlConnection(ConnectionString);
        }
    }
}