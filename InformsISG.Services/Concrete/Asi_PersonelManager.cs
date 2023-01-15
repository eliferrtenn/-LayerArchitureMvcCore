using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Concrete
{
    public class Asi_PersonelManager : IAsi_PersonelService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Asi_PersonelManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Asi_PersonelDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.asi_PersonelRepository.AnyAsync(x => x.Personel_Id == addObject.Personel_Id && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Asi_Personel>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.asi_PersonelRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Uygulayan_Ad} kişisi başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Uygulayan_Ad} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.asi_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.asi_PersonelRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Uygulayan_Ad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Uygulayan_Ad} kişisi bulunamadı.");
        }

        public async  Task<IDataResult<IList<Asi_PersonelDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.asi_PersonelRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Asi_PersonelDTO>>(resultObject);
                return new DataResult<IList<Asi_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Asi_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Asi_PersonelDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.asi_PersonelRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Asi_PersonelDTO>(resultObject);
                return new DataResult<Asi_PersonelDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Asi_PersonelDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.asi_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.asi_PersonelRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Uygulayan_Ad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Uygulayan_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Asi_PersonelDTO updateObject, long modifiedByUserId)
        {
            var resultObject = await _unitOfWork.asi_PersonelRepository.GetAsync(x => x.Personel_Id == updateObject.Personel_Id && x.Id != updateObject.Id && !x.isDeleted);
            if (resultObject != null)
            {
                var result = _mapper.Map<Asi_PersonelDTO, Asi_Personel>(updateObject, resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.asi_PersonelRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Uygulayan_Ad} kişisi başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Uygulayan_Ad} kişisi bulunamadı.");
            }
        }
    }
}
