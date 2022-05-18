
class FindNumbers
{
    static void Main()

    {

        string path = @"C:\Users\Richard\Downloads\input.txt";

        int count = 0;
        int counter = 0;
        var lines = File.ReadLines(path).ToArray();

        int[] array = new int[lines.Length];


        foreach (var line in lines)
        {

            int numberA = Int32.Parse(line);

            array[count++] = numberA;

        }

        /*

        //Day1:1 solution

        for (int i = 1; i < lines.Length; i++)
        {
            if (array[i - 1] < array[i])
                counter++;
        }

        Console.WriteLine("The number of occurances with greater numbers are: " + counter);

        */

        //Day1:2 solution

        for (int i = 3; i < lines.Length; i++)
        {
            if (  (array[i-3]+array[i-2]+array[i-1]) < (array[i-2]+array[i-1]+array[i]))
                counter++;
        }

        Console.WriteLine("The number of occurances with greater sequence than last are " + counter);

    }

}




