//double ZongLiXi = 0; // 总利息
//double ZongBenJin = 0; // 总本金
//double[] LX = new double[47]; // 每一年的利息
//double[] BJ = new double[47]; // 每一年的本金，item中没有包含任何利息收入
//for (int i = 1; i < 47; i++)
//{
//    BJ[i] = 20 * 365 + ZongBenJin + ZongLiXi; // 每年的本金中 包含今年买烟的钱 + 之前买烟的钱 + 之前的总利息
//    LX[i] = BJ[i] * 0.0195; // 每年的利息中  包含以前的利息收入和最近一年的利息收入
//    ZongBenJin = BJ[i];
//    ZongLiXi += LX[i];
//    Console.WriteLine("第{0}年的存款本息合计为{1};  其中本金{2}元、利息{3}元",
//        i,
//        BJ[i] + LX[i],
//        BJ[i],
//        LX[i]
//        );
//}
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine("以上本息合计:{0}元;  其中利息收入:{1}元。", ZongBenJin + ZongLiXi, ZongLiXi);






using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

List<char> listChar = new() { ' ', '^', '+', '!', '$', '#', '*', '%', '@' };

string GetChars(Bitmap bmp, int hScale, int vScale)
{
    StringBuilder sb = new();
    for (int h = 0; h < bmp.Height; h += vScale)
    {
        for (int w = 0; w < bmp.Width; w += hScale)
        {
            Color color = bmp.GetPixel(w, h);
            float brightness = color.GetBrightness(); // 这里的明度也可以使用 RGB 分量合成
            char ch = GetChar(brightness);
            sb.Append(ch);
        }
        sb.AppendLine();
    }
    return sb.ToString();
}

char GetChar(float brightness)
{
    int index = (int)(brightness * 0.99 * listChar.Count);
    return listChar[index];
}
Image PngImg = Image.FromFile(@"./console_logo.png");
Bitmap myImage = new(PngImg.Width, PngImg.Height, PixelFormat.Format32bppRgb);
using (Graphics g = Graphics.FromImage(myImage))
{
    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    g.DrawImage(PngImg, 0, 0);
}
Console.WriteLine(GetChars(myImage, 8, 7));
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
//香烟价格上涨的花费计算
//currentAgeOfSmoker：当前年龄
//expectedAgeOfSmoker：还能活到多少岁
//currentCigarettePrices：现在的烟多少钱一包
//cigarettePriceGrowth：香烟价格的年增长趋势，即每年上涨多少钱
//amountSmoked：每天抽几根烟
static double CigarettesAndConsumption(int currentAgeOfSmoker, int expectedAgeOfSmoker, double currentCigarettePrices, double cigarettePriceGrowth, double amountSmoked)
{
    double TOTAL = 0.0;
    int yearsRemaining = expectedAgeOfSmoker - currentAgeOfSmoker;
    for (global::System.Int32 i = 1; i < yearsRemaining + 1; i++)
    {
        TOTAL += (currentCigarettePrices + (i - 1) * cigarettePriceGrowth) * 365 * amountSmoked;
        Console.WriteLine("第{0}年的香烟价格为{1}，买烟共花费{2}元。", i, currentCigarettePrices + (i - 1) * cigarettePriceGrowth, (currentCigarettePrices + (i - 1) * cigarettePriceGrowth) * 365 * amountSmoked);
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    return TOTAL;
}
/**
 * 以下：
 * 年龄24岁的吸烟者按照预期寿命80岁，9元的红将烟价格每年上涨0.5元，当前烟量每天1盒，假设烟量不再上涨计算
 */
Console.WriteLine("还需要准备{0}元，用来买烟", CigarettesAndConsumption(24, 80, 9.00, 0.50, 1));
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.ReadLine();