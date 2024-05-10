namespace LeaveManagementSystem.UI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; }
    }
}
