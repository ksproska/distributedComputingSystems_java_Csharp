using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using WcfServiceClient2.ServiceReference1;
//using WcfServiceClient2.ServiceReference2;

namespace WcfServiceClient2
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None
        //, SessionMode = SessionMode.Required
        //, CallbackContract = typeof(IMoviesCallback)
        )
        ]
    public interface IMovieHandler
    {
        //[OperationContract(IsOneWay = true)]
        //void getMovies(String title);
        [OperationContract(IsOneWay = true)]
        void add(ServiceReference1.Movie movie);
        [OperationContract]
        void removeAll(String title);
    }

    //[ServiceContract(ProtectionLevel = ProtectionLevel.None
    //    , SessionMode = SessionMode.Required
    //    , CallbackContract = typeof(IMoviesCallback)
    //    )
    //    ]
    //public interface IMovieHandlerCallback
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void getMovies(String title);
    //}


    //public interface IMoviesCallback
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void getMoviesResult(List<ServiceReference2.Movie> result);
    //}

}
