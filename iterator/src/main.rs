#[derive(Clone, Debug)]
pub struct Track {
    pub title: String,
    pub artist: String,
}

impl Track {
    pub fn new(title: impl Into<String>, artist: impl Into<String>) -> Self {
        Self {
            title: title.into(),
            artist: artist.into(),
        }
    }
}

#[derive(Clone, Debug, Default)]
pub struct Playlist {
    tracks: Vec<Track>,
}

impl Playlist {
    pub fn new() -> Self {
        Self { tracks: vec![] }
    }

    pub fn add(&mut self, track: Track) {
        self.tracks.push(track);
    }

    pub fn iter(&self) -> PlaylistIterator<'_> {
        PlaylistIterator::new(self)
    }
}

pub struct PlaylistIterator<'a> {
    playlist: &'a Playlist,
    index: usize,
}

impl<'a> PlaylistIterator<'a> {
    pub fn new(playlist: &'a Playlist) -> Self {
        Self { playlist, index: 0 }
    }
}

impl<'a> Iterator for PlaylistIterator<'a> {
    type Item = &'a Track;

    fn next(&mut self) -> Option<Self::Item> {
        let track = self.playlist.tracks.get(self.index)?;
        self.index += 1;
        Some(track)
    }
}

impl<'a> IntoIterator for &'a Playlist {
    type Item = &'a Track;
    type IntoIter = PlaylistIterator<'a>;

    fn into_iter(self) -> Self::IntoIter {
        self.iter()
    }
}

fn main() {
    let mut playlist = Playlist::new();

    playlist.add(Track::new("Paranoid Android", "Radiohead"));
    playlist.add(Track::new("Digital Love", "Daft Punk"));
    playlist.add(Track::new("The Adults Are Talking", "The Strokes"));

    println!("Playlist:");

    let mut iterator = playlist.iter();

    #[allow(clippy::while_let_on_iterator)]
    while let Some(track) = iterator.next() {
        println!("{} - {}", track.artist, track.title);
    }
}
