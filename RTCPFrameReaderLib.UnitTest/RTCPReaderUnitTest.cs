using BigEndianReaderLib;

namespace RTCPFrameReaderLib.UnitTest
{
	[TestClass]
	public class RTCPReaderUnitTest
	{
		[TestMethod]
		public void ShouldCheckIfDataIsNull()
		{
			RTCPReader reader;

			reader = new RTCPReader();
			Assert.ThrowsException<ArgumentNullException>(() => reader.Read((byte[])null));
			Assert.ThrowsException<ArgumentNullException>(() => reader.Read((BigEndianReader)null));
		}
		[TestMethod]
		public void ShouldCheckIfDataIsTooSmall()
		{
			RTCPReader reader;

			reader = new RTCPReader();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => reader.Read(Consts.RTCPTooSmall));
		}

		
		[TestMethod]
		public void ShouldReadSenderReport1()
		{
			RTCPReader reader;
			SenderReport? RTCP;

			reader = new RTCPReader();

			RTCP = reader.Read(Consts.SenderReport1) as SenderReport;

			Assert.IsNotNull(RTCP);

			// header
			Assert.AreEqual(2, RTCP.Header.Version);
			Assert.AreEqual(false, RTCP.Header.Padding);
			Assert.AreEqual(1u, RTCP.Header.ReceptionReportCount);
			Assert.AreEqual(PacketTypes.SR, RTCP.Header.PacketType);
			Assert.AreEqual((ushort)12, RTCP.Header.Length);
			Assert.AreEqual(0x5b917d5au, RTCP.Header.SenderSSRC);

			// SenderInfo
			Assert.AreEqual(3901249035u, RTCP.SenderInfo.NTPTimeStampIntegerPart);
			Assert.AreEqual(3012348327u, RTCP.SenderInfo.NTPTimeStampFractionalPart);
			Assert.AreEqual(44812u, RTCP.SenderInfo.RTPTimeStamp);
			Assert.AreEqual(247u, RTCP.SenderInfo.SenderPacketCount);
			Assert.AreEqual(39520u, RTCP.SenderInfo.SenderOctetCount);

			// ReceptionReport
			Assert.AreEqual(1, RTCP.ReceptionReports.Length);
			Assert.AreEqual(2571709637u, RTCP.ReceptionReports[0].SSRC);
			Assert.AreEqual(0, RTCP.ReceptionReports[0].FractionLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].CumulatedPacketLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].SequenceNumberCycles);
			Assert.AreEqual(2173u, RTCP.ReceptionReports[0].HighestSequenceNumberReceived);
			Assert.AreEqual(4u, RTCP.ReceptionReports[0].InterarrivalJitter);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].LastSRTimeStamp);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].DelaySinceLastSRTimeStamp);

		}
		[TestMethod]
		public void ShouldReadSenderReport2()
		{
			RTCPReader reader;
			SenderReport? RTCP;

			reader = new RTCPReader();

			RTCP = reader.Read(Consts.SenderReport2) as SenderReport;

			Assert.IsNotNull(RTCP);

			// header
			Assert.AreEqual(2, RTCP.Header.Version);
			Assert.AreEqual(false, RTCP.Header.Padding);
			Assert.AreEqual(1u, RTCP.Header.ReceptionReportCount);
			Assert.AreEqual(PacketTypes.SR, RTCP.Header.PacketType);
			Assert.AreEqual((ushort)12, RTCP.Header.Length);
			Assert.AreEqual(0x99492cc5, RTCP.Header.SenderSSRC);


			// SenderInfo
			Assert.AreEqual(3901249045u, RTCP.SenderInfo.NTPTimeStampIntegerPart);
			Assert.AreEqual(3138847999u, RTCP.SenderInfo.NTPTimeStampFractionalPart);
			Assert.AreEqual(0x7884a18bu, RTCP.SenderInfo.RTPTimeStamp);
			Assert.AreEqual(748u, RTCP.SenderInfo.SenderPacketCount);
			Assert.AreEqual(119680u, RTCP.SenderInfo.SenderOctetCount);

			// ReceptionReport
			Assert.AreEqual(1, RTCP.ReceptionReports.Length);
			Assert.AreEqual(0x5b917d5au, RTCP.ReceptionReports[0].SSRC);
			Assert.AreEqual(0, RTCP.ReceptionReports[0].FractionLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].CumulatedPacketLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].SequenceNumberCycles);
			Assert.AreEqual(19792u, RTCP.ReceptionReports[0].HighestSequenceNumberReceived);
			Assert.AreEqual(4u, RTCP.ReceptionReports[0].InterarrivalJitter);
			Assert.AreEqual(1444263151u, RTCP.ReceptionReports[0].LastSRTimeStamp);
			Assert.AreEqual(1376u, RTCP.ReceptionReports[0].DelaySinceLastSRTimeStamp);

		}

		[TestMethod]
		public void ShouldReadSourceDescription1()
		{
			RTCPReader reader;
			SourceDescription? RTCP;

			reader = new RTCPReader();

			RTCP = reader.Read(Consts.SourceDescription1) as SourceDescription;

			Assert.IsNotNull(RTCP);

			// header
			Assert.AreEqual(2, RTCP.Header.Version);
			Assert.AreEqual(false, RTCP.Header.Padding);
			Assert.AreEqual(1u, RTCP.Header.SourceCount);
			Assert.AreEqual(PacketTypes.SDES, RTCP.Header.PacketType);
			Assert.AreEqual((ushort)7, RTCP.Header.Length);

			// Chunks
			Assert.AreEqual(1, RTCP.Chunks.Length);
			Assert.AreEqual(0x0ad72405u, RTCP.Chunks[0].SSRC);
			Assert.AreEqual(2, RTCP.Chunks[0].Items.Length);
			Assert.AreEqual(SDESItemTypes.CNAME, RTCP.Chunks[0].Items[0].Type);
			Assert.AreEqual((byte)18, RTCP.Chunks[0].Items[0].Length);
			Assert.AreEqual("sip:2001@10.0.2.11", RTCP.Chunks[0].Items[0].Text);

		}

		[TestMethod]
		public void ShouldReadSourceDescription2()
		{
			RTCPReader reader;
			SourceDescription? RTCP;

			reader = new RTCPReader();

			RTCP = reader.Read(Consts.SourceDescription2) as SourceDescription;

			Assert.IsNotNull(RTCP);

			// header
			Assert.AreEqual(2, RTCP.Header.Version);
			Assert.AreEqual(false, RTCP.Header.Padding);
			Assert.AreEqual(1u, RTCP.Header.SourceCount);
			Assert.AreEqual(PacketTypes.SDES, RTCP.Header.PacketType);
			Assert.AreEqual((ushort)2, RTCP.Header.Length);

			// Chunks
			Assert.AreEqual(1, RTCP.Chunks.Length);
			Assert.AreEqual(0xcf5f7fc1, RTCP.Chunks[0].SSRC);
			Assert.AreEqual(2, RTCP.Chunks[0].Items.Length);
			Assert.AreEqual(SDESItemTypes.CNAME, RTCP.Chunks[0].Items[0].Type);
			Assert.AreEqual((byte)0, RTCP.Chunks[0].Items[0].Length);
			Assert.AreEqual("", RTCP.Chunks[0].Items[0].Text);

		}

		[TestMethod]
		public void ShouldReadReceiverReport1()
		{
			RTCPReader reader;
			ReceiverReport? RTCP;

			reader = new RTCPReader();

			RTCP = reader.Read(Consts.ReceiverReport1) as ReceiverReport;

			Assert.IsNotNull(RTCP);

			// header
			Assert.AreEqual(2, RTCP.Header.Version);
			Assert.AreEqual(false, RTCP.Header.Padding);
			Assert.AreEqual(0u, RTCP.Header.ReceptionReportCount);
			Assert.AreEqual(PacketTypes.RR, RTCP.Header.PacketType);
			Assert.AreEqual((ushort)1, RTCP.Header.Length);
			Assert.AreEqual(0x77a2abdbu, RTCP.Header.SenderSSRC);


			// ReceptionReport
			/*
			Assert.AreEqual(1, RTCP.ReceptionReports.Length);
			Assert.AreEqual(2571709637u, RTCP.ReceptionReports[0].SSRC);
			Assert.AreEqual(0, RTCP.ReceptionReports[0].FractionLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].CumulatedPacketLost);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].SequenceNumberCycles);
			Assert.AreEqual(2173u, RTCP.ReceptionReports[0].HighestSequenceNumberReceived);
			Assert.AreEqual(4u, RTCP.ReceptionReports[0].InterarrivalJitter);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].LastSRTimeStamp);
			Assert.AreEqual(0u, RTCP.ReceptionReports[0].DelaySinceLastSRTimeStamp);*/

		}



	}
}