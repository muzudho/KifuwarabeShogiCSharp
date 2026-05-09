namespace KifuwarabeCSharp.Views;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeCSharp.Core.Usi.Models.Position.Elements;
using KifuwarabeCSharp.Models;
using System.Text;

internal static class MuzPositionView
{
    private static readonly ConsoleColor TatamiColor = ConsoleColor.DarkGreen;
    private static readonly ConsoleColor WoodColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor TextColor = ConsoleColor.Black;

    private const int StatusLeft = 0;
    private const int StatusTop = 0;
    private const int TopHandLeft = 1;
    private const int TopHandTop = 2;
    private const int BoardLeft = 0;
    private const int BoardTop = 7;
    private const int BottomHandLeft = 15;
    private const int BottomHandGapTop = 1;

    public static async Task PrintPositionAsync(
        MuzCoreModelReadonly core)
    {
        var topHandLines = BuildHandStandLines(core.Position.HandStandCollection, isKudariSide: true);
        var boardLines = BuildBoardFrameLines();
        var bottomHandTop = BoardTop + boardLines.Length + BottomHandGapTop;
        var bottomHandLines = BuildHandStandLines(core.Position.HandStandCollection, isKudariSide: false);

        Console.BackgroundColor = TatamiColor;
        Console.ForegroundColor = TextColor;
        Console.Clear();

        await RenderPanelAsync(TopHandLeft, TopHandTop, topHandLines);
        await RenderPanelAsync(BoardLeft, BoardTop, boardLines);
        await RenderPanelAsync(BottomHandLeft, bottomHandTop, bottomHandLines);
        await RenderStatusAsync();
        await RenderHandStandAsync(TopHandLeft, TopHandTop, topHandLines);
        await RenderBoardAsync(BoardLeft, BoardTop, core.Position.Board, boardLines);
        await RenderHandStandAsync(BottomHandLeft, bottomHandTop, bottomHandLines);

        Console.ResetColor();
    }


    private static async Task RenderStatusAsync()
    {
        await MuzConsole.WriteAtAsync(
            left: StatusLeft,
            top: StatusTop,
            foregroundColor: TextColor,
            backgroundColor: ConsoleColor.White,
            message: "[次は 1 手目 / 下の番 / 反復 0 回目]");
    }


    private static async Task RenderPanelAsync(
        int left,
        int top,
        IReadOnlyList<string> lines)
    {
        await MuzConsole.FillRectAsync(
            left: left,
            top: top,
            width: GetPanelWidth(lines),
            height: lines.Count,
            fgColor: TextColor,
            bgColor: WoodColor);
    }


    private static async Task RenderHandStandAsync(
        int left,
        int top,
        IReadOnlyList<string> lines)
    {
        await RenderLinesAsync(
            left,
            top,
            lines,
            foregroundColor: TextColor,
            backgroundColor: WoodColor);
    }


    private static async Task RenderBoardAsync(
        int left,
        int top,
        MuzBoardModelReadonly board,
        IReadOnlyList<string> lines)
    {
        await RenderLinesAsync(
            left,
            top,
            lines,
            foregroundColor: TextColor,
            backgroundColor: WoodColor);

        await RenderBoardPiecesAsync(left, top, board);
    }


    private static async Task RenderLinesAsync(
        int left,
        int top,
        IReadOnlyList<string> lines,
        ConsoleColor foregroundColor,
        ConsoleColor backgroundColor)
    {
        for (int index = 0; index < lines.Count; index++)
        {
            await MuzConsole.WriteAtAsync(
                left: left,
                top: top + index,
                foregroundColor: foregroundColor,
                backgroundColor: backgroundColor,
                message: lines[index]);
        }
    }


    private static async Task RenderBoardPiecesAsync(
        int left,
        int top,
        MuzBoardModelReadonly board)
    {
        for (int dan = 1; dan <= 9; dan++)
        {
            for (int suji = 9; suji >= 1; suji--)
            {
                var piece = board.GetPieceAt(ToMasu(suji, dan));
                if (piece == MuzKomaType.Empty)
                {
                    continue;
                }

                await MuzConsole.WriteAtAsync(
                    left: left + 1 + ((9 - suji) * 4),
                    top: top + 2 + ((dan - 1) * 2),
                    foregroundColor: TextColor,
                    backgroundColor: WoodColor,
                    message: piece.AsOneStr());
            }
        }
    }


    private static string[] BuildHandStandLines(
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

        var line = new StringBuilder();
        line.Append('|');

        foreach (var count in counts)
        {
            line.Append($"{count,2}|");
        }

        return
        [
            " 飛 角 金 銀 桂 香 歩",
            "+--+--+--+--+--+--+--+",
            line.ToString(),
            "+--+--+--+--+--+--+--+",
        ];
    }


    private static string[] BuildBoardFrameLines()
    {
        var danLabels = new[] { "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        var lines = new List<string>
        {
            "  9   8   7   6   5   4   3   2   1"
        };

        for (int dan = 1; dan <= 9; dan++)
        {
            lines.Add("+---+---+---+---+---+---+---+---+---+");
            lines.Add($"|   |   |   |   |   |   |   |   |   | {danLabels[dan - 1]}");
        }

        lines.Add("+---+---+---+---+---+---+---+---+---+");
        return [.. lines];
    }


    private static MuzMasuType ToMasu(int suji, int dan)
    {
        return (MuzMasuType)(((dan - 1) * 9) + (9 - suji));
    }


    private static int GetPanelWidth(IReadOnlyList<string> lines)
    {
        return lines.Count == 0 ? 0 : lines.Max(line => line.Length);
    }
}
