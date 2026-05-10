namespace KifuwarabeShogiCSharp.Domain.Shogi.Pieces;

/// <summary>
///		<pre>
/// 上下付きの駒。
///		</pre>
/// </summary>
internal enum MuzKomaType
{
    Empty = 0,
    NoboriFu = 1,   // ▲歩
    NoboriKyo,      // ▲香
    NoboriKei,      // ▲桂
    NoboriGin,      // ▲銀
    NoboriKaku,     // ▲角
    NoboriHisya,    // ▲飛
    NoboriKin,      // ▲金
    NoboriGyoku,    // ▲玉
    NoboriTokin,    // ▲と金
    NoboriNariKyo,  // ▲成香
    NoboriNariKei,  // ▲成桂
    NoboriNariGin,  // ▲成銀
    NoboriUma,      // ▲馬
    NoboriRyu,      // ▲龍
    // 15
    // 16
    KudariFu = 17,  // ▽歩
    KudariKyo,      // ▽香
    KudariKei,      // ▽桂
    KudariGin,      // ▽銀
    KudariKaku,     // ▽角
    KudariHisya,    // ▽飛
    KudariKin,      // ▽金
    KudariGyoku,    // ▽玉
    KudariTokin,    // ▽と金
    KudariNariKyo,  // ▽成香
    KudariNariKei,  // ▽成桂
    KudariNariGin,  // ▽成銀
    KudariUma,      // ▽馬
    KudariRyu,      // ▽龍
    // 31
}
