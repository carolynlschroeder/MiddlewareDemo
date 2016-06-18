using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiddlewareDemo.Entities;

namespace MiddlewareDemo.Repositories
{
    public class ImageRepository
    {
        private EntitiesDbContext entities = new EntitiesDbContext();
        public List<Image> GetImages()
        {
            return entities.Image.ToList();
        }
    }
}
