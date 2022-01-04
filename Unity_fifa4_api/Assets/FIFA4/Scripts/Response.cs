
namespace FIFA4
{
    public class Response<T>
    {
        public readonly bool isError;
        public readonly string errorMessage;

        public readonly string url;
        public readonly string content;

        public readonly T data;

        public Response(string url, bool isError, string errorMessage, string content, T data)
        {
            this.isError = isError;
            this.errorMessage = errorMessage;

            this.url = url;
            this.content = content;

            this.data = data;
        }
    }
}
