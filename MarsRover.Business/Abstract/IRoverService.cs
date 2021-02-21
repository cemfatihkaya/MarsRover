namespace MarsRover.Business.Abstract
{
    public interface IRoverService
    {
        void Process(string commands);

        string Print();
    }
}