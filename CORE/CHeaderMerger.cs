using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CORE {
  public class CHeaderMerger {
    private readonly IList<CFileEntry> _headers;
    //private List<CParsedHeaders> _parsedHeaders;
    private const string INCLUDE_RE =
      @"^\#include\s+(" + 
        "([\\<\"])" + // 2
        "(.+?)" + // 3
        "[\\>\"]" +
      ")";

    public CHeaderMerger(IList<CFileEntry> headers) {
      _headers = headers;
    }

    private IList<CIncludeDirective> getIncludes(string content) {
      var RE = new Regex(INCLUDE_RE, RegexOptions.Multiline);
      var res = new List<CIncludeDirective>();
      foreach (Match match in RE.Matches(content)) {
        var type = match.Groups[2].Value;
        var name = match.Groups[3].Value;
        res.Add(new CIncludeDirective(type == "<", name));
      }
      return res;
    }

    public string process(string content, CPath root) {
      var includes = getIncludes(content)
        .Select(x => new CResolvedInclude(x, root));

      return string.Join("\n", includes.Select(x => x.FullPath));
    }
  }
}
