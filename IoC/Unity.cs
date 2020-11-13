using System;
using Unity;

namespace IoC
{
    public class Unity
    {
        class Program
        {
            public class CustomerService
            {
                CustomerBusinessLogic _logic;

                public CustomerService()
                {
                    _logic = new CustomerBusinessLogic(new DataAccess());
                }

                public CustomerService(IDataAccess dataAccess)
                {
                    _logic = new CustomerBusinessLogic(dataAccess);
                }

                public string GetCustomerName(int id)
                {
                    return _logic.GetCustomerName(id);
                }
            }

            public interface IDataAccess
            {
                public string GetCustomerName(int id);
            }

            public class CustomerBusinessLogic
            {
                IDataAccess _dataAccess;

                public CustomerBusinessLogic(IDataAccess dataAccess)
                {
                    _dataAccess = dataAccess;
                }

                public string GetCustomerName(int id)
                {
                    return _dataAccess.GetCustomerName(id);
                }
            }

            public class DataAccess : IDataAccess
            {
                public DataAccess() { }

                public string GetCustomerName(int id)
                {
                    return "Dummy Customer Name"; // get it from DB in real app
                }
            }

            public class MoqDataAccess : IDataAccess
            {
                public MoqDataAccess() { }

                public string GetCustomerName(int id)
                {
                    return "MOQ Customer Name"; // get it from DB in real app
                }
            }
        }
        static void Main(string[] args)
        {

           
        }
    }
}
