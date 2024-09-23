using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<int>>
    {
        public InsertDonationHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }

        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        public async Task<ResultViewModel<int>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();
            var donor = await _donorRepository.GetById(donation.DonorId);
            var donationByDonor = await _donationRepository.GetByDonorId(donor.Id);

            if (donor is not null && donationByDonor is not null)
            {
                if (!donationByDonor.CheckAge())
                {
                    return ResultViewModel<int>.Error("Só é possível realizar doação maior de idade!");
                }
                if (!donation.CheckQuantityMlDonation())
                {
                    return ResultViewModel<int>.Error("Quantidade doada fora do limite!");
                }
                if (donor.Gender == Core.Enum.Gender.Male && !donationByDonor.MenDonation())
                {
                    return ResultViewModel<int>.Error("Só é possível realizar doações a cada 60 dias");
                }
                if (donor.Gender == Core.Enum.Gender.Female && !donationByDonor.WomenDonation())
                {
                    return ResultViewModel<int>.Error("Só é possível realizar doações a cada 90 dias");
                }
            }

            await _donationRepository.Insert(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
