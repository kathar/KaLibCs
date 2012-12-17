using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace KaLib.WinForm
{
	/// <summary>
	/// Windows Form アプリで MVC パターンで構築する際、<br />
	/// View はこのクラスを継承すること。
	/// </summary>
	public class KaView : KaMvcBase
	{
		public Form mainForm { get; protected set; }

		protected override void init()
		{
			base.init();

			mainForm = new Form();

			// デフォルト設定
			/// サイズ関係
			mainForm.Width = KaWinDefVals.WinW;
			mainForm.Height = KaWinDefVals.WinH;
			/// 色関係
			mainForm.BackColor = KaWinDefVals.BgColor;
			mainForm.ForeColor = KaWinDefVals.ForeColor;
		}
	}
}
