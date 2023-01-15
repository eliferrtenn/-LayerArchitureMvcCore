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
    public class Asi_TurManager : IAsi_TurService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Asi_TurManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Asi_TurDTO addObject, long createdByUserId)
        {

            var exist = await _unitOfWork.asi_TurRepository.AnyAsync(x => x.Asi_Ad == addObject.Asi_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Asi_Tur>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.asi_TurRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Asi_Ad} aşısı başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Asi_Ad} aşısı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.asi_TurRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.asi_TurRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Asi_Ad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Asi_Ad} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<Asi_TurDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.asi_TurRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Asi_TurDTO>>(resultObject);
                return new DataResult<IList<Asi_TurDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Asi_TurDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Asi_TurDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.asi_TurRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Asi_TurDTO>(resultObject);
                return new DataResult<Asi_TurDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Asi_TurDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.asi_TurRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.asi_TurRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Asi_Ad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Asi_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Asi_TurDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.asi_TurRepository.AnyAsync(x => x.Asi_Ad == updateObject.Asi_Ad && x.Id != updateObject.Id && !x.isDeleted);
            if (exist==false)
            {
                var resultObject = await _unitOfWork.asi_TurRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Asi_TurDTO, Asi_Tur>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.asi_TurRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Asi_Ad} aşısı başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Asi_Ad} kişisi bulunamadı.");
                }

            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Asi_Ad} aşısı bulunamadı.");
            }
        }
    }
}
