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
        private SeeTheWorldContext Context { get; }
        public PictureRepository(SeeTheWorldContext context)
        {
            Context = context
                      ?? throw new ArgumentNullException(nameof(context));
        }

        public void PutPicture(PictureEntity pictureIn)
        {
            Context.Pictures.Add(pictureIn);
            Context.SaveChanges();
        }

        public async Task<IEnumerable<PictureEntity>> GetAllAsync() =>
            await Context.Pictures.ToArrayAsync();

        public async Task<IEnumerable<PictureEntity>> RandomAsync(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 0)
                return Array.Empty<PictureEntity>();

            var dataCount = Context.Pictures.Count();
            if (count >= dataCount)
                return await GetAllAsync();

            var rand = new Random().Next(0, dataCount - count);

            var result =
                from pictures in Context.Pictures
                where pictures.Id >= rand
                select pictures;

            return await result.ToListAsync();
        }
    }
}
