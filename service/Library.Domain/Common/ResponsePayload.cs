namespace Library.Domain.Common
{
    public class ResponsePayload<T>
    {
        public T? Data { get; set; }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string UIFriendlyMessage { get; set; } = string.Empty;

    }
}
