using System.IO;
using System.Runtime.InteropServices;

namespace CORE {
	public class CFileEntry {
		private readonly CPath _path;
		public string Name { get; private set; }

		public CPath Dir {
			get { return _path.parent(); }
		}

		public string FullName {
			get { return _path.Normalized; }
		}

		public CFileEntry(CPath path, string relName) {
			_path = path.resolve(relName);
			Name = _path.relativeTo(path).Normalized;
		}

		public string content() {
			var path = _path.Normalized;
			var exist = File.Exists(path);
			return exist ? File.ReadAllText(path) : "";
		}
	}
}