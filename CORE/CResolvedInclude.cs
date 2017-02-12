using System;
using System.IO;

namespace CORE {
	internal class CResolvedInclude {
		private readonly CIncludeDirective _include;
		private readonly CPath _path;

		public bool isRelative {
			get { return _include.isRelative; }
		}

		public CResolvedInclude(CIncludeDirective include, CPath root) {
			_include = include;

			var name = _include.Name;
			_path = _include.isRelative ? root.resolve(name) : new CPath(name);
		}

		public string Name {
			get { return _include.Name; }
		}
		public string FullPath {
			get {
				return _path.Normalized;
			}
		}

		public bool Openable {
			get {
				try {
					return isRelative && File.Exists(FullPath);
				} catch (Exception) {
					return false;
				}
			}
		}

		public string asDirective() {
			return _include.Include;
		}

		public CHeaderFile Header() {
			return new CHeaderFile(_path);
		}
	}
}