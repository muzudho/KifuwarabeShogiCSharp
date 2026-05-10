namespace KifuwarabeShogiCSharp.Core.Usi.Models.Position;

using KifuwarabeShogiCSharp.Core.Usi.Models.Position.Elements;
using KifuwarabeShogiCSharp.Domain.Shogi.Hands;

/// <summary>
/// 局面のモデルだぜ（＾～＾）！
/// </summary>
internal class MuzPositionModel
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzPositionModel()
    {
        this.HandStandCollection = new MuzHandStandCollectionModel();
        this.Board = new MuzBoardModel();
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    /// <summary>
    /// ２つの駒台。
    /// </summary>
    public MuzHandStandCollectionModel HandStandCollection { get; init; }


    /// <summary>
    /// 盤。
    /// </summary>
    public MuzBoardModel Board { get; init; }
}
