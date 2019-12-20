using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogsite.Maps
{
    public class FolderMap
    {
        public FolderMap(EntityTypeBuilder<Folder> entityBuilder)
        {
            //Таблицы и столбцы Postgres находятся в нижнем регистре, а наши классы C # - в PascalCase, мы должны сопоставить имя и свойства таблицы с нашей моделью.
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("folder");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.FolderName).HasColumnName("foldername");
            entityBuilder.Property(x => x.Status).HasColumnName("status");
            entityBuilder.Property(x => x.Parent).HasColumnName("parent");
        }
    }
}
