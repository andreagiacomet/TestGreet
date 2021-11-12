using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGreet
{
    public interface IGreetHello
    {
        string Greet(params string[] names);
    }
}
