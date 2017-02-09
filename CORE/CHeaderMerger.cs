using System.Collections.Generic;

namespace CORE {
  public class CHeaderMerger {
    private readonly IList<CFileEntry> _headers;

    public CHeaderMerger(IList<CFileEntry> headers) {
      _headers = headers;
    }

    public string process(string content) {
      return "NotImplemented";
    }
  }
}
