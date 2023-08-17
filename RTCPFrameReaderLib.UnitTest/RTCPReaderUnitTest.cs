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
			Assert.ThrowsException<ArgumentNullException>(() => reader.Read(null));
		}
		[TestMethod]
		public void ShouldCheckIfDataIsTooSmall()
		{
			RTCPReader reader;

			reader = new RTCPReader();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => reader.Read(Consts.RTCPTooSmall));
		}//*/
		/*[TestMethod]
		public void ShouldCheckIfDataSizeIsMultipleOf32()
		{
			RTCPReader reader;

			reader = new RTCPReader();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => reader.Read(Consts.RTCPInvalidSize));
		}//*/
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
			Assert.AreEqual(0xe888560bb38cc9a7, RTCP.SenderInfo.NTPTimeStamp);
			Assert.AreEqual(44812u, RTCP.SenderInfo.RTPTimeStamp);
			Assert.AreEqual(247u, RTCP.SenderInfo.SenderPacketCount);
			Assert.AreEqual(39520u, RTCP.SenderInfo.SenderOctetCount);

		}

	}
}