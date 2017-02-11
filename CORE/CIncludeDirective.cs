namespace CORE {
  public class CIncludeDirective {
    public readonly string Name;
    public readonly bool isRelative;

    public CIncludeDirective(bool isAbsolute, string name) {
      Name = name;
      isRelative = !isAbsolute;
    }

    public string Include {
      get {
        var format = isRelative ? "\"{0}\"" : "<{0}>";
        return "#include " + string.Format(format, Name);
      }
    }
  }
}