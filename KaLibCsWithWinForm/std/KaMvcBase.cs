using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaLib.WinForm
{
	/// <summary>
	/// 各 MVC クラスの親クラス。
	/// </summary>
	public class KaMvcBase
	{
		public static KaModel m;
		public static KaView v;
		public static KaController c;

		/// <summary>
		/// MVC インスタンスをセット。<br />
		/// インスタンスは各クラスで共有される。
		/// </summary>
		/// <param name="model"></param>
		/// <param name="view"></param>
		/// <param name="controller"></param>
		public static void setMvc(
			KaModel model,
			KaView view,
			KaController controller )
		{
			m = model;
			v = view;
			c = controller;
		}

		/// <summary>
		/// 初期化メソッド。
		/// </summary>
		/// <remarks>
		/// KaMvcMgr.run 経由で実行した場合は、<br />
		/// model, view contrller の順で呼ばれる。
		/// </remarks>
		protected virtual void init() { }
	}
}
