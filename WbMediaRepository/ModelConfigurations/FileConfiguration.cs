using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WbMediaModels;

namespace WbMediaRepository.ModelConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(p => p.FileId);
        }
    }

}
