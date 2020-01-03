using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapHanaDapper
{
    public class IduConnection
    {
        public static HanaConnection Create()
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
            return new HanaConnection(ConnectionString);
        }
    }
}
