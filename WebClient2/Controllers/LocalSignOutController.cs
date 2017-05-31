using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Http;

namespace WebClient2.Controllers
{
	public class LocalSignOutController : ApiController
	{
		// GET api/<controller>
		public void Get(string baseUrl, string token)
		{
			
			string responseBody;
			WebHeaderCollection responseHeaders;
			var requestHeaders = new NameValueCollection
			{
				["Authorization"] = $"WRAP access_token=\"{token}\""
			};
			ApiRequest(baseUrl + "Sitefinity/SignOut", out responseBody, out responseHeaders,
				requestHeaders: requestHeaders);

		}

		private HttpStatusCode ApiRequest(string url, out string responseBody, out WebHeaderCollection responseHeaders,
			byte[] data = null, string httpMethod = "GET", string contentType = "", NameValueCollection requestHeaders = null)
		{
			// Create and set the request object
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = httpMethod;
			request.ContentType = contentType;
			request.CookieContainer = new CookieContainer();
			if (requestHeaders != null)
				request.Headers.Add(requestHeaders);

			request.KeepAlive = true;


			if (data != null)
			{
				request.ContentLength = data.Length;
				// Send the data to the request stream
				using (var writer = request.GetRequestStream())
				{
					writer.Write(data, 0, data.Length);
				}
			}

			// Invoke the method and return the response.
			HttpStatusCode statusCode;
			HttpWebResponse response = null;

			try
			{
				response = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
					response = (HttpWebResponse)ex.Response;
			}
			finally
			{
				if (response != null)
				{
					// Read the response
					using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
					{
						responseBody = reader.ReadToEnd();
					}
					responseHeaders = response.Headers;
					statusCode = response.StatusCode;
					response.Close();
				}
				else
				{
					statusCode = HttpStatusCode.InternalServerError;
					responseBody = "";
					responseHeaders = null;
				}
			}
			//SignOut();
			return statusCode;
		}
	}
}