namespace Kalendra.Commons.Runtime.Architecture.Patterns
{
    //TODO: better naming.
    public interface ITranslator<in TOrigin, out TTarget>
    {
        TTarget Translate(TOrigin origin);
    }
}