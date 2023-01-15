using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Concrete
{
    public class Kkd_PersonelAtamaManager : IKkd_Personel_AtamaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kkd_PersonelAtamaManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IResult> AddAsync(Kkd_Personel_AtamaDTO addObject, long createdByUserId)
        {

                var result = _mapper.Map<Kkd_Personel_Atama>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkd_Personel_AtamaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"başarılı bir şekilde eklenmiştir.");
   
        }

        public async Task<IResult> UpdateAsync(Kkd_Personel_AtamaDTO updateObject, long modifiedByUserId)
        {

                var resultObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAsync(x => x.Id == updateObject.Id);

                if (resultObject != null)
                {
                    var result = _mapper.Map<Kkd_Personel_AtamaDTO, Kkd_Personel_Atama>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.kkd_Personel_AtamaRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $" başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $" bulunamadı.");
                }
       
        }
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kkd_Personel_AtamaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $" bulunamadı.");
        }

        public async Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kkd_Personel_AtamaDTO>>(resultObject);
                return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kkd_Personel_AtamaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kkd_Personel_AtamaDTO>(resultObject);
                return new DataResult<Kkd_Personel_AtamaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kkd_Personel_AtamaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.kkd_Personel_AtamaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"bulunamadı.");
        }



        public async Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllKkdAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Kkd_Id == Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kkd_Personel_AtamaDTO>>(resultObject);
                return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllPersonelAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkd_Personel_AtamaRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Personel_Id == Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kkd_Personel_AtamaDTO>>(resultObject);
                return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kkd_Personel_AtamaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
