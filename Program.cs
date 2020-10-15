using System;
/*Варіант 3. Профіль студента університету
    У проекті передбачити розділення інтерфейсу та логіки типів, що створювалися під час виконання завдання. 
    Передбачити створення виключень під час введення некоректних значень.
    
    Дані типу:
    ·        ПІБ студента: не може бути порожнім рядком або містити цифри;
    ·        номера залікової книжки: не може містити пробіли;
    ·        курс: тільки ціле число;
    ·        середній бал: дійсне число, залежить від оцінок з предметів;
    ·        оцінки за 10 предметів за 100-бальною шкалою.
    Методи типу:
    ·        ініціалізуючий конструктор;
    ·        встановлення оцінки за індексом предмета;
    ·        отримання значення оцінки за значенням предмета: всі предмети представляються у перерахуванні з 10 елементів, 
             у масиві предметів не може бути однакових елементів;
    ·        перевизначення методу ToString;
    ·        порівняння 2 студентів за оцінками: у результаті порівняння повертається масив різниці балів у предметах.*/
namespace SS_task_1
{
    public enum Disciplines
    {
        English = 0,
        Mathematicks,
        History,
        Geography,
        Physics,
        Chemistry,
        Phylosophy,
        Literature,
        Biology,
        Sociology,
        Length         //size of enum
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student rick = new Student("Rick Sanchez", "AS2F81S", "2");
            rick.SetMark(Disciplines.English,92);
            rick.SetMark(Disciplines.Mathematicks,64);
            rick.SetMark(Disciplines.History,68);
            rick.SetMark(Disciplines.Geography,75);
            rick.SetMark(Disciplines.Physics,82);
            rick.SetMark(Disciplines.Chemistry,66);
            rick.SetMark(Disciplines.Phylosophy,85);
            rick.SetMark(Disciplines.Literature,98);
            rick.SetMark(Disciplines.Biology,90);
            rick.SetMark(Disciplines.Sociology,100);

            rick.ViewInfo();
            Console.WriteLine(rick.ToString());
            
            Student morty = new Student("Morty Smith", "DS654S4", "3" );
            morty.SetMark(Disciplines.English,78);
            morty.SetMark(Disciplines.Mathematicks,96);
            morty.SetMark(Disciplines.History,68);
            morty.SetMark(Disciplines.Geography,88);
            morty.SetMark(Disciplines.Physics,60);
            morty.SetMark(Disciplines.Chemistry,97);
            morty.SetMark(Disciplines.Phylosophy,92);
            morty.SetMark(Disciplines.Literature,78);
            morty.SetMark(Disciplines.Biology,85);
            morty.SetMark(Disciplines.Sociology,90);

            var diff = rick.CompareMarks(morty);
            Console.WriteLine("The difference between Rick's and Morty's marks: ");
            foreach (var value in diff)
                Console.Write((value) + " ");

            Console.WriteLine("\nRick's grade in biology: " + rick.GetMark(Disciplines.Biology));
            Console.WriteLine("\nRick's grade in biology: " + rick.GetMark(Disciplines.Biology));
        }
    }
}