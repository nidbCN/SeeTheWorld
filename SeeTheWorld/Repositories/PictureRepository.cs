using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public void PutPicture(PictureEntity pictureIn)
        {
            _context.Pictures.Add(pictureIn);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<PictureEntity>> GetAllAsync() =>
            await _context.Pictures.ToArrayAsync();

        public async Task<IEnumerable<PictureEntity>> RandomAsync(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (count == 0)
                return Array.Empty<PictureEntity>();

            var dataCount = _context.Pictures.Count();
            if (count >= dataCount)
                return await GetAllAsync();

            var indexRand = new Random().Next(0, dataCount - count);
            var result = _context.Pictures.Skip(indexRand).Take(count);

            return await result.ToListAsync();
        }
    }
}
