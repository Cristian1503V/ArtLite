using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static class CreatorError
{
    public static Error NotFound => Error.NotFound(
        code: "Creator.NotFound",
        description: "Creator not found"
    );
}


