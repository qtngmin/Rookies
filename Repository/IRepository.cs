using System.Collections.Generic;
using CoreDBFirst.Models;

namespace CoreDBFirst.Repository
{
    public interface IRepository
    {
        Response<List<Category>> GetCategoryList();
    //     Response<User>  GetUserById(int id);
    //    Response<List<User>> GetUsers(); 
       Response<string> Delete(string namecateg);

       Response<string> UpdateCategory(Category category);
       Response<string> Insert_data(Category _category);
        
    }
}