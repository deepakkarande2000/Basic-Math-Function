namespace Backend_App_2.Interfaces
{
    public interface IMathRepository
    {
        Task<double> Add(double v1,double v2);
        Task<double> Mul(double v1,double v2);
        Task<double> Div(double v1,double v2);
        Task<double> Sub(double v1,double v2);
    }
}
