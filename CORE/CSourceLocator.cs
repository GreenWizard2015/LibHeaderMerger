using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CORE {
	public class CSourceLocator {
		private readonly CPath _folder;
		private const string TMPL_EXT = "*.t.h";

		public CSourceLocator(string folder) {
			_folder = (new CPath(folder)).asFolder();
		}

		private IEnumerable<CFileEntry> findAll(string mask) {
			try {
				return Directory
					.GetFiles(_folder.Normalized, mask, SearchOption.AllDirectories)
					.Select(s => new CFileEntry(_folder, s));
			} catch (Exception) {
				return new List<CFileEntry>();
			}
		}

		public IList<CFileEntry> Templates() {
			return findAll(TMPL_EXT).ToList();
		}
	}
}
