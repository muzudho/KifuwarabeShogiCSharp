namespace KifuwarabeCSharp.Models;

using KifuwarabeCSharp.Core.Usi.Models;

/// <summary>
/// 読取専用のコアだぜ（＾～＾）！
/// </summary>
internal class MuzCoreReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    internal MuzCoreReadonly(
        MuzPositionReadonly pos)
    {
        this.Position = pos;
    }


    // ========================================
    // 窓口プロパティ
    // ========================================


    internal MuzPositionReadonly Position { get; init; } = default!;
}
