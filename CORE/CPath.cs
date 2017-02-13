using System;
using System.IO;

namespace CORE {
	public class CPath {
		private readonly Uri _path;

		public CPath(string path) {
			 _path = new Uri(Normalize(path), UriKind.RelativeOrAbsolute);
		}

		private CPath(Uri path) {
			_path = path;
		}
		
		private static string Normalize(string p) {
			return p.Replace('/', Path.DirectorySeparatorChar);
		}

		public string Normalized {
			get { return _path.OriginalString; }
		}

		public bool isFolder {
			get {
				var sep = Path.DirectorySeparatorChar.ToString();
				return Normalized.EndsWith(sep);
			}
		}

		public CPath resolve(string relativePath) {
			var path = new Uri(relativePath, UriKind.Relative);
			var comb = new Uri(_path, path);
			return new CPath(comb);
		}

		public CPath parent() {
			return new CPath(new Uri(_path, isFolder ? ".." : "."));
		}

		public CPath asFolder() {
			var folder = Normalized;
			var seps = new[] {
				Path.DirectorySeparatorChar.ToString(), 
				Path.AltDirectorySeparatorChar.ToString()
			};

			foreach(var s in seps) {
				if(folder.EndsWith(s))
					return this;
			}
			foreach(var s in seps) {
				if(folder.Contains(s))
					return new CPath(folder + s);
			}
			throw new Exception("wtf");
		}

		public CPath relativeTo(CPath other) {
			return new CPath(other._path.MakeRelativeUri(_path));
		}

		public CPath changeExtension(string newExt) {
			var name = Path.GetFileName(Normalized);
			var dotPos = name.IndexOf('.');
			if (dotPos > 0)
				name = name.Substring(0, dotPos);
			return parent().resolve(name + newExt);
		}
	}
}
