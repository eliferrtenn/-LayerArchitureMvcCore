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
    public class Acil_Durum_EkipleriManager : IAcil_Durum_EkipleriService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Acil_Durum_EkipleriManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Acil_Durum_EkipleriDTO addObject, long createdByUserId)
        {

            var exist = await _unitOfWork.acil_Durum_EkipleriRepository.AnyAsync(x => x.Ekip_Ad == addObject.Ekip_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Acil_Durum_Ekipleri>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.acil_Durum_EkipleriRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{addObject.Ekip_Ad} kişisi başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Ekip_Ad} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.acil_Durum_EkipleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.acil_Durum_EkipleriRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ekip_Ad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ekip_Ad} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<Acil_Durum_EkipleriDTO>>> GetAllAsync()
        {
    
            var resultObject = await _unitOfWork.acil_Durum_EkipleriRepository.GetAllAsync(x => x.isActive && !x.isDeleted);

            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Acil_Durum_EkipleriDTO>>(resultObject);
                return new DataResult<IList<Acil_Durum_EkipleriDTO>>(ResultStatus.Success,result);
            }
            return new DataResult<IList<Acil_Durum_EkipleriDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Acil_Durum_EkipleriDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_EkipleriRepository.GetAsync(x => x.Id == Id);

            if (resultObject != null)
            {
                var result = _mapper.Map<Acil_Durum_EkipleriDTO>(resultObject);
                return new DataResult<Acil_Durum_EkipleriDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Acil_Durum_EkipleriDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.acil_Durum_EkipleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.acil_Durum_EkipleriRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ekip_Ad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ekip_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Acil_Durum_EkipleriDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.acil_Durum_EkipleriRepository.AnyAsync(x => x.Ekip_Ad == updateObject.Ekip_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.acil_Durum_EkipleriRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    DateTime dateTime = DateTime.Now;                
                    var result = _mapper.Map<Acil_Durum_EkipleriDTO,Acil_Durum_Ekipleri>(updateObject,resultObject);
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.acil_Durum_EkipleriRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{updateObject.Ekip_Ad} kişisi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Ekip_Ad} kişisi bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Ekip_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }

        }
   
    
    }
}
