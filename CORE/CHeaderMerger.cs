using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE {
  public class CHeaderMerger {
    private readonly IList<CBaseHeader> _headers;

    public CHeaderMerger(IList<CBaseHeader> headers) {
      _headers = headers;
    }

    public string process(string content) {
      throw new NotImplementedException();
    }
  }
}
