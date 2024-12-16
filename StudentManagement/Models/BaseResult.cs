namespace StudentManagement.Models
{
    public class BaseResult<T>
    {
        public bool IsError { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
        public Exception Exception { get; set; }
    }
}
