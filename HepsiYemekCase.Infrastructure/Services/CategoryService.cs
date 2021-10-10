using HepsiYemekCase.Infrastructure.Interfaces;
using HepsiYemekCore.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiYemekCase.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Categories> _categories;
        public CategoryService(IDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb+srv://DbFirst:1234@cluster0.q4yk7.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"); // settings.ConnectionString
            var database = client.GetDatabase("HepsiYemek"); // settings.DatabaseName
            _categories = database.GetCollection<Categories>("Categories");
        }
        public Categories Create(Categories category)
        {
            _categories.InsertOne(category);
            return category;
        }

        public Categories Get(string id)
        {
            return _categories.Find(p => p.Id == id).FirstOrDefault();
        }

        public List<Categories> GetAll()
        {
            return _categories.Find(p => true).ToList();
        }

        public void Remove(string id)
        {
            _categories.DeleteOne(p => p.Id == id);
        }

        public void Update(string id, Categories category)
        {
            _categories.ReplaceOne(p => p.Id == id, category);
        }
    }
}
