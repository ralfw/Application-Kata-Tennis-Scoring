using System;
using System.Collections.Generic;

using tennisscoring.scoring;

namespace tennisscoring.client.mapping
{
	class Spielstand_formatieren
	{
		public void Process(string spielstand)
		{
			Result(new[]{string.Format("  {0}", spielstand)});
		}
		
		public event Action<IEnumerable<string>> Result;
	}
}

