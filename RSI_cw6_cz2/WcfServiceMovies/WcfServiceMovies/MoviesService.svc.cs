using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMovies
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MoviesService : IMoviesService
    {
        private static List<Movie> movies_list = new List<Movie>() {
            new Movie {Id = 100, Title = "Echoman", Length = 90, Director = "Name1"},
            new Movie {Id = 101, Title = "Ekstradycja", Length = 90, Director = "Name1"},
            new Movie {Id = 102, Title = "Project Riese", Length = 90, Director = "Name1"}
        };

        public string addXml(Movie item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = item.Id;
            int idx = movies_list.FindIndex(b => b.Id == newIdx);
            if (idx == -1)
            {
                item.Id = newIdx;
                movies_list.Add(item);
                return "Added item with ID=" + item.Id;
            }
            else
                return "Id already exists ID=" + item.Id;
        }

        public string deleteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return "No item with ID=" + Id;
            movies_list.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<Movie> getAllXml()
        {
            return movies_list;
        }

        public Movie getByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return movies_list.ElementAt(idx);
        }

        string IMoviesService.addJson(Movie item)
        {
            return addXml(item);
        }

        string IMoviesService.deleteJson(string Id)
        {
            return deleteXml(Id);
        }

        List<Movie> IMoviesService.getAllJson()
        {
            return getAllXml();
        }

        Movie IMoviesService.getByIdJson(string Id)
        {
            return getByIdXml(Id);
        }
    }
}
