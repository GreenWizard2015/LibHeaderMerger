using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CORE {
	internal class CHeaderContent {
		private readonly string _content;

		public CHeaderContent(string content) {
			_content = content;
		}

		private const string INCLUDE_RE =
			@"^\#include\s+(" +
				"([\\<\"])" + // 2
				"(.+?)" + // 3
				"[\\>\"]" +
			")";
		private static readonly Regex RE = 
			new Regex(INCLUDE_RE, RegexOptions.Compiled);

		public IEnumerable<CHeaderLine> split(CPath root) {
			var lines = _content
				.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

			foreach (var line in lines) {
				var match = RE.Match(line);
				if (!match.Success) {
					yield return new CHeaderLine(line);
					continue;
				}

				var type = match.Groups[2].Value;
				var name = match.Groups[3].Value;
				var include = new CIncludeDirective(type == "<", name);
				var resolved = new CResolvedInclude(include, root);
				yield return new CHeaderLine(resolved);
			}
		}
	}
}