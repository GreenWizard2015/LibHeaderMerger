using System;
using System.Collections.Generic;
using System.Linq;
using CORE;

namespace LHM {
	internal class CParameters {
		private readonly CSourceLocator _sourceLocator;
		private readonly CPath _dest;

		private CParameters(string source, string dest) {
			var current = new CPath(Environment.CurrentDirectory);
			_sourceLocator = new CSourceLocator(current.resolve(source));
			_dest = current.resolve(dest).asFolder();
		}

		public static CParameters from(string[] args) {
			// add checks
			return new CParameters(args[0], args[1]);
		}

		public IList<CTemplate> Templates() {
			return _sourceLocator.Templates()
				.Select(x => new CTemplate(_dest, x))
				.ToList();
		}
	}
}