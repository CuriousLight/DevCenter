using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;

namespace Dev_Center.Repository
{
    public class DomainRepository:IDomainRepository
    {
        bool worldline = false;

        public string GetConnectionString()
        {
            if (worldline)
            {
                return "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(Host = ECREP.org.oebb.at)(Port = 1521)))(CONNECT_DATA =(SID = ECREP)(SERVER = DEDICATED)));User Id=ws;Password=cisoe2016;";
            }
            else
            {
                // IF ist keine Schleife
                return "Data Source=localhost:1521;User Id=repcapp;Password=w0rldlin3;";
            }
        }

        public List<string[]> GetTable(string com)
        {
            Stopwatch sw = new Stopwatch();
            bool first = true;
            string x = "", y = "";
            List<string[]> ls = new List<string[]>();
            sw.Start();
            using (OracleConnection conn = new OracleConnection(GetConnectionString()))
            using (OracleCommand cmd = new OracleCommand(com, conn))
            {
                conn.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (first)
                            {
                                foreach (DataRow dr in reader.GetSchemaTable().Rows)
                                {
                                    x += (dr[0].ToString() + ";");
                                }
                                ls.Add(x.Split(';'));
                                first = false;
                                x = "";
                            }
                            foreach (DataRow dr in reader.GetSchemaTable().Rows)
                            {
                                if (("").Equals(reader[$"{dr[0].ToString()}"].ToString()))
                                    y += "null" + ";"; 
                                else
                                    y += reader[$"{dr[0].ToString()}"].ToString() + ";";
                            }
                            ls.Add(y.Split(';'));
                            y = "";
                        }
                        sw.Stop();
                        Debug.WriteLine("DisplayRepository : "+sw.ElapsedMilliseconds/1000+ " Sekunden");
                        return ls;
                    }
                    else
                        return null;
                }
            }
        }
    }
}

