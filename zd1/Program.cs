using System.Runtime.InteropServices;
using System;
using System.Text;
using System.Drawing;

class call_dll
{
    [DllImport("liba.dll")]
    static extern unsafe char* ChengeRegisterLettersInArray(char* arrayLetters, int n);
    [DllImport("liba.dll")]
    static extern void Write();


    public static void Main()
    {
        unsafe
        {
            int size = 6;
            char* listLetters = stackalloc char[size];
            listLetters[0] = 'r';
            listLetters[1] = 'A';
            listLetters[2] = 'K';
            listLetters[3] = 'z';
            listLetters[4] = 'V';
            listLetters[5] = 'm';
            char* a = ChengeRegisterLettersInArray(listLetters, size);
            Write();

        }
    }
}