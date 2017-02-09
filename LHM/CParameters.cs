using System;
using System.Collections;
using System.Collections.Generic;
using CORE;

namespace LHM {
  internal class CParameters {
    public readonly string Source;
    public readonly string Dest;

    private CParameters(string source, string dest) {
      Source = source;
      Dest = dest;
    }

    public static CParameters from(string[] args) {
      // add checks
      return new CParameters(args[0], args[1]);
    }

    public IList<CBaseHeader> Headers() {
      throw new NotImplementedException();
    }

    public IList<CTemplate> Templates(string dest) {
      throw new NotImplementedException();
    }
  }
}