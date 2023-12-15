using ErrorOr;

namespace ArtLite.Api.Services;

public interface ITagService
{
    Task<ErrorOr<List<Tag>>> GetAllTags();
}
