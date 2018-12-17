using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Tools;
using MyGameServer.Model;
using MyGameServer.Manager;

namespace MyGameServer.Handler {
    public class RegistHandler:BaseHandler{

        public RegistHandler() {
            RpCode = ResponseCode.Regist;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer) {
            //获得传递过来的参数，通过ParameterCode获得参数
            string username = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters,(byte)ParameterCode.Username);
            string password = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Password);

            //使用Manager进行数据库的操作
            IUserInfoManager userManager = new UserInfoManager();

            UserInfo userinfo = new UserInfo() {Username=username,Password=password,RegistDate=DateTime.Now };
            //添加用户
            bool result = userManager.Add(userinfo);

            //响应客户端
            Dictionary<byte, object> respData = new Dictionary<byte, object>();
            respData.Add((byte)ParameterCode.RegistResult, result);

            OperationResponse op = new OperationResponse(operationRequest.OperationCode,respData);
            clientPeer.SendOperationResponse(op,sendParameters);


        }

    }
}
