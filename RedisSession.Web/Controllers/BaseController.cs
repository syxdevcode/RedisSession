using RedisSession.Web.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSession.Web.Controllers
{
    public class BaseController : Controller
    {
        private RedisSessionBase redisSession;

        /// <summary>
        /// RedisSession
        /// </summary>
        public RedisSessionBase RedisSession
        {
            get
            {
                if (redisSession == null)
                {
                    redisSession = new RedisSessionBase(HttpContext, true, 20);
                }
                return redisSession;
            }
        }

    }
}