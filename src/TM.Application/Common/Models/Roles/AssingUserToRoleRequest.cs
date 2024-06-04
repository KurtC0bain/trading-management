namespace TM.Application.Common.Models.Roles
{
    public class AssingUserToRoleRequest
    {
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}
