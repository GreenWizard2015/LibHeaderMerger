﻿using System;
using CORE;

namespace LHM {
	class Program {
		static void Main(string[] args) {
			try {
				var param = CParameters.from(args);
				if(null == param) {
					showHelp();
				} else {
					Console.WriteLine("Start merging headers");

					var start = DateTime.Now;
					doWork(param);
					var elapsed = (DateTime.Now - start).ToString(@"hh\:mm\:ss\.fff");
					Console.WriteLine(string.Format("Done. ({0})", elapsed));
				}
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
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
