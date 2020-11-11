////Convert TheProblem to a loosely coupled using IoC

using System;

namespace TheProblem
{
    class Program
    {
        public class CustomerBusinessLogic
        {
            DataAccess _dataAccess;

            public CustomerBusinessLogic()
            {
                _dataAccess = new DataAccess();
            }

            public string GetCustomerName(int id)
            {
                return _dataAccess.GetCustomerName(id);
            }
        }

        public class DataAccess
        {
            public DataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Dummy Customer Name"; // get it from DB in real app
            }
        }
    }
}
