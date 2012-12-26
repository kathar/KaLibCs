using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka;

namespace ka.WinForm
{
	public static class KaControls
	{
		public static void KaAdd<T>(
			this Control.ControlCollection self,
			List<T> list )
		{
			if ( list.KaIs() )
			{
				new ArgumentNullException();
			}

			if ( typeof( T ).BaseType != typeof( Control ) )
			{
				new TypeAccessException();
			}

			foreach ( var l in list )
			{
				self.Add( l as Control );
			}
		}
	}
}
