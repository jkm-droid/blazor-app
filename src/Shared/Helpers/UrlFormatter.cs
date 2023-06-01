using Microsoft.AspNetCore.WebUtilities;

namespace BlazorApp.Shared.Helpers
{
  public class UrlFormatter
  {
    private string _baseAddress;
    private Dictionary<string, string> _params = new Dictionary<string, string>();

    /// <summary>
    /// Sets a root url to append query string parameters
    /// </summary>
    public UrlFormatter SetBaseUrl(string url)
    {
      _baseAddress = url;
      return this;
    }

    /// <summary>
    /// Adds a query string parameter with name and value given.
    /// </summary>
    public UrlFormatter AddParameter<TValue>(string name, TValue value)
    {
      _params.TryAdd(name, value?.ToString() ?? string.Empty);
      return this;
    }

    /// <summary>
    /// Overriden. Returns a formatted url.
    /// </summary>
    public override string ToString()
    {
      return QueryHelpers.AddQueryString(_baseAddress, _params);
    }
  }
}
