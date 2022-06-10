using CustomerAPI.Models;
using CustomerAPI.Services;


namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customersDataList;

        List<Customer> CustomersDataList
        {
            get => _customersDataList;
            set => _customersDataList = value;
        }
        public CustomerService()
        {
        }
        public bool CreateUser(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            const int count = 0;
            _customersDataList.Add(customer);
            return CustomersDataList.Count == count + 1;
        }

        public bool UpdateUser(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(Int64 idNumber)
        {
            if (idNumber <= 0) throw new ArgumentOutOfRangeException(nameof(idNumber));
            
            var findCustomer = _customersDataList.Find(x => x.IdNumber == idNumber);
            var result = _customersDataList.Remove(findCustomer);

            return result;
        }
        public List<Customer> Customers
        {
            get
            {
                if (_customersDataList != null)
                {
                    return _customersDataList;
                }

                _customersDataList = new List<Customer>();
                return _customersDataList;
            }
            set { _customersDataList = value; }
        }
    }
}
