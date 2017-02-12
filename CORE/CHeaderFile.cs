using System.Collections.Generic;

namespace CORE {
  internal class CHeaderFile {
    private readonly CPathReader _file;

    public CHeaderFile(CPath file) {
      _file = new CPathReader(file);
    }

    public IList<CHeaderPart> split() {
      var header = new CHeaderContent(_file.content());
      return header.split(_file.Directory);
    }
  }
}