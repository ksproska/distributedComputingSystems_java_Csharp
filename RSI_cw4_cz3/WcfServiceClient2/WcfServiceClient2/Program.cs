using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient2.ServiceReference1;
//using WcfServiceClient2.ServiceReference2;

namespace WcfServiceClient2
{
    class Program
    {
        //class MovieCallback : IMoviesCallback
        //{
        //    void IMoviesCallback.getMoviesResult(List<ServiceReference2.Movie> result)
        //    {
        //        Console.WriteLine($"Returned {result.Count} values");
        //        foreach (var movie in result)
        //        {
        //            Console.WriteLine(movie.title);
        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            var moviesAsyncClient = new ServiceReference1.MovieHandlerClient("WSHttpBinding_IMovieHandler");
            //IMoviesCallback moviesCallback = new MovieCallback();
            //InstanceContext instanceContext = new InstanceContext(moviesCallback);
            //MovieHandlerCallbackClient moviesCallbackClient = new MovieHandlerCallbackClient(instanceContext);
            var movie = new ServiceReference1.Movie();
            movie.title = "Avatar";
            movie.length = 230;
            moviesAsyncClient.add(movie);
            movie = new ServiceReference1.Movie();
            movie.title = "Avatar 2";
            movie.length = 230;
            moviesAsyncClient.add(movie);
            //moviesCallbackClient.getMovies("Avatar");
            //moviesAsyncClient.removeAll("Avatar");
            //moviesAsyncClient.add(movie);
            //moviesAsyncClient.add(movie);
            Console.WriteLine("finished");
            Console.Read();
        }
    }
}
