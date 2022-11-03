using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.entity;

namespace Teknoapp.data.Concrete.EfCore
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new TeknoContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }


                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }

            }
            context.SaveChanges();
        }
        private static CategoryEntity[] Categories =
        {
            new CategoryEntity() {CategoryId=10,Name="Telefon",Description="12",Url="telefon"},
            new CategoryEntity() {CategoryId=11,Name="Elektronik",Description="12",Url="elektronik"},
            new CategoryEntity() {CategoryId=12,Name="Bilgisayar",Description="12",Url="bilgisayar"},
            new CategoryEntity() {CategoryId=13,Name="Beyaz Eşya",Description="12",Url="beyaz-esya"}

        };
        private static ProductEntity[] Products =
        {
            new ProductEntity() {ProductId=10,Name="Iphone 13 Pro Max",Url="iphone-13-pro-max",Price=30000,ImageUrl="1.jpg",Description="Çok iyi telefon",IsApproved=true},
            new ProductEntity() {ProductId=11,Name="Iphone 13 Pro",Url="iphone-13-pro",Price=25000,ImageUrl="2.jpg",Description="Çok iyi telefon",IsApproved=false},
            new ProductEntity() {ProductId=12,Name="Samsung",Url="samsung-s20",Price=7000,ImageUrl="3.jpg",Description="iyi telefon",IsApproved=true},
            new ProductEntity() {ProductId=13,Name="Samsung",Url="samsung-s20-ultra",Price=10000,ImageUrl="4.jpg",Description="iyi telefon",IsApproved=false},
            new ProductEntity() {ProductId=14,Name="Iphone 7",Url="iphone-7",Price=8000,ImageUrl="5.jpg",Description="Orta telefon",IsApproved=true},
        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[2],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]},
            new ProductCategory(){Product=Products[3],Category=Categories[2]},
            new ProductCategory(){Product=Products[4],Category=Categories[1]},
            new ProductCategory(){Product=Products[4],Category=Categories[2]}

        };
        

    }
}
