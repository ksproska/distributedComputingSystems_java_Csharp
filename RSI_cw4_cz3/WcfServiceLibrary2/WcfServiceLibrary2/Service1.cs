using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace WcfServiceLibrary2
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession,
                  ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MovieHandlerCallback : IMovieHandlerCallback
    {
        IMoviesCallback callback = null;
        public MovieHandlerCallback()
        {
            callback = OperationContext.Current.GetCallbackChannel
                       <IMoviesCallback>();
        }
        void IMovieHandlerCallback.getMovies(string title)
        {
            Console.WriteLine($"Getting movies with title {title}...");
            Thread.Sleep(10);
            callback.getMoviesResult(MovieHandler.movies.Where(x => x.title == title).ToList());
            Console.WriteLine("...movies collected.");
        }
    }

    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession,
                  ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MovieHandler : IMovieHandler
    {
        public static List<Movie> movies = new List<Movie>();
        void IMovieHandler.add(Movie movie)
        {
            Console.WriteLine($"Adding movie {movie.Description}...");
            Thread.Sleep(10);
            movies.Add(movie);
            Console.WriteLine("...movie added.");
        }

        void IMovieHandler.removeAll(string title)
        {
            Console.WriteLine($"Removieng movies with title {title}...");
            Thread.Sleep(10);
            movies = movies.Where(x => x.title != title).ToList();
            Console.WriteLine("...movies removed.");
        }
    }

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
    //              ConcurrencyMode = ConcurrencyMode.Multiple)]
    //public class BookHandler : IBookHandler
    //{
    //    IBooksCallback callback = null;
    //    public BookHandler()
    //    {
    //        callback = OperationContext.Current.GetCallbackChannel
    //                   <IBooksCallback>();
    //    }
    //    private static List<Book> books = new List<Book>();
    //    void IBookHandler.add(Book book)
    //    {
    //        books.Add(book);
    //    }

    //    void IBookHandler.getBooksOfAuthor(string author)
    //    {
    //        callback.getBooksOfAuthorResult(books.Where(x => x.author == author).ToList());
    //    }

    //    void IBookHandler.removeAll(string title)
    //    {
    //        books = books.Where(x => x.title == title).ToList();
    //    }
    //}
}
