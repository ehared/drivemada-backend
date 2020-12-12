
using DriveMada_Backend.Model;

namespace DriveMada_Backend.Manager.Interfaces
{
    public interface ILoginManager
    {
        User Authenticate(User user);
    }
}
