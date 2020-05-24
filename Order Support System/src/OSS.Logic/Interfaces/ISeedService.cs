using System.Threading.Tasks;

namespace OSS.Domain.Interfaces.Services
{
    public interface ISeedService
    {
        Task SeedRoles();
        Task SeedUsers();
        Task SeedItems();
        Task SeedOrders();
        Task SeedImages();
    }
}