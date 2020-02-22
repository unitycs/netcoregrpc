using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.IO;
using Google.Protobuf;

namespace GrpcService
{
    public class StreamContentService:StreamContent.StreamContentBase
    {

        private readonly ILogger<StreamContentService> _logger;
        public StreamContentService(ILogger<StreamContentService> logger)
        {
            _logger = logger;
        }


        public override Task GetStreamContent(StreamRequest request, IServerStreamWriter<StreamReplyContent> responseStream, ServerCallContext context)
        {
            return Task.Run(async () =>
            {
                using var fs = File.Open(request.FileName, FileMode.Open);
                var remainingLength = fs.Length; // 剩余长度
                var buff = new byte[1048576]; // 缓冲区，这里我们设置为 1 Mb
                while (remainingLength > 0) // 若未读完则继续读取
                {
                    var len = await fs.ReadAsync(buff); // 异步从文件中读取数据到缓冲区中
                    remainingLength -= len; // 剩余长度减去刚才实际读取的长度

                    // 向流中写入我们刚刚读取的数据
                    await responseStream.WriteAsync(new StreamReplyContent
                    {
                        Content = ByteString.CopyFrom(buff, 0, len)
                    });
                }
            });
        }

    }
}
