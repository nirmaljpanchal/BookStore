using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.ViewModel
{
    public class BookViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public byte[] Cover { get; set; }
        public decimal Price { get; set; }
    }
}
