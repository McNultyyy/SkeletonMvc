using DAL.Models.Entities;
using DAL.Repository;
using DAL.UnitOfWork;

namespace BLL.EntityServices
{
    public class BlogService : GenericEntityService<Blog>
    {
        public BlogService(IRepository<Blog> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}