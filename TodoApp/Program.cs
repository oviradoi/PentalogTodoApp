namespace TodoApp
{
    using Microsoft.EntityFrameworkCore;
    using TodoAppDatabase.DbContext;
    using TodoAppDatabase.Models;

    internal class Program
    {
        private static int _userId;
        private static string _userName;

        static void InitializeDatabase()
        {
            using var dbContext = new TodoDbContext();
            dbContext.Database.EnsureCreated();
        }

        static void Login()
        {
            Console.WriteLine("What is your username");
            string username = Console.ReadLine();

            using var dbContext = new TodoDbContext();
            var user = dbContext.Users.SingleOrDefault(u => u.Name == username);
            if (user == null)
            {
                user = new User { Name = username };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            _userId = user.Id;
            _userName = user.Name;
        }

        static void ShowNotes()
        {
            using var dbContext = new TodoDbContext();
            var user = dbContext.Users.Include(u => u.Notes).SingleOrDefault(u => u.Id == _userId);
            Console.WriteLine($"You have {user.Notes.Count} notes");
            foreach (var note in user.Notes)
            {
                Console.WriteLine($"Note id={note.Id} text={note.Text}");
            }

        }

        static int ShowMenuAndReadChoice()
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome {_userName}!");
            Console.WriteLine("1. Show notes");
            Console.WriteLine("2. Add a new note");
            Console.WriteLine("3. Delete last note");
            Console.WriteLine("4. Modify last note");
            Console.WriteLine("0. Exit");
            return int.Parse(Console.ReadLine());
        }

        static void AddNewNote()
        {
            Console.WriteLine("Enter the text of the note:");
            string text = Console.ReadLine();

            Note note = new Note() { Text = text, UserId = _userId };

            using var dbContext = new TodoDbContext();
            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
        }

        static void ModifyLastNote()
        {
            using var dbContext = new TodoDbContext();

            var user = dbContext.Users.Include(u => u.Notes).SingleOrDefault(u => u.Id == _userId);

            var lastNote = user.Notes.LastOrDefault();
            if (lastNote != null)
            {
                Console.WriteLine("Please enter the new text for the last note");
                string newText = Console.ReadLine();
                lastNote.Text = newText;

                dbContext.SaveChanges();
            }
        }

        static void DeleteLastNote()
        {
            using var dbContext = new TodoDbContext();

            var user = dbContext.Users.Include(u => u.Notes).SingleOrDefault(u => u.Id == _userId);
            Console.WriteLine("Deleting the last note");
            var lastNote = user.Notes.LastOrDefault();
            if (lastNote != null)
            {
                user.Notes.Remove(lastNote);

                dbContext.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            InitializeDatabase();

            Login();

            int choice;
            do
            {
                choice = ShowMenuAndReadChoice();
                if (choice == 1)
                {
                    ShowNotes();
                }
                else if (choice == 2)
                {
                    AddNewNote();
                }
                else if (choice == 3)
                {
                    DeleteLastNote();
                }
                else if (choice == 4)
                {
                    ModifyLastNote();
                }
            } while (choice != 0);
        }
    }
}