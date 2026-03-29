namespace KifuwarabeCSharp.Core.Usi.Models.Position.Elements;

internal static class MuzMasuTypeHelper
{
    public static int AsInt(this MuzMasuType masu)
    {
        return (int)masu;
    }
}

/// <summary>
///     <pre>
/// マス番号。
/// 
///     - M は マスの頭文字だぜ（＾～＾）
///	  
///		        (-9)
///		        北
///		        ↑
///		(-1)西←　→東(+1)
///		        ↓
///		        南
///		        (+9)
///     </pre>
/// </summary>
internal enum MuzMasuType
{
    M91, M81, M71, M61, M51, M41, M31, M21, M11,
    M92, M82, M72, M62, M52, M42, M32, M22, M12,
    M93, M83, M73, M63, M53, M43, M33, M23, M13,
    M94, M84, M74, M64, M54, M44, M34, M24, M14,
    M95, M85, M75, M65, M55, M45, M35, M25, M15,
    M96, M86, M76, M66, M56, M46, M36, M26, M16,
    M97, M87, M77, M67, M57, M47, M37, M27, M17,
    M98, M88, M78, M68, M58, M48, M38, M28, M18,
    M99, M89, M79, M69, M59, M49, M39, M29, M19,

    Num // 要素数
}
