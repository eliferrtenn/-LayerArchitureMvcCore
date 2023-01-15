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
    public class Kaza_Personel_DisiManager : IKaza_Personel_DisiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kaza_Personel_DisiManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kaza_Personel_DisiDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.kaza_Personel_DisiRepository.AnyAsync(x => x.Kaza_No == addObject.Kaza_No);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza_Personel_Disi>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_Personel_DisiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kaza_No} numaralı kaza başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Kaza_No} numaralı kaza zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kaza_Personel_DisiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kaza_Personel_DisiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kaza_No} numaralı kaza başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kaza_No} numaaralı kaza bulunamadı.");
        }

        public async Task<IDataResult<IList<Kaza_Personel_DisiDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kaza_Personel_DisiRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kaza_Personel_DisiDTO>>(resultObject);
                return new DataResult<IList<Kaza_Personel_DisiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kaza_Personel_DisiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kaza_Personel_DisiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_Personel_DisiRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_Personel_DisiDTO>(resultObject);
                return new DataResult<Kaza_Personel_DisiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_Personel_DisiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kaza_Personel_DisiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kaza_Personel_DisiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kaza_No} numaralı kaza veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kaza_No} numaralı kaza bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kaza_Personel_DisiDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.kaza_Personel_DisiRepository.AnyAsync(x => x.Kaza_No == updateObject.Kaza_No && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kaza_Personel_DisiRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Kaza_Personel_DisiDTO,Kaza_Personel_Disi>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.kaza_Personel_DisiRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Kaza_No} numaralı kaza başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Kaza_No} numaralı kaza bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kaza_No} numaralı kaza zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
