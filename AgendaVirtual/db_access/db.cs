using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AgendaVirtual.db_access
{
    public class db
    {
        SqlConnection DBconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);

        public DataSet Show_data()
        {
            SqlCommand com = new SqlCommand("Select * from dados", DBconnection);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}