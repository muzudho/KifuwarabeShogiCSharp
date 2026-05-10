namespace KifuwarabeShogiCSharp.Protocols.Usi;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeShogiCSharp.Domain.Shogi.Position;
using KifuwarabeShogiCSharp.Infrastructure.Configuration;
using KifuwarabeShogiCSharp.Infrastructure.Logging;
using Microsoft.Extensions.Logging;

internal static class UsiCommandHandler
{
    internal static bool TryExecute(
        string commandName,
        MuzPositionModel pos,
        MuzAppSettings appSettings,
        IMuzLoggingService loggingSvc,
        out MuzREPLRequestType result)
    {
        if (commandName == "usi")
        {
            // 将棋の思考エンジンの名前と開発者名を返すぜ（＾▽＾）
            SendOutput($"id name {appSettings.ShogiEngineName}\nid author {appSettings.ShogiEngineAuthor}\nusiok\n", loggingSvc);
            result = MuzREPLRequestType.None;
            return true;
        }

        if (commandName == "isready")
        {
            // エンジンが準備できたら、"readyok" を返すぜ（＾▽＾）
            SendOutput("readyok\n", loggingSvc);
            result = MuzREPLRequestType.None;
            return true;
        }

        if (commandName == "setoption")
        {
            // TODO: エンジンのオプションを設定するコマンド。これが来たら、オプションを変更する。
            result = MuzREPLRequestType.None;
            return true;
        }

        if (commandName == "usinewgame")
        {
            // 新しいゲームの開始を知らせるコマンド。これが来たら、前のゲームの情報をクリアする。
            result = MuzREPLRequestType.None;
            return true;
        }

        // ----------------------------------------
        // 局面
        // ----------------------------------------
        //      - 例： `position sfen lnsgkgsnl/9/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL w - 1 moves 5a6b 7g7f 3a3b`
        if (commandName == "position")
        {
            result = MuzREPLRequestType.None;
            return true;
        }

        if (commandName == "go")
        {
            // TODO: 思考開始のコマンド。これが来たら、思考を開始する。
            //usiOperation.Go(gameStats, pos, ssCmd);

            SendOutput("bestmove resign\n", loggingSvc);   // とりあえず投了を返すぜ（＾ｑ＾）
            result = MuzREPLRequestType.None;
            return true;
        }

        result = MuzREPLRequestType.None;
        return false;
    }


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
}
