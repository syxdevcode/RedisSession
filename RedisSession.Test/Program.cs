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
            //初始化RedisClient对象
            var client = new RedisClient("192.168.137.133", 6385);

            #region  String 类型
            //var b = client.Set<string>("name", "test1");
            //string userName = client.Get<string>("name");
            //Console.WriteLine(userName);

            ////访问次数
            //client.Set<int>("IpAcceseeCount", 0);
            //client.Incr("IpAccessCount");
            //Console.WriteLine(client.Get<int>("IpAccessCount"));
            #endregion

            #region Hash
            //string hashId = "userInfoId";
            //client.SetEntryInHash(hashId, "name", "test1");
            //client.SetEntryInHash(hashId, "name2", "test2");
            //client.SetEntryInHash(hashId, "name3", "test3");
            //client.SetEntryInHash(hashId, "name4", "test4");
            //client.GetHashKeys(hashId).ForEach(e => Console.WriteLine(e));
            //client.GetHashValues(hashId).ForEach(e => Console.WriteLine(e));
            #endregion

            #region List类型
            //string listId = "userInfoId1";
            //client.AddItemToList(listId, "123");
            //client.AddItemToList(listId, "1234");

            //Console.WriteLine("List数据项条数：" + client.GetListCount(listId));
            //Console.WriteLine("List数据项第一条数据" + client.GetItemFromList(listId, 0));

            //Console.WriteLine("获取所有List数据");
            //client.GetAllItemsFromList(listId).ForEach(e => Console.WriteLine(e));

            //#region List类型作为队列和栈使用
            //Console.WriteLine("List数量" + client.GetListCount(listId));

            ////队列先进先出
            ////Console.WriteLine(client.DequeueItemFromList(listId));
            ////Console.WriteLine(client.DequeueItemFromList(listId));

            ////栈后进先出
            //Console.WriteLine("出栈" + client.PopItemFromList(listId));
            //Console.WriteLine("出栈" + client.PopItemFromList(listId));

            //#endregion
            #endregion

            #region Set 集合
            /*
            client.AddItemToSet("A", "B");
            client.AddItemToSet("A", "C");
            client.AddItemToSet("A", "D");
            client.AddItemToSet("A", "E");
            client.AddItemToSet("A", "F");

            client.AddItemToSet("B", "C");
            client.AddItemToSet("B", "F");
            //求差集
            Console.WriteLine("A,B集合差集");
            client.GetDifferencesFromSet("A", "B").ToList<string>().ForEach(e => Console.WriteLine(e + ","));

            //求集合交集
            Console.WriteLine("\nA,B集合交集");
            client.GetIntersectFromSets(new string[] { "A", "B" }).ToList<string>().ForEach(e => Console.WriteLine(e));

            //求集合合并
            Console.WriteLine("\nA,B集合并集");
            client.GetUnionFromSets(new string[] { "A", "B" }).ToList<string>().ForEach(e => Console.WriteLine(e));

            */
            #endregion

            #region Sort Set集合
            client.AddItemToSortedSet("SA", "B", 2);
            client.AddItemToSortedSet("SA", "C", 1);
            client.AddItemToSortedSet("SA", "D", 5);
            client.AddItemToSortedSet("SA", "E", 3);
            client.AddItemToSortedSet("SA", "F", 4);

            //有序集合降序排列
            Console.WriteLine("\n有序集合降序排列");
            client.GetAllItemsFromSortedSetDesc("SA").ForEach(e => Console.WriteLine(e));
            Console.WriteLine("\n有序集合升序排列");
            client.GetAllItemsFromSortedSet("SA").ForEach(e => Console.WriteLine(e));
            client.AddItemToSortedSet("SB", "C", 2);
            client.AddItemToSortedSet("SB", "F", 1);
            client.AddItemToSortedSet("SB", "D", 3);
            Console.WriteLine("\n获得某个值在有序集合中的排名，按照分数的排序排列");

            Console.WriteLine(client.GetItemIndexInSortedSet("SB", "D"));

            Console.WriteLine("\n获取有序集合中某个分数值");
            Console.WriteLine(client.GetItemScoreInSortedSet("SB", "D"));
            Console.WriteLine("\n获得有序集合中，某个排名范围的所有值");
            client.GetRangeFromSortedSet("SA", 0, 3).ForEach(o => Console.WriteLine(o));

            #endregion

            Console.ReadKey();
        }
    }
}
