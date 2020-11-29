
using HB.MarsRover.Domain.Entities;

namespace HB.MarsRover.Application.Services
{
    public interface IRoverService
    {
        void InitilazeInputsAndCalculate();
        void CalculateMovements(Plateau plateau);
        Position GetPositionByInputString(string positionInput);
    }
}
