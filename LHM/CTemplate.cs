using System;
using System.IO;
using CORE;

namespace LHM {
	public class CTemplate {
		private readonly CPath _destDir;
		private readonly CFileEntry _file;

		public CTemplate(CPath destDir, CFileEntry file) {
			_destDir = destDir;
			_file = file;
		}

		public string Name {
			get { return _file.Name; }
		}

		public string content() {
			return _file.content();
		}

		public void put(string _content) {
			var destPath = _destDir.resolve(_file.Name).changeExtension(".h");
			System.IO.Directory.CreateDirectory(destPath.parent().Normalized);

			var oldContent = _file.content();
			if(!_content.Equals(oldContent))
				File.WriteAllText(destPath.Normalized, _content);
		}

		public CPath Directory() {
			return _file.Dir;
		}
	}
}