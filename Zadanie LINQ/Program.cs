using System;
using System.Collections.Generic;
using System.Linq;


namespace Zadanie_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listcomp = new List<Computer>()
           {

               new Computer(){Qod = 264856, Marka = "Intel", Processor = "Pentium 4", Chastota = 2400, Memory = 256, HardDisk = 80, Video = 128, Stoimost = 50000, Kolichestvo = 35},
               new Computer(){Qod = 584628, Marka = "Intel", Processor = "Pentium 4", Chastota = 2200, Memory = 256, HardDisk = 80, Video = 64, Stoimost = 40000, Kolichestvo = 25},
               new Computer(){Qod = 879245, Marka = "Intel", Processor = "Pentium 4", Chastota = 2000, Memory = 128, HardDisk = 40, Video = 32, Stoimost = 35000, Kolichestvo = 3},
               new Computer(){Qod = 148526, Marka = "Intel", Processor = "Celeron", Chastota = 1800, Memory = 64, HardDisk = 40, Video = 32, Stoimost = 30000, Kolichestvo = 28},
               new Computer(){Qod = 2910235, Marka = "Intel", Processor = "Celeron", Chastota = 1600, Memory = 32, HardDisk = 20, Video = 16, Stoimost = 20000, Kolichestvo = 44},
               new Computer(){Qod = 234839, Marka = "AMD", Processor = "Athlon", Chastota = 2100, Memory = 256, HardDisk = 120, Video = 64, Stoimost = 50000, Kolichestvo = 31},
               new Computer(){Qod = 970248, Marka = "AMD", Processor = "Athlon", Chastota = 2000, Memory = 256, HardDisk = 80, Video = 64, Stoimost = 45000, Kolichestvo = 12},
               new Computer(){Qod = 309745, Marka = "AMD", Processor = "Athlon", Chastota = 2000, Memory = 128, HardDisk = 80, Video = 32, Stoimost = 40000, Kolichestvo = 26},
               new Computer(){Qod = 974855, Marka = "AMD", Processor = "Athlon", Chastota = 1800, Memory = 128, HardDisk = 40, Video = 16, Stoimost = 38000, Kolichestvo = 4},
               new Computer(){Qod = 166842, Marka = "AMD", Processor = "Athlon", Chastota = 1800, Memory = 64, HardDisk = 40, Video = 16, Stoimost = 20000, Kolichestvo = 1}
           };

            //- все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("Введите тип процессора для вывода компьютеров в наличии");
            string type_proc = Console.ReadLine();
            List<Computer> computer_1 = listcomp
                .Where(c => c.Processor == type_proc)
                .ToList();
            if (computer_1.Count ==0)
            {
                Console.WriteLine("Компьютеров с процессором {0} не существует", type_proc);
            }
            else
            { Console.WriteLine(@"Перечень компьютеров с процессором {0}:", type_proc);
                foreach (Computer c in computer_1)
                {
                    Console.WriteLine($"Код компьютера {c.Qod}, марка компьютера {c.Marka}, частота процессора {c.Chastota},объем оперативной памяти {c.Memory}, жесткого диска {c.HardDisk}, видеокарты {c.Video}, стоимость {c.Stoimost}, в наличии {c.Kolichestvo}");
                }
            }
            Console.ReadKey();

            //- все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            Console.WriteLine("Введите необходимый объем опреативной памяти для вывода компьютеров в наличии");
            int obem_ozu = Convert.ToInt32(Console.ReadLine());
            List<Computer> computer_2 = (from v in listcomp
                                         where v.Memory >= obem_ozu
                                         select v).ToList();
            if (computer_2.Count == 0)
            {
                Console.WriteLine("Компьютеров с объемом ОЗУ не ниже {0} не существует", obem_ozu);
            }
            else
            {
                Console.WriteLine(@"Перечень компьютеров с объемом ОЗУ не ниже {0}:", obem_ozu);
                foreach (Computer v in computer_2)
                {
                    Console.WriteLine($"Код компьютера {v.Qod}, марка компьютера {v.Marka}, тип процессора {v.Processor}, частота процессора {v.Chastota},объем оперативной памяти {v.Memory}, жесткого диска {v.HardDisk}, видеокарты {v.Video}, стоимость {v.Stoimost}, в наличии {v.Kolichestvo}");
                }
            }
            Console.ReadKey();

            //- вывести весь список, отсортированный по увеличению стоимости;
            List<Computer> computer_3=listcomp
                .OrderBy(b=>b.Stoimost)
                .ToList();
            foreach (Computer b in computer_3)
            {
                Console.WriteLine($"Код компьютера {b.Qod}, марка компьютера {b.Marka}, тип процессора {b.Processor}, частота процессора {b.Chastota},объем оперативной памяти {b.Memory}, жесткого диска {b.HardDisk}, видеокарты {b.Video}, стоимость {b.Stoimost}, в наличии {b.Kolichestvo}");
            }
            Console.ReadKey();

            //- вывести весь список, сгруппированный по типу процессора;
            var computer_4 = listcomp
                .GroupBy(t => t.Processor);
                
            foreach (IGrouping<string, Computer> t in computer_4)
            {
                Console.WriteLine(t.Key);
                foreach (var y in t)
                                       
                Console.WriteLine($"Код компьютера {y.Qod}, марка компьютера {y.Marka}, тип процессора {y.Processor}, частота процессора {y.Chastota},объем оперативной памяти {y.Memory}, жесткого диска {y.HardDisk}, видеокарты {y.Video}, стоимость {y.Stoimost}, в наличии {y.Kolichestvo}");
            }
            Console.ReadKey();

            //- найти самый дорогой и самый бюджетный компьютер;
            IEnumerable<Computer> computer_5 = listcomp
                .Where(j => j.Stoimost == computer_3[0].Stoimost);
            foreach (Computer j in computer_5)
            {
                Console.WriteLine($"Код компьютера с самой низкой стоимостью {j.Qod}");
            }
            IEnumerable<Computer> computer_6 = listcomp
                .Where(h => h.Stoimost == computer_3[computer_3.Count - 1].Stoimost);
            foreach (Computer h in computer_5)
            {
                Console.WriteLine($"Код компьютера с самой высокой стоимостью {h.Qod}");
            }
            Console.ReadKey();


            //- есть ли хотя бы один компьютер в количестве не менее 30 штук?
            List<Computer> computer_7 = listcomp
                .Where(z => z.Kolichestvo >= 300)
                .ToList();
             if (computer_7.Count()!=0)
            {
                Console.WriteLine("Есть не менее одной модели компьютера в количестве не менее 30 штук");
            }
            else
            {
                Console.WriteLine("Нет ни одной модели компьютера в количестве не менее 30 штук");
            }
            Console.ReadKey();
        }

    }
    class Computer
    {
        public int Qod { get; set; }
        public string Marka { get; set; }
        public string Processor { get; set; }
        public int Chastota { get; set; }
        public int Memory { get; set; }
        public int HardDisk { get; set; }
        public int Video { get; set; }
        public double Stoimost { get; set; }
        public int Kolichestvo { get; set; }
    }
}
