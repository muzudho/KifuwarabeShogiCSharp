namespace KifuwarabeShogiCSharp.Core.Usi.Models.Position;

using KifuwarabeShogiCSharp.Core.Usi.Models.Position.Elements;
using KifuwarabeShogiCSharp.Domain.Shogi.Hands;

internal class MuzPositionModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzPositionModelReadonly(MuzPositionModel content)
    {
        this._content = content;
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    public MuzHandStandCollectionModelReadonly HandStandCollection
    {
        get
        {
            if (this._handStandCollection == null)
            {
                this._handStandCollection = new MuzHandStandCollectionModelReadonly(this._content.HandStandCollection);
            }
            return this._handStandCollection;
        }
    }
    private MuzHandStandCollectionModelReadonly? _handStandCollection;


    public MuzBoardModelReadonly Board
    {
        get
        {
            if (this._board == null)
            {
                this._board = new MuzBoardModelReadonly(this._content.Board);
            }
            return this._board;
        }
    }
    private MuzBoardModelReadonly? _board;


    // ========================================
    // 内部データメンバー
    // ========================================


    private MuzPositionModel _content;
}
