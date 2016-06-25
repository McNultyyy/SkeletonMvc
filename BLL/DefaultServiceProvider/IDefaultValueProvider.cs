using Extension;

namespace BLL.DefaultServiceProvider
{
    public interface IDefaultValueProvider<T> where T : class
    {
        T GetDefaultValue();
    }

    public class GenericDefaultValueProvider<T> : IDefaultValueProvider<T> where T : class
    {
        public T GetDefaultValue()
        {
            var defaultValue = typeof(T).DefaultValue<T>();
            return defaultValue;
        }
    }

}