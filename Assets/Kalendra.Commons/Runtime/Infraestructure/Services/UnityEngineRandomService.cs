using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Services
{
    public sealed class UnityEngineRandomService : AbstractRandomService
    {
        #region Accesors
        public override int Seed
        {
            set => Random.InitState(value);
        }
        #endregion

        #region Constructors
        public UnityEngineRandomService() { }
        public UnityEngineRandomService(int seed) => Seed = seed;
        #endregion

        #region Random providing
        public override int Next(int inclusiveMin, int exclusiveMax) => Random.Range(inclusiveMin, exclusiveMax);
        
        public override float Next() => Random.value;
        public override float Next(float inclusiveMin, float inclusiveMax) => Random.Range(inclusiveMin, inclusiveMax);
        #endregion
    }
}