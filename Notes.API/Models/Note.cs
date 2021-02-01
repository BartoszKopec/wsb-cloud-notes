using System;

namespace Notes.API.Models
{
	public class Note : NoteBase
	{
		public int ID { get; set; }
		public DateTime Modification { get; set; }
	}
}
