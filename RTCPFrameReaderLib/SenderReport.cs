using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public record SenderReport : RTCP
	{
		public SenderInfo SenderInfo
		{
			get;
			private set;
		}

		public ReceptionReport[] ReceptionReports
		{
			get;
			private set;
		}

		public SenderReport(RTCPHeader Header,SenderInfo SenderInfo, ReceptionReport[] ReceptionReports) : base(Header)
		{
			this.SenderInfo= SenderInfo;this.ReceptionReports= ReceptionReports; 
		}

	}
}
