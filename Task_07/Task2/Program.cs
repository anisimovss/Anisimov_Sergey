using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person s1 = new Person();
            Person s2 = new Person();
            Person s3 = new Person();
            EventCame c1 = new EventCame(s1.GreetingEmp);
            EventCame c2 = new EventCame(s2.GreetingEmp);
            EventCame c3 = new EventCame(s3.GreetingEmp);
            //EventCame c = c1 + c2 + c3;
            s1.Came += new EventCame(s1.GreetingEmp);
        }

        private static void S1_Came1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void S1_Came(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        delegate void EventCame(Person emp, int time);

        delegate void EventGone(Person emp);

        delegate void EvCame(Person emp, EventArgs e);

    }
}
