using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiscothequeWPF
{
    public class RelayCommand : ICommand // Représente l'action d'un bouton
    {
        private readonly Action _action; // Méthode void ()

        public RelayCommand(Action action)
        {
            _action = action;
        }

        // public event EventHandler? CanExecuteChanged;
        //
        // Puisque l'évènement n'est jamais déclenché (la commande est toujours active),
        // on explicite ses méthodes d'abonnement/désabonnement, qui ne font RIEN :

        public event EventHandler? CanExecuteChanged
        {
            add { } // Abonnement à l'évènement
            remove { } // Désabonnement
        }

        // La commande est active ?
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action(); // Exécute ladite méthode
        }
    }
}
