using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<int>>
    {
        public InsertDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonationRepository _repository;
        public async Task<ResultViewModel<int>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();

            await _repository.Insert(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
