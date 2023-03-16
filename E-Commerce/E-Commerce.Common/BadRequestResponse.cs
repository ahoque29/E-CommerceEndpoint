namespace E_Commerce.Common;

public record BadRequestResponse(IEnumerable<string> Errors);