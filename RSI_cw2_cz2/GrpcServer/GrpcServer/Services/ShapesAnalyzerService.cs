using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class ShapesAnalyzerService : ShapesAnalyzer.ShapesAnalyzerBase
    {
        private readonly ILogger<ShapesAnalyzerService> _logger;
        public ShapesAnalyzerService(ILogger<ShapesAnalyzerService> logger)
        {
            _logger = logger;
        }

        public override Task<Surface> GetTriangleSurface(TriangleSides request, ServerCallContext context)
        {
            double p = (request.A + request.B + request.C) / 2;
            double multiplied = p * Math.Abs(p - request.A) * Math.Abs(p - request.B) * Math.Abs(p - request.C);
            double size = Math.Sqrt(multiplied);
            //Console.WriteLine(multiplied);
            //Console.WriteLine(size);
            return Task.FromResult(new Surface
            {
                Size = size
            });
        }
    }
}
