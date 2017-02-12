using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE {
  public class CHeaderMerger {
    public CHeaderMerger() {
    }

    public string process(string content, CPath root) {
      var res = new StringBuilder();
      var header = new CHeaderContent(content);
      var includedAlready = new CIncludedHeadersList();

      foreach(var part in header.split(root)) {
        if(part.isCode) {
          res.AppendLine(part.Line());
          continue;
        }

        var include = part.Include();
        foreach(var subline in processInclude(include, includedAlready)) {
          var isGood = !subline.StartsWith("#pragma once", 
            StringComparison.OrdinalIgnoreCase);
          if(isGood)
             res.AppendLine(subline);
        }
      }

      return res.ToString();
    }

    private IEnumerable<string> processInclude
      (CResolvedInclude mainHeader,  CIncludedHeadersList includedAlready) 
    {
      if(includedAlready.isIgnore(mainHeader))
        yield break;

      if (!mainHeader.Openable) {
        yield return mainHeader.asDirective();
        yield break;
      }
      
      yield return ("// " + mainHeader.Name);

      var header = mainHeader.Header();
      foreach(var part in header.split()) {
        if(part.isCode) {
          yield return part.Line();
        } else {
          var sublines = processInclude(part.Include(), includedAlready);
          foreach (var line in sublines) {
            yield return line;
          }
        }
      }
      yield return ("// end of " + mainHeader.Name);
    }
  }
}
