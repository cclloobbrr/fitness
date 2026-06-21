namespace Fitness.API.Contracts
{
    public record MembershipsResponse(
        Guid Id,
        string Name,
        string Descriptions,
        decimal Price);
}
