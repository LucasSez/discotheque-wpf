using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscothequeWPF
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly Album _model;

        public AlbumViewModel()
        {
            _model = new Album();
        }

        public string Titre
        {
            get { return _model.Titre; }
            set
            {
                _model.Titre = value;
                OnPropertyChanged(nameof(Titre));
                OnPropertyChanged(nameof(TitreCompositeur));
            }
        }

        public string Compositeur
        {
            get { return _model.Compositeur; }
            set
            {
                _model.Compositeur = value;
                OnPropertyChanged(nameof(Compositeur));
                OnPropertyChanged(nameof(TitreCompositeur));
            }
        }

        public ObservableCollection<TrackViewModel> Tracks { get; }
            = new ObservableCollection<TrackViewModel>();

        public void AddTrack(TrackViewModel track)
        {
            Tracks.Add(track);
        }

        public void RemoveTrack(TrackViewModel track)
        {
            Tracks.Remove(track);
        }

        public string TitreCompositeur
        {
            get { return $"{_model.Titre} {_model.Compositeur}"; }
        }

        public override string ToString()
        {
            return TitreCompositeur;
        }
    }
}
