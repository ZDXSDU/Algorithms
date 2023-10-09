double ZongLiXi = 0; // 总利息
double ZongBenJin = 0; // 总本金
double[] LX = new double[47]; // 每一年的利息
double[] BJ = new double[47]; // 每一年的本金，item中没有包含任何利息收入
for (int i = 1; i < 47; i++)
{
    BJ[i] = 20 * 365 + ZongBenJin + ZongLiXi; // 每年的本金中 包含今年买烟的钱 + 之前买烟的钱 + 之前的总利息
    LX[i] = BJ[i] * 0.0195; // 每年的利息中  包含以前的利息收入和最近一年的利息收入
    ZongBenJin = BJ[i];
    ZongLiXi += LX[i];
    Console.WriteLine("第{0}年的存款本息合计为{1};  其中本金{2}元、利息{3}元",
        i,
        BJ[i] + LX[i],
        BJ[i],
        LX[i]
        );
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("以上本息合计:{0}元;  其中利息收入:{1}元。", ZongBenJin + ZongLiXi, ZongLiXi);