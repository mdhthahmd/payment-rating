namespace Ratings.Application.Services;

public interface RatingServiceModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public int Stars { get; set; }
}