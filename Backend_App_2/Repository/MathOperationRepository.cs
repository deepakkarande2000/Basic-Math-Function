using Backend_App_2.Interfaces;

namespace Backend_App_2.Repository
{
    public class MathOperationRepository : IMathRepository
    {
        ILogger<MathOperationRepository> _logger;
        public MathOperationRepository(ILogger<MathOperationRepository> logger)
        {
            _logger = logger;
        }
        public async Task<double> Add(double v1, double v2)
        {
            return v1 + v2;
        }

        public async Task<double> Div(double v1, double v2)
        {          
                return v1 / v2;                        
        }

        public async Task<double> Mul(double v1, double v2)
        {
            return v1 * v2;
        }

        public async Task<double> Sub(double v1, double v2)
        {
            return (v1 - v2) ;
        }
    }
}
