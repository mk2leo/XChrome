﻿#region copyright
/**
// --------------------------------------------------------------------------------
// 文件名：Config.cs
// 作者：刹那 https://x.com/chanawudi
// 公司：https://x.com/chanawudi
// 更新日期：2025，2，27，13:55
// 版权所有 © Your Company. 保留所有权利。
// --------------------------------------------------------------------------------
*/
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using XChrome.cs.db;

namespace XChrome.cs
{
    public class Config
    {
        /// <summary>
        /// 数据存储位置
        /// </summary>
        public static string chrome_data_path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "chrome_data");
        /// <summary>
        /// 本地安装的唯一标识
        /// </summary>
        public static string userid = "";
        /// <summary>
        /// 启动页
        /// </summary>
        public static string chrome_start_page = "https://web3tool.vip/browser/";
        /// <summary>
        /// 社群页面
        /// </summary>
        /// <returns></returns>
        public static string community_url = "http://web3tool.vip/xchrome/community";

        /// <summary>
        /// github
        /// </summary>
        public static string github_url = "http://web3tool.vip/xchrome/github";

        /// <summary>
        /// 自定义chrome路径
        /// </summary>
        public static string chrome_path = "";

        /// <summary>
        /// socks5转发本地服务端口，如果占用，会自动加1启动
        /// </summary>
        public static int ProxySocks5Server_Port = 10666;
        public static async Task ini()
        {
            if (!System.IO.Path.Exists(chrome_data_path)) { Directory.CreateDirectory(chrome_data_path); }
            var db = MyDb.DB;
            userid=await db.Queryable<cs.db.Config>().Where(it => it.key == "userid").Select(it => it.val).FirstAsync();
            var cp = await db.Queryable<cs.db.Config>().Where(it => it.key == "chromePath").FirstAsync();
            if (cp != null)
            {
                chrome_path = cp.val.Trim();
            }
            

            db.Close();
        }
    }
}
