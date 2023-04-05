using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using randomString.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace randomString.Controllers
{
	public class RandomController : Controller
	{
		public async Task<IActionResult> Index(int Count, int Length)
		{
            HttpClient client = new HttpClient();
			string baseString = $"https://ciprand.p3p.repl.co/api?len={Length}&count={Count}";
			HttpResponseMessage response = await client.GetAsync(baseString);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            RandomStrings stringsModel = System.Text.Json.JsonSerializer.Deserialize<RandomStrings>(responseBody)!;
            return View(stringsModel);
		}
	}
}
