namespace Webfeb.Models.Admin
{
	public class UserViewModel
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public List<string> Roles { get; set; } = new List<string>();
	}
}
