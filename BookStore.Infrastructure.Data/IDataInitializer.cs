using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Data
{
    public interface IDataInitializer
    {
        void SeedDB(BookStoreDBContext _ctx);
    }
}
