namespace Fitness.Core.Models
{
    public class Membership
    {
        public const int MAX_NAME_LENGHT = 50;
        public const int MAX_DESCRIPTION_LENGHT = 250;

        public Membership(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Guid Id { get;}
        public string Name { get;} = string.Empty;
        public string Description { get;} = string.Empty;
        public decimal Price { get;}

        public static (Membership Membership, string Error) Create(Guid id, string name, string description, decimal price)
        {
            var error = string.Empty;

            if(name == null || name.Length > MAX_NAME_LENGHT)
            {
                error = "The name is empty or more than allowed";
                return (null, error);
            }

            if (description == null || description.Length > MAX_DESCRIPTION_LENGHT)
            {
                error = "The description is empty or more than allowed";
            }

            if(price < 0)
            {
                error = "The price cannot be less than 0";
            }

            var membership = new Membership(id, name, description, price);

            return (membership, error);
        }
    }
}
