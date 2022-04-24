using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMove.Reportes
{
    public class ReportesConexion
    {
        public static CrystalDecisions.Shared.ConnectionInfo getConexion()
        {
            CrystalDecisions.Shared.ConnectionInfo infocon = new
            CrystalDecisions.Shared.ConnectionInfo();
            infocon.ServerName = "mysqlsimplemove.database.windows.net";
            infocon.DatabaseName = "SimpleMove";
            infocon.UserID = "simplemove";
            infocon.Password = "Simple2022";

            return infocon;
        }
    }
}