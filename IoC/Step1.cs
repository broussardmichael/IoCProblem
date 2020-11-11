//First Step - in TheProblem CustomerBusinessLogic is dependent on the class DataAccess. It's expecting GetCustomerName, accepting one parameter, and will need to change if DataAccess
//changes or if a different type of DataAccess is needed.
//There may be other classes that create DataAccess in this way. If the name changes, you have to find every place that uses it and update it.
//Since it's creating an object from the concrete DataAccess class, it can't be tested.

using System;

namespace Step1
{
    class Program
    {
        
    }
}
