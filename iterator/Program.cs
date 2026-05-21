using System.Collections;

namespace IteratorPattern;

public sealed record Track(string Title, string Artist);

public sealed class Playlist : IEnumerable<Track>
{
    private readonly List<Track> _tracks = [];

    public void Add(Track track)
    {
        _tracks.Add(track);
    }

    public IEnumerator<Track> GetEnumerator()
    {
        return new PlaylistIterator(_tracks);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public sealed class PlaylistIterator : IEnumerator<Track>
{
    private readonly IReadOnlyList<Track> _tracks;
    private int _index = -1;

    public PlaylistIterator(IReadOnlyList<Track> tracks)
    {
        _tracks = tracks;
    }

    public Track Current => _tracks[_index];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_index + 1 >= _tracks.Count)
        {
            return false;
        }

        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public void Dispose()
    {
    }
}

internal static class Program
{
    private static void Main()
    {
        Playlist playlist = new();

        playlist.Add(new Track("Paranoid Android", "Radiohead"));
        playlist.Add(new Track("Digital Love", "Daft Punk"));
        playlist.Add(new Track("The Adults Are Talking", "The Strokes"));

        Console.WriteLine("Playlist:");

        foreach (Track track in playlist)
        {
            Console.WriteLine($"{track.Artist} - {track.Title}");
        }
    }
}
