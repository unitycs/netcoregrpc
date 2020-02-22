using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGRPC.GrpcServices
{
    public class SuckCatService:SuckCatSession.SuckCatSessionBase
    {

        private static readonly List<string> Cats = new List<string>() { "英短银渐层", "英短金渐层", "美短", "蓝猫", "狸花猫", "橘猫" };
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);

        public override Task<SuckingReply> SuckingaCats(SuckingCatRequest request, ServerCallContext context)
        {
            //  return base.SuckingaCats(request, context);

            return Task.FromResult(new SuckingReply()
            {
                Message = $"Congratulations! You Sucked a {Cats[Rand.Next(0, Cats.Count)]}",
            });
        }

    }
}
