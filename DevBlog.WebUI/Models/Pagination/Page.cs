namespace DevBlog.WebUI.Models.Pagination
{
	/// <summary>
	/// Hazirki sehife ile elaqeli melumatlari saxlayir.
	/// </summary>
	public class PageInformation
	{
		public int  TotalPosts            { get; set; }
		public int  PostsPerPage          { get; set; }
		public int  CurrentPage           { get; set; }
		public string CurrentCategoryName { get; set; }

		/// <summary>
		/// Bu property geriye olmali olan sehife sayini qaytarir.
		/// </summary>
		public int TotalPages() => (int)Math.Ceiling((decimal)TotalPosts / PostsPerPage);
	}
}