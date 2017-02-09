using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CORE {
  public class CSourceLocator {
    private readonly string _folder;
    private const string TMPL_EXT = "*.t.h";

    public CSourceLocator(string folder) {
      _folder = Path.GetFullPath(folder);
      if (!_folder.EndsWith("\\")) {
        _folder += "\\";
      }
    }

    private IEnumerable<CFileEntry> findAll(string mask) {
      try {
        return Directory
          .GetFiles(_folder, mask, SearchOption.AllDirectories)
          .Select(s => new CFileEntry(_folder, s));
      } catch (Exception) {
        return new List<CFileEntry>();
      }
    }

    public IList<CFileEntry> Templates() {
      return findAll(TMPL_EXT).ToList();
    }

    public IList<CFileEntry> Headers() {
      return findAll("*.H")
        .Where(x => !x.Name.ToLower().EndsWith(TMPL_EXT))
        .ToList();
    }
  }
}
