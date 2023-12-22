using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static partial class Errors
{
    public static class Image
    {
        public static Error Upload => Error.NotFound(
            code: "Image.Upload",
            description: "Something failled when uploading the image"
        );
    }
}
