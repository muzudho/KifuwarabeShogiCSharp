namespace KifuwarabeShogiCSharp.Tests;

using KifuwarabeShogiCSharp.Domain.Shogi.Coordinates;
using KifuwarabeShogiCSharp.Domain.Shogi.Hands;
using KifuwarabeShogiCSharp.Domain.Shogi.Position;
using KifuwarabeShogiCSharp.Domain.Shogi.Turns;
using Xunit;

public class ElementsTest
{


    // ［筋］


    /// <summary>
    /// 筋テスト。
    /// </summary>
    [Fact]
    public void Inverse_Suji_ReturnsNumber()
    {
        Assert.Equal(expected: MuzSujiType.Suji2, actual: MuzSujiHelper.Inverse(MuzSujiType.Suji8));
        Assert.Equal(expected: MuzSujiType.Suji5, actual: MuzSujiHelper.Inverse(MuzSujiType.Suji5));
        Assert.Equal(expected: MuzSujiType.Suji9, actual: MuzSujiHelper.Inverse(MuzSujiType.Suji1));
    }


    // ［持ち駒の枚数］


    /// <summary>
    ///     <pre>
    /// 持ち駒の枚数テスト。
    ///     </pre>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="expected"></param>
    [Fact]
    public void ColorPiece_HandStandCollection_ReturnsNumber()
    {
        var actual = new MuzHandStandCollectionModel(
            noboriFu: 17, noboriKyo: 2, noboriKei: 3, noboriGin: 4, noboriKin: 1, noboriKaku: 2, noboriHisya: 1,
            kudariFu: 16, kudariKyo: 1, kudariKei: 2, kudariGin: 3, kudariKin: 4, kudariKaku: 1, kudariHisya: 2);
        Assert.Equal(expected: 17, actual.NoboriFu);
        Assert.Equal(expected: 2, actual.NoboriKyo);
        Assert.Equal(expected: 3, actual.NoboriKei);
        Assert.Equal(expected: 4, actual.NoboriGin);
        Assert.Equal(expected: 1, actual.NoboriKin);
        Assert.Equal(expected: 2, actual.NoboriKaku);
        Assert.Equal(expected: 1, actual.NoboriHisya);
        Assert.Equal(expected: 16, actual.KudariFu);
        Assert.Equal(expected: 1, actual.KudariKyo);
        Assert.Equal(expected: 2, actual.KudariKei);
        Assert.Equal(expected: 3, actual.KudariGin);
        Assert.Equal(expected: 4, actual.KudariKin);
        Assert.Equal(expected: 1, actual.KudariKaku);
        Assert.Equal(expected: 2, actual.KudariHisya);
    }


    // ［手番］


    /// <summary>
    ///     <pre>
    /// データ駆動テスト。
    /// 
    ///     - 複数のケースを一気にやる例。
    ///     </pre>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="expected"></param>
    [Theory]
    [InlineData(MuzColorType.Black, "b")]   // 黒番
    [InlineData(MuzColorType.White, "w")]   // 白番
    [InlineData(MuzColorType.None, ".")]    // エラー表示
    public void ToString_Color_ReturnsString(MuzColorType color, string expected)
    {
        var actual = new MuzColorModel(color).ToString();
        Assert.Equal(expected, actual);
    }


    // ［手数］


    /// <summary>
    /// 2 と 3 を足したら 5 になることをテストする例。
    /// </summary>
    [Fact]
    public void Value_RadixHalfPlyFive_ReturnsFive()
    {
        var expected = 5;
        int actual = new MuzRadixHalfPlyModel(expected).Value;
        Assert.Equal(expected, actual);
    }
}
