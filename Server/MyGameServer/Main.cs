using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using ExitGames.Logging;
using System.IO;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Common;
using MyGameServer.Handler;

namespace MyGameServer {
    public class Main:ApplicationBase {

        public static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public static Main Instance {
            get;
            private set;
        }

        //定义个字典，用于存储所有handler
        Dictionary<ResponseCode, BaseHandler> handlerDict = new Dictionary<ResponseCode, BaseHandler>();

        public Dictionary<ResponseCode, BaseHandler> HandlerDict {
            get { return handlerDict; }
            set { handlerDict = value; }
        }

        //当有客户端请求使调用，返回一个PeerBase对象
        protected override PeerBase CreatePeer(InitRequest initRequest) {
            log.Info("客户端连接");
            
            return new ClientPeer(initRequest);
        }
        
        //服务器开启时调用
        protected override void Setup() {
            //使用单例模式
            Instance = this;
            initHandler();
            initLog();

            log.Info("Setup completed");
        }

        //服务器关闭时调用
        protected override void TearDown() {
            
        }

        private void initLog() {
            //设置MyGame.Server.Log文件的输出路径
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(
               Path.Combine(this.ApplicationRootPath, "bin_Win64"), "log");

            //进行log的初始化
            //读取log4net.config.xml文件
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));

            if (configFileInfo.Exists) {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(configFileInfo);
            }
        }

        //初始化Handler
        private void initHandler() {
            LoginHandler loginHandler = new LoginHandler();
            handlerDict.Add(loginHandler.RpCode,loginHandler);

            RegistHandler registHandler = new RegistHandler();
            handlerDict.Add(registHandler.RpCode, registHandler);

            DefaultHandler defaultHandler = new DefaultHandler();
            handlerDict.Add(defaultHandler.RpCode,defaultHandler);

        }

    }
}
