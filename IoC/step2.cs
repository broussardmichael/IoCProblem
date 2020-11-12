//Second Step - Utilize Dependency Inversion Principle to further us along our path to loosely coupled classes
//Problem - CustomerBusinessLogic still depends on the concrete DataAccess class even though we've moved object creation to the factory class.
//In DIP, high level modules should not depend on low level modules and
//Abstractions should not depend on details. Details should depend on abstractions.

//Solution - Both the High level BusinessLogic and Dataccess should depend on abstractions.
//CustomerBusinessLogic oes not depend on the concrete DataAccess class, instead it includes a reference of the ICustomerDataAccess interface.
//So now, we can easily use another class which implements ICustomerDataAccess with a different implementation as shown below.

using System;
namespace IoC
{
    public class step2
    {
        class Program
        {
            public class DataAccessFactory
            {
                public static ICustomerDataAccess createCustomerDataAccess()
                {
                    return new CustomerDataAccess();
                }

                public static ICustomerDataAccess createOldCustomerDataAccess()
                {
                    return new OldCustomerDataAccess();
                }

            }

            public class CustomerBusinessLogic
            {
                private ICustomerDataAccess _dataAccess;
                private ICustomerDataAccess _oldDataAccess;

                public CustomerBusinessLogic()
                {
                    _dataAccess = DataAccessFactory.createCustomerDataAccess();
                    _oldDataAccess = DataAccessFactory.createOldCustomerDataAccess();
                }

                public string GetCustomerName(int id)
                {
                    return _dataAccess.GetCustomerName(id);
                }

                public string GetOldCustomerName(int id)
                {
                    return _oldDataAccess.GetCustomerName(id);
                }
            }

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
        }
    }
}
