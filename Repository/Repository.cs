using System;
using System.Collections.Generic;
using System.Linq;
using CoreDBFirst.Models;

namespace CoreDBFirst.Repository
{
    public class Repository : IRepository
    {
        private readonly shopee_fakeContext _dbContext;
        public Repository(shopee_fakeContext dbContext)
        {
            _dbContext = dbContext;

        }
        // public Response<User> GetUserById(int id)
        // {
        //     Response<User> result = new Response<User>();
        //     result.Data = _dbContext.Users.Find(id);
        //     return result;
        // }

        // public Response<List<User>> GetUsers()
        // {
        //     Response<List<User>> result = new Response<List<User>>();
        //     result.Data = _dbContext.Users.ToList(); 
        //     return result;
        // }
        public Response<string> Delete(string namecateg)
        {
            Response<string> result = new Response<string>();
            try
            {
                    Category data = _dbContext.Categories.FirstOrDefault(u => u.NameCategory == namecateg);
                    _dbContext.Categories.Remove(data);
                    var res =  _dbContext.SaveChanges();
                    if (res == 1)
                    {
                        result.message = "Success";
                    }
                    else
                    {
                        result.message = "Failed";
                    }
                
            }
            catch (Exception ex)
            {
                result.message = ex.Message;

            }
            return result;
        }

        public Response<string> UpdateCategory(Category category)
        {
            Response<string> result = new Response<string>();
            try
            {
               
                    Category data = _dbContext.Categories.FirstOrDefault(d => d.NameCategory == category.NameCategory);

                    data.NameCategory = category.NameCategory;
                    data.Discription = category.Discription;
                    

                    var res = _dbContext.SaveChanges();
                    if (res == 1)
                    {
                        result.Data = "Success";
                    }
                    else
                    {
                        result.Data = "Failed";
                    }
               
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
            }
            return result;
        }
        public Response<List<Category>> GetCategoryList()
        {
            Response<List<Category>> result = new Response<List<Category>>();
            result.Data = _dbContext.Categories.ToList(); 
            return result;
        }

        public Response<string> Insert_data(Category _category)
        {
            Response<string> result = new Response<string>();
            try
            {
                
                    var categ = _dbContext.Categories.FirstOrDefault(d => d.NameCategory == _category.NameCategory);
                    if (categ != null) //if name exist update data
                    {
                        result.Data = "User already Exists!";
                    }
                    else
                    {
                        _dbContext.Categories.Add(_category);
                        var res = _dbContext.SaveChanges();
                        if (res == 1)
                        {
                            result.Data = "Success";
                        }
                        else
                        {
                            result.Data = "Failed"; 
                        }

                    }
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;

            }
            return result;
        }
    }
}