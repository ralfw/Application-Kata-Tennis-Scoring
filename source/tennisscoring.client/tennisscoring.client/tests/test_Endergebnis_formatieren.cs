using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using tennisscoring.client.mapping;

namespace tennisscoring.client
{
	[TestFixture()]
	public class test_Endergebnis_formatieren
	{
		[Test()]
		public void Process ()
		{
			var sut = new Endergebnis_formatieren();
			
			IEnumerable<object> results = null;
			sut.Result += _ => results = _;
			sut.Process(new[]{"Setgewinn:0", "Setgewinn:1", "Setgewinn:0"});
			
			Assert.That(results.ToArray(),
			            Is.EqualTo(new[]{"", "Winner: Player A with 2 : 1", ""}));
		}
	}
}

