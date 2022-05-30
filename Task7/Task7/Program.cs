using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Task5.DataAccessLayer.Persistence;

public class Program
{
    public static void Main(string[] args)
    {
        using (var unitOfWork = new UnitOfWork(new SchoolContext()))
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Select the option: ");
                Console.WriteLine("1. Create subject");
                Console.WriteLine("2. Update subject by ID");
                Console.WriteLine("3. Delete subject by ID");
                Console.WriteLine("4. Read subject by ID");
                Console.WriteLine("5. Exit");

                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        unitOfWork.Subjects.CreateSubject();
                        break;
                    case 2:
                        unitOfWork.Subjects.UpdateSubject();
                        break;
                    case 3:
                        unitOfWork.Subjects.DeleteSubject();
                        break;
                    case 4:
                        unitOfWork.Subjects.ReadSubject();
                        break;
                    case 5:
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

                unitOfWork.Save();
            }
        }
    }
}