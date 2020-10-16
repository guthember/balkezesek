using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
  class Jatekos
  {
    public string Nev { get; private set; }
    public string Elso { get; private set; }
    public string Utolso { get; private set; }
    public int Suly { get; private set; }
    public int Magassag { get; private set; }

    public Jatekos(string nev, string elso, string utolso, 
      int suly, int mag)
    {
      this.Nev = nev;
      this.Elso = elso;
      this.Utolso = utolso;
      this.Suly = suly;
      this.Magassag = mag;
    }

  }
}
