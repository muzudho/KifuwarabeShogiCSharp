namespace KifuwarabeShogiCSharp.Core.Usi.Models.Position.Elements;

using KifuwarabeShogiCSharp.Domain.Shogi.Coordinates;

/// <summary>
/// 盤面のモデルだぜ（＾～＾）！
/// </summary>
internal class MuzBoardModel
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzBoardModel()
    {
        this.Pieces = new MuzKomaType[MuzMasuType.Num.AsInt()];
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    public MuzKomaType[] Pieces { get; init; }
}
