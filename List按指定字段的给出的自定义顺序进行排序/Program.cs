using System;
using System.Collections.Generic;
using System.Linq;

namespace List按指定字段的给出的自定义顺序进行排序
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Foo> foos = new List<Foo> {
                new Foo { Id = 1, Name = "b" },
                new Foo { Id = 2, Name = "a" }, 
                new Foo { Id = 3, Name = "A" },
                new Foo { Id = 4, Name = "B" } 
            };
            int[] orderArr = new int[] { 4, 2, 3, 1 };
            foos = foos.OrderBy(e =>
            {
                var index = 0;
                index = Array.IndexOf(orderArr, e.Id);
                if (index != -1) { return index; }
                else
                {
                    return int.MaxValue;
                }

            }).ToList();

            foos.ForEach(p =>
            {
                Console.WriteLine(string.Format("Id:{0},Name:{1}", p.Id, p.Name));
            });
        }
        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
