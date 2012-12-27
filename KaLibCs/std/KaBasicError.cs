using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ka
{
	/// <summary>
	/// 基本的なエラーコードを列挙型で定義
	/// </summary>
	public enum BasicErrorCode_e
	{
		no,
		input,
		file,
		directory,

		unknown
	}

	/// <summary>
	/// 入力に関する詳細なエラーコード
	/// </summary>
	public enum InputErrorCode_e
	{
		no,

		unknown
	}

	/// <summary>
	/// ファイルに関する詳細なエラーコード
	/// </summary>
	public enum FileErrorCode_e
	{
		no,

		unknown
	}

	/// <summary>
	/// ディレクトリに関する詳細なエラーコード
	/// </summary>
	public enum DirectoryErrorCode_e
	{
		no,

		unknown
	}
}
