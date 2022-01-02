
namespace FIFA4
{
    public interface IResponse<T>
    {
        bool IsError { get; }

        string ErrorMessage { get; }

        string Content { get; }

        T Data { get; }
    }
}
