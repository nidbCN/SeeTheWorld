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
            return await Context.Pictures.OrderBy(x => Guid.NewGuid()).Take(countInt).ToListAsync();
        }

        public void PutPicture(PictureEntity pictureIn)
        {
            Context.Pictures.Add(pictureIn);
            Context.SaveChanges();
        }
    }
}
