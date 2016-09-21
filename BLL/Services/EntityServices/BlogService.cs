using Core.Entities;
using DAL.Repository;
using DAL.UnitOfWork;

namespace BLL.Services.EntityServices
{
    public class BlogService : GenericEntityService<Blog>, IBlogService
    {
        public BlogService(IRepository<Blog> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}