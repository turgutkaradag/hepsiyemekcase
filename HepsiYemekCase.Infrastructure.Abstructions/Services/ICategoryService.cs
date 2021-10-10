using HepsiYemekCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiYemekCase.Infrastructure.Interfaces
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
        Categories Get(string id);
        Categories Create(Categories category);
        void Remove(string id);
        void Update(string id, Categories category);
    }
}
