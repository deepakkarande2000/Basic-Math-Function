namespace Backend_App_2.Interfaces
{
    public interface IMathService
    {
        Task<double> Addition(double x, double y);
        Task<double> Multiplication(double x, double y);
        Task<double> Division(double x, double y);
        Task<double> Substraction(double x, double y);
    }
}
