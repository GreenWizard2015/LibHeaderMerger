﻿using System;
using System.Linq;
using CORE;

namespace LHM {
  class Program {
    static void Main(string[] args) {
      try {
        var param = CParameters.from(args);
        if(null == param) {
          // show help
        } else {
          doWork(param);
          Console.WriteLine("Done.");
        }
      } catch (Exception e) {
        Console.WriteLine(e.ToString());
      }
      Console.ReadLine();
    }

    private static void doWork(CParameters param) {
      var headers = param.Headers();
      var merger = new CHeaderMerger(headers);
      var templates = param.Templates(param.Dest);
      var N = templates.Count;
      foreach (var i in Enumerable.Range(0, N)) {
        Console.WriteLine(String.Format("Processing {0}/{1}", 1 + i, N));
        var template = templates[i];
        var result = merger.process(template.content(), "");
        template.put(result);
      }
    }
  }
}
