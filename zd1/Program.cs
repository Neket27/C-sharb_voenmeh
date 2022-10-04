using System.Runtime.InteropServices;
using System.Text;

class LibraryForWorkFile
{
    public string path { get; set; }
    public bool modeFile { get; set; }
    public Action mode { get; set; }
    public IntPtr openFile { get; set; }


    [DllImport("file64.dll")]
    public static extern IntPtr open(string path, bool read);

    [DllImport("file64.dll")]
    public static extern void close(IntPtr file);

    [DllImport("file64.dll")]
    public static extern bool read(IntPtr file, int num, StringBuilder word);

    [DllImport("file64.dll")]
    public static extern void write(IntPtr file, string text);

    [DllImport("file64.dll")]
    public static extern int length(IntPtr file);

    ~LibraryForWorkFile()
    {
    }

    public LibraryForWorkFile()
    {
    }

    public LibraryForWorkFile(string path, bool modeFile)
    {
        this.path = path;
        this.modeFile = modeFile;

        if (openFile == (IntPtr)0)
            this.openFile = open(path, modeFile);
    }

    public IntPtr OpenFile(string path, bool modeFile)
    {
        return open(path, modeFile);
    }


    public bool ReadFile(IntPtr file, int num, StringBuilder word)
    {
        return read(file, num, word);
    }

    public void Dispose()
    {
        Dispose();
    }
}


namespace lab_3
{
    internal class Program
    {
        static int Menu()
        {
            int choosed = -1;
            Console.WriteLine("1 - Открыть файл");
            Console.WriteLine("2 - Получить количество слов в файле");
            Console.WriteLine(
                "3 - Найти самую часто встречающуюся букву в первом файле, удалить все слова на эту букву из второго.");
            Console.WriteLine(
                "4 - Заменить каждое чётное слово из первого файла на соответствующее по порядку слово из второго.");
            Int32.TryParse(Console.ReadLine(), out choosed);
            return choosed;
        }

        static void Main(string[] args)
        {
            int choosed = -1;
            StringBuilder stringBuilder = null;
            LibraryForWorkFile workFile = null;

            while (choosed != 0)
            {
                choosed = Menu();
                switch (choosed)
                {
                    case 1:
                        Console.WriteLine("Введите название файла:");
                        string nameFile = Console.ReadLine();
                        Console.WriteLine("Режим открытия файла (true или false)");
                        bool mode;
                        Boolean.TryParse(Console.ReadLine(), out mode);
                        workFile = new LibraryForWorkFile(nameFile, mode);
                        break;

                    case 2:
                        stringBuilder = new StringBuilder();
                        stringBuilder.Capacity = 255;
                        Console.WriteLine(LibraryForWorkFile.length(workFile.openFile));
                        // LibraryForWorkFile.read(workFile.openFile, 1, stringBuilder);
                        // Console.WriteLine("---a= " + stringBuilder);
                        break;
                    case 3:
                    {
                        StringBuilder stringBuilder2 = new StringBuilder();
                        StringBuilder stringBuilder3 = new StringBuilder();
                        LibraryForWorkFile workFile_1 = new LibraryForWorkFile("texter (1).txt", true);
                        LibraryForWorkFile workFile_2 = new LibraryForWorkFile("texter (2).txt", true);

                        char MAXRepeateLetter = MaxRepeateLetter(workFile_1, stringBuilder2);
                        string text = RepeateLetter(workFile_2, stringBuilder3, MAXRepeateLetter);
                        Console.WriteLine(text);
                    }
                        break;

                    case 4:
                    {
                        StringBuilder stringBuilder2 = new StringBuilder();
                        StringBuilder stringBuilder3 = new StringBuilder();
                        LibraryForWorkFile workFile_1 = new LibraryForWorkFile("texter (1).txt", true);
                        LibraryForWorkFile workFile_2 = new LibraryForWorkFile("texter (2).txt", true);
                        int lenFile_1 = LibraryForWorkFile.length(workFile_1.openFile);
                        int lenFile_2 = LibraryForWorkFile.length(workFile_2.openFile);
                        Console.WriteLine("-----------------------------------");
                        List<string> listFile_1 = new List<string>();
                        List<string> listFile_2 = new List<string>();

                        int minLen;
                        if (lenFile_1 < lenFile_2)
                            minLen = lenFile_1;
                        else
                            minLen = lenFile_2;
/////////////////////////////////////////////////////////////////////////////////////////
                        LibraryForWorkFile.read(workFile_1.openFile, 3, stringBuilder2);
                        Console.WriteLine(stringBuilder2);
//////////////////////////////////////////////////////////////////////////////////////////
                        string text_1 = "";
                       for (int i = 1; i <= minLen; i++)
                        {
                            LibraryForWorkFile.read(workFile_1.openFile, i, stringBuilder2);
                            LibraryForWorkFile.read(workFile_2.openFile, i, stringBuilder3);

                            if (i % 2 == 0)
                                text_1 = text_1 + stringBuilder3 + " ";
                            else
                                text_1 = text_1 + stringBuilder2 + " ";
                        }
                       
                       LibraryForWorkFile.read(workFile_1.openFile, 1, stringBuilder2);
                       string text_2 = stringBuilder2+" ";
                        for (int i = 2; i <= minLen; i++)
                        {
                            LibraryForWorkFile.read(workFile_1.openFile, i, stringBuilder2);
                            LibraryForWorkFile.read(workFile_2.openFile, i, stringBuilder3);
                            
                            if (i % 2 == 0)
                                text_2 = text_2 + stringBuilder3 + " ";
                            else
                                text_2 = text_2 + stringBuilder2 + " ";  
                        }

                        // Console.WriteLine(text_2);
                    }
                        break;
                }
            }
        }

        private static string RepeateLetter(LibraryForWorkFile workFile, StringBuilder stringBuilder,
            char MAXRepeateLetter)
        {
            int countWorlds = LibraryForWorkFile.length(workFile.openFile);
            int i = 1;
            string str = "";
            while (i <= countWorlds)
            {
                LibraryForWorkFile.read(workFile.openFile, i, stringBuilder);
                i++;

                char oneLetter = stringBuilder.ToString()[0];
                if (oneLetter != MAXRepeateLetter)
                    str = str + " " + stringBuilder.ToString();
            }

            return str;
        }


        private static char MaxRepeateLetter(LibraryForWorkFile file, StringBuilder stringBuilder)
        {
            List<char> letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList();
            Dictionary<char, int> dictionaryLetters = new Dictionary<char, int>();
            letters.ForEach(l => dictionaryLetters.Add(l, 0));
            int countWorlds = LibraryForWorkFile.length(file.openFile);

            int i = 1;
            int sumLetters = 0;
            while (i <= countWorlds)
            {
                LibraryForWorkFile.read(file.openFile, i, stringBuilder);
                i++;
                for (int index = 0; index < letters.Count; index++)
                {
                    string strRepeat = stringBuilder.ToString();
                    int s = strRepeat.Count(c => c == letters[index]);

                    dictionaryLetters[letters[index]] = dictionaryLetters[letters[index]] + s;
                }
            }

            int maxRepeate = 0;
            char keyLetterRepeate = '\0';
            foreach (var keyValuePair in dictionaryLetters)
            {
                if (keyValuePair.Value > maxRepeate)
                {
                    maxRepeate = keyValuePair.Value;
                    keyLetterRepeate = keyValuePair.Key;
                }
            }
            
            return keyLetterRepeate;
        }
    }
}