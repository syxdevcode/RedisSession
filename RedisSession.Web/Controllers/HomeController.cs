using RedisSession.Web.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSession.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //会往主服务里面写入
            var b = RedisBase.Hash_Set<string>("PooledRedisClientManager", "one", "123");

            //从服务里面读取信息
            var str = RedisBase.Hash_Get<string>("PooledRedisClientManager", "one");

            return View();
        }
    }
}