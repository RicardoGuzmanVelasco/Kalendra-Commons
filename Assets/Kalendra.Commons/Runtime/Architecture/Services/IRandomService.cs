using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Architecture.Services
{
    public interface IRandomService
    {
        int Seed { set; }

        int Next(int min, int exclusiveMax);

        float Next();
        float Next(float min, float max);
        
        bool TossUp();
        bool TossUpWeighted(float chanceToWin);
        bool TossUpWeightedToBeat(float chanceToLose);

        int RollDie();
        int RollDieOfFaces(int facesAmount);

        T GetRandom<T>(IEnumerable<T> collection);
    }
}