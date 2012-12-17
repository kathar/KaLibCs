using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaLib.WinForm
{
	/// <summary>
	/// Windows Form アプリのデフォルト値を設定する。
	/// </summary>
	public static class KaWinDefVals
	{
		public static readonly int WinW = 960;
		public static readonly int WinH = 720;
		public static readonly Color BgColor = KaColor.FormHex( 0x333333 );
		public static readonly Color ForeColor = KaColor.FormHex( 0xffffff );
	}
}
