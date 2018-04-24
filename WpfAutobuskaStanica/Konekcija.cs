using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WpfAutobuskaStanica
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder ();

            ccnSb.DataSource = @"DESKTOP-MSMDUBP\SQLEXPRESS";
            ccnSb.InitialCatalog = @"AutobuskaStanica";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);

            return konekcija;
        }
    }
}
