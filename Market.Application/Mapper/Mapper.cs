using System.Reflection;

namespace Application
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source) where TSource : class, new() where TDestination : class, new()
        {
            var destination = Activator.CreateInstance<TDestination>();
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList();

                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);//AddEdit

                    if (destinationProperty != null)
                    {
                        try
                        {
                            destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);//Set to DC
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                return destination;

            }
            return default;
        }

        public static IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> sources)
        {
            foreach (var source in sources)
            {
                var destination = Activator.CreateInstance<TDestination>();
                if (source != null && destination != null)
                {
                    List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList();
                    List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList();

                    foreach (PropertyInfo sourceProperty in sourceProperties)
                    {
                        PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);//AddEdit

                        if (destinationProperty != null)
                        {
                            try
                            {
                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);//Set to DC
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    yield return destination;
                }
                yield return default;

            }
        }

    }

}
