using System;
using System.Collections.Generic;
using System.Text;

namespace CapaInterfaz
{
    class Configuracion
    {
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
