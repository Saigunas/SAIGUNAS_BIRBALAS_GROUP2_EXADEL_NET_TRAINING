using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        using(var db = new SchoolContext())
        {
            bool showMenu = true;
            while(showMenu)
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
                        CreateSubject(db);
                        break;
                    case 2:
                        UpdateSubject(db);
                        break;
                    case 3:
                        DeleteSubject(db);
                        break;
                    case 4:
                        ReadSubject(db);
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

    public static void CreateSubject(SchoolContext db)
    {
        Console.WriteLine("Subject name: ");
        string name = Console.ReadLine();
        var subject = new Subject { Name = name };
        db.Subjects.Add(subject);

        db.SaveChanges();
    }

    public static void UpdateSubject(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("New name: ");
        string name = Console.ReadLine();
    
        var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

        if (subject == null)
        {
            Console.WriteLine("Err: no object found");
            return;
        }

        subject.Name = name;

        db.SaveChanges();
    }

    public static void DeleteSubject(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

        if (subject == null)
        {
            Console.WriteLine("Err: no object found");
            return;
        }

        db.Subjects.Remove(subject);

        db.SaveChanges();
    }

    public static void ReadSubject(SchoolContext db)
    {
        Console.WriteLine("Subject Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var subject = db.Subjects.FirstOrDefault(s => s.Id == id);

        if (subject == null)
        {
            Console.WriteLine("Err: no object found");
            return;
        }

        Console.WriteLine($"Subject Id: {subject.Id}");
        Console.WriteLine($"Subject name: {subject.Name}");
    }

}

public class Student
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class Subject
{
    public int Id{ get; set; }
    public string Name { get; set; }
}

public class Class 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Letter { get; set; }
}

public class ClassSubject
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public virtual Class Class { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}

public class SchoolContext : DbContext
{
    public SchoolContext()
    { 
        Database.EnsureCreated();
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ClassSubject> ClassSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=School_5;Trusted_Connection=True;");
    }
}