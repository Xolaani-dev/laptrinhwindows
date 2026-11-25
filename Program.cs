
using lab01_02;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> studentList = new List<Student>();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Sinh vien thuoc khoa CNTT");
            Console.WriteLine("4. Sinh vien co diem TB >= 5");
            Console.WriteLine("5. Sap xep diem TB tang dan");
            Console.WriteLine("6. Sinh vien CNTT co diem TB >= 5");
            Console.WriteLine("7. Sinh vien CNTT co diem TB cao nhat");
            Console.WriteLine("8. Thong ke xep loai sinh vien");
            Console.WriteLine("0. Thoat");

            Console.Write("Chon chuc nang (0-8): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent(studentList);
                    break;

                case "2":
                    DisplayStudentList(studentList);
                    break;

                case "3":
                    DisplayStudentsByFaculty(studentList, "CNTT");
                    break;

                case "4":
                    DisplayStudentsWithHighAverageScore(studentList, 5);
                    break;

                case "5":
                    SortStudentsByAverageScore(studentList);
                    break;

                case "6":
                    DisplayStudentsByFacultyAndScore(
                        studentList, "CNTT", 5);
                    break;

                case "7":
                    DisplayStudentsWithHighestAverageScoreByFaculty(
                        studentList, "CNTT");
                    break;

                case "8":
                    CountStudentsByClassification(studentList);
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }
    static void AddStudent(List<Student> studentList)
    {
        Console.WriteLine("\n=== Nhap thong tin sinh vien ===");

        Student student = new Student();
        student.Input();

        studentList.Add(student);

        Console.WriteLine("Them sinh vien thanh cong!");
    }
    static void DisplayStudentList(List<Student> studentList)
    {
        Console.WriteLine("\n=== Danh sach sinh vien ===");

        foreach (Student student in studentList)
        {
            student.Show();
        }
    }
    static void DisplayStudentsByFaculty(
        List<Student> studentList, string faculty)
    {
        Console.WriteLine("\n=== Sinh vien thuoc khoa {0} ===", faculty);

        var students = studentList
            .Where(s => s.Faculty.Equals(
                faculty, StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplayStudentList(students);
    }
    static void DisplayStudentsWithHighAverageScore(
        List<Student> studentList, float minDTB)
    {
        Console.WriteLine("\n=== Sinh vien co diem TB >= {0} ===", minDTB);

        var students = studentList
            .Where(s => s.AverageScore >= minDTB)
            .ToList();

        DisplayStudentList(students);
    }
    static void SortStudentsByAverageScore(
        List<Student> studentList)
    {
        Console.WriteLine("\n=== Sap xep diem TB tang dan ===");

        var sortedStudents = studentList
            .OrderBy(s => s.AverageScore)
            .ToList();

        DisplayStudentList(sortedStudents);
    }
    static void DisplayStudentsByFacultyAndScore(
        List<Student> studentList, string faculty, float minDTB)
    {
        Console.WriteLine(
            "\n=== Sinh vien khoa {0} co diem TB >= {1} ===",
            faculty, minDTB);

        var students = studentList
            .Where(s => s.AverageScore >= minDTB
                && s.Faculty.Equals(
                    faculty, StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplayStudentList(students);
    }
    static void DisplayStudentsWithHighestAverageScoreByFaculty(
        List<Student> studentList, string faculty)
    {
        Console.WriteLine(
            "\n=== Sinh vien khoa {0} co diem TB cao nhat ===",
            faculty);

        var students = studentList
            .Where(s => s.Faculty.Equals(
                faculty, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (students.Count == 0)
        {
            Console.WriteLine("Khong co sinh vien thuoc khoa {0}!", faculty);
            return;
        }

        float maxScore = students.Max(s => s.AverageScore);

        var highestStudents = students
            .Where(s => s.AverageScore == maxScore)
            .ToList();

        DisplayStudentList(highestStudents);
    }
    static void CountStudentsByClassification(
        List<Student> studentList)
    {
        Console.WriteLine("\n=== THONG KE XEP LOAI SINH VIEN ===");

        int xuatSac = studentList.Count(
            s => s.AverageScore >= 9 && s.AverageScore <= 10);

        int gioi = studentList.Count(
            s => s.AverageScore >= 8 && s.AverageScore < 9);

        int kha = studentList.Count(
            s => s.AverageScore >= 7 && s.AverageScore < 8);

        int trungBinh = studentList.Count(
            s => s.AverageScore >= 5 && s.AverageScore < 7);

        int yeu = studentList.Count(
            s => s.AverageScore >= 4 && s.AverageScore < 5);

        int kem = studentList.Count(
            s => s.AverageScore < 4);

        Console.WriteLine("Xuat sac: " + xuatSac);
        Console.WriteLine("Gioi: " + gioi);
        Console.WriteLine("Kha: " + kha);
        Console.WriteLine("Trung binh: " + trungBinh);
        Console.WriteLine("Yeu: " + yeu);
        Console.WriteLine("Kem: " + kem);
    }
}
