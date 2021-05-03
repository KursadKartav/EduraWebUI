using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData //static classlar static metodlarla çalışır.
    {
        public static void EnsurePopulated(EduraContext context) /*(IApplicationBuilder app)*/ //projem çalıştığında işlem yapsın.Appin içerisi dolucak
        {
            /*  var context = app.ApplicationServices.GetRequiredService<EduraContext>();*/ //app dolduktan sonra ilk app serviceseye git sonra gerekli serviceseye git sonra edura contexti bul contexte yükle.
            context.Database.Migrate();

            if (!context.Products.Any()) //hiç yoksa
            {
                var products = new[] //birden fazla new oluşturacağım için new i arrayledim.
                {
                    new Product(){ProductName="Photo Camera",Price=1000,Image="product1.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-10)},
                    new Product(){ProductName="Chair",Price=200,Image="product2.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-20)},
                    new Product(){ProductName="Hand Bag",Price=500,Image="product4.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ProductName="Sofa",Price=3000,Image="product3.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-15)}
                };
                context.Products.AddRange(products);  //bir veri göndereceğim zaman add ama birden fazla kayıt gönderiyorsam addrange.

                var categories = new[]
                {
                    new Category(){CategoryName="Electronics"},
                    new Category(){CategoryName="Accessories"},
                    new Category(){CategoryName="Furniture"}
                };
                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){Product=products[0],Category=categories[0]},
                    new ProductCategory(){Product=products[1],Category=categories[2]},
                    new ProductCategory(){Product=products[2],Category=categories[1]},
                    new ProductCategory(){Product=products[3],Category=categories[2]}
                };
                context.AddRange(productcategories);

                var images = new[]
                {
                    new Image(){ImageName="product1.jpg",Product=products[0]},
                    new Image(){ImageName="product1.jpg",Product=products[0]},
                    new Image(){ImageName="product1.jpg",Product=products[0]},
                    new Image(){ImageName="product1.jpg",Product=products[0]},

                    new Image(){ImageName="product2.jpg",Product=products[1]},
                    new Image(){ImageName="product2.jpg",Product=products[1]},
                    new Image(){ImageName="product2.jpg",Product=products[1]},
                    new Image(){ImageName="product2.jpg",Product=products[1]},

                    new Image(){ImageName="product3.jpg",Product=products[2]},
                    new Image(){ImageName="product3.jpg",Product=products[2]},
                    new Image(){ImageName="product3.jpg",Product=products[2]},
                    new Image(){ImageName="product3.jpg",Product=products[2]},
                                                                          
                    new Image(){ImageName="product4.jpg",Product=products[3]},
                    new Image(){ImageName="product4.jpg",Product=products[3]},
                    new Image(){ImageName="product4.jpg",Product=products[3]},
                    new Image(){ImageName="product4.jpg",Product=products[3]}

                };
                context.Images.AddRange(images);

                var attribute = new[]
                {
                    new ProductAttribute(){Attribute="Ürün Boyutları",Value="6 x 12,7 x 9,6 cm ; 558 g",Product=products[0]},
                    new ProductAttribute(){Attribute="Piller",Value="Lithium ion piller gereklidir.(piller ürüne dahildir)",Product=products[0]},
                    new ProductAttribute(){Attribute="Ürün Model Numarası",Value="ILCE7M2B.CE C",Product=products[0]},
                    new ProductAttribute(){Attribute="ASIN",Value="B00Q2KEUFI",Product=products[0]},

                    new ProductAttribute(){Attribute="Ürün Boyutları",Value="6 x 12,7 x 9,6 cm ; 558 g",Product=products[1]},
                    new ProductAttribute(){Attribute="Piller",Value="Lithium ion piller gereklidir.(piller ürüne dahildir)",Product=products[1]},
                    new ProductAttribute(){Attribute="Ürün Model Numarası",Value="ILCE7M2B.CE C",Product=products[1]},
                    new ProductAttribute(){Attribute="ASIN",Value="B00Q2KEUFI",Product=products[1]},

                    new ProductAttribute(){Attribute="Ürün Boyutları",Value="6 x 12,7 x 9,6 cm ; 558 g",Product=products[2]},
                    new ProductAttribute(){Attribute="Piller",Value="Lithium ion piller gereklidir.(piller ürüne dahildir)",Product=products[2]},
                    new ProductAttribute(){Attribute="Ürün Model Numarası",Value="ILCE7M2B.CE C",Product=products[2]},
                    new ProductAttribute(){Attribute="ASIN",Value="B00Q2KEUFI",Product=products[2]},

                    new ProductAttribute(){Attribute="Ürün Boyutları",Value="6 x 12,7 x 9,6 cm ; 558 g",Product=products[3]},
                    new ProductAttribute(){Attribute="Piller",Value="Lithium ion piller gereklidir.(piller ürüne dahildir)",Product=products[3]},
                    new ProductAttribute(){Attribute="Ürün Model Numarası",Value="ILCE7M2B.CE C",Product=products[3]},
                    new ProductAttribute(){Attribute="ASIN",Value="B00Q2KEUFI",Product=products[3]}


                };
                context.Attributes.AddRange(attribute);

                context.SaveChanges();
                
            }
        }
    }
}
