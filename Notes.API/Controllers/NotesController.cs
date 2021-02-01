using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Notes.API.Models;
using Notes.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.API.Controllers
{
	[Route("api/notes")]
	[ApiController]
	[Produces(Constants.CONTENTTYPE_JSON)]
	public class NotesController : ControllerBase
	{
		private readonly NotesDbContext _dbContext;

		public NotesController(NotesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetList()
		{
			List<Note> notes = _dbContext.Notes.ToList();
			return Ok(notes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNote(string id)
		{
			if (int.TryParse(id, out int dbInt))
			{
				Note note = await _dbContext.Notes.FindAsync(dbInt);
				return Ok(note);
			}
			else
			{
				return BadRequest(Error.Create(400, "Id was not in correct format"));
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateNote([FromBody] NoteRequestBody body, CancellationToken token)
		{
			if (body.Validate())
			{
				EntityEntry<Note> createdNote = await _dbContext.Notes.AddAsync(new Note
				{
					Title = body.Title,
					Description = body.Description,
					Modification = DateTime.Now
				}, token);
				await _dbContext.SaveChangesAsync(token);
				return Ok(createdNote.Entity);
			}
			else
			{
				return BadRequest(Error.Create(400, "Body was not valid"));
			}
		}
	}
}
