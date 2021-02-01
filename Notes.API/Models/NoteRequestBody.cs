namespace Notes.API.Models
{
	public class NoteRequestBody : NoteBase, IValidModel
	{
		public bool Validate() => !string.IsNullOrWhiteSpace(this.Title) &&
			!string.IsNullOrWhiteSpace(this.Description);
	}
}
