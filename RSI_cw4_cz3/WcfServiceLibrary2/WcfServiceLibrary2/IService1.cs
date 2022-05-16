using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace WcfServiceLibrary2
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
        void add(Movie movie);
        [OperationContract]
        void removeAll(String title);
    }

    [ServiceContract(ProtectionLevel = ProtectionLevel.None
        , SessionMode = SessionMode.Required
        , CallbackContract = typeof(IMoviesCallback)
        )
        ]
    public interface IMovieHandlerCallback
    {
        [OperationContract(IsOneWay = true)]
        void getMovies(String title);
    }

    //[ServiceContract(ProtectionLevel = ProtectionLevel.None,
    //    SessionMode = SessionMode.Required,
    //           CallbackContract = typeof(IBooksCallback))]
    //public interface IBookHandler
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void getBooksOfAuthor(String author);
    //    [OperationContract(IsOneWay = true)]
    //    void add(Book book);
    //    [OperationContract]
    //    void removeAll(String title);
    //}

    public interface IMoviesCallback
    {
        [OperationContract(IsOneWay = true)]
        void getMoviesResult(List<Movie> result);
    }
    //public interface IBooksCallback
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void getBooksOfAuthorResult(List<Book> result);
    //}

    [DataContract]
    public class Movie
    {
        [DataMember]
        public String title { get; set; }
        [DataMember]
        public int length { get; set; }
        [DataMember]
        public string Description
        {
            get { return $"{title} - {length}"; }
        }
        public Movie(String title, int length)
        {
            this.title = title;
            this.length = length;
        }
    }

    //[DataContract]
    //public class Book
    //{
    //    [DataMember]
    //    public String title { get; set; }
    //    [DataMember]
    //    public String author { get; set; }
    //    [DataMember]
    //    public string Description
    //    {
    //        get { return $"{title} - {author}"; }
    //    }
    //    public Book(String title, String author)
    //    {
    //        this.title = title;
    //        this.author = author;
    //    }
    //}
}
