namespace KifuwarabeShogiCSharp.Domain.Shogi.Board;

using KifuwarabeShogiCSharp.Domain.Shogi.Coordinates;
using KifuwarabeShogiCSharp.Domain.Shogi.Pieces;

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
