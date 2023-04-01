
using Domain.Model;
using Domain.Repository;
using WebApplication1.Model.Mappers;

namespace WebApplication1.Model.Repository;

public class BootReposirory :IBootRepository
{
    private readonly ApplicationContext _context;
    public BootReposirory(ApplicationContext context)
    {
        _context = context;
    }
    public List<BootModel> GetFullBoots()
    {
        return _context.Brands.Select(x => x.ToModel()).ToList();
    }
}