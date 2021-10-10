using HepsiYemekCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiYemekCase.Infrastructure
{
    public interface IProductService
    {
        List<Products> GetAll();
        Products Get(string id);
        Products Create(Products product);
        void Remove(string id);
        void Update(string id, Products product);
    }
}
