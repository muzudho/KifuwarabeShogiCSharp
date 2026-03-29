namespace KifuwarabeCSharp.Views;

using KifuwarabeCSharp.Models;

internal static class MuzPositionView
{
    public static string GetPositionViewString(
        MuzCoreModelReadonly core)
    {
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

        return $@"[次は 1 手目 / 下の番 / 反復 0 回目]

 飛 角 金 銀 桂 香 歩
+--+--+--+--+--+--+--+
|{h1:2}|{h2:2}|{h3:2}|{h4:2}|{h5:2}|{h6:2}|{h7:2}|
+--+--+--+--+--+--+--+

  9   8   7   6   5   4   3   2   1
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 一
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 二
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 三
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 四
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 五
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 六
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 七
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 八
+---+---+---+---+---+---+---+---+---+
|   |   |   |   |   |   |   |   |   | 九
+---+---+---+---+---+---+---+---+---+

 飛 角 金 銀 桂 香 歩
+--+--+--+--+--+--+--+
|{h8:2}|{h9:2}|{h10:2}|{h11:2}|{h12:2}|{h13:2}|{h14:2}|
+--+--+--+--+--+--+--+
";
    }
}
