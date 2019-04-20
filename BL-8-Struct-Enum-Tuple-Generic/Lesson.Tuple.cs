using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Lesson
    {
        public static Song CreateSong()
        {
            var song = new Song()
            {
                Title = "Judos",
                Duration = 456,
                Author = new Author()
                {
                    Name = "Lady Gaga",
                    Genre = "Pop",
                },
                Album = new Album()
                {
                    Title = "Pocker Face",
                    ReleaseDate = DateTime.Today.AddYears(-7)
                }
            };

            return song;
        }

        public static void ParametersExample()
        {
            var song = CreateSong();

            var title = song.Title;
            var minutes = song.Duration / 60;
            var seconds = song.Duration % 60;
            var author = song.Author.Name;
            var album = song.Album.Title;
            var albumYear = song.Album.ReleaseDate.Year;

            //Использовать все переменные в коде.
        }

        public static void OutParametersExample()
        {
            var song = CreateSong();

            string title, author, album;
            int minutes, seconds, albumYear;

            GetSongData(song, out title, out minutes, out seconds, out author, out album, out albumYear);

            //Использовать все переменные в коде.
        }

        public static void MassiveExample()
        {
            var song = CreateSong();

            var data = GetSongData(song);

            var title = data[0] as string;
            var minutes = (int)data[1];
            var seconds = (int)data[2];
            var author = data[3] as string;
            var album = data[4] as string;
            var albumYear = (int)data[5];

            //Использовать все переменные в коде.
        }

        public static void DataClassExample()
        {
            var song = CreateSong();

            var songData = GetSongDataDTO(song);

            var title = songData.Title;
            var minutes = songData.Minutes;
            var seconds = songData.Seconds;
            var author = songData.Author;
            var album = songData.Album;
            var albumYear = songData.AlbumYear;

            //Использовать все переменные в коде.
        }

        public static void TupleExample()
        {
            var song = CreateSong();

            Tuple<string, int, int, string, string, int> songData = GetSongDataTuple(song);

            var title = songData.Item1;
            var minutes = songData.Item2;
            var seconds = songData.Item3;
            var author = songData.Item4;
            var album = songData.Item5;
            var albumYear = songData.Item6;

            //Использовать все переменные в коде.
        }

        public static void ValueTupleExample()
        {
            var song = CreateSong();

            var songData = GetSongDataValueTuple(song);
            var (title, minutes, seconds, author, album, year) = GetSongDataValueTuple(song);
           
            //Использовать все переменные в коде.
        }


        public static void GetSongData(Song song, out string title, out int minutes, out int seconds, out string author, out string album, out int year)
        {
            title = song.Title;
            minutes = song.Duration / 60;
            seconds = song.Duration % 60;
            author = song.Author.Name;
            album = song.Album.Title;
            year = song.Album.ReleaseDate.Year;
        }

        public static Object[] GetSongData(Song song)
        {
            return new Object[] {
                song.Title,
                song.Duration / 60,
                song.Duration % 60,
                song.Author.Name,
                song.Album.Title,
                song.Album.ReleaseDate.Year,
            };
        }

        public static SongData GetSongDataDTO(Song song)
        {
            return new SongData {
                Title = song.Title,
                Minutes = song.Duration / 60,
                Seconds = song.Duration % 60,
                Author = song.Author.Name,
                Album = song.Album.Title,
                AlbumYear = song.Album.ReleaseDate.Year,
            };
        }

        public static Tuple<string, int, int, string, string, int> GetSongDataTuple (Song song)
        {
            return new Tuple<string, int, int, string, string, int>
            (
                song.Title,
                song.Duration / 60,
                song.Duration % 60,
                song.Author.Name,
                song.Album.Title,
                song.Album.ReleaseDate.Year
            );
        }

        public static (string title, int minutes, int seconds, string author, string album, int year) GetSongDataValueTuple(Song song)
        {
            return 
            (
                song.Title,
                song.Duration / 60,
                song.Duration % 60,
                song.Author.Name,
                song.Album.Title,
                song.Album.ReleaseDate.Year
            );
        }
    }

    public class SongData
    {
        public string Title { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public int AlbumYear { get; set; }
    }

    public class Song
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Author Author { get; set; }
        public Album Album { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }

    public class Album
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

