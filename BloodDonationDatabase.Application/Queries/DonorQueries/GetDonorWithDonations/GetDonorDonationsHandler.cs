using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorWithDonations
{
    public class GetDonorDonationsHandler : IRequestHandler<GetDonorDonationsQuery, ResultViewModel<DonorDonationsViewModel>>
    {
        private readonly IDonorRepository _repository;

        public GetDonorDonationsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<DonorDonationsViewModel>> Handle(GetDonorDonationsQuery request, CancellationToken cancellationToken)
        {
            var donorWithDonations = await _repository.GetByIdWithDonations(request.DonorId);

            var model = DonorDonationsViewModel.FromEntity(donorWithDonations);

            return ResultViewModel<DonorDonationsViewModel>.Success(model);
        }
    }
}
