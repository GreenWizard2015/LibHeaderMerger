using System.Collections.Generic;
using System.Linq;

namespace CORE {
	internal class CIncludedHeadersList {
		private readonly List<string> _list;

		public CIncludedHeadersList() {
			_list = new List<string>();
		}

		public bool isIgnore(CResolvedInclude inc) {
			var path = inc.FullPath;
			if(_list.Any(x => x == path))
				return true;

			_list.Add(path);
			return false;
		}
	}
}