using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ser1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> users = new List<User>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Insert Client's full name: ");
                string n = Console.ReadLine();
                Console.WriteLine("Insert Client's address: ");
                string a = Console.ReadLine();
                User u = new User();
                u.Name = n;
                u.Address = a;
                users.Add(u);

            }

            foreach (User u in users)
            {
                Console.WriteLine(u.ID + ", " + u.Name + ", " + u.Address);
                u.WriteXML("userlist");
            }
            Console.ReadKey();
        }
    }
}
