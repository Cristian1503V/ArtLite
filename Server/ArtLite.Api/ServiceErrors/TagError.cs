using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public class TagError
{
    public static Error NotFound => Error.NotFound(
        code: "Tag.NotFound",
        description: "Tag not found"
    );
}
