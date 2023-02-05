using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscothequeWPF
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly Track _model;

        public TrackViewModel()
        {
            _model = new Track();
        }

        public TrackViewModel(Track t)
        {
            _model = t;
        }

        public int Id { 
            get { return _model.Id; }
            set
            {
                _model.Id = value;
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(IdTitre));
            }
        }

        public string Titre
        {
            get { return _model.Titre; }
            set
            {
                _model.Titre = value;
                OnPropertyChanged(nameof(Titre));
                OnPropertyChanged(nameof(IdTitre));
            }
        }

        public string IdTitre
        {
            get { return $"{_model.Id} - {_model.Titre}"; }
        }

        public override string ToString()
        {
            return IdTitre;
        }
    }
}
