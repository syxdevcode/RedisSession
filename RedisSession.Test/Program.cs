using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisSession.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RedisClient("192.168.137.133", 6379);
            client.Set<string>("name", "test1");
        }
    }
}
