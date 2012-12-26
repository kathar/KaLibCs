using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ka.WinForm
{
	public class KaColor
	{
		/// <summary>
		/// 16進数カラーコードから Color 構造体を生成。
		/// </summary>
		/// <param name="hexColorCode"></param>
		/// <returns></returns>
		public static Color FormHex( uint hexColorCode )
		{
			if ( hexColorCode < 0 || hexColorCode > 16777215 )
			{
				return Color.Black;
			}

			var r = hexColorCode & 0xff;
			var g = ( hexColorCode >> 8 ) & 0xff;
			var b = ( hexColorCode >> 16 ) & 0xff;

			return Color.FromArgb( ( int )r, ( int )g, ( int )b );
		}
	}
}
