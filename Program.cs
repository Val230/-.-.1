using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace КР2
{
    class Song
    {   // t - title; p - performer; g - genre; ds - duration in seconds; r - rating
        private string t, p, g;
        private int ds, r;
        public Song(string t, string p, string g, int ds, int r)
        {
            this.t = t;
            this.p = p;
            this.g = g;
            this.ds = ds;
            this.r = r;
        }
        public Song()
        {
        }
        public string T { get { return t; } set { t = value; } }
        public string P { get { return p; } set { p = value; } }
        public string G { get { return g; } set { g = value; } }
        public int Ds { get { return ds; } set { ds = value; } }
        public int R { get { return r; } set { r = value; } }
    }
    internal class Program
    {
        static void SortR(Song[] data)
        {
            object temp;
            for (int i = data.Length; i > 0; i--) 
            {
                for (int j = data.Length - 1; j > 0; j--)
                {
                    try
                    {
                        temp = data[j - 1];
                        if (data[j].R < data[j - 1].R)
                        {
                            data[j - 1] = data[j];
                            data[j] = (Song)temp;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Songs sorted by ranking:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"{data[i].R}. {data[i].T} by {data[i].P}; genre: {data[i].G}; Length: {data[i].Ds} seconds");
            }
        }
        static void SortL(Song[] data)
        {
            object temp;
            for (int i = data.Length; i > 0; i--)
            {
                for (int j = data.Length - 1; j > 0 ; j--)
                {
                    try
                    {
                        temp = data[j - 1];
                        if (data[j].Ds < data[j - 1].Ds)
                        {
                            data[j - 1] = data[j];
                            data[j] = (Song)temp;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Songs sorted by length:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {data[i].T} by {data[i].P}; genre: {data[i].G}; Length: {data[i].Ds} seconds; Rank: {data[i].R}");
            }
        }
        static void RankByGenre(Song[] data, string[] info)
        {
            int c;
            for (int i = 0; i < info.Length; i++)
            {
                c = 1;
                Console.WriteLine($"Songs ranked by the {info[i]} genre:");
                for (int j = 0; j < data.Length; j++) 
                {
                    if (info[i] == data[j].G)
                    {
                        Console.WriteLine($"{c}. {data[j].T} by {data[j].P}; Length: {data[j].Ds} seconds");
                        c++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            /* Example array:
            Song Re = new Song("Respect", "Otis Redding", "Soul", 125, 1);
            Song FtP = new Song("Fight the Power", "Public Enemy", "Hip Hop", 323, 2);
            Song CGC = new Song("A Change Is Gonna Come", "Sam Cooke", "Soul", 191, 3);
            Song LRS = new Song();
            LRS.T = "Like a Rolling Stone";
            LRS.P = "Bob Dylan";
            LRS.G = "Rock";
            LRS.Ds = 373;
            LRS.R = 4;
            Song SLTS = new Song("Smells Like Teen Spirit", "Nirvana", "Rock", 278, 5);
            Song WGO = new Song("What's Going On", "Marvin Gaye", "Soul", 420, 6);
            Song SFF = new Song("Strawberry Fields Forever", "The Beatles", "Rock", 247, 7);
            Song GUFO = new Song("Get Ur Freak On", "Missy Elliott", "Pop", 236, 8);
            Song Dr = new Song("Dreams", "Fleetwood Mac", "Rock", 258, 9);
            Song HY = new Song("Hey Ya!", "Outkast", "Pop", 235, 10);*/
           
            Console.Write("Enter number of genres which will be used: ");
            int z = int.Parse(Console.ReadLine());
            string[] genre = new string[z];
            Console.WriteLine("Enter all genres which will be used. Every new word must start with a capital letter. Press Enter after each input:");
            for (int i = 0; i < genre.Length; i++)
            {
                genre[i] = Console.ReadLine();
            }
            Console.Write("Enter count of songs: ");
            int n = int.Parse(Console.ReadLine());
            Song[] songs = new Song[n];
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i]= new Song();
                Console.WriteLine($"Input song number {i + 1}'s title, performer, genre, length in seconds and rating. Do not deviate from the format of inputted earlier genres. Press Enter after each section input:");
                songs[i].T = Console.ReadLine();
                songs[i].P = Console.ReadLine();
                songs[i].G = Console.ReadLine();
                songs[i].Ds = int.Parse(Console.ReadLine());
                songs[i].R = int.Parse(Console.ReadLine());
            }
            SortL(songs);
            SortR(songs);
            RankByGenre(songs, genre);
        }
    }
}