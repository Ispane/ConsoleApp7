using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
    {
        class Ispitanie
        {
            public string name;
            public int sb;
            public Ispitanie(string name, int sb)
            {
                this.name = name;
                this.sb = sb;
            }
            virtual public void Vivod()
            {
                Console.WriteLine($"{name} средний балл за семестр: {sb}");
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                Ispitanie temp = (Ispitanie)obj;
                return sb == temp.sb;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public virtual void Proverka()
            {

            }
        }
        class Test : Ispitanie
        {
            int ocenka;
            public Test(int ocenka, string name, int sb) : base(name, sb)
            {
                this.ocenka = ocenka;

            }
            public override void Vivod()
            {
                Console.WriteLine($"{name} получил за итоговый тест {ocenka} ");
            }
            public override void Proverka()
            {
                if (ocenka >= 4)
                    Console.WriteLine(name + " сдал тест\nОтметка за тест: " + ocenka);
                else
                    Console.WriteLine(name + " не сдал тест\nОценка за тест: " + ocenka);
            }

        }
        class Ekzamen : Ispitanie
        {
            string ter;
            int ocenka;
            public Ekzamen(int ocenka, string name, int sb, string ter) : base(name, sb)
            {
                this.ter = ter;
                this.ocenka = ocenka;
            }
            public override void Vivod()
            {
                Console.WriteLine($"{name} сдал экзамен на {ocenka} по {ter}");
            }
            public override void Proverka()
            {
                if (ocenka >= 4)
                    Console.WriteLine($"{name} сдал экзамен на {ocenka}");
                else
                    Console.WriteLine(name + " не сдал экзамен, оценка " + ocenka);
            }
        }
        class VPEkzamen : Ispitanie
        {
            int ocenka;
            public VPEkzamen(int ocenka, string name, int sb) : base(name, sb)
            {
                this.ocenka = ocenka;
            }
            public override void Vivod()
            {
                Console.WriteLine("{0} сдал выпускной экзамен на {1} ", name, ocenka);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Ispitanie[] p = new Ispitanie[5];
                p[0] = new Ispitanie("Иванов И.И.", 5);
                p[1] = new Test(2, "Петров П.П.", 7);
                p[2] = new Ekzamen(6, "Иванов", 5, "ЗКИ");
                p[3] = new Ispitanie("Петров П.П.", 7);
                p[4] = new VPEkzamen(5, "Петров", 7);
                foreach (var item in p)
                {
                    item.Vivod();
                }
                Console.WriteLine("__________________________________________");
                Console.WriteLine("Узнать сдал ли тест {0}\n1-да 2-нет", p[1].name);
                int y = int.Parse(Console.ReadLine());
                if (y == 1)
                    p[1].Proverka();
                Console.WriteLine();
                Console.WriteLine("Узнать сдал ли {0} экзамен\n1-да 2-нет", p[2].name);
                y = int.Parse(Console.ReadLine());
                if (y == 1)
                    p[2].Proverka();
                Console.WriteLine();
                Console.WriteLine($"Сравнить средний балл за семестр {p[0].name} и {p[3].name}\n1-да 2-нет");
                y = int.Parse(Console.ReadLine());
                if (y == 1)
                {
                    Console.WriteLine($"Средние баллы\nИванов: {p[0].sb}\nПетров: {p[3].sb}");
                    if (p[0].Equals(p[3]))
                        Console.WriteLine("Значение равны");
                    else
                        Console.WriteLine("Не равны");
                }
                Console.ReadKey();
            }

        }
}
    

