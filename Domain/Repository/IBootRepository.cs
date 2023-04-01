using Domain.Model;

namespace Domain.Repository;

public interface IBootRepository
{
    List<BootModel> GetFullBoots();
}