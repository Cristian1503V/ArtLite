using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static partial class Errors
{
    public static class Creator
    {
        public static Error NotFound => Error.NotFound(
            code: "Creator.NotFound",
            description: "Creator not found"
        );
    }
}
