namespace KifuwarabeShogiCSharp.Models;

using KifuwarabeShogiCSharp.Domain.Shogi.Position;

/// <summary>
/// 読取専用のコアだぜ（＾～＾）！
/// </summary>
internal class MuzCoreModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    internal MuzCoreModelReadonly(
        MuzPositionModelReadonly pos)
    {
        this.Position = pos;
    }


    // ========================================
    // 窓口プロパティ
    // ========================================


    internal MuzPositionModelReadonly Position { get; init; } = default!;
}
