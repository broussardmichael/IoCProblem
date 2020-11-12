//Step 3 - Dependency Injection (DI) is a design pattern used to implement IoC. It allows the creation of dependent objects outside
//of a class and provides those objects to a class through different ways

//The Problem The problem with the above example is that we used DataAccessFactory inside the CustomerBusinessLogic class. So, suppose there is another implementation of
//ICustomerDataAccess and we want to use that new class inside CustomerBusinessLogic.
//Then, we need to change the source code of the CustomerBusinessLogic class as well

//Solution - We're going to use Dependecy Injection using Constructor injection.
//Create an injector service called CustomerService. The class will both create and injection customer data access, eliminating the need for the factory method.

using System;
namespace IoC
{
    public class step3
    {
        public interface ICustomerDataAccess
        {
            public string GetCustomerName(int id);
        }

        public class CustomerDataAccess : ICustomerDataAccess
        {
            public CustomerDataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Dummy Customer Name"; // get it from DB in real app
            }
        }

        public class OldCustomerDataAccess : ICustomerDataAccess
        {
            public OldCustomerDataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Old Style Customer"; // get it from DB in real app
            }
        }

        public class CustomerService
        {
            CustomerBusinessLogic _customerBusinessLogic;
            public CustomerService()
            {
                _customerBusinessLogic = new CustomerBusinessLogic(new CustomerDataAccess());
            }
            public CustomerService(ICustomerDataAccess dataAccess)
            {
                _customerBusinessLogic = new CustomerBusinessLogic(dataAccess);
            }

            public string GetCustomerName(int id)
            {
                return _customerBusinessLogic.GetCustomerName(id);
            }
        }

        public class CustomerBusinessLogic
        {
            private ICustomerDataAccess _dataAccess;

            public CustomerBusinessLogic(ICustomerDataAccess dataAccess)
            {
                _dataAccess = dataAccess;
            }

            public string GetCustomerName(int id)
            {
                return _dataAccess.GetCustomerName(id);
            }
        }
    }
}
