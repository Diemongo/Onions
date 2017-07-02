using System;
using System.Data.Entity;
using System.Windows;

namespace WPFDatabaseTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CreateData();
		}

		private void CreateData()
		{
			using (var db = new AnimalContext())
			{
				//Animal animal = new Animal { Name = "Big", LastName = "Elephant", Created = DateTime.Now, Modified = DateTime.Now };

				//db.Animals.Add(animal);
				//db.SaveChanges();
				db.Animals.ForEachAsync<Animal>(item => Console.WriteLine($"{item.AnimalId}  {item.Name} {item.LastName}"));
			}
		}
	}

	public class AnimalContext : DbContext
	{
		public AnimalContext() : base()	{ }
		public DbSet<Animal> Animals { get; set; }
	}

	public class Animal
	{
		public int AnimalId { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}

}
