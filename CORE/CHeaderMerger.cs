using System.Collections.Generic;
using System.Linq;

namespace CORE {
  public class CHeaderMerger {
    private readonly IList<CFileEntry> _headers;
    //private List<CParsedHeaders> _parsedHeaders;
    public CHeaderMerger(IList<CFileEntry> headers) {
      _headers = headers;
    }

    public string process(string content, CPath root) {
      var includes = new CHeaderContent(content)
        .Includes()
        .Select(x => new CResolvedInclude(x, root));

      return string.Join("\n", includes.Select(x => x.Expand()));
    }
  }
}
