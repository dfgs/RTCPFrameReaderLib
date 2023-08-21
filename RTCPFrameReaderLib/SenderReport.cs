using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public record SenderReport : RTCP
	{
		public ReportHeader Header
		{
			get;
			private set;
		}

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

		public SenderReport(ReportHeader Header,SenderInfo SenderInfo, ReceptionReport[] ReceptionReports) : base()
		{
			this.Header = Header; this.SenderInfo= SenderInfo;this.ReceptionReports= ReceptionReports; 
		}

	}
}
