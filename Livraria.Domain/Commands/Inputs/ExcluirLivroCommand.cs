using Flunt.Notifications;
using Livraria.Infra.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Livraria.Domain.Commands.Inputs
{
    public class ExcluirLivroCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommad()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id precisa ser maior do que 0");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
