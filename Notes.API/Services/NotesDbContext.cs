using Microsoft.EntityFrameworkCore;
using Notes.API.Models;

namespace Notes.API.Services
{
	public class NotesDbContext : DbContext
	{
		public NotesDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>().ToTable("Notes")
				.HasKey("ID");
		}

		public DbSet<Note> Notes { get; set; }
	}
}
