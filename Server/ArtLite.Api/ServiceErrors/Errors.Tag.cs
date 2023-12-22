using ErrorOr;

namespace ArtLite.Api.ServiceErrors;

public static partial class Errors
{
    public static class Tag
    {
        public static Error Empty => Error.NotFound(
            code: "Tag.Empty",
            description: "There are not tags available"
        );
    }
}