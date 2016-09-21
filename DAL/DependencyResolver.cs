using System.ComponentModel.Composition;
using DAL.Repository;
using DAL.UnitOfWork;
using Resolver;

namespace DAL
{
    [Export(typeof(IResolverComponent))]
    public class DependencyResolver : IResolverComponent
    {
        public void SetUp(IRegisterComponent container)
        {
            container.RegisterTypeWithControlledLifeTime<IContext, SkeletonMvcContext>();
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}