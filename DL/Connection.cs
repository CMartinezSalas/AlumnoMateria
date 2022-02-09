using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            string connectionString = "";
            try
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExamenDigiPro"].ConnectionString.ToString();
            }
            catch (Exception ex)
            {

            }


            return connectionString;
        }
    }
}
