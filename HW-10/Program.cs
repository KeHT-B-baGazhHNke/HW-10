using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HW_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1 Мероприятия");
            List<string> lines = File.ReadAllLines("students.txt").ToList();
            List<Student> students = new List<Student>();
            foreach (var line in lines)
            {
                var nwline = line.Split(new[] { "," }, StringSplitOptions.None);
                string name = nwline[0];
                int group = Convert.ToInt32(nwline[1]);
                students.Add(new Student(name, group));
            }
            List<Student> group321 = new List<Student>();
            List<Student> group322 = new List<Student>();
            foreach (Student student in students)
            {
                switch (student.Group)
                {
                    case 321:
                        group321.Add(student);
                        break;
                    case 322:
                        group322.Add(student);
                        break;
                    default:
                        Console.WriteLine("Найден персонаж из неизвестной группы!\nОн никуда не добавлен");
                        break;
                }
            }
            FileStream fs = File.Open("Events.txt", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(0);
            fs.Close();
            Event event1 = new Event("День первокурсника", new DateTime(2023, 30, 11), group321, 1);
            event1.Select();
            event1.Print();
            Event event2 = new Event("Гала-концерт", new DateTime(2023, 30, 11), group322, 2);
            event2.Select();
            event2.Print();
            Event event3 = new Event("МиМ ИВМиИТ", new DateTime(2023, 30, 11), group321, 3);
            event3.Select();
            event3.Print();
            Event event4 = new Event("Квиз", new DateTime(2023, 12, 10), group322, 1);
            event4.Select();
            event4.Print();
            Console.ReadKey();
        }
    }
}
