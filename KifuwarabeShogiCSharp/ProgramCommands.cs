namespace KifuwarabeShogiCSharp;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeShogiCSharp.Domain.Shogi.Position;
using KifuwarabeShogiCSharp.Infrastructure.Configuration;
using KifuwarabeShogiCSharp.Infrastructure.Logging;
using KifuwarabeShogiCSharp.Models;
using KifuwarabeShogiCSharp.Protocols.Usi;
using KifuwarabeShogiCSharp.Views;
using Microsoft.Extensions.DependencyInjection;
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

        if (UsiCommandHandler.TryExecute(
            commandName: commandName,
            pos: pos,
            appSettings: appSettings,
            loggingSvc: loggingSvc,
            out var usiResult))
        {
            return usiResult;
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
        UsiCommandHandler.SendOutput("そんなコマンド無い（＾～＾）\n", loggingSvc);
        return MuzREPLRequestType.None;
    }


    // ========================================
    // 内部メソッド
    // ========================================

    [Conditional("DEBUG")]
    internal static void DebugAssert<T>(string title, T expected, T actual, IMuzLoggingService loggingSvc)
    {
        if (!object.Equals(expected, actual))
        {
            var msg = $"Fail　{title}　期待値: {expected}, 実際の値: {actual}\n";
            UsiCommandHandler.SendOutput(msg, loggingSvc);
            //Debug.Assert(false, msg);
        }
    }
}
