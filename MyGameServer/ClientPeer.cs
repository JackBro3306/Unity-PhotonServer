using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using MyGameServer.Manager;
using MyGameServer.Model;
using Common;
using Common.Tools;
using MyGameServer.Handler;

namespace MyGameServer {
    public class ClientPeer : Photon.SocketServer.ClientPeer{
        

        public ClientPeer(InitRequest initRequest):base(initRequest) {
           
        }

        //当客户端断开连接时调用
        protected override void OnDisconnect(PhotonHostRuntimeInterfaces.DisconnectReason reasonCode, string reasonDetail) {
            Main.log.Info("客户端断开连接");
        }

        //当客户端成功连接服务器时调用

        protected override void OnOperationRequest(Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters) {
            //通过opcode获得处理的handler，如果找不到，则使用默认的Handler
            BaseHandler baseHandler = DictTool.GetValue<ResponseCode, BaseHandler>(Main.Instance.HandlerDict,(ResponseCode)operationRequest.OperationCode);
            if (baseHandler != null) {
                baseHandler.OnOperationRequest(operationRequest, sendParameters, this);
            } else {
                DictTool.GetValue<ResponseCode, BaseHandler>(Main.Instance.HandlerDict, (ResponseCode)ResponseCode.Default)
                    .OnOperationRequest(operationRequest, sendParameters, this);
                
            }
        }
    }
}
