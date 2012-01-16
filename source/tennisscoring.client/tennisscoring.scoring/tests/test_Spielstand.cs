using System;
using NUnit.Framework;

//namespace tennisscoring.scoring
//{
//	[TestFixture()]
//	public class test_Spielstand
//	{
//		[Test()]
//		public void Parse()
//		{
//			var st = Spielstand.Parse("Thirty:Forty");
//			Assert.AreEqual(Spielpunkte.Thirty, st.SpielerAPunkte);
//			Assert.AreEqual(Spielpunkte.Forty, st.SpielerBPunkte);
//		}
//		
//		[Test()]
//		public void Parse_with_whitespace()
//		{
//			var st = Spielstand.Parse(" Love :  Winner  ");
//			Assert.AreEqual(Spielpunkte.Love, st.SpielerAPunkte);
//			Assert.AreEqual(Spielpunkte.Winner, st.SpielerBPunkte);
//		}
//
//		[Test()]
//		public void Parse_caseinsensitive()
//		{
//			var st = Spielstand.Parse(" fifteen :  deuce  ");
//			Assert.AreEqual(Spielpunkte.Fifteen, st.SpielerAPunkte);
//			Assert.AreEqual(Spielpunkte.Deuce, st.SpielerBPunkte);
//		}
//		
//		[Test()]
//		public void To_string()
//		{
//			var sut = new Spielstand{SpielerAPunkte=Spielpunkte.Fifteen, SpielerBPunkte=Spielpunkte.Love};
//			Assert.AreEqual("Fifteen:Love", sut.ToString());
//		}
//	}
//}

