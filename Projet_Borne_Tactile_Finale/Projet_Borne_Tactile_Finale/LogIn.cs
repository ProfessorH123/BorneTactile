using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Borne_Tactile_Finale
{
    class LogIn
    {
        public static readonly string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bd_Projet_Borne_Tactile;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection Connection = new SqlConnection(str);

        public static bool isvalid(string user, string pass)
        {
            bool isval = false;
            string conn = @"SELECT * FROM Admin where lower(Admin_Name) = '" + user + "' and Admin_Pass = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(conn, Connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                isval = true;
            }
            return isval;
        }
    }
}
