using AirRestService.Data;
using AirLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

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
            try
            {
                return _service.Air.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public Air GetLatest()
        {
            return _service.Air.Where(e => e.TimeStamp == _service.Air.Max(e2 => (DateTime?)e2.TimeStamp)).Single();
        }
        public Air Get(int id)
        {
            return _service.Air.Find(id);
        }
        public int GetCount()
        {
            return _service.Air.Count();
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
        public async void Clean()
        {
            await Task.Delay(new TimeSpan(0, 0, 10)).ContinueWith(o =>
            {
                //_service.Remove(id);
            });
        }
    }
}
