namespace Fitness.DataAccess.Entites
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
    }
}
