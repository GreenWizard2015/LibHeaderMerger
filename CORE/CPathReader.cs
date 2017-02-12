using System;
using System.IO;

namespace CORE {
  internal class CPathReader {
    private readonly CPath _file;

    public CPathReader(CPath file) {
      _file = file;
    }

    public CPath Directory {
      get { return _file.parent(); }
    }

    public string content() {
      try {
        return File.ReadAllText(_file.Normalized);
      } catch (Exception) {
        return "";
      }
    }
  }
}