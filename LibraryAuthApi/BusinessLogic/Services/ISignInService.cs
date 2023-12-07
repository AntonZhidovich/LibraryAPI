using LibraryAuthApi.DAL.Models;

namespace LibraryAuthApi.BLL.Services
{
	public interface ISignInService
	{
		public Task<string> SignIn(UserLoginDTO userLogin);
	}
}
