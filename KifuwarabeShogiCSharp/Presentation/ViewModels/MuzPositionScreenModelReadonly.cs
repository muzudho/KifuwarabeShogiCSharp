namespace KifuwarabeShogiCSharp.Presentation.ViewModels;

using KifuwarabeShogiCSharp.Domain.Shogi.Position;

/// <summary>
/// 読取専用の局面画面モデルだぜ（＾～＾）！
/// </summary>
internal class MuzPositionScreenModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    internal MuzPositionScreenModelReadonly(
        MuzPositionModelReadonly pos)
    {
        this.Position = pos;
    }


    // ========================================
    // 窓口プロパティ
    // ========================================


    internal MuzPositionModelReadonly Position { get; init; } = default!;
}
