using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static partial class Errors
{
    public static class Artwork
    {
        public static Error NotFound => Error.NotFound(
            code: "Artwork.NotFound",
            description: "Artwork not found"
        );
    }
}