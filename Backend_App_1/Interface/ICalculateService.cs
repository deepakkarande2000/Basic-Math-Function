using System.Reflection.Emit;

namespace Backend_App_1.Interface
{
    public interface ICalculateService
    {
        Task<double> Calculate(double i, double j, string OpCode);
    }
}
