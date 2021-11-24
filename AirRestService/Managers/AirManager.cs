using AirRestService.Data;
using AirLibrary;
using AirRestService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirRestService.Managers
{
    public class AirManager
    {
        public IAir AirService;
        public static List<Air> AirCatalog = new List<Air>();

        public AirManager(IAir airserv)
        {
            AirService = airserv;
            AirCatalog = AirService.GetAll();
        }
    }
}
