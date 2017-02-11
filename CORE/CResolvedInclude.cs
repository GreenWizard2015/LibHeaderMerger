using System;
using System.IO;

namespace CORE {
  internal class CResolvedInclude {
    private readonly CIncludeDirective _include;
    private readonly CPath _relDir;

    public CResolvedInclude(CIncludeDirective include, CPath relDir) {
      _include = include;
      _relDir = relDir;
    }

    public string Name {
      get { return _include.Name; }
    }

    public string FullPath {
      get {
        return _relDir.resolve(_include.Name).Normalized;
      }
    }

    public string Expand() {
      var incDirective = _include.Include;
      if (!_include.isRelative) {
        return incDirective;
      }

      try {
        var content = File.ReadAllText(FullPath);
        return string.Format("//{0}\n{1}", incDirective, content);
      } catch (Exception e) {
        return incDirective + " // <= " + e.Message;
      }
    }
  }
}