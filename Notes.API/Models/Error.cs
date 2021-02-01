namespace Notes.API.Models
{
	public class Error
	{
		public static Error Create(int status, string message) => new Error
		{
			Status = status,
			Message = message
		};

		protected Error() { }

		public int Status { get; private set; }
		public string Message { get; private set; }
	}
}
