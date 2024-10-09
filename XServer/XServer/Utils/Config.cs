using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XServer.Utils {
    internal class Config : Singleton<Config> {
        private ILog log = LogManager.GetLogger("Config");
        private IConfiguration config;
        public void Init() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // 设置配置文件所在目录
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            config = builder.Build();

            log.Info("配置加载完成");
        }

        public string GetStr(string key) {
            return config[key];
        }

        public int GetInt(string key) {
            return int.Parse(config[key]);
        }
        
    }
}
