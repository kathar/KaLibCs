using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ka.WinForm
{
	/// <summary>
	/// Windows Form アプリで MVC パターンで構築する際、<br />
	/// Controller はこのクラスを継承すること。
	/// </summary>
	public class KaController : KaMvcBase
	{
		public ApplicationContext ac { get; protected set; }

		protected override void init()
		{
			base.init();

			ac = new ApplicationContext();
			ac.MainForm = view.mainForm;
		}
	}
}
