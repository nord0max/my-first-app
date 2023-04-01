using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Model.Mappers;

public static class BootMapper
{
    public static BootModel ToModel(this Brand source)
    {
        return new BootModel()
        {
            BrandName = source.Name
        };
    }
}