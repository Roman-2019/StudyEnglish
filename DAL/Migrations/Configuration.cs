namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.DBContext";
        }

        public class MyContextInitializer : DropCreateDatabaseAlways<DBContext>
        {
            protected override void Seed(DBContext context)
            {
                context.Topics.Add(new Topic { Name = "Numbers", Marker = false });
                context.Topics.Add(new Topic { Name = "Colors", Marker = false });
                context.Topics.Add(new Topic { Name = "Fruits", Marker = false });

                context.SaveChanges();

                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "один",
                    EnglishWord = "one"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "два",
                    EnglishWord = "two"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "три",
                    EnglishWord = "three"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "четыре",
                    EnglishWord = "four"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "пять",
                    EnglishWord = "five"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "шесть",
                    EnglishWord = "six"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "семь",
                    EnglishWord = "seven"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "восемь",
                    EnglishWord = "eight"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "девять",
                    EnglishWord = "nine"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "десять",
                    EnglishWord = "ten"
                });

                context.SaveChanges();

                context.Colors.Add(new Color { ColorOnEnglish = "red", ColorOnRussian = "красный" });
                context.Colors.Add(new Color { ColorOnEnglish = "blue", ColorOnRussian = "синий" });
                context.Colors.Add(new Color { ColorOnEnglish = "green", ColorOnRussian = "зеленый" });
                context.Colors.Add(new Color { ColorOnEnglish = "black", ColorOnRussian = "черный" });
                context.Colors.Add(new Color { ColorOnEnglish = "pink", ColorOnRussian = "розовый" });
                context.Colors.Add(new Color { ColorOnEnglish = "orange", ColorOnRussian = "оражевый" });
                context.Colors.Add(new Color { ColorOnEnglish = "purple", ColorOnRussian = "фиолетовый" });
                context.Colors.Add(new Color { ColorOnEnglish = "yellow", ColorOnRussian = "желтый" });

                context.SaveChanges();

                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
            }
        }
    }
}