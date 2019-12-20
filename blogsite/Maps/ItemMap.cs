using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogsite.Maps
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            //Таблицы и столбцы Postgres находятся в нижнем регистре, а наши классы C # - в PascalCase, мы должны сопоставить имя и свойства таблицы с нашей моделью.
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("item");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.Name).HasColumnName("name");
            entityBuilder.Property(x => x.LinkUrl).HasColumnName("linkurl");
            entityBuilder.Property(x => x.Image).HasColumnName("image");
            entityBuilder.Property(x => x.ParentId).HasColumnName("parentid");
            entityBuilder.Property(x => x.Click).HasColumnName("click");
        }
    }
}
