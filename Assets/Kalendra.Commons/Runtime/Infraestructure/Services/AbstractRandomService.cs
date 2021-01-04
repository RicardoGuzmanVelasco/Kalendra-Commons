using System.Collections.Generic;
using System.Linq;
using Kalendra.Commons.Runtime.Architecture.Services;

namespace Kalendra.Commons.Runtime.Infraestructure.Services
{
    public abstract class AbstractRandomService : IRandomService
    {
        public abstract int Seed { set; }
        
        #region Constructors
        protected AbstractRandomService() { }
        protected AbstractRandomService(int seed) => Seed = seed;
        #endregion

        #region Random providing
        public abstract int Next(int min, int exclusiveMax);
        public abstract float Next();
        public abstract float Next(float min, float max);
        #endregion

        #region Coin sugar syntax
        public bool TossUp() => TossUpWeighted(.5f);
        public bool TossUpWeighted(float chanceToWin) => Next() <= chanceToWin;
        public bool TossUpWeightedToBeat(float chanceToLose) => TossUpWeighted(1 - chanceToLose);
        #endregion

        #region Dice sugar syntax
        public int RollDie() => RollDieOfFaces(6);
        public int RollDieOfFaces(int facesAmount) => Next(1, facesAmount + 1);
        #endregion

        public T GetRandom<T>(IEnumerable<T> collection)
        {
            var listedCollection = collection.ToList();
            var randomMemberIndex = Next(0, listedCollection.Count);
            return listedCollection[randomMemberIndex];
        }
    }
}