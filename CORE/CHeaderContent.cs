using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CORE {
  internal class CHeaderContent {
    private readonly string _content;

    public CHeaderContent(string content) {
      _content = content;
    }

    private const string INCLUDE_RE =
      @"^\#include\s+(" +
        "([\\<\"])" + // 2
        "(.+?)" + // 3
        "[\\>\"]" +
      ")";

    public IList<CIncludeDirective> Includes() {
      var RE = new Regex(INCLUDE_RE, RegexOptions.Multiline);
      var res = new List<CIncludeDirective>();
      foreach (Match match in RE.Matches(_content)) {
        var type = match.Groups[2].Value;
        var name = match.Groups[3].Value;
        res.Add(new CIncludeDirective(type == "<", name));
      }
      return res;
    }
  }
}