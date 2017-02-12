using System;
using System.Linq;
using CORE;

namespace LHM {
	class Program {
		static void Main(string[] args) {
			try {
				var param = CParameters.from(args);
				if(null == param) {
					showHelp();
				} else {
					doWork(param);
					Console.WriteLine("Done.");
				}
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
			Console.ReadLine();
		}

		private static void showHelp() {
			Console.WriteLine("Read source code! :-)");
		}

		private static void doWork(CParameters param) {
			var merger = new CHeaderMerger();
			var templates = param.Templates();
			foreach (var templ in templates) {
				Console.WriteLine(String.Format("Processing... {0}", templ.Name));
				var result = merger.process(templ.content(), templ.Directory());
				templ.put(result);
			}
		}
	}
}
