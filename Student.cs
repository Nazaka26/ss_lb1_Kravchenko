using System;

namespace SS_task_1
{
    public class Student
    {
        public string _fullName { get; }
        public string _reportCard { get; }
        public int _studingYear { get; }

        private int[] _marks = new int[(int)Disciplines.Length]; 
            // "Disciplines.Length" contains size of the enum.
            //  We need "marks" array to have the same size as "Disciplines".
        public float GradePointAverage
        {
            get
            {
                float res = 0;
                foreach (var value in _marks)
                    res += value;
                return res / (int) Disciplines.Length;
            }
        }
        public Student(string fullName, string reportCard, string studingYear)
        {
            if(!NameInputCheck(fullName)) 
                throw new Exception("Student name can only consist of english words");
            _fullName = fullName;

            if(string.IsNullOrWhiteSpace(reportCard) || reportCard.Contains(' '))
                throw new Exception("Report card cannot contain spaces");
            _reportCard = reportCard.ToUpper();

            if (!Int32.TryParse(studingYear, out int intStudingYear)) 
                throw new Exception("The year of study must be numeric");
            _studingYear = intStudingYear;
        }

        public void ViewInfo()
        {
            Console.WriteLine(@"
Student name:               {0} 
Student reportCard:         {1}     
Student year of studying:   {2}     
Student GPA                 {3}
", _fullName, _reportCard, _studingYear, GradePointAverage);
        }
        public int[] CompareMarks(Student student)
        {
            var differences = new int[_marks.Length];
            for (var i = 0; i < _marks.Length; i++)
                differences[i] = this._marks[i] - student._marks[i];
            return differences;
        }
       
        private bool NameInputCheck(string fullName)
        {
            if (String.IsNullOrWhiteSpace(fullName))
                return false;
            var splitedFullName = fullName.Trim().Split(' ');
            foreach (var ch in fullName.Replace(" ", ""))
                if (!((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
                    return false;
            return true;
        }
        
        public void SetMark(Disciplines disciplines, int mark)
        {
            var indexOfDiscipline = (int)disciplines;
            if (_marks[indexOfDiscipline] != 0)
                throw new Exception("The mark of the chosen discipline was entered twice");
            _marks[indexOfDiscipline] = mark;
        }

        public int GetMark(Disciplines disciplines)
        {
            return _marks[(int) disciplines];
        }
        public string ToString()
        {
            var allMarks = new string[_marks.Length];
            for (var i = 0; i < _marks.Length; i++)
                allMarks[i] = (Disciplines)i + ":\t" + _marks[i];
            return String.Join("\n", allMarks);
        }
    }
}
