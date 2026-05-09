namespace KifuwarabeCSharp.Views;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeCSharp.Core.Usi.Models.Position.Elements;
using KifuwarabeCSharp.Models;
using System.Text;

internal static class MuzPositionView
{
    public static async Task PrintPositionAsync(
        MuzCoreModelReadonly core)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        // 画面の左上に、次の手番などを表示
        await MuzConsole.WriteLineAtAsync(
            left: 0,
            top: 0,
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.White,
            message: $"[次は 1 手目 / 下の番 / 反復 0 回目]");

        Console.SetCursorPosition(left: 0, top: 2);

        await MuzConsole.WriteLineAsync(
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.Yellow,
            message: BuildHandStandText(core.Position.HandStandCollection, isKudariSide: true));

        // 将棋盤を表示
        await MuzConsole.WriteLineAsync(
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.Yellow,
            message: BuildBoardText(core.Position.Board));

        await MuzConsole.WriteLineAsync(
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.Yellow,
            message: BuildHandStandText(core.Position.HandStandCollection, isKudariSide: false));

        Console.ResetColor();
    }


    private static string BuildHandStandText(
        MuzHandStandCollectionModelReadonly handStandCollection,
        bool isKudariSide)
    {
        var counts = isKudariSide
            ? new byte[]
            {
                handStandCollection.KudariHisya,
                handStandCollection.KudariKaku,
                handStandCollection.KudariKin,
                handStandCollection.KudariGin,
                handStandCollection.KudariKei,
                handStandCollection.KudariKyo,
                handStandCollection.KudariFu,
            }
            : new byte[]
            {
                handStandCollection.NoboriHisya,
                handStandCollection.NoboriKaku,
                handStandCollection.NoboriKin,
                handStandCollection.NoboriGin,
                handStandCollection.NoboriKei,
                handStandCollection.NoboriKyo,
                handStandCollection.NoboriFu,
            };

        var builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendLine(" 飛 角 金 銀 桂 香 歩");
        builder.AppendLine("+--+--+--+--+--+--+--+");
        builder.Append('|');

        foreach (var count in counts)
        {
            builder.Append($"{count,2}|");
        }

        builder.AppendLine();
        builder.AppendLine("+--+--+--+--+--+--+--+");

        return builder.ToString();
    }


    private static string BuildBoardText(MuzBoardModelReadonly board)
    {
        var danLabels = new[] { "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        var builder = new StringBuilder();

        builder.AppendLine();
        builder.AppendLine("  9   8   7   6   5   4   3   2   1");

        for (int dan = 1; dan <= 9; dan++)
        {
            builder.AppendLine("+---+---+---+---+---+---+---+---+---+");
            builder.Append('|');

            for (int suji = 9; suji >= 1; suji--)
            {
                builder.Append($"{board.GetPieceAt(ToMasu(suji, dan)).AsOneStr(),3}|");
            }

            builder.Append(' ');
            builder.AppendLine(danLabels[dan - 1]);
        }

        builder.AppendLine("+---+---+---+---+---+---+---+---+---+");
        return builder.ToString();
    }


    private static MuzMasuType ToMasu(int suji, int dan)
    {
        return (MuzMasuType)(((dan - 1) * 9) + (9 - suji));
    }
}
