using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SeedHelper
    {
        public void Seeder(ModelBuilder modelBuilder)
        {

            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Name="Dresses"
                },
                new Category
                {
                    Id=2,
                    Name="Shirts"
                },
                new Category
                {
                    Id=3,
                    Name="Jeans"
                },
                new Category
                {
                    Id=4,
                    Name="Sportwear "
                },
                new Category
                {
                    Id=5,
                    Name="Blazers "
                },
                new Category
                {
                    Id=6,
                    Name="Swimsuit"
                }

            };

            var users = new List<User>
            {
                new User
                {
                    Id=1,
                    FirstName="Andjela",
                    LastName="Kostic",
                    Email="andjela@gmail.com",
                    Password="pass123",
                    RoleId=2,
                },
                new User
                {
                    Id=2,
                    FirstName="Luka",
                    LastName="Lukic",
                    Email="luka.lukic@gmail.com",
                    Password="pass123",
                    RoleId=2,
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Name="ASOS DESIGN ultimate midi tea",
                    Image="dress1-black.jpg",
                    Price=29.99M,
                    CategoryId=1,
                    IsDeleted=false
                },
                 new Product
                {
                    Id=2,
                    Name="ASOS DESIGN ruched racer front",
                    Image="dress2-black.jpg",
                    Price=21.00M,
                    CategoryId=1,
                    IsDeleted=false
                },
                new Product
                {
                    Id=3,
                    Name="ASOS DESIGN long sleeve blouse",
                    Image="shirt1.jpg",
                    Price=31.99M,
                    CategoryId=2,
                    IsDeleted=false
                },
                 new Product
                {
                    Id=4,
                    Name="ASOS DESIGN natural crinkle to",
                    Image="shirt2.jpg",
                    Price=21.99M,
                    CategoryId=2,
                    IsDeleted=false
                }
            };

            var sizes = new List<Size>
            {
                new Size
                {
                    Id=1,
                    Value="XS"
                },
                new Size
                {
                    Id=2,
                    Value="S"
                },
                new Size
                {
                    Id=3,
                    Value="M"
                },
                new Size
                {
                    Id=4,
                    Value="L"
                },
                new Size
                {
                    Id=5,
                    Value="XL"
                },
                new Size
                {
                    Id=6,
                    Value="XXL"
                },
                new Size
                {
                    Id=7,
                    Value="XXXL"
                }
            };

            var sizesProducts = new List<SizeProduct>
            {
                new SizeProduct
                {
                    SizeId=1,
                    ProductId=1,
                    Quantity=10
                },
                new SizeProduct
                {
                    SizeId=2,
                    ProductId=1,
                    Quantity=15
                },
                new SizeProduct
                {
                    SizeId=3,
                    ProductId=1,
                    Quantity=5
                },
                new SizeProduct
                {
                    SizeId=4,
                    ProductId=1,
                    Quantity=6
                },
                 new SizeProduct
                {
                    SizeId=4,
                    ProductId=3,
                    Quantity=6
                },
                 new SizeProduct
                {
                    SizeId=5,
                    ProductId=3,
                    Quantity=9
                },
                 new SizeProduct
                {
                    SizeId=1,
                    ProductId=3,
                    Quantity=0
                },
                  new SizeProduct
                {
                    SizeId=6,
                    ProductId=4,
                    Quantity=2
                },
                   new SizeProduct
                {
                    SizeId=2,
                    ProductId=4,
                    Quantity=12
                },
                    new SizeProduct
                {
                    SizeId=3,
                    ProductId=4,
                    Quantity=10
                }
            };

            var orders = new List<Order>
            {
                new Order
                {
                    Id=1,
                    ShippingAddress="Adresa bb",
                    ShippingCity="Beograd",
                    Phone="1230212",
                    Price=123.99M,
                    UserId= 1
                }
            };

            var orderLines = new List<OrderLine>()
            {
                new OrderLine
                {
                    Id=1,
                    SizeId=1,
                    ProductId=1,
                    OrderId=1,
                    Quantity=1
                },
                new OrderLine
                {
                    Id=2,
                    SizeId=2,
                    ProductId=1,
                    OrderId=1,
                    Quantity=1
                },
                new OrderLine
                {
                    Id=3,
                    SizeId=3,
                    ProductId=1,
                    OrderId=1,
                    Quantity=1
                },
                new OrderLine
                {
                    Id=4,
                    SizeId=5,
                    ProductId=3,
                    OrderId=1,
                    Quantity=1
                }
            };

            var userUseCases = new List<UserUseCase>()
            {
                new UserUseCase
                {
                    Id=1,
                    UserId=1,
                    UseCaseId=1,
                },
                 new UserUseCase
                {
                     Id=2,
                    UserId=1,
                    UseCaseId=2,
                },
                  new UserUseCase
                {
                    Id=3,
                    UserId=1,
                    UseCaseId=3,
                },
                   new UserUseCase
                {
                       Id=4,
                    UserId=1,
                    UseCaseId=4,
                },
                  new UserUseCase
                {Id = 5,
                    UserId=1,
                    UseCaseId=5,
                },
                  new UserUseCase
                {Id = 6,
                    UserId=1,
                    UseCaseId=6,
                },
                  new UserUseCase
                {Id = 7,
                    UserId=1,
                    UseCaseId=7,
                },
                  new UserUseCase
                {Id = 8,
                    UserId=1,
                    UseCaseId=8,
                },
                  new UserUseCase
                {Id = 9,
                    UserId=1,
                    UseCaseId=9,
                },
                   new UserUseCase
                {Id = 10,
                    UserId=1,
                    UseCaseId=10,
                },
                  new UserUseCase
                {Id = 11,
                    UserId=1,
                    UseCaseId=11,
                },
                  new UserUseCase
                {Id = 12,
                    UserId=1,
                    UseCaseId=12,

                },
                  new UserUseCase
                {Id = 13,
                    UserId=1,
                    UseCaseId=13,
                },
                  new UserUseCase
                {Id = 14,
                    UserId=1,
                    UseCaseId=14,
                },
                   new UserUseCase
                {Id = 15,
                    UserId=1,
                    UseCaseId=15,
                },
                  new UserUseCase
                {Id = 16,
                    UserId=1,
                    UseCaseId=16,
                },
                  new UserUseCase
                {Id = 17,
                    UserId=1,
                    UseCaseId=17,
                },
                 new UserUseCase
                {Id = 18,
                    UserId=1,
                    UseCaseId=18,
                },
                 new UserUseCase
                {Id = 19,
                    UserId=1,
                    UseCaseId=19,
                },
                 new UserUseCase
                {Id = 20,
                    UserId=1,
                    UseCaseId=20,
                },
                 new UserUseCase
                {Id = 21,
                    UserId=1,
                    UseCaseId=21,
                }, 
                new UserUseCase
                {Id = 22,       
                    UserId=1,
                    UseCaseId=22,
                },
                new UserUseCase
                {  Id= 23,      
                    UserId=2,
                    UseCaseId=1,
                },
                 new UserUseCase
                {Id= 24,
                    UserId=2,
                    UseCaseId=2,
                },
                  new UserUseCase
                {Id=25,
                    UserId=2,
                    UseCaseId=3,
                },
                   new UserUseCase
                {
                       Id= 26,
                    UserId=2,
                    UseCaseId=4,
                },
                  new UserUseCase
                {
                      Id= 27,
                    UserId=2,
                    UseCaseId=5,
                },
                  new UserUseCase
                {
                      Id= 28,
                    UserId=2,
                    UseCaseId=6,
                },
                  new UserUseCase
                {
                      Id= 29,
                    UserId=2,
                    UseCaseId=7,
                },
                  new UserUseCase
                {
                      Id= 30,
                    UserId=2,
                    UseCaseId=8,
                },
                  new UserUseCase
                {
                      Id= 31,
                    UserId=2,
                    UseCaseId=9,
                },
                   new UserUseCase
                {
                       Id= 32,
                    UserId=2,
                    UseCaseId=10,
                },
                  new UserUseCase
                {
                      Id=33,
                    UserId=2,
                    UseCaseId=11,
                },
                  new UserUseCase
                {
                      Id=34,
                    UserId=2,
                    UseCaseId=12,

                },
                  new UserUseCase
                {
                      Id=35,
                    UserId=2,
                    UseCaseId=13,
                },
                  new UserUseCase
                {
                      Id=36,
                    UserId=2,
                    UseCaseId=14,
                },
                   new UserUseCase
                {
                       Id=37,
                    UserId=2,
                    UseCaseId=15,
                },
                  new UserUseCase
                {
                      Id=38,
                    UserId=2,
                    UseCaseId=16,
                },
                  new UserUseCase
                {
                      Id=39,
                    UserId=2,
                    UseCaseId=17,
                },
                 new UserUseCase
                {
                     Id=40,
                    UserId=2,
                    UseCaseId=18,
                },
                 new UserUseCase
                {
                     Id=41,
                    UserId=2,
                    UseCaseId=19,
                },
                 new UserUseCase
                {
                     Id=42,
                    UserId=2,
                    UseCaseId=20,
                },
                 new UserUseCase
                {
                     Id=43,
                    UserId=2,
                    UseCaseId=21,
                },
                new UserUseCase
                {
                    Id=44,
                    UserId=2,
                    UseCaseId=22,
                },
                 new UserUseCase
                {
                    Id=45,
                    UserId=1,
                    UseCaseId=23,
                },
                  new UserUseCase
                {
                    Id=46,
                    UserId=2,
                    UseCaseId=23,
                },
                    new UserUseCase
                {
                    Id=47,
                    UserId=1,
                    UseCaseId=24,
                },
                      new UserUseCase
                {
                    Id=48,
                    UserId=2,
                    UseCaseId=24,
                },
                      new UserUseCase
                {
                    Id=49,
                    UserId=1,
                    UseCaseId=25,
                },

                      new UserUseCase
                {
                    Id=50,
                    UserId=2,
                    UseCaseId=25,
                }

            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Size>().HasData(sizes);
            modelBuilder.Entity<SizeProduct>().HasData(sizesProducts);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderLine>().HasData(orderLines);
            modelBuilder.Entity<UserUseCase>().HasData(userUseCases);
        }
    }
}
