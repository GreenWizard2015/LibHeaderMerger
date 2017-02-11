using System;
using System.IO;

namespace CORE {
  internal class CResolvedInclude {
    private readonly CIncludeDirective _include;
    private readonly CPath _path;

    public bool isRelative {
      get { return _include.isRelative; }
    }

    public CResolvedInclude(CIncludeDirective include, CPath root) {
      _include = include;

      var name = _include.Name;
      _path = _include.isRelative ? root.resolve(name) : new CPath(name);
    }

    public string Name {
      get { return _include.Name; }
    }
    public string FullPath {
      get {
        return _path.Normalized;
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
      } catch(Exception e) {
        return incDirective + " // <= " + e.Message;
      }
    }

    public string content() {
      var res = "";
      try {
        if (_include.isRelative) res = File.ReadAllText(FullPath);
      } catch {}
      return res;
    }
  }
}