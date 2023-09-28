int[] ints = new int[3000];
bool isSort = true;
Random rnd = new();
for (int i = 0; i < ints.Length; i++)
{
    ints[i] = rnd.Next(10, 5000);
}
QuickSort2(ints, 0, ints.Length - 1);
Console.WriteLine("sort result:");
foreach (int item in ints)
{
    Console.Write(item + "  ");
}
for (int i = 0; i < ints.Length-1; i++)
{
    if (ints[i] > ints[i + 1])
        isSort = false;
}
Console.WriteLine(isSort);
static void QuickSort(int[] ints, int less, int greater)
{
    int pivot = ints[0];
    if (less > greater)
        return;
    int i = less, j = greater;
    while (i < j)
    {
        while (i < j && pivot <= ints[j])
        {
            j--;
        }
        ints[i] = ints[j];
        while (i < j && pivot >= ints[i])
        {
            i++;
        }
        ints[j] = ints[i];
    }
    ints[i] = pivot;
    QuickSort(ints, less, i - 1);
    QuickSort(ints, i + 1, greater);
}

static void QuickSort2(int[] A, int lo, int hi)
{
    if (lo > hi)//递归退出条件
    {
        return;
    }
    int i = lo;
    int j = hi;
    int temp = A[i];//取得基准数，空出一个位置
    while (i < j)//当i=j时推出，表示temp左边的数都比temp小，右边的数都比temp大
    {
        while (i < j && temp <= A[j])//从后往前找比temp小的数，将比temp小的数往前移
        {
            j--;
        }
        A[i] = A[j];//将比基准数小的数放在空出的位置，j的位置又空了出来
        while (i < j && temp >= A[i])//从前往后找比temp大的数，将比temp大的数往后移
        {
            i++;
        }
        A[j] = A[i];//将比基准数大的数放在hi空出来的位置,如此，i所在的位置又空了出来
    }
    A[i] = temp;
    QuickSort2(A, lo, i - 1);//对lo到i-1之间的数再使用快速排序，每次快速排序的结果是找到了基准数应该在的位置
                             //其左边的数都<=它，右边的数都>=它，它此时在数组中的位置就是排序好时其应该在的位置。
    QuickSort2(A, i + 1, hi);//对i+1到hi之间的数再使用快速排序
}