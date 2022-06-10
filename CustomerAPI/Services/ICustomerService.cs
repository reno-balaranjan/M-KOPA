using CustomerAPI.Models;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        /// <summary>
        ///     Create User
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool CreateUser(Customer customer);

        /// <summary>
        ///     Update User
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool UpdateUser(Customer customer);

        /// <summary>
        ///     Delete User
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        bool DeleteUser(Int64 idNumber);

        /// <summary>
        /// List Of Customers
        /// </summary>
        List<Customer> Customers
        {
            get;
            set;
        }
    }
}
