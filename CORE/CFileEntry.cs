using System.IO;

namespace CORE {
  public class CFileEntry {
    private readonly string _fullName;
    public string Name { get; private set; }

    public CFileEntry(string folder, string fullName) {
      _fullName = fullName.ToLower();
      Name = _fullName.Substring(folder.Length);
    }

    public string content() {
      return File.ReadAllText(_fullName);
    }
  }
}