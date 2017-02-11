using System.Collections.Generic;

namespace CORE {
  internal class CHeaderFile {
    private readonly CFileEntry _file;

    public CHeaderFile(CFileEntry file) {
      _file = file;
    }

    public IList<CResolvedInclude> Includes() {
      var header = new CHeaderContent(_file.content());
      return header.Includes(_file.Dir);
    }
  }
}