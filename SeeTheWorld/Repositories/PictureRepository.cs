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

        public async Task<IEnumerable<PictureEntity>> GetPictures(uint count = 1)
        {

            var countInt = (int)count;
            var dataCount = Context.Pictures.Count();
            
            if (countInt >= dataCount)
            {
                return await Context.Pictures.ToListAsync();
            }

            var rand = new Random().Next(0, dataCount - countInt);

            var result =
                Context.Pictures
                    .Where(it => it.Id == rand).Take(countInt);

            return await result.ToListAsync();
        }

        public void PutPicture(PictureEntity pictureIn)
        {
            Context.Pictures.Add(pictureIn);
            Context.SaveChanges();
        }
    }
}
