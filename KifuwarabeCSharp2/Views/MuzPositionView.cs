namespace KifuwarabeCSharp.Views;

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeCSharp.Core.Usi.Models.Position.Elements;
using KifuwarabeCSharp.Models;

internal static class MuzPositionView
{
    public static async Task PrintPositionAsync(
        MuzCoreModelReadonly core)
    {
        // 持ち駒の枚数
        var h1 = core.Position.HandStandCollection.KudariHisya;
        var h2 = core.Position.HandStandCollection.KudariKaku;
        var h3 = core.Position.HandStandCollection.KudariKin;
        var h4 = core.Position.HandStandCollection.KudariGin;
        var h5 = core.Position.HandStandCollection.KudariKei;
        var h6 = core.Position.HandStandCollection.KudariKyo;
        var h7 = core.Position.HandStandCollection.KudariFu;
        var h8 = core.Position.HandStandCollection.NoboriHisya;
        var h9 = core.Position.HandStandCollection.NoboriKaku;
        var h10 = core.Position.HandStandCollection.NoboriKin;
        var h11 = core.Position.HandStandCollection.NoboriGin;
        var h12 = core.Position.HandStandCollection.NoboriKei;
        var h13 = core.Position.HandStandCollection.NoboriKyo;
        var h14 = core.Position.HandStandCollection.NoboriFu;

        // 各マスの駒
        var m11 = core.Position.Board.GetPieceAt(MuzMasuType.M11).AsOneStr();
        var m12 = core.Position.Board.GetPieceAt(MuzMasuType.M12).AsOneStr();
        var m13 = core.Position.Board.GetPieceAt(MuzMasuType.M13).AsOneStr();
        var m14 = core.Position.Board.GetPieceAt(MuzMasuType.M14).AsOneStr();
        var m15 = core.Position.Board.GetPieceAt(MuzMasuType.M15).AsOneStr();
        var m16 = core.Position.Board.GetPieceAt(MuzMasuType.M16).AsOneStr();
        var m17 = core.Position.Board.GetPieceAt(MuzMasuType.M17).AsOneStr();
        var m18 = core.Position.Board.GetPieceAt(MuzMasuType.M18).AsOneStr();
        var m19 = core.Position.Board.GetPieceAt(MuzMasuType.M19).AsOneStr();

        var m21 = core.Position.Board.GetPieceAt(MuzMasuType.M21).AsOneStr();
        var m22 = core.Position.Board.GetPieceAt(MuzMasuType.M22).AsOneStr();
        var m23 = core.Position.Board.GetPieceAt(MuzMasuType.M23).AsOneStr();
        var m24 = core.Position.Board.GetPieceAt(MuzMasuType.M24).AsOneStr();
        var m25 = core.Position.Board.GetPieceAt(MuzMasuType.M25).AsOneStr();
        var m26 = core.Position.Board.GetPieceAt(MuzMasuType.M26).AsOneStr();
        var m27 = core.Position.Board.GetPieceAt(MuzMasuType.M27).AsOneStr();
        var m28 = core.Position.Board.GetPieceAt(MuzMasuType.M28).AsOneStr();
        var m29 = core.Position.Board.GetPieceAt(MuzMasuType.M29).AsOneStr();

        var m31 = core.Position.Board.GetPieceAt(MuzMasuType.M31).AsOneStr();
        var m32 = core.Position.Board.GetPieceAt(MuzMasuType.M32).AsOneStr();
        var m33 = core.Position.Board.GetPieceAt(MuzMasuType.M33).AsOneStr();
        var m34 = core.Position.Board.GetPieceAt(MuzMasuType.M34).AsOneStr();
        var m35 = core.Position.Board.GetPieceAt(MuzMasuType.M35).AsOneStr();
        var m36 = core.Position.Board.GetPieceAt(MuzMasuType.M36).AsOneStr();
        var m37 = core.Position.Board.GetPieceAt(MuzMasuType.M37).AsOneStr();
        var m38 = core.Position.Board.GetPieceAt(MuzMasuType.M38).AsOneStr();
        var m39 = core.Position.Board.GetPieceAt(MuzMasuType.M39).AsOneStr();

        var m41 = core.Position.Board.GetPieceAt(MuzMasuType.M41).AsOneStr();
        var m42 = core.Position.Board.GetPieceAt(MuzMasuType.M42).AsOneStr();
        var m43 = core.Position.Board.GetPieceAt(MuzMasuType.M43).AsOneStr();
        var m44 = core.Position.Board.GetPieceAt(MuzMasuType.M44).AsOneStr();
        var m45 = core.Position.Board.GetPieceAt(MuzMasuType.M45).AsOneStr();
        var m46 = core.Position.Board.GetPieceAt(MuzMasuType.M46).AsOneStr();
        var m47 = core.Position.Board.GetPieceAt(MuzMasuType.M47).AsOneStr();
        var m48 = core.Position.Board.GetPieceAt(MuzMasuType.M48).AsOneStr();
        var m49 = core.Position.Board.GetPieceAt(MuzMasuType.M49).AsOneStr();

        var m51 = core.Position.Board.GetPieceAt(MuzMasuType.M51).AsOneStr();
        var m52 = core.Position.Board.GetPieceAt(MuzMasuType.M52).AsOneStr();
        var m53 = core.Position.Board.GetPieceAt(MuzMasuType.M53).AsOneStr();
        var m54 = core.Position.Board.GetPieceAt(MuzMasuType.M54).AsOneStr();
        var m55 = core.Position.Board.GetPieceAt(MuzMasuType.M55).AsOneStr();
        var m56 = core.Position.Board.GetPieceAt(MuzMasuType.M56).AsOneStr();
        var m57 = core.Position.Board.GetPieceAt(MuzMasuType.M57).AsOneStr();
        var m58 = core.Position.Board.GetPieceAt(MuzMasuType.M58).AsOneStr();
        var m59 = core.Position.Board.GetPieceAt(MuzMasuType.M59).AsOneStr();

        var m61 = core.Position.Board.GetPieceAt(MuzMasuType.M61).AsOneStr();
        var m62 = core.Position.Board.GetPieceAt(MuzMasuType.M62).AsOneStr();
        var m63 = core.Position.Board.GetPieceAt(MuzMasuType.M63).AsOneStr();
        var m64 = core.Position.Board.GetPieceAt(MuzMasuType.M64).AsOneStr();
        var m65 = core.Position.Board.GetPieceAt(MuzMasuType.M65).AsOneStr();
        var m66 = core.Position.Board.GetPieceAt(MuzMasuType.M66).AsOneStr();
        var m67 = core.Position.Board.GetPieceAt(MuzMasuType.M67).AsOneStr();
        var m68 = core.Position.Board.GetPieceAt(MuzMasuType.M68).AsOneStr();
        var m69 = core.Position.Board.GetPieceAt(MuzMasuType.M69).AsOneStr();

        var m71 = core.Position.Board.GetPieceAt(MuzMasuType.M71).AsOneStr();
        var m72 = core.Position.Board.GetPieceAt(MuzMasuType.M72).AsOneStr();
        var m73 = core.Position.Board.GetPieceAt(MuzMasuType.M73).AsOneStr();
        var m74 = core.Position.Board.GetPieceAt(MuzMasuType.M74).AsOneStr();
        var m75 = core.Position.Board.GetPieceAt(MuzMasuType.M75).AsOneStr();
        var m76 = core.Position.Board.GetPieceAt(MuzMasuType.M76).AsOneStr();
        var m77 = core.Position.Board.GetPieceAt(MuzMasuType.M77).AsOneStr();
        var m78 = core.Position.Board.GetPieceAt(MuzMasuType.M78).AsOneStr();
        var m79 = core.Position.Board.GetPieceAt(MuzMasuType.M79).AsOneStr();

        var m81 = core.Position.Board.GetPieceAt(MuzMasuType.M81).AsOneStr();
        var m82 = core.Position.Board.GetPieceAt(MuzMasuType.M82).AsOneStr();
        var m83 = core.Position.Board.GetPieceAt(MuzMasuType.M83).AsOneStr();
        var m84 = core.Position.Board.GetPieceAt(MuzMasuType.M84).AsOneStr();
        var m85 = core.Position.Board.GetPieceAt(MuzMasuType.M85).AsOneStr();
        var m86 = core.Position.Board.GetPieceAt(MuzMasuType.M86).AsOneStr();
        var m87 = core.Position.Board.GetPieceAt(MuzMasuType.M87).AsOneStr();
        var m88 = core.Position.Board.GetPieceAt(MuzMasuType.M88).AsOneStr();
        var m89 = core.Position.Board.GetPieceAt(MuzMasuType.M89).AsOneStr();

        var m91 = core.Position.Board.GetPieceAt(MuzMasuType.M91).AsOneStr();
        var m92 = core.Position.Board.GetPieceAt(MuzMasuType.M92).AsOneStr();
        var m93 = core.Position.Board.GetPieceAt(MuzMasuType.M93).AsOneStr();
        var m94 = core.Position.Board.GetPieceAt(MuzMasuType.M94).AsOneStr();
        var m95 = core.Position.Board.GetPieceAt(MuzMasuType.M95).AsOneStr();
        var m96 = core.Position.Board.GetPieceAt(MuzMasuType.M96).AsOneStr();
        var m97 = core.Position.Board.GetPieceAt(MuzMasuType.M97).AsOneStr();
        var m98 = core.Position.Board.GetPieceAt(MuzMasuType.M98).AsOneStr();
        var m99 = core.Position.Board.GetPieceAt(MuzMasuType.M99).AsOneStr();

        Console.Clear();

        // 画面の左上に、次の手番などを表示
        await MuzConsole.WriteLineAsync(
            left: 0,
            top: 0,
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.White,
            message: $"[次は 1 手目 / 下の番 / 反復 0 回目]");

        // 白番の持ち駒を表示
        Console.WriteLine($@"

 飛 角 金 銀 桂 香 歩
+--+--+--+--+--+--+--+
|{h1,2}|{h2,2}|{h3,2}|{h4,2}|{h5,2}|{h6,2}|{h7,2}|
+--+--+--+--+--+--+--+
");

        // 将棋盤を表示
        await MuzConsole.WriteLineAsync(
            foregroundColor: ConsoleColor.Black,
            backgroundColor: ConsoleColor.Yellow,
            message: $@"
  9   8   7   6   5   4   3   2   1
+---+---+---+---+---+---+---+---+---+
|{m91,3}|{m81,3}|{m71,3}|{m61,3}|{m51,3}|{m41,3}|{m31,3}|{m21,3}|{m11,3}| 一
+---+---+---+---+---+---+---+---+---+
|{m92,3}|{m82,3}|{m72,3}|{m62,3}|{m52,3}|{m42,3}|{m32,3}|{m22,3}|{m12,3}| 二
+---+---+---+---+---+---+---+---+---+
|{m93,3}|{m83,3}|{m73,3}|{m63,3}|{m53,3}|{m43,3}|{m33,3}|{m23,3}|{m13,3}| 三
+---+---+---+---+---+---+---+---+---+
|{m94,3}|{m84,3}|{m74,3}|{m64,3}|{m54,3}|{m44,3}|{m34,3}|{m24,3}|{m14,3}| 四
+---+---+---+---+---+---+---+---+---+
|{m95,3}|{m85,3}|{m75,3}|{m65,3}|{m55,3}|{m45,3}|{m35,3}|{m25,3}|{m15,3}| 五
+---+---+---+---+---+---+---+---+---+
|{m96,3}|{m86,3}|{m76,3}|{m66,3}|{m56,3}|{m46,3}|{m36,3}|{m26,3}|{m16,3}| 六
+---+---+---+---+---+---+---+---+---+
|{m97,3}|{m87,3}|{m77,3}|{m67,3}|{m57,3}|{m47,3}|{m37,3}|{m27,3}|{m17,3}| 七
+---+---+---+---+---+---+---+---+---+
|{m98,3}|{m88,3}|{m78,3}|{m68,3}|{m58,3}|{m48,3}|{m38,3}|{m28,3}|{m18,3}| 八
+---+---+---+---+---+---+---+---+---+
|{m99,3}|{m89,3}|{m79,3}|{m69,3}|{m59,3}|{m49,3}|{m39,3}|{m29,3}|{m19,3}| 九
+---+---+---+---+---+---+---+---+---+");

        // 黒番の持ち駒を表示
        Console.WriteLine($@"

 飛 角 金 銀 桂 香 歩
+--+--+--+--+--+--+--+
|{h8,2}|{h9,2}|{h10,2}|{h11,2}|{h12,2}|{h13,2}|{h14,2}|
+--+--+--+--+--+--+--+
");

    }
}
