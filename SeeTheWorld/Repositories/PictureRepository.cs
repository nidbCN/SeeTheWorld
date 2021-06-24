using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using SeeTheWorld.Contexts;
using SeeTheWorld.Entities;

namespace SeeTheWorld.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly SeeTheWorldContext _context;
        public PictureRepository(SeeTheWorldContext context)
        {
            _context = context
                      ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PictureEntity>> GetPictures(uint count = 1)
        {

            var countInt = (int)count;
            var dataCount = _context.Pictures.Count();
            
            if (countInt >= dataCount)
            {
                return await _context.Pictures.ToListAsync();
            }

            var rand = new Random().Next(1, dataCount - countInt);

            var result =
                _context.Pictures
                    .Where(it => it.Id == rand).Take(countInt);

            return await result.ToListAsync();
        }

        public void PutPicture(PictureEntity pictureIn)
        {
            _context.Pictures.Add(pictureIn);
            _context.SaveChanges();
        }
    }
}
