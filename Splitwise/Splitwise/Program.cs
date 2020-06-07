using Splitwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize 4 users
            List<User> userList = new List<User>();

            userList.Add(new User("Apoorv","abcd@g.com",9811454764));
            userList.Add(new User("Dixit", "abcd@g.com", 9334433764));
            userList.Add(new User("Vaibhav", "abcd@g.com", 9811451111));
            userList.Add(new User("Dhyani", "abcd@g.com", 9811452222));

            Operations split = new Operations();
            while (true)
            {
                Console.WriteLine("Welcome to Splitwise. Type exit to close application or record your transactions.");
                var input = Console.ReadLine();
                if (input.ToUpper() != "EXIT")
                {

                    var result = split.PerformOperation(input,userList);
                    foreach(var output in result)
                        Console.WriteLine(result);
                }
                else 
                {
                    break;
                }
            }
        }
        
    }

    
}
