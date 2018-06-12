using System;
using High10.CustomControls;

namespace High10.iOS.Controls
{
	public class FastCellCache : IFastCellCache
	{
		
		static FastCellCache _instance;

		public static FastCellCache Instance { 
			get { 
				if (_instance == null) {
					_instance = new FastCellCache ();
				}
				return _instance; 
			} 
		}

		public FastCellCache ()
		{
		}

		#region IFastCellCache implementation

		public void FlushAllCaches ()
		{
		}

		#endregion
	}
}

