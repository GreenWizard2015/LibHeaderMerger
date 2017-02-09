using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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
      foreach (var template in templates) {
        var result = merger.process(template.content());
        template.put(result);
      }
    }
  }
}
