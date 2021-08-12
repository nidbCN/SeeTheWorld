using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SeeTheWorld.Contexts;
using SeeTheWorld.Entities;
using SeeTheWorld.Extensions;

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

            return await _context.Pictures.Random(count).ToArrayAsync();
        }
    }
}
