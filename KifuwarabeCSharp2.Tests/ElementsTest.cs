namespace KifuwarabeCSharp.Tests;

using KifuwarabeCSharp.Core.Usi.Elements;
using KifuwarabeCSharp.Core.Usi.Models.Position;
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
        var actual = MuzHandStandCollectionModel.FromPieces(
            bPawn: 17, bLance: 2, bKnight: 3, bSilver: 4, bGold: 1, bBishop: 2, bRook: 1,
            wPawn: 16, wLance: 1, wKnight: 2, wSilver: 3, wGold: 4, wBishop: 1, wRook: 2);
        Assert.Equal(expected: 17, actual.BPawn);
        Assert.Equal(expected: 2, actual.BLance);
        Assert.Equal(expected: 3, actual.BKnight);
        Assert.Equal(expected: 4, actual.BSilver);
        Assert.Equal(expected: 1, actual.BGold);
        Assert.Equal(expected: 2, actual.BBishop);
        Assert.Equal(expected: 1, actual.BRook);
        Assert.Equal(expected: 16, actual.WPawn);
        Assert.Equal(expected: 1, actual.WLance);
        Assert.Equal(expected: 2, actual.WKnight);
        Assert.Equal(expected: 3, actual.WSilver);
        Assert.Equal(expected: 4, actual.WGold);
        Assert.Equal(expected: 1, actual.WBishop);
        Assert.Equal(expected: 2, actual.WRook);
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
