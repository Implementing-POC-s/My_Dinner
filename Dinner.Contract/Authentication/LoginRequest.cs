namespace Dinner.Contract.Authentication;

    public record RegisterRequest(
        string Email,
        string Password);
