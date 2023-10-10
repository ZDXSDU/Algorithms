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
Console.WriteLine(GetChars(myImage, 7, 7));
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("1. 本计算方式将假设你第一年每月存入相同的金额，例如500元，从第二年开始每月存入500元以及到期的本金和利息收益。");
Console.WriteLine("2. 假设存款期间银行一年期存款利率不变。");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("请输入你计划每月新存入的金额(单位:元, 不可为小数)");
int everyMonth = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("请输入你计划坚持的时间，单位:年, 不可为小数字");
int year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("请输入目标银行一年期整存整取的利率，保留四位小数。例: 1.95%写作0.0195");
double rate = Convert.ToDouble(Console.ReadLine());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("月存入的金额:{0} 存款时间:{1} 利率:{2}", everyMonth, year, rate);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("-------------------- 以下为计算结果 --------------------");
Console.WriteLine();
Console.WriteLine();
double[] ZongShouRu = new double[year + 1];
double[] LiXi = new double[year + 1];

for (global::System.Int32 i = 1; i < year + 1; i++)
{
    if (i > 1)
    {
        ZongShouRu[i] = (everyMonth * 12 + ZongShouRu[i - 1]);
        LiXi[i] = (everyMonth * 12 + ZongShouRu[i - 1]) * rate;
    }
    else if (i == 1)
    {
        ZongShouRu[i] = everyMonth * 12 + ZongShouRu[i - 1];
        LiXi[i] = 0;
    }
    Console.WriteLine("第{0}年年末时，有存款累计{1}元，其中本金{2}元，利息{3}元",
        i,
        Math.Round(ZongShouRu[i] + LiXi[i], 2),
        everyMonth * 12 * i,
        Math.Round(LiXi[i], 2)
    );
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("-------------------- 总 结 --------------------");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("坚持{0}年每月存入{1}元，按照{2}%的存款利率到第{3}年时，你将拥有银行存款{4}元，其中本金{5}元、利息{6}元。",
    year,
    everyMonth,
    rate * 100,
    year + 1,
    Math.Round(ZongShouRu[^1] + LiXi[^1], 2),
    everyMonth * year * 12,
    Math.Round(LiXi[^1], 2)
);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("-----------------------------------------------");