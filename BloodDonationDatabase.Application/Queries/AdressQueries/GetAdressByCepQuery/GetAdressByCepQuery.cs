using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.AdressQueries.GetAdressByCepQuery
{
    public class GetAdressByCepQuery : IRequest<ResultViewModel<AdressViewModel>>
    {
        public GetAdressByCepQuery(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; set; }
    }
}
