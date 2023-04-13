namespace Ratings.Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions
/// </summary>
public class RatingDomainException : Exception
{
    public RatingDomainException()
    { }

    public RatingDomainException(string message)
        : base(message)
    { }

    public RatingDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
