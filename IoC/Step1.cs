//First Step - in TheProblem CustomerBusinessLogic is dependent on the class DataAccess. It's expecting GetCustomerName, accepting one parameter, and will need to change if DataAccess
//changes or if a different type of DataAccess is needed.
//There may be other classes that create DataAccess in this way. If the name changes, you have to find every place that uses it and update it.
//Since it's creating an object from the concrete DataAccess class, it can't be tested.

//Solution - use a factory method. Instead of creating dataccess in business logic, we'll create a method that isntantiates it. We invert the control of creating an object of the
//dependent class to a factory method.

using System;

namespace Step1
{
    class Program
    {
        public class CustomerBusinessLogic
        {
            private DataAccessFactory _dataAccessFactory = new DataAccessFactory();
            public CustomerBusinessLogic() { }

            public string GetCustomerName(int id)
            {
                DataAccess _dataAccess = _dataAccessFactory.createDataAccessObj();
                return _dataAccess.GetCustomerName(id);
            }
        }

        public class DataAccessFactory
        {
            public DataAccess createDataAccessObj()
            {
                return new DataAccess();
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
