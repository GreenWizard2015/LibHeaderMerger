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
  }
}