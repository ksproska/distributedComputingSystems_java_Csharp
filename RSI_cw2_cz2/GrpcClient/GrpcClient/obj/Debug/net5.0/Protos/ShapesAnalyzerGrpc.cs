// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/shapesAnalyzer.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcClient {
  public static partial class ShapesAnalyzer
  {
    static readonly string __ServiceName = "shapesAnalyzer.ShapesAnalyzer";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcClient.TriangleSides> __Marshaller_shapesAnalyzer_TriangleSides = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcClient.TriangleSides.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcClient.Surface> __Marshaller_shapesAnalyzer_Surface = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcClient.Surface.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcClient.IsRightAngle> __Marshaller_shapesAnalyzer_IsRightAngle = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcClient.IsRightAngle.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcClient.IsIsosceles> __Marshaller_shapesAnalyzer_IsIsosceles = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcClient.IsIsosceles.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.Surface> __Method_GetTriangleSurface = new grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.Surface>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTriangleSurface",
        __Marshaller_shapesAnalyzer_TriangleSides,
        __Marshaller_shapesAnalyzer_Surface);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.IsRightAngle> __Method_IsTriangleRightAngle = new grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.IsRightAngle>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IsTriangleRightAngle",
        __Marshaller_shapesAnalyzer_TriangleSides,
        __Marshaller_shapesAnalyzer_IsRightAngle);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.IsIsosceles> __Method_IsTriangleIsosceles = new grpc::Method<global::GrpcClient.TriangleSides, global::GrpcClient.IsIsosceles>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IsTriangleIsosceles",
        __Marshaller_shapesAnalyzer_TriangleSides,
        __Marshaller_shapesAnalyzer_IsIsosceles);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcClient.ShapesAnalyzerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ShapesAnalyzer</summary>
    public partial class ShapesAnalyzerClient : grpc::ClientBase<ShapesAnalyzerClient>
    {
      /// <summary>Creates a new client for ShapesAnalyzer</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ShapesAnalyzerClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ShapesAnalyzer that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ShapesAnalyzerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ShapesAnalyzerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ShapesAnalyzerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.Surface GetTriangleSurface(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTriangleSurface(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.Surface GetTriangleSurface(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetTriangleSurface, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.Surface> GetTriangleSurfaceAsync(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTriangleSurfaceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.Surface> GetTriangleSurfaceAsync(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetTriangleSurface, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.IsRightAngle IsTriangleRightAngle(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsTriangleRightAngle(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.IsRightAngle IsTriangleRightAngle(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IsTriangleRightAngle, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.IsRightAngle> IsTriangleRightAngleAsync(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsTriangleRightAngleAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.IsRightAngle> IsTriangleRightAngleAsync(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IsTriangleRightAngle, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.IsIsosceles IsTriangleIsosceles(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsTriangleIsosceles(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcClient.IsIsosceles IsTriangleIsosceles(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IsTriangleIsosceles, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.IsIsosceles> IsTriangleIsoscelesAsync(global::GrpcClient.TriangleSides request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsTriangleIsoscelesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcClient.IsIsosceles> IsTriangleIsoscelesAsync(global::GrpcClient.TriangleSides request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IsTriangleIsosceles, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ShapesAnalyzerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ShapesAnalyzerClient(configuration);
      }
    }

  }
}
#endregion