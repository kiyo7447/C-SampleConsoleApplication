using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApplication
{
	internal class C_逆引きレシピ
	{
		public static async void Run()
		{
			var c = new C_逆引きレシピ();

			//C#2


			//C#3
			c.初期化子();

			c.匿名型();

			//C#4
			c.名前付き引数_省略可能引数();

			//C#5
			var ret = await c.AsyncAwait();
			Console.WriteLine(ret);

			//C#6
			c.Nameof();

			c.Null条件演算子();

			c.初期化拡張();

			c.例外フィルター();

			c._030_StringFormat();
		}	

		void 初期化子()
		{

		}

		void 匿名型()
		{
			var v = new { Amount = 108, Name = "Hello" };

			Console.WriteLine($"{v.Name}:{v.Amount:D4}");
		}

		void 名前付き引数_省略可能引数()
		{
			FuncParamTest(2);
			FuncParamTest(3,4);
			FuncParamTest(5,6,7);
			FuncParamTest(Y:8);
			FuncParamTest(Z: 9, Y:10);
			/*
名前付き引数_省略可能引数 X=2, Y=2, Z=3
名前付き引数_省略可能引数 X=3, Y=4, Z=3
名前付き引数_省略可能引数 X=5, Y=6, Z=7
名前付き引数_省略可能引数 X=1, Y=8, Z=3
名前付き引数_省略可能引数 X=1, Y=10, Z=9 
			 */
		}

		void FuncParamTest(int X = 1, int Y = 2, int Z = 3, params int[] param)
		{
			Console.WriteLine($"名前付き引数_省略可能引数 X={X}, Y={Y}, Z={Z}");
		}


		async Task<string> AsyncAwait()
		{
			var url = "http://www.s-giken.co.jp";

			var client = new HttpClient();

			var res = await client.GetAsync(url);

			var content = await res.Content.ReadAsStringAsync();

			return content;
		}

		void Nameof()
		{
			var abe = "hgehoge";
			Console.WriteLine(nameof(abe));
		}

		void Null条件演算子()
		{
			Parson p = null;

			Console.WriteLine($"{p?.Name}");
			//空文字を出力


			int?[] i = new int?[] { 0, 1, null };
			//InvalidOutOfRangeExceptionが発生する。
			//Console.WriteLine($"{i?[3]}");

			Console.WriteLine($"{i?[2]}");

			Console.WriteLine($"{i[2]}");

			int[] j = null;//= new int[3];
			Console.WriteLine($"{{j?[2]}}={j?[2]}");
			//'System.NullReferenceException' 
			//Console.WriteLine($"{{j[2]}}={j[2]}");

		}

		class Parson
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		//自動実装プロパティ初期化子
		internal string Name { get; private set; } = "";
		internal int Age { get; set; } = 0;

		void 初期化拡張()
		{
			var dic = new Dictionary<string, string> { ["Hello"] = "Kitty", ["Micky"] = "Mouse" };
			foreach (var key in dic.Keys)
			{
				WriteLine(key + " " + dic[key]);
			}

			//stack拡張
			var stack = new Stack<int> { 1, 2, 3};

			WriteLine(stack.Pop());	//3
			WriteLine(stack.Pop());	//2
			WriteLine(stack.Pop());	//1

			//queue拡張
			var queue = new Queue<int>() {1,2,3};

			WriteLine(queue.Dequeue());	//1
			WriteLine(queue.Dequeue());	//2
			WriteLine(queue.Dequeue());	//3


		}

		void 例外フィルター()
		{
			try
			{
				//--- SQL Serverへのアクセス
			}
			catch (SqlException ex) when (ex.Number == 1205)
			{
				//--- デッドロック
			}
			catch (SqlException ex)
			{
				//--- デッドロック以外のSqlExceptionに関する処理
			}
			catch (Exception ex)
			{
				//--- その他のすべての例外
			}

			try
			{
				//F();
			}
			catch (Exception e) when (e is DirectoryNotFoundException || e is FileNotFoundException)
			{
				// DirectoryNotFoundException のときと FileNotFoundException の時で
				// 全く同じ例外処理の仕方をしたい場合がある。
				Console.WriteLine(e);
			}
		}


		void _030_StringFormat()
		{

			WriteLine(1234.ToString());						//1234
			WriteLine(1234.ToString("D"));                  //1234
			WriteLine(1234.ToString("D8"));                 //00001234
			WriteLine(String.Format("{0,-10:D8}/", 1234));  //00001234  /
			WriteLine(String.Format("{0,10:D8}", 1234));    //  00001234
			WriteLine(1234.ToString("N"));					//1,234.00
			WriteLine(1234.ToString("N0"));					//1,234
			var i = 1234;
			WriteLine($"{i}");                              //1234
			WriteLine($"{i:D}");							//1234
			WriteLine($"{i:D8}");							//00001234
			WriteLine($"{i,-10:D8}/");						//00001234  /
			WriteLine($"{i,10:D8}");						//  00001234
			WriteLine($"{i:N}");							//1,234.00
			WriteLine($"{i:N0}");                           //1,234

			WriteLine($"{i:0-0=0 0}");                      //1-2=3 4


		}

		//055まで読み込み

	}
	static class Extensions
	{
		public static void Add(this Stack<int> stack, int n)
		{
			stack.Push(n);
		}
		/// 
		/// Stackの拡張メソッド Add
		/// 
		public static void Add(this Queue<int> queue, int n)
		{
			queue.Enqueue(n);
		}

	}
}
