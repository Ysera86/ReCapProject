﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDAL : IBrandDAL
    {
        List<Brand> _brands;
        public InMemoryBrandDAL()
        {
            _brands = new List<Brand>
            {
                new Brand{ Id=1, Name="Audi"},
                new Brand{ Id=2, Name="Peugeot"},
                new Brand{ Id = 3, Name="Lamborghini"}
            };
        }
        public void Add(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);
            if (brandToDelete != null)
            {
                _brands.Add(brandToDelete);
            }
        }

        public void Delete(Brand brand)
        {
            _brands.Remove(brand);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brands.SingleOrDefault(filter.Compile());
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return filter == null ? _brands : _brands.Where(filter.Compile()).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(x => x.Id == brand.Id);
            if (brandToUpdate != null)
            {
                brandToUpdate.Name = brand.Name;
            }
        }
    }
}
