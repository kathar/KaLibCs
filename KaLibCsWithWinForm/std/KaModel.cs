using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaLib.WinForm
{
	/// <summary>
	/// Windows Form アプリで MVC パターンで構築する際、<br />
	/// Model はこのクラスを継承すること。
	/// </summary>
	public class KaModel : KaMvcBase
	{
		protected override void init()
		{
			base.init();
		}
	}
}
