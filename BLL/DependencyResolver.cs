using System.ComponentModel.Composition;
using BLL.Services;
using Resolver;

namespace BLL
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent container)
        {
            container.RegisterType(typeof(IEntityService<>), typeof(GenericEntityService<>));
        }
    }
}