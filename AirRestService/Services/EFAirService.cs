using AirRestService.Data;
using AirRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirRestService.Services
{
    public class EFAirService : IAir
    {
        private AirRestServiceContext _service;
        public EFAirService(AirRestServiceContext db)
        {
            _service = db;
        }

        public List<Air> GetAll()
        {
            return _service.Air.ToList();
        }
        public Air Get(int id)
        {
            return _service.Air.Find(id);
        }
        public void Create(Air air)
        {
            _service.Air.Add(air);
            _service.SaveChanges();
        }
        public void Update(int id, Air air)
        {
            _service.Air.Find(id).Humidity = air.Humidity;
            _service.Air.Find(id).Temperature = air.Temperature;
            _service.Air.Find(id).CO2 = air.CO2;
            _service.SaveChanges();
        }
        public void Remove(int id)
        {
            _service.Air.Remove(_service.Air.Find(id));
            _service.SaveChanges();
        }
    }
}
