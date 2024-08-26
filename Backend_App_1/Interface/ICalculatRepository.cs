namespace Backend_App_1.Interface
{
    public interface ICalculatRepository
    {
        Task<double> Calculate(double i, double j, string opName);
    }
}
