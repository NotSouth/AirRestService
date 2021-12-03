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
            CalculateAverages();
            if(_service.Air.Count() > 1000)
            {
                var maxid = _service.Air.Where(e => e.ID == _service.Air.Max(e2 => (int?)e2.ID)).Single().ID;
                var oldest = _service.Air.Where(s => s.ID <= maxid - 80).ToList();
                _service.RemoveRange(oldest);
                Console.WriteLine("Removed " + _service.Air.Where(s => s.ID < maxid - 80).Count() + " items");
                _service.SaveChanges();
            }
            else { Console.WriteLine("Database is not over the limit"); }
        }
        public Average GetAverage(Average.type type) // which average to get, 0=today, 1=last day, 2=last week, 3=last month
        {
            try
            {
                return _service.Averages.Where(s => s.Type == type).Single();
            }
            catch (InvalidOperationException)
            {
                return null; 
            }
        }
        public void CalculateAverages()
        {
            //today average
            var list = _service.Air.Where(s => s.TimeStamp.DayOfYear == DateTime.Now.DayOfYear);
            if (list.Count() > 0)
            {
                double co2 = 0; double temp = 0; double hum = 0;
                foreach (Air item in list)
                {
                    co2 = co2 + item.CO2;
                    temp = temp + item.Temperature;
                    hum = hum + item.Humidity;
                }
                co2 = co2 / list.Count();
                temp = temp / list.Count();
                hum = hum / list.Count();

                co2 = Math.Truncate(co2 * 100) / 100;
                temp = Math.Truncate(temp * 100) / 100;
                hum = Math.Truncate(hum * 100) / 100;

                Average today = new Average(Average.type.today, co2, temp, hum, DateTime.Now);
                try
                {
                    _service.Averages.Remove(_service.Averages.Where(s => s.Type == Average.type.today).Single());
                }
                catch (InvalidOperationException)
                {

                }
                _service.Averages.Add(today);

                _service.SaveChanges();
            }

            //yesterday average
        }
    }
}
