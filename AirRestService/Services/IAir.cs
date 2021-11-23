using AirRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirRestService.Services
{
    public interface IAir
    {
        public List<Air> GetAll();
        public Air Get(int id);
        public void Create(Air air);
        public void Update(int id, Air air);
        public void Remove(int id);
    }
}
