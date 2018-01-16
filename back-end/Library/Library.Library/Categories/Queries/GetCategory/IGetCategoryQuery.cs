using Library.Library.Categories.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Categories.Queries.GetCategory
{
    public interface IGetCategoryQuery
    {
        Task<List<CategoryViewModel>> ExecuteAsync();
    }
}
