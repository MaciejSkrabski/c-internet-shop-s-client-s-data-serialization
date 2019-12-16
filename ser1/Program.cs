using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace ser1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean loop = true;
            while (loop)
            { 
                Console.WriteLine("How many users to add?");
                String numOfUsers = Console.ReadLine();
                if (int.TryParse(numOfUsers, out int number))
                {
                    loop = false;
                    List<User> users = new List<User>();
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Insert Client's full name: ");
                        string n = Console.ReadLine();
                        Console.WriteLine("Insert Client's address: ");
                        string a = Console.ReadLine();
                        User u = new User
                        {
                            Name = n,
                            Address = a
                        };
                        users.Add(u);
                        
                    }
                    XmlSerializer serializer = new XmlSerializer(users.GetType(), new XmlRootAttribute("users"));
                    StreamWriter writer = new StreamWriter("Users.xml");
                    serializer.Serialize(writer.BaseStream, users);


                    /*foreach (User u in users)
                    {
                        Console.WriteLine(u.ID + ", " + u.Name + ", " + u.Address);
                        u.WriteXML("haba");
                    }*/




                }
                else
                {
                    Console.WriteLine("WRONG INPUT");
                }


            }
        Console.ReadKey();
            
        }
    }
}
