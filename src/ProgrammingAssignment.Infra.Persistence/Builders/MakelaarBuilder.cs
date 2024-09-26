using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Infra.Persistence.Builders
{
    internal class MakelaarBuilder : IEntityTypeConfiguration<Makelaar>
    {
        public void Configure(EntityTypeBuilder<Makelaar> builder)
        {
            // Todo: fix intern id
            builder.HasKey(u => u.FundaId);
        }
    }
}
