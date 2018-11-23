using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IBusinessLogic
    {
        ProductDetails GetProductsDetailedList(int productId, int UserId);
        bool GetUserRoleByUsername(string username);
        bool ValidateUser(string username, string password, out bool isAdmin, out int id);
    }
}
