using System;

namespace Obuci.me.Data
{
    public class Artikl
    {
        public Artikl() { }

        public int ID { get; set; }
        public string ImeAritkla { get; set; }
        public string Velicina { get; set; }
        public Kategorija Kategorija { get; set; } 
        public double Cijena { get; set; }

        public int GenerišiID()
        {
            int id = 0;
            Random generator = new Random();
            for (int i = 0; i < 10; i++)
            {
                id += (int)Math.Pow(10, i) * generator.Next(0, 9);
            }
            return id;
        }

    }
}
