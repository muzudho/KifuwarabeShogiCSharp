namespace KifuwarabeCSharp.Infrastructure.REPL;

using KifuwarabeCSharp.Core.Usi.Models.Position;
using KifuwarabeCSharp.Infrastructure.Configuration;
using KifuwarabeCSharp.Infrastructure.Logging;
using KifuwarabeCSharp.Models;
using KifuwarabeCSharp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;

/// <summary>
/// TODO: `MuzREPL.cs` に移行したい（＾～＾）
/// </summary>
internal static class MuzUsiLoop
{


    // ========================================
    // 窓口メソッド
    // ========================================


    public static async Task RunAsync(
        IServiceProvider services)
    {
        // ［アプリケーション設定ファイル］を動作確認してみようぜ（＾～＾）
        var appSettings = services.GetRequiredService<IOptions<MuzAppSettings>>().Value;

        // ［ロガー別のログ］を動作確認してみようぜ（＾～＾）
        var loggingSvc = services.GetRequiredService<IMuzLoggingService>();

        var pos = new MuzPositionModel();

        await MuzREPL.RunAsync(
            printPromptAsync: async () =>
            {
                // プロンプトは表示しないぜ（＾～＾）
                await Task.CompletedTask;
            },
            evalAsync: async (input) =>
            {
                // 空文字列なら、ループを続けるぜ（＾～＾）！ そうすれば、ユーザーが何か入力するまで待ち続けることができるぜ（＾～＾）！
                if (!string.IsNullOrWhiteSpace(input)) return MuzRequestType.None;

                // 最初のスペースで分割（2つに分ける）
                string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) throw new UnreachableException("空っぽだぜ");

                // "Apple Banana Cherry" なら。
                string commandName = parts[0];                    // "Apple"
                string rest = parts.Length > 1 ? parts[1] : "";  // "Banana Cherry"

                //loggingSvc.Others.LogDebug($"最初の部分   : {commandName}");
                //loggingSvc.Others.LogDebug($"残りの部分   : {rest}");

                if (commandName == "quit") return MuzRequestType.Exit;

                if (commandName == "usi")
                {
                    // 将棋の思考エンジンの名前と開発者名を返すぜ（＾▽＾）
                    SendOutput($"id name {appSettings.ShogiEngineName}\nid author {appSettings.ShogiEngineAuthor}\nusiok\n", loggingSvc);
                    return MuzRequestType.None;
                }

                if (commandName == "isready")
                {
                    // エンジンが準備できたら、"readyok" を返すぜ（＾▽＾）
                    SendOutput($"readyok\n", loggingSvc);
                    return MuzRequestType.None;
                }

                if (commandName == "setoption")
                {
                    // TODO: エンジンのオプションを設定するコマンド。これが来たら、オプションを変更する。
                    return MuzRequestType.None;
                }

                if (commandName == "usinewgame")
                {
                    // 新しいゲームの開始を知らせるコマンド。これが来たら、前のゲームの情報をクリアする。
                    return MuzRequestType.None;
                }

                // ----------------------------------------
                // 局面
                // ----------------------------------------
                //      - 例： `position sfen lnsgkgsnl/9/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL w - 1 moves 5a6b 7g7f 3a3b`
                if (commandName == "position")
                {
                    return MuzRequestType.None;
                }

                if (commandName == "go")
                {
                    // TODO: 思考開始のコマンド。これが来たら、思考を開始する。
                    //usiOperation.Go(gameStats, pos, ssCmd);

                    SendOutput($"bestmove resign\n", loggingSvc);   // とりあえず投了を返すぜ（＾ｑ＾）
                    return MuzRequestType.None;
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
                    var text = MuzPositionView.GetPositionViewString(new MuzCoreModelReadonly(pos2));
                    MuzUsiLoop.SendOutput($"{text}\n", loggingSvc);
                    return MuzRequestType.None;
                }

                // ----------------------------------------
                // 無いよ
                // ----------------------------------------
                SendOutput("そんなコマンド無い（＾～＾）\n", loggingSvc);
                return MuzRequestType.None;


            }
        );
    }


    // ========================================
    // 内部メソッド
    // ========================================


    /// <summary>
    /// USIメッセージの出力用（＾～＾）
    /// </summary>
    /// <param name="message">USIメッセージ</param>
    /// <param name="loggingSvc"></param>
    public static void SendOutput(string message, IMuzLoggingService loggingSvc)
    {
        //Console.Write(message); // 改行はもう付いてるから、ここでは付けないぜ（＾～＾）！
        loggingSvc.USIProtocol.LogInformation(message);
    }


    [Conditional("DEBUG")]
    public static void DebugAssert<T>(string title, T expected, T actual, IMuzLoggingService loggingSvc)
    {
        if (!object.Equals(expected, actual))
        {
            var msg = $"Fail　{title}　期待値: {expected}, 実際の値: {actual}\n";
            SendOutput(msg, loggingSvc);
            //Debug.Assert(false, msg);
        }
    }
}
