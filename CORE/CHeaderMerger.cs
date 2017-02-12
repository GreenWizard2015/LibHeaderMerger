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
      foreach(var part in header.split(root)) {
        if(part.isCode) {
          res.AppendLine(part.Code());
          continue;
        }

        var include = part.Include();
        var path = include.FullPath;
        if(includedAlready.Any(x => x == path))
          continue;

        includedAlready.Add(path);
        if(include.isRelative) {
          res.AppendLine(processInclude(include, includedAlready));
        } else {
          res.AppendLine(include.asDirective());
        }
      }

      return res.ToString();
    }

    private string processInclude
      (CResolvedInclude include,  List<string> includedAlready) {
      var header = include.Header();
      var res = new StringBuilder();
      res.AppendLine("// " + include.Name);

      foreach(var part in header.split()) {
        if(part.isCode) {
          res.AppendLine(part.Code());
          continue;
        }

        var inc = part.Include();
        var path = inc.FullPath;
        if(includedAlready.Any(x => x == path))
          continue;

        includedAlready.Add(path);
        var code = inc.isRelative ? 
          processInclude(inc, includedAlready): inc.asDirective();

        res.AppendLine(code.TrimEnd(' ', '\n', '\r', '\t', ' '));
      }
      res.AppendLine("// end of " + include.Name);
      return res.ToString();
    }
  }
}
