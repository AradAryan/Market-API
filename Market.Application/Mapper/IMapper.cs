namespace Application
{
    public interface IMapper<TSource, TDestination> where TDestination : class, new()
    {
        TDestination Map(object source);
        IEnumerable<TDestination> MapList(IEnumerable<object> sources);

        TSource MapTo(object destination);
        IEnumerable<TSource> MapListTo(IEnumerable<object> destinations);
    }
}