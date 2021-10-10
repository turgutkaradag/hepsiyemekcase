using HepsiYemekCore.Core;
using HepsiYemekCore.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiYemekCase.Infrastructure
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Products> _products;
        public ProductService(IDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb+srv://DbFirst:1234@cluster0.q4yk7.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"); 
            var database = client.GetDatabase("HepsiYemek"); // settings.DatabaseName
            _products = database.GetCollection<Products>("Products");

        }

        public Products Create(Products product)
        {
            _products.InsertOne(product);
            return product;
        }

        public Products Get(string id)
        {
            return _products.Find<Products>(p => p.Id == id).FirstOrDefault();

        }

        public List<Products> GetAll()
        {
            return _products.Find(p => true).ToList();
        }

        public void Remove(string id)
        {
            _products.DeleteOne(p => p.Id == id);
        }

        public void Update(string id, Products product)
        {
            _products.ReplaceOne(p => p.Id == id, product);
        }
    }
}
