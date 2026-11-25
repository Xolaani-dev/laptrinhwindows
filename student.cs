using System;
using System.Collections.Generic;
using System.Text;

namespace lab01_02
{
    class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public float AverageScore
        {
            get { return averageScore; }
            set { averageScore = value; }
        }

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }
        public Student()
        {
        }

        public Student(string studentID, string fullName,
                       float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }
        public void Input()
        {
            Console.Write("Nhap MSSV: ");
            StudentID = Console.ReadLine();

            Console.Write("Nhap Ho ten sinh vien: ");
            FullName = Console.ReadLine();

            Console.Write("Nhap Diem TB: ");
            AverageScore = float.Parse(Console.ReadLine());

            Console.Write("Nhap Khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine(
                "MSSV: {0} | Ho ten: {1} | Khoa: {2} | Diem TB: {3}",
                StudentID, FullName, Faculty, AverageScore
            );
        }
    }

}
