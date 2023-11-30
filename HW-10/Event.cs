using System;
using System.Collections.Generic;
using System.IO;

namespace HW_10
{
    internal class Event
    {
        private string name { get; set; }
        private DateTime date { get; set; }
        private List<Student> event_group { get; set; }
        private int people_quantity { get; set; }

        public List<Student> students { get; set; }
        public Event(string name, DateTime date, List<Student> event_group, int people_quantity)
        {
            this.name = name;
            this.date = date;
            this.event_group = event_group;
            this.people_quantity = people_quantity;
            StreamWriter write = new StreamWriter("Events.txt", true);
            write.WriteLine($"Мероприятие: {name}, {date.ToShortDateString()}\nУчаствуют: ");
            write.Close();
        }
        public void Select()
        {
            List<Student> event_students = new List<Student>();
            int people = people_quantity;
            for (int j = 0; j < event_group.Count; j++)
            {
                event_group[j].CountVisits();
                if (event_group[j].Is_freeloader && people > 0)
                {
                    event_students.Add(event_group[j]);
                    students = event_students;
                    event_group[j].Visits.Add(true);
                    people--;
                }
                else
                {
                    event_group[j].Visits.Add(false);
                }
            }
            if (people > 0)
            {
                for (int j = 0; j < event_group.Count; j++)
                {
                    event_students.Add(event_group[j]);
                    students = event_students;
                    event_group[j].Visits.Add(true);
                }
            }
        }
        public void Print()
        {
            StreamWriter write = new StreamWriter("Events.txt", true);
            for (int i = 0; i < students.Count; i++)
            {
                write.WriteLine($"Участвует {students[i].Name}, группа: {students[i].Group}");
            }
            write.Close();
        }
    }
}