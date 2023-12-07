using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Queries
{
    public class UserLoginQuery : IRequest<string>
    {
        public UserLoginDTO UserDTO { get; set; }

        public UserLoginQuery(UserLoginDTO userDTO)
        {
            UserDTO = userDTO;
        }
    }
}
