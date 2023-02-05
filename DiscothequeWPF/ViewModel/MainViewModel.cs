using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace DiscothequeWPF
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AlbumViewModel> _albums;
        private AlbumViewModel _newAlbum;
        private AlbumViewModel? _selectedAlbum;

        private ObservableCollection<TrackViewModel> _tracks;
        private TrackViewModel _newTrack;
        private TrackViewModel? _selectedTrack;

        public MainViewModel()
        {
            _albums = new ObservableCollection<AlbumViewModel>();
            _tracks = new ObservableCollection<TrackViewModel>();
            _newAlbum = new AlbumViewModel();
            _selectedAlbum = null;
            _newTrack = new TrackViewModel();
            _selectedTrack = null;
        }

        // Encapsulation dans une collection en lecture seule.
        public ReadOnlyObservableCollection<AlbumViewModel> Albums
        {
            get { return new ReadOnlyObservableCollection<AlbumViewModel>(_albums); }
        }

        public ObservableCollection<TrackViewModel> Tracks
        {
            get { return _tracks; }
        }

        public AlbumViewModel Album
        {
            get { return _newAlbum; }
        }

        public TrackViewModel Track
        {
            get { return _newTrack; }
        }

        public AlbumViewModel? AlbumSelection
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                if( _selectedAlbum != null ) { 
                    _tracks = _selectedAlbum.Tracks;
                }
                OnPropertyChanged(nameof(AlbumSelection));
                OnPropertyChanged(nameof(Tracks));
            }
        }

        public TrackViewModel? TrackSelection
        {
            get { return _selectedTrack; }
            set
            {
                _selectedTrack = value;
                OnPropertyChanged(nameof(TrackSelection));
            }
        }

        public ICommand AddAlbumCommand
        {
            get { return new RelayCommand(AjoutAlbum); }
        }

        public void AjoutAlbum()
        {
            _albums.Add(_newAlbum);
            _tracks = _newAlbum.Tracks;
            AlbumSelection = _newAlbum;

            // Prépare le prochain ajout :
            _newAlbum = new AlbumViewModel();
            OnPropertyChanged(nameof(Albums));
        }

        public ICommand RemoveAlbumCommand
        {
            get { return new RelayCommand(SuppressionAlbum); }
        }

        public void SuppressionAlbum()
        {
            if (_selectedAlbum != null)
            {
                _albums.Remove(_selectedAlbum);
                _tracks.Clear();
                AlbumSelection = null;
                TrackSelection = null;
            }
            OnPropertyChanged(nameof(Tracks));
        }

        public ICommand AddTrackCommand
        {
            get { return new RelayCommand(AjoutPiste); }
        }

        public void AjoutPiste()
        {
            if (_selectedAlbum != null)
            {
                _newTrack.Id = _tracks.Count+1;
                TrackSelection = _newTrack;
                _selectedAlbum.AddTrack(_newTrack);
            }

            // Prépare le prochain ajout :
            _newTrack = new TrackViewModel();
            OnPropertyChanged(nameof(Track));
        }

        public ICommand RemoveTrackCommand
        {
            get { return new RelayCommand(SuppressionPiste); }
        }

        public void SuppressionPiste()
        {
            if (_selectedTrack != null && _selectedAlbum != null)
            {
                updateTrackIds(_selectedTrack.Id);
                _selectedAlbum.RemoveTrack(_selectedTrack);
                TrackSelection = null;
            }
        }

        public void updateTrackIds(int startingId)
        {
            for( int i=startingId; i < Tracks.Count; i++ )
            {
                Tracks[i].Id--;
            }
        }

    }
}
