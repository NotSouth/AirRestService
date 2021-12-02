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
            return _service.Air.Where(e => e.ID == _service.Air.Max(e2 => (int?)e2.ID)).Single();
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
        public void Clean()
        {
            if(_service.Air.Count() > 80)
            {
                var maxid = _service.Air.Where(e => e.ID == _service.Air.Max(e2 => (int?)e2.ID)).Single().ID;
                var oldest = _service.Air.Where(s => s.ID <= maxid - 80).ToList();
                _service.RemoveRange(oldest);
                Console.WriteLine("Removed " + _service.Air.Where(s => s.ID < maxid - 80).Count() + " items");
                _service.SaveChanges();
            }
            else { Console.WriteLine("Database is not over the limit"); }
        }
        public Air GetAverage(int id) //id = which average to get, 1=today, 2=last day, 3=last week, 4=last month
        {
            return _service.Averages.Where(s =>s.ID==id).Single();
        }
        public void CalculateAverages()
        {
            //today average
            _service.Air.Where(s => s.TimeStamp.DayOfYear == DateTime.Now.DayOfYear);
            //foreach

           //yesterday average
        }
    }
}
