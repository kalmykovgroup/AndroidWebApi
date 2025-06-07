namespace Api.Contracts
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string? ErrorMessage { get; init; }
        public T? Data { get; init; }

        public static ApiResponse<T> Ok(T value) => new() { Success = true, Data = value };
        public static ApiResponse<T> Fail(string error) => new() { Success = false, ErrorMessage = error };
    }
}
