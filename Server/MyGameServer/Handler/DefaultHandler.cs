using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
namespace MyGameServer.Handler {
    
    public class DefaultHandler:BaseHandler {

        public DefaultHandler() {
            RpCode = Common.ResponseCode.Default;

        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer) {
            
        }
    }
}
