using System.Runtime.InteropServices;

class call_dll
{
    [DllImport("liba.dll")]
    static extern unsafe sbyte *ChengeRegisterLettersInArray(sbyte *arrayLetters, int n);

    public static void Main()
    {
        unsafe
        {
            int size = 6;
            sbyte[] listLetters = new sbyte[size];
            listLetters[0] = (sbyte)'r';
            listLetters[1] = (sbyte)'A';
            listLetters[1] = (sbyte)'A';
            listLetters[2] = (sbyte)'K';
            listLetters[3] = (sbyte)'z';
            listLetters[4] = (sbyte)'V';
            listLetters[5] = (sbyte)'m';
            
            fixed (sbyte* p = &listLetters[0])
            {
                sbyte* a = ChengeRegisterLettersInArray(p, size);
                string abyr = new string(a);
                Console.WriteLine(abyr);
            }
        }
    }
}