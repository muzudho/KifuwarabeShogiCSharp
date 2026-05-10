# きふわらぷりーＣＳ

きふわらぷりーの C# 版だぜ（＾～＾）  


## お前はまずここを読め

* [📄KifuwarabeShogiCSharp/Docs/1_界隈知識.md](./Docs/1_界隈知識.md) - ［コンピューター将棋］界隈の前提知識（＾～＾）


## 親切なフォルダー構成の案内


* 📁 KifuwarabeShogiCSharp
	* [📁bin](./bin) - ビルドしてできたファイル置き場（＾～＾）
		* [📁Debug/net10.0/Logs] - デバッグビルドのログ置き場（＾～＾）
	* [📁Docs](./Docs) - 細々とした説明書（ドキュメント）置き場（＾～＾）
   * [📁Domain](./Domain) - 将棋そのものの知識を置く場所（＾～＾）
		* [📁Shogi](./Domain/Shogi) - 将棋ドメイン本体（＾～＾）
			* [📁Coordinates](./Domain/Shogi/Coordinates) - 筋、段、升などの座標系（＾～＾）
			* [📁Turns](./Domain/Shogi/Turns) - 手番（黒番、白番）まわり（＾～＾）
			* [📁Pieces](./Domain/Shogi/Pieces) - 駒の種類（＾～＾）
			* [📁Hands](./Domain/Shogi/Hands) - 持ち駒の枚数（＾～＾）
			* [📁Board](./Domain/Shogi/Board) - 盤面モデル（＾～＾）
			* [📁Position](./Domain/Shogi/Position) - 局面、手数など（＾～＾）
	* [📁Application](./Application) - アプリケーションとしての処理の流れ（＾～＾）
		* [📁Commands](./Application/Commands) - REPL など入口側のコマンド処理（＾～＾）
	* [📁Protocols](./Protocols) - 通信規約としてのコード置き場（＾～＾）
		* [📁Usi](./Protocols/Usi) - USI プロトコル関係（＾～＾）
	* [📁Presentation](./Presentation) - 表示用モデルなど、見せ方寄りのコード置き場（＾～＾）
		* [📁ViewModels](./Presentation/ViewModels) - 画面表示用の読取モデル（＾～＾）
	* [📁Views](./Views) - コンソール画面表示のコード置き場（＾～＾）
	* [📁Infrastructure](./Infrastructure) - 設定やログなど外部都合のコード置き場（＾～＾）
		* [📁Configuration](./Infrastructure/Configuration) - アプリ設定（＾～＾）
		* [📁Logging](./Infrastructure/Logging) - ロギング（＾～＾）
	* [📁Lib](./Lib) - 外部 DLL や説明書置き場（＾～＾）
	* 📄 `Program.cs` - アプリの入口（＾～＾）
	* 📄 `appsettings.json` - アプリの設定ファイル（＾～＾）


## 今の整理方針

このプロジェクトは、学習しやすいように次の考え方で整理しているぜ（＾～＾）

- `Domain` = 将棋そのもの
- `Application` = アプリとしての流れ
- `Protocols` = USI などの通信規約
- `Presentation` = 表示用モデル
- `Views` = 画面表示
- `Infrastructure` = 設定、ログなど外部都合

詳しい設計メモは以下を読むといいぜ（＾～＾）

- [📄 Docs/4_フォルダー構成案.md](./Docs/4_フォルダー構成案.md)
- [📄 Docs/5_フォルダー再編TODO.md](./Docs/5_フォルダー再編TODO.md)
