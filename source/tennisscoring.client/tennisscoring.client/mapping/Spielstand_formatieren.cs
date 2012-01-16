using System;
using System.Collections.Generic;

using tennisscoring.scoring;

namespace tennisscoring.client.mapping
{
	class Spielstand_formatieren
	{
		public void Process(Spielstand spielstand)
		{
			Result(new[]{string.Format("  {0} : {1}", spielstand.SpielerAPunkte, spielstand.SpielerBPunkte)});
		}
		
		public event Action<IEnumerable<string>> Result;
	}
}

