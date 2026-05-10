namespace KifuwarabeShogiCSharp;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeShogiCSharp.Core.Usi.Models.Position;
using KifuwarabeShogiCSharp.Infrastructure.Configuration;
using KifuwarabeShogiCSharp.Infrastructure.Logging;
using KifuwarabeShogiCSharp.Models;
using KifuwarabeShogiCSharp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

internal static class ProgramCommands
{
    internal static async Task<MuzREPLRequestType> ExecuteAsync(
        IServiceProvider services,
        MuzPositionModel pos,
        string command)
    {
        // ［アプリケーション設定ファイル］を動作確認してみようぜ（＾～＾）
        var appSettings = services.GetRequiredService<IOptions<MuzAppSettings>>().Value;

        // ［ロガー別のログ］を動作確認してみようぜ（＾～＾）
        var loggingSvc = services.GetRequiredService<IMuzLoggingService>();

        // 空文字列なら、ループを続けるぜ（＾～＾）！ そうすれば、ユーザーが何か入力するまで待ち続けることができるぜ（＾～＾）！
        if (string.IsNullOrWhiteSpace(command)) return MuzREPLRequestType.None;

        // 最初のスペースで分割（2つに分ける）
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) throw new UnreachableException("空っぽだぜ");

        // "Apple Banana Cherry" なら。
        string commandName = parts[0];                    // "Apple"
        string rest = parts.Length > 1 ? parts[1] : "";  // "Banana Cherry"

        //loggingSvc.Others.LogDebug($"最初の部分   : {commandName}");
        //loggingSvc.Others.LogDebug($"残りの部分   : {rest}");

        if (commandName == "quit") return MuzREPLRequestType.Exit;

        if (commandName == "usi")
        {
            // 将棋の思考エンジンの名前と開発者名を返すぜ（＾▽＾）
            SendOutput($"id name {appSettings.ShogiEngineName}\nid author {appSettings.ShogiEngineAuthor}\nusiok\n", loggingSvc);
            return MuzREPLRequestType.None;
        }

        if (commandName == "isready")
        {
            // エンジンが準備できたら、"readyok" を返すぜ（＾▽＾）
            SendOutput($"readyok\n", loggingSvc);
            return MuzREPLRequestType.None;
        }

        if (commandName == "setoption")
        {
            // TODO: エンジンのオプションを設定するコマンド。これが来たら、オプションを変更する。
            return MuzREPLRequestType.None;
        }

        if (commandName == "usinewgame")
        {
            // 新しいゲームの開始を知らせるコマンド。これが来たら、前のゲームの情報をクリアする。
            return MuzREPLRequestType.None;
        }

        // ----------------------------------------
        // 局面
        // ----------------------------------------
        //      - 例： `position sfen lnsgkgsnl/9/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL w - 1 moves 5a6b 7g7f 3a3b`
        if (commandName == "position")
        {
            return MuzREPLRequestType.None;
        }

        if (commandName == "go")
        {
            // TODO: 思考開始のコマンド。これが来たら、思考を開始する。
            //usiOperation.Go(gameStats, pos, ssCmd);

            SendOutput($"bestmove resign\n", loggingSvc);   // とりあえず投了を返すぜ（＾ｑ＾）
            return MuzREPLRequestType.None;
        }

        // ----------------------------------------
        // 以下、独自実装
        // ----------------------------------------
        // ----------------------------------------
        // 局面の表示
        // ----------------------------------------
        if (commandName == "pos")
        {
            var pos2 = new MuzPositionModelReadonly(pos);
            await MuzPositionView.PrintPositionAsync(new MuzCoreModelReadonly(pos2));
            return MuzREPLRequestType.None;
        }

        if (commandName == "clear")
        {
            Console.Clear();
            return MuzREPLRequestType.None;
        }

        // ----------------------------------------
        // 無いよ
        // ----------------------------------------
        SendOutput("そんなコマンド無い（＾～＾）\n", loggingSvc);
        return MuzREPLRequestType.None;
    }


    // ========================================
    // 内部メソッド
    // ========================================


    /// <summary>
    /// USIメッセージの出力用（＾～＾）
    /// </summary>
    /// <param name="message">USIメッセージ</param>
    /// <param name="loggingSvc"></param>
    internal static void SendOutput(string message, IMuzLoggingService loggingSvc)
    {
        Console.Write(message); // 改行はもう付いてるから、ここでは付けないぜ（＾～＾）！
        loggingSvc.USIProtocol.LogInformation(message);
    }


    [Conditional("DEBUG")]
    internal static void DebugAssert<T>(string title, T expected, T actual, IMuzLoggingService loggingSvc)
    {
        if (!object.Equals(expected, actual))
        {
            var msg = $"Fail　{title}　期待値: {expected}, 実際の値: {actual}\n";
            SendOutput(msg, loggingSvc);
            //Debug.Assert(false, msg);
        }
    }
}
