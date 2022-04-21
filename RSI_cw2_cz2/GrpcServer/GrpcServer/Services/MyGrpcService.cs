using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class MyGrpcService : GrpcService.GrpcServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public MyGrpcService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<GrpcResponse> GrpcProc(GrpcRequest request, ServerCallContext context)
        {
            string msg;
            int val;
            val = request.Age * 365;
            msg = "Hello " + request.Name + " being " + request.Age + " years old.";
            return Task.FromResult(new GrpcResponse { Message = msg, Days = val });
        }
    }
}
