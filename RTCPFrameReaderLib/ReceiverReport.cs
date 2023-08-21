using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPFrameReaderLib
{
	public record ReceiverReport : RTCP
	{
		public ReportHeader Header
		{
			get;
			private set;
		}


		public ReceptionReport[] ReceptionReports
		{
			get;
			private set;
		}

		public ReceiverReport(ReportHeader Header, ReceptionReport[] ReceptionReports) : base()
		{
			this.Header = Header; this.ReceptionReports= ReceptionReports; 
		}

	}
}
