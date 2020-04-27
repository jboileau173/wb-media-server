namespace WbMediaCore.Features
{
    public interface IFeature<TRequest, TResponse>
    {
        TResponse Result { get; }
        void Execute(TRequest request);
    }
}
