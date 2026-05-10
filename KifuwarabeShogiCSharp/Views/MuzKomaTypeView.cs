namespace KifuwarabeShogiCSharp.Views;

using KifuwarabeShogiCSharp.Domain.Shogi.Pieces;

internal static class MuzKomaTypeView
{
    /// <summary>
    /// １字駒に変換します。
    /// </summary>
    /// <param name="koma"></param>
    /// <returns></returns>
    public static string AsOneStr(this MuzKomaType koma)
    {
        return koma switch
        {
            MuzKomaType.Empty => "   ",
            MuzKomaType.NoboriFu => " 歩",
            MuzKomaType.NoboriKyo => " 香",
            MuzKomaType.NoboriKei => " 桂",
            MuzKomaType.NoboriGin => " 銀",
            MuzKomaType.NoboriKaku => " 角",
            MuzKomaType.NoboriHisya => " 飛",
            MuzKomaType.NoboriKin => " 金",
            MuzKomaType.NoboriGyoku => " 玉",
            MuzKomaType.NoboriTokin => " と",
            MuzKomaType.NoboriNariKyo => " 杏",
            MuzKomaType.NoboriNariKei => " 圭",
            MuzKomaType.NoboriNariGin => " 全",
            MuzKomaType.NoboriUma => " 馬",
            MuzKomaType.NoboriRyu => " 龍",
            // 15
            // 16
            MuzKomaType.KudariFu => "v歩",
            MuzKomaType.KudariKyo => "v香",
            MuzKomaType.KudariKei => "v桂",
            MuzKomaType.KudariGin => "v銀",
            MuzKomaType.KudariKaku => "v角",
            MuzKomaType.KudariHisya => "v飛",
            MuzKomaType.KudariKin => "v金",
            MuzKomaType.KudariGyoku => "v玉",
            MuzKomaType.KudariTokin => "vと",
            MuzKomaType.KudariNariKyo => "v杏",
            MuzKomaType.KudariNariKei => "v圭",
            MuzKomaType.KudariNariGin => "v全",
            MuzKomaType.KudariUma => "v馬",
            MuzKomaType.KudariRyu => "v龍",
            // 31
        };
    }
}
