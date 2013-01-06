using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ka
{
	public static class KaExtensionForImage
	{
		public static Image KaMagnify(
			this Image self,
			int rate,
			InterpolationMode im = InterpolationMode.Default )
		{
			if ( !self.KaIs() )
			{
				return null;
			}

			var src = self.Clone() as Image;
			var w = src.Width * rate;
			var h = src.Height * rate;

			var res = new Bitmap( w, h );

			Graphics g = null;
			using ( g = Graphics.FromImage( res ) )
			{
				g.InterpolationMode = im;
				g.DrawImage( src, 0, 0, w, h );
			}

			return res;
		}
	}
}
