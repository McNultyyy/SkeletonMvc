using System.ComponentModel.Composition;
using BLL.Services;
using Resolver;

namespace BLL
{
    [Export(typeof(IResolverComponent))]
    public class DependencyResolver : IResolverComponent
    {
        public void SetUp(IRegisterComponent container)
        {
            container.RegisterType(typeof(IEntityService<>), typeof(GenericEntityService<>));
        }
    }
}