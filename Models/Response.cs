namespace Models
{
    public class Response<T>
    {
        public bool Successful { get; set; }

        public string Message { get; set; }

        public T Content { get; set; }
    }
}
