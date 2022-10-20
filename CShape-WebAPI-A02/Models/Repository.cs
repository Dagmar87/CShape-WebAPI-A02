using System.Collections.Generic;

namespace CShape_WebAPI_A02.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> items;

        public Repository()
        {
            items = new Dictionary<int, Reserva>();

            new List<Reserva>
            {
                new Reserva
                {
                    ReservaId = 1,
                    Nome = "André",
                    InicioLocacao = "Recife",
                    FimLocacao = "Paulista"
                },
                new Reserva
                {
                    ReservaId = 2,
                    Nome = "Laura",
                    InicioLocacao = "Olinda",
                    FimLocacao = "Caruaru"
                },
                new Reserva
                {
                    ReservaId = 3,
                    Nome = "Fernando",
                    InicioLocacao = "Ipojuca",
                    FimLocacao = "Jaboatão dos Guararapes"
                }
            }.ForEach(r => AddReserva(r));
        }

        public Reserva this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reserva> Reservas => items.Values;

        public Reserva AddReserva (Reserva reserva)
        {
            if(reserva.ReservaId == 0)
            {
                int key = items.Count;
                while(items.ContainsKey(key)) { key++; };
                reserva.ReservaId = key;
            }
            items[reserva.ReservaId] = reserva;
            return reserva;
        }

        public void DeleteReserva(int id)
        {
            items.Remove(id);
        }

        public Reserva UpdateReserva(Reserva reserva)
        {
            AddReserva(reserva);
            return reserva;
        }
    }
}
