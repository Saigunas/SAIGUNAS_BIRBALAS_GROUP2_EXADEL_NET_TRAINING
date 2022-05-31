using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Task5.DataAccessLayer.Persistence;
using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Core.Interfaces;
using Task7.DataAccessLayer.Persistence.StudentServices;

public class Program
{
    public static void Main(string[] args)
    {
        using (var unitOfWork = new UnitOfWork(new SchoolContext()))
        {
            //For Testing Task7_2
            /*
            PopulateTableForTask7_2(unitOfWork);
            */
            //

            GetStudentsInfoService(unitOfWork);
        }
    }

    public static void PopulateTableForTask7_2(UnitOfWork unitOfWork)
    {
        var newClass = new Class();
        newClass.Number = 5;
        newClass.Letter = "b";

        unitOfWork.Classes.Add(newClass);

        var newStudent = new Student();
        newStudent.FirstName = "Morgana";
        newStudent.LastName = "Paw";
        newStudent.Address = "Metaverse";
        newStudent.PhoneNumber = 3664545;
        newStudent.DateOfBirth = new DateTime(1987, 7, 15, 10, 39, 30);
        newStudent.ClassId = 1;

        unitOfWork.Students.Add(newStudent);

        unitOfWork.Save();
    }

    public static void GetStudentsInfoService(UnitOfWork unitOfWork)
    {

        IInfoStringFormatterService studentInfo = null;

        bool showMenu = true;
        while (showMenu)
        {
            Console.WriteLine("Select the option: ");
            Console.WriteLine("1. Get student info");
            Console.WriteLine("2. Get student last name");
            Console.WriteLine("3. Exit");

            int selection = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter The Id: ");

            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Student student = unitOfWork.Students.Get(studentId);
            if(student == null)
            {
                Console.WriteLine("Wrong student id");
                continue;
            }

            switch (selection)
            {
                case 1:
                    {
                        studentInfo = new GetFullInfoService();
                        break;
                    }
                case 2:
                    {
                        studentInfo = new GetLastNameService();
                        break;
                    }
                case 3:
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }

            if(studentInfo != null)
            {
                Console.WriteLine(studentInfo.GetInfoString(student));
            }
        }

    }
}