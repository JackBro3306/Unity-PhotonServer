using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;

namespace MyGameServer.Handler {
    public abstract class BaseHandler {
        public ResponseCode RpCode;

        public abstract void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters,ClientPeer clientPeer);
    }
}
