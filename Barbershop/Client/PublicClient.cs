public class PublicClient
{
	public HttpClient client { get; }
	public PublicClient (HttpClient httpClient) { client = httpClient; }	
}