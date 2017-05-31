using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace SFWinformsClient
{
	public partial class RESTfulClientSimple : Form
	{

		private string _token;
		

		#region initialize

		public RESTfulClientSimple()
		{
			InitializeComponent();
		}

		#endregion

		private void SignOut()
		{
			if (_token == null) return;

			var baseUrl = txtBaseUrl.Text;
			string responseBody;
			WebHeaderCollection responseHeaders;
			var requestHeaders = new NameValueCollection
			{
				["Authorization"] = $"WRAP access_token=\"{_token}\""
			};
			Request(baseUrl + "Sitefinity/SignOut", out responseBody, out responseHeaders,
				requestHeaders: requestHeaders);
		}

		
		private HttpStatusCode Request(string url, out string responseBody, out WebHeaderCollection responseHeaders,
			byte[] data = null, string httpMethod = "GET", string contentType = "", NameValueCollection requestHeaders = null)
		{
			// Create and set the request object
			var request = (HttpWebRequest) WebRequest.Create(url);
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
				response = (HttpWebResponse) request.GetResponse();
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
					response = (HttpWebResponse) ex.Response;
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

		private void btnListData_Click(object sender, EventArgs e)
		{
			var baseUrl = txtBaseUrl.Text;

			#region generate auth token

			//sign the user out first to avoid any unauthed errors
			SignOut();

			//authenticate with the service and get a token back
			// we first have to determine the configured authentication method
			var authUrl = baseUrl + "Sitefinity/Authenticate";
			string response;
			var username = txtUsername.Text;
			var password = txtPassword.Text;

			WebHeaderCollection headers;
			var statusCode = Request(authUrl, out response, out headers);
			if (statusCode == HttpStatusCode.OK)
			{
				var formData = $"wrap_name={username}&wrap_password={password}";
				var bytes = Encoding.UTF8.GetBytes(formData);
				var responseCode = Request(authUrl + "/SWT", out response, out headers, bytes, "POST",
					"application/x-www-form-urlencoded");

				if (responseCode == HttpStatusCode.OK)
				{
					// we expect WRAP formatted response which is the same as query string
					var nameValueColl = HttpUtility.ParseQueryString(response);
					_token = nameValueColl["wrap_access_token"];
				}
				if (responseCode == HttpStatusCode.Unauthorized)
				{
					MessageBox.Show(@"invalid credentials");
					return;
				}
			}
			else
			{
				MessageBox.Show(@"unable to authenticate with Sitefinity");
				return;
			}

			#endregion

			#region call the service to get the data

			var url = baseUrl + txtServiceUrl.Text;
			WebHeaderCollection responseHeaders;

			// NOTE: in this example we are going to add the bootstrap security token with every request, however bootstrap security tokens require
			// a bit more processing on the server then session security tokens. When you make a request providing a bootstrap token, 
			// Sitefinity will add session token in the response cookies collection. Cookies with FedAuth in the name comprise the session token.
			var requestHeaders = new NameValueCollection
			{
				["Authorization"] = $"WRAP access_token=\"{_token}\""
			};

			// We could check if the token is close to expire and we can renew it in advance or alternatively we could catch the error response.
			// In general the first approach is more efficient but for the sake of demoing we will use the second one.    
			string responseBody;
			var serviceResponseCode = Request(url, out responseBody, out responseHeaders, null, "GET", "application/json",
				requestHeaders);
			switch (serviceResponseCode)
			{
				case HttpStatusCode.OK:
					break;
				case HttpStatusCode.Unauthorized:
					MessageBox.Show(@"Unauthorized service call");
					break;
				case HttpStatusCode.Forbidden:
					MessageBox.Show(@"forbidden service call");
					if (responseHeaders["X-Authentication-Error"] == "UserAlreadyLoggedIn")
						MessageBox.Show(
							@"Someone is already using this username and password from another computer or browser. To proceed, you need to log him/her off.");
					break;
				default:
					MessageBox.Show(@"Error calling service http code " + serviceResponseCode);
					break;
			}
			txtResults.Text = responseBody;

			#endregion

		}

		private void RESTfulClientSimple_FormClosed(object sender, FormClosedEventArgs e)
		{
			SignOut();
		}
	}
}