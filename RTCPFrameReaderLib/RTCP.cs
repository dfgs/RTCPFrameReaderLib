namespace RTCPFrameReaderLib
{
	public abstract record RTCP
	{
		public RTCPHeader Header
		{
			get;
			private set;
		}
		

		public RTCP( RTCPHeader Header)
		{
			this.Header = Header;
		}
	}
}