using Backend_App_2.Interfaces;

namespace Backend_App_2.Services
{
    public class MathService : IMathService
    {
        private readonly IMathRepository _mathRepository;
        
        public MathService(IMathRepository mathRepository)
        {
                _mathRepository=mathRepository;
        }
        public async Task<double> Addition(double x, double y)
        {
            var result = await _mathRepository.Add(x, y);
            return result;
        }

        public async Task<double> Division(double x, double y)
        {
            var result = await _mathRepository.Div(x, y);
            return result;
        }

        public async Task<double> Multiplication(double x, double y)
        {
            var result = await _mathRepository.Mul(x, y);
            return result;
        }

        public async Task<double> Substraction(double x, double y)
        {
            var result = await _mathRepository.Sub(x, y);
            return result;
        }
    }
}
