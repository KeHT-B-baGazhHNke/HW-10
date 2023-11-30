using System.Collections.Generic;

namespace HW_10
{
    internal class Student
    {
        private string name;
        public string Name
        {
            get{return name;}
        }
        private int group;
        public int Group
        {
            get{return group;}
        }
        private List<bool> visits;
        public List<bool> Visits
        {
            get{return visits;}
            set{visits = value;}
        }
        private bool is_freeloader;
        public bool Is_freeloader
        {
            get{return is_freeloader;}
            set{is_freeloader = value;}
        }
        public Student(string name, int group)
        {
            this.name = name;
            this.group = group;
            visits = new List<bool>();
            Is_freeloader = true;
        }
        public void CountVisits()
        {
            if (visits.Count > 2)
            {
                if (visits[visits.Count - 1] == true || visits[visits.Count - 2] == true || visits[visits.Count - 3] == true)
                {
                    is_freeloader = false;
                }
            }
            if (visits.Count == 2)
            {
                if (visits[visits.Count - 1] == true || visits[visits.Count - 2] == true)
                {
                    is_freeloader = false;
                }
            }
            if (visits.Count == 1)
            {
                if (visits[visits.Count - 1] == true)
                {
                    is_freeloader = false;
                }
            }
            else
            {
                is_freeloader = true;
            }

        }
    }
}
