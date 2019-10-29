using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMoviesViewModel
    {
        public Movies Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}