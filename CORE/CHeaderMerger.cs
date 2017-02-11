using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE {
  public class CHeaderMerger {
    public CHeaderMerger() {
    }

    public string process(string content, CPath root) {
      var header = new CHeaderContent(content);
      var res = new StringBuilder();
      var includedAlready = new List<string>();
      foreach (var part in header.split(root)) {
        if (part.isCode) {
          res.AppendLine(part.Code());
          continue;
        }

        var include = part.Include();
        var path = include.FullPath;
        if(includedAlready.Any(x => x == path))
          continue;

        includedAlready.Add(path);
        if(include.isRelative) {
          res.AppendLine("///////////////////");
          res.AppendLine("// " + include.Name);
          res.AppendLine("///////////////////");
          res.AppendLine(include.content());
          var inc = new CHeaderContent(include.content());
        } else {
          res.AppendLine(include.Expand());
        }
      }

      return res.ToString();
    }
  }
}
