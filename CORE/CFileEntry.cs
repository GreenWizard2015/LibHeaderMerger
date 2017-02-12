using System.IO;

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
			return File.ReadAllText(_path.Normalized);
		}
	}
}