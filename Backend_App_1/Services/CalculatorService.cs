using Backend_App_1.Interface;

namespace Backend_App_1.Services
{
    public class CalculatorService : ICalculateService
    {
        private readonly ICalculatRepository _calculatRepository;

        public CalculatorService(ICalculatRepository calculatRepository)
        {
            _calculatRepository = calculatRepository;    
        }
        public async Task<double> Calculate(double i, double j, string OpCode)
        {
           var result=await _calculatRepository.Calculate(i, j, OpCode);
            return result;
        }
    }
}
