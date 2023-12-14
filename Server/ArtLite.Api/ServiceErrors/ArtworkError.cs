using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static class ArtworkError
{
    public static Error NotFound => Error.NotFound(
        code: "Artwork.NotFound",
        description: "Artwork not found"
    );
}