using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdCommand, ResultViewModel<DonationViewModel>>
    {
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonationRepository _repository;

        public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationByIdCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);
            if (donation is null)
            {
                return ResultViewModel<DonationViewModel>.Error("Doação não encontrada");
            }
            var model = DonationViewModel.FromEntity(donation);

            return ResultViewModel<DonationViewModel>.Success(model);
        }
    }
}
