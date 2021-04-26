using System;

namespace Model
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public byte[] Cover { get; set; }
        public decimal Price { get; set; }
    }
}
