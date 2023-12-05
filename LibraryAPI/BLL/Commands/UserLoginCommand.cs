using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Commands
{
	public class UserLoginCommand : IRequest<string>
	{
		public UserLoginDTO UserDTO {  get; set; }

        public UserLoginCommand(UserLoginDTO userDTO)
        {
            UserDTO = userDTO;
        }
    }
}
