namespace WebAPI.Services
{
    public class HelloworldServices : IHelloworldService
    {
        public string GetHelloworld()
        {
            return "Hello world";
        }
    }

    public interface IHelloworldService
    {
        string GetHelloworld();
    }
}


