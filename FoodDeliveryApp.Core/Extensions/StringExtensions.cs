using System.Text.RegularExpressions;

namespace FoodDeliveryApp.Core.Extensions
{
	public static class StringExtensions
	{
		public static string Sanitize(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return string.Empty;
			}

			input = input.Trim();

			input = System.Web.HttpUtility.HtmlEncode(input);

			input = input.Replace("'", "").Replace(";", "");

			const int MaxLength = 255;
			input = input.Length > MaxLength ? input.Substring(0, MaxLength) : input;

			input = input.ToLowerInvariant();

			input = Regex.Replace(input, @"\s+", " ");

			const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_/~.";
			input = new string(input.Where(c => AllowedChars.Contains(c)).ToArray());

			input = input.Replace("..", "");

			return input;
		}
	}
}