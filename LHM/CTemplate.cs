using System;
using CORE;

namespace LHM {
  public class CTemplate {
    private readonly CFileEntry _file;

    public CTemplate(string dest, CFileEntry file) {
      _file = file;
    }

    public string content() {
      return _file.content();
    }

    public void put(string content) {
      throw new NotImplementedException();
    }

    public CPath Directory() {
      return _file.Dir;
    }
  }
}