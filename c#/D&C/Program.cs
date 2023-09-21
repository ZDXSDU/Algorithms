// See https://aka.ms/new-console-template for more information
using System.Collections;

int SumList(List<int> ints)
{
    if (ints.Count == 1)
    {
        return ints[0];
    }
    else
    {
        int temp = ints[0];
        ints.RemoveAt(0);
        return temp + SumList(ints);
    }
}

int[] ints = { 1, 2147, 3, 654, 5, 6, 567, 8, 9, 120 };
List<int> list = new List<int>(ints);
Console.WriteLine(SumList(list));
list = new List<int>(ints);

int sum = 0;
for (int i = 0; i < ints.Length; i++)
{
    sum += ints[i];
}
Console.WriteLine(sum);
Console.WriteLine(list.Count);
Console.WriteLine(CounntListsItems(list));

static int CounntListsItems(List<int> ints1)
{
    if (ints1.Count == 1)
    {
        return 1;
    }
    else
    {
        ints1.RemoveAt(0);
        return 1 + CounntListsItems(ints1);
    }
}