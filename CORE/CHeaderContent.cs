using System;
using System.Collections;
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

    public IList<CHeaderPart> split(CPath root) {
      var RE = new Regex(INCLUDE_RE, RegexOptions.Multiline);
      var res = new List<CHeaderPart>();
      int lastCodePos = 0;

      Action<int, int> cutCode = (from, to) => {
        var code = _content.Substring(from, to - from);
        if (!string.IsNullOrWhiteSpace(code)) {
          res.Add(new CHeaderPart(code));
        }
      };

      foreach(Match match in RE.Matches(_content)) {
        cutCode(lastCodePos, match.Index);
        
        var type = match.Groups[2].Value;
        var name = match.Groups[3].Value;
        var include = new CIncludeDirective(type == "<", name);
        var resolved = new CResolvedInclude(include, root);
        res.Add(new CHeaderPart(resolved));

        lastCodePos = match.Index + match.Length;// + 1;
      }
      cutCode(lastCodePos, _content.Length);

      return res;
    }
  }

  internal class CHeaderPart {
    private readonly CResolvedInclude _include;
    private readonly string _code;
    public readonly bool isCode;

    public CHeaderPart(string code) {
      _code = code;
      isCode = true;
    }

    public CHeaderPart(CResolvedInclude include) {
      _include = include;
      isCode = false;
    }

    public string Code() {
      return _code;
    }

    public CResolvedInclude Include() {
      return _include;
    }
  }
}