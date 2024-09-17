using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonationsQueries.GetAllDonation
{
    public class GetAllDonationHandler : IRequestHandler<GetAllDonationCommand, ResultViewModel<List<DonationViewModel>>>
    {
        public GetAllDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonationRepository _repository;

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationCommand request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();
            var model = donations.Select(DonationViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationViewModel>>.Success(model);
        }
    }
}
