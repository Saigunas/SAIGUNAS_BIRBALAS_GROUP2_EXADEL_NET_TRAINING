using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Task6.Models;
using Task6;

public class Program
{
    public static void Main(string[] args)
    {
        using (var db = new SchoolContext())
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
                        CreateSubjectAsync(db);
                        break;
                    case 2:
                        UpdateSubjectAsync(db);
                        break;
                    case 3:
                        DeleteSubjectAsync(db);
                        break;
                    case 4:
                        ReadSubjectAsync(db);
                        break;
                    case 5:
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

            }

            db.SaveChanges();
        }
    }

    public static async Task CreateSubjectAsync(SchoolContext db)
    {
        Console.WriteLine("Subject name: ");
        string name = Console.ReadLine();
        await Task.Run(() =>
        {
            var subject = new Subject { Name = name };
            db.Subjects.Add(subject);
            db.SaveChanges();
        });
    }

    public static async Task UpdateSubjectAsync(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("New name: ");
        string name = Console.ReadLine();

        await Task.Run(() => 
        {
            var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine($"Err: no object found for id: {id}");
                return;
            }

            subject.Name = name;

            db.SaveChanges();
        });
    }

    public static async Task DeleteSubjectAsync(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        await Task.Run(() =>
        {
            var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine($"Err: no object found for id: {id}");
                return;
            }

            db.Subjects.Remove(subject);

            db.SaveChanges();
        });
    }

    public static async Task ReadSubjectAsync(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        await Task.Run(() =>
        {
            var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine("Err: no object found");
                return;
            }

            Console.WriteLine($"Subject Id: {subject.Id}");
            Console.WriteLine($"Subject name: {subject.Name}");
        });
    }

}