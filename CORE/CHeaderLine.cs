namespace CORE {
	internal class CHeaderLine {
		private readonly CResolvedInclude _include;
		private readonly string _code;
		public readonly bool isCode;

		public CHeaderLine(string code) {
			_code = code;
			isCode = true;
		}

		public CHeaderLine(CResolvedInclude include) {
			_include = include;
			isCode = false;
		}

		public string Line() {
			return _code;
		}

		public CResolvedInclude Include() {
			return _include;
		}
	}
}