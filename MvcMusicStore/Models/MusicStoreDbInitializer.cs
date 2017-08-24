using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class MusicStoreDbInitializer:System.Data.Entity.DropCreateDatabaseAlways<MusicStoreDBContext>
    {
        protected override void Seed(MusicStoreDBContext context)
        {
            context.Artists.Add(new Artist() { Name="Al Di Meola"});
            context.Genres.Add(new Genre() { Name="jazz"});
            context.Ablums.Add(new Ablum() {
                Artist = new Artist() { Name = "Rush" },
                Genre = new Genre() { Name = "Rock" },
                Price = 9.9m,
                Title="Caravan"
            });



            base.Seed(context);
        }
    }
}