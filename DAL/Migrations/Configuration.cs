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
                    RussianWord = "����",
                    EnglishWord = "one"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "���",
                    EnglishWord = "two"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "���",
                    EnglishWord = "three"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "������",
                    EnglishWord = "four"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "����",
                    EnglishWord = "five"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "�����",
                    EnglishWord = "six"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "����",
                    EnglishWord = "seven"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "������",
                    EnglishWord = "eight"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "������",
                    EnglishWord = "nine"
                });
                context.Words.Add(new Word
                {
                    Topic = context.Topics.FirstOrDefault(x => x.Name == "Numbers"),
                    RussianWord = "������",
                    EnglishWord = "ten"
                });

                context.SaveChanges();

                context.Colors.Add(new Color { ColorOnEnglish = "red", ColorOnRussian = "�������" });
                context.Colors.Add(new Color { ColorOnEnglish = "blue", ColorOnRussian = "�����" });
                context.Colors.Add(new Color { ColorOnEnglish = "green", ColorOnRussian = "�������" });
                context.Colors.Add(new Color { ColorOnEnglish = "black", ColorOnRussian = "������" });
                context.Colors.Add(new Color { ColorOnEnglish = "pink", ColorOnRussian = "�������" });
                context.Colors.Add(new Color { ColorOnEnglish = "orange", ColorOnRussian = "��������" });
                context.Colors.Add(new Color { ColorOnEnglish = "purple", ColorOnRussian = "����������" });
                context.Colors.Add(new Color { ColorOnEnglish = "yellow", ColorOnRussian = "������" });

                context.SaveChanges();

                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
            }
        }
    }
}