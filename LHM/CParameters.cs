﻿using System.Collections.Generic;
using System.Linq;
using CORE;

namespace LHM {
	internal class CParameters {
		private readonly CSourceLocator sourceLocator;
		public readonly string Dest;

		private CParameters(string source, string dest) {
			sourceLocator = new CSourceLocator(source);
			Dest = dest;
		}

		public static CParameters from(string[] args) {
			// add checks
			return new CParameters(args[0], args[1]);
		}

		public IList<CTemplate> Templates(string dest) {
			return sourceLocator.Templates()
				.Select(x => new CTemplate(dest, x))
				.ToList();
		}
	}
}