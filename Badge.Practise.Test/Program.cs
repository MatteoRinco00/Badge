using Badge.EF.Entity;
using System.Text;
using System;
using System.Collections.Generic;

namespace Badge.Practise.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Person persona1 = new Person();
            Person persona2 = new Person();
            Swipe swipepersona1 = new Swipe();
            Swipe swipepersona2 = new Swipe();
            Machine machinepersona1 = new Machine();
            Machine machinepersona2 = new Machine();
            persona1.nome();
            persona2.nome();
            swipepersona1.infoswipe();
            swipepersona2.infoswipe();
            machinepersona1.infomachine();
            machinepersona2.infomachine();
            Console.ReadKey();

        }
    }
}